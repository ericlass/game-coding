using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Audio;
using OkuBase.Driver;
using OkuBase.Settings;
using Tao.OpenAl;

namespace OkuDrivers
{
  public class OpenALAudioDriver : IAudioDriver
  {
    private IntPtr _device;
    private IntPtr _context;
    private Dictionary<int, int> _buffers = new Dictionary<int, int>(); //Maps content ids to open al buffer ids
    private Dictionary<int, int> _sources = new Dictionary<int, int>(); //Maps instance ids to open al source ids
    private Dictionary<int, int> _bufferRefCount = new Dictionary<int, int>(); //Used to ref count uses of buffers in sources

    private float _volume = 1.0f;

    private int GetAlFormatForChannels(int numChannels)
    {
      if (numChannels == 8)
        return Al.AL_FORMAT_71CHN16;
      if (numChannels == 7)
        return Al.AL_FORMAT_61CHN16;
      if (numChannels == 6)
        return Al.AL_FORMAT_51CHN16;
      if (numChannels == 4)
        return Al.AL_FORMAT_QUAD16;
      if (numChannels == 2)
        return Al.AL_FORMAT_STEREO16;
      if (numChannels == 1)
        return Al.AL_FORMAT_MONO16;

      return 0;
    }

    public string DriverName
    {
      get { return "openal"; }
    }

    public float Volume
    {
      get { return _volume; }
      set { _volume = value; }
    }

    public bool Initialize(AudioSettings settings)
    {
      _volume = settings.Volume;

      //Open OpenAL device and create context
      _device = Alc.alcOpenDevice(null);
      _context = Alc.alcCreateContext(_device, IntPtr.Zero);
      Alc.alcMakeContextCurrent(_context);
      int error = Alc.alcGetError(_device);

      //Setup Listener
      Al.alListener3f(Al.AL_POSITION, 0, 0, 0);
      float[] vec = new float[] { 0, 0, -1, 0, 1, 0 };
      Al.alListenerfv(Al.AL_ORIENTATION, vec);
      Al.alListenerf(Al.AL_GAIN, _volume);

      return true;
    }

    public void Update(float dt)
    {
    }

    public void Finish()
    {
      //Go through all sound sources and release them
      foreach (KeyValuePair<int, int> kvp in _sources)
      {
        int src = kvp.Value;
        Al.alDeleteSources(1, ref src);
      }

      //Go through all sound buffers and release them
      foreach (KeyValuePair<int, int> kvp in _buffers)
      {
        int buffer = kvp.Value;
        Al.alDeleteBuffers(1, ref buffer);
      }

      //Destroy context and close OpenAL device
      Alc.alcMakeContextCurrent(IntPtr.Zero);
      Alc.alcDestroyContext(_context);
      Alc.alcCloseDevice(_device);
    }

    public void Play(Source source)
    {
      if (!_sources.ContainsKey(source.Id))
        throw new OkuException("Trying to play an unintialized source! ID: " + source.Id);

      Al.alSourcePlay(_sources[source.Id]);
    }

    public void Pause(Source source)
    {
      if (!_sources.ContainsKey(source.Id))
        throw new OkuException("Trying to pause an unintialized source! ID: " + source.Id);

      Al.alSourcePause(_sources[source.Id]);
    }

    public void Stop(Source source)
    {
      if (!_sources.ContainsKey(source.Id))
        throw new OkuException("Trying to stop an unintialized source! ID: " + source.Id);

      Al.alSourceStop(_sources[source.Id]);
    }

    public void LoadSource(Source source)
    {
      if (_sources.ContainsKey(source.Id))
        throw new OkuException("Trying to load a source twice! ID: " + source.Id);

      //Create or reuse buffer
      int buffer = 0;
      if (_buffers.ContainsKey(source.Sound.Id))
      {
        buffer = _buffers[source.Sound.Id];
        _bufferRefCount[source.Sound.Id] += 1;
      }
      else
      {
        int format = GetAlFormatForChannels(source.Sound.NumChannels);

        Al.alGenBuffers(1, out buffer);
        Al.alBufferData(buffer, format, source.Sound.ChannelData, source.Sound.ChannelData.Length, source.Sound.SampleRate);

        _buffers.Add(source.Sound.Id, buffer);
        _bufferRefCount.Add(source.Sound.Id, 0);
      }

      //Create a new source
      int sourceName = 0;
      Al.alGenSources(1, out sourceName);
      _sources.Add(source.Id, sourceName);

      //Set up the source
      Al.alSourcei(sourceName, Al.AL_BUFFER, buffer);
      Al.alSourcef(sourceName, Al.AL_PITCH, source.Pitch);
      Al.alSourcef(sourceName, Al.AL_GAIN, source.Volume);
      Al.alSource3f(sourceName, Al.AL_POSITION, source.Pan, 0, -1);
      Al.alSource3f(sourceName, Al.AL_VELOCITY, 0, 0, 0);

      if (source.Loop)
        Al.alSourcei(sourceName, Al.AL_LOOPING, Al.AL_TRUE);
      else
        Al.alSourcei(sourceName, Al.AL_LOOPING, Al.AL_FALSE);
    }

    public void UpdateSource(Source source)
    {
      if (!_sources.ContainsKey(source.Id))
        throw new OkuException("Trying to update an unintialized source! ID: " + source.Id);

      int sourceName = _sources[source.Id];

      //Set up the source
      Al.alSourcef(sourceName, Al.AL_PITCH, source.Pitch);
      Al.alSourcef(sourceName, Al.AL_GAIN, source.Volume);
      Al.alSource3f(sourceName, Al.AL_POSITION, source.Pan, 0, -1);
      Al.alSource3f(sourceName, Al.AL_VELOCITY, 0, 0, 0);

      if (source.Loop)
        Al.alSourcei(sourceName, Al.AL_LOOPING, Al.AL_TRUE);
      else
        Al.alSourcei(sourceName, Al.AL_LOOPING, Al.AL_FALSE);
    }

    public void ReleaseSource(Source source)
    {
      if (_sources.ContainsKey(source.Id))
        throw new OkuException("Trying to release a source that was not initialized! ID: " + source.Id);

      //Release source
      int sourceName = _sources[source.Id];
      Al.alDeleteSources(1, ref sourceName);
      _sources.Remove(source.Id);

      if (!_buffers.ContainsKey(source.Sound.Id))
        throw new OkuException("Trying to release a sound buffer that was not initialized! ID: " + source.Id);

      //Check ref count of buffer
      int refCount = _bufferRefCount[source.Sound.Id] - 1;
      _bufferRefCount[source.Sound.Id] = refCount;
      if (refCount <= 0)
      {
        //Free buffer if it is not used anymore
        int buffer = _buffers[source.Sound.Id];
        Al.alDeleteBuffers(1, ref buffer);

        _buffers.Remove(source.Sound.Id);
        _bufferRefCount.Remove(source.Sound.Id);
      }
    }

  }
}
