using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using Tao.OpenAl;

namespace OkuEngine.Driver.Audio
{
  /// <summary>
  /// Implements a sound engine using OpenAL.
  /// </summary>
  public class OpenALSoundEngine : ISoundEngine
  {
    public const string EngineName = "openal";

    private IntPtr _device;
    private IntPtr _context;
    private Dictionary<int, int> _buffers = new Dictionary<int, int>(); //Maps content ids to open al buffer ids
    private Dictionary<int, int> _sources = new Dictionary<int, int>(); //Maps instance ids to open al source ids

    private float _volume = 1.0f;

    public float Volume
    {
      get { return _volume; }
      set { _volume = value; }
    }

    public bool Initialize(XmlNode soundNode)
    {
      XmlNode child = soundNode.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "volume":
            _volume = Converter.StrToFloat(child.FirstChild.Value);
            break;

          default:
            break;
        }
        child = child.NextSibling;
      }

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

    public void InitContent(SoundContent content, WaveForm wave)
    {
      InitContentRaw(content, wave.ChannelData, wave.SampleRate, wave.NumChannels);
    }

    public void InitContentRaw(SoundContent content, byte[] data, int sampleRate, int numChannels)
    {
      int format = GetAlFormatForChannels(numChannels);

      int buffer = 0;
      Al.alGenBuffers(1, out buffer);
      Al.alBufferData(buffer, format, data, data.Length, sampleRate);

      _buffers.Add(content.ContentId, buffer);
    }

    public void ReleaseContent(SoundContent content)
    {
      if (_buffers.ContainsKey(content.ContentId))
      {
        //Release buffer
        int buffer = _buffers[content.ContentId];
        Al.alDeleteBuffers(1, ref buffer);
      }
    }

    public void Play(SoundInstance instance)
    {
      if (!_buffers.ContainsKey(instance.Content.ContentId))
        throw new ArgumentException("The sound content does not have a corresponding buffer in the sound engine!");

      int buffer = _buffers[instance.Content.ContentId];

      int source = 0;
      if (_sources.ContainsKey(instance.InstanceId))
        source = _sources[instance.InstanceId];
      else
      {
        source = GetPlayableSource();
        Al.alSourcei(source, Al.AL_BUFFER, buffer);
        Al.alSourcef(source, Al.AL_PITCH, instance.Pitch);
        Al.alSourcef(source, Al.AL_GAIN, instance.Volume);
        Al.alSource3f(source, Al.AL_POSITION, instance.Pan, 0, -1);
        Al.alSource3f(source, Al.AL_VELOCITY, 0, 0, 0);

        if (instance.Loop)
          Al.alSourcei(source, Al.AL_LOOPING, Al.AL_TRUE);
        else
          Al.alSourcei(source, Al.AL_LOOPING, Al.AL_FALSE);

        int error = Al.alGetError();

        _sources.Add(instance.InstanceId, source);
      }

      Al.alSourcePlay(source);
    }

    public void Pause(SoundInstance instance)
    {
      if (!_sources.ContainsKey(instance.InstanceId))
        throw new ArgumentException("The sound instance does not have a corresponding source in the sound engine!");
      int source = _sources[instance.InstanceId];

      Al.alSourcePause(source);
    }

    public void Stop(SoundInstance instance)
    {
      if (!_sources.ContainsKey(instance.InstanceId))
        throw new ArgumentException("The sound instance does not have a corresponding source in the sound engine!");
      int source = _sources[instance.InstanceId];

      Al.alSourceStop(source);
    }

    private int GetPlayableSource()
    {
      int result = 0;
      int instance = 0;
      foreach (KeyValuePair<int, int> kvp in _sources)
      {
        int src = kvp.Value;
        int state = 0;
        Al.alGetSourceiv(src, Al.AL_SOURCE_STATE, out state);
        if (state != Al.AL_PLAYING && state != Al.AL_PAUSED)
        {
          result = src;
          instance = kvp.Key;
          break;
        }
      }

      if (result == 0)
      {
        Al.alGenSources(1, out result);
        int error = Al.alGetError();
      }
      else
      {
        _sources.Remove(instance); // If source is beeing reused, the current entry in _sources must be removed to avoid source leak
      }

      return result;
    }

  }
}
