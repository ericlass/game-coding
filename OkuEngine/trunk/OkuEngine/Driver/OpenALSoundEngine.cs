using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tao.OpenAl;

namespace OkuEngine
{
  class OpenALSoundEngine : ISoundEngine
  {
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

    public void Initialize()
    {
      //Open OpenAL device and create context
      _device = Alc.alcOpenDevice(null);
      _context = Alc.alcCreateContext(_device, IntPtr.Zero);
      Alc.alcMakeContextCurrent(_context);
      int error = Alc.alcGetError(_device);
    }

    public void Update(float dt)
    {
      CleanUpSources();
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

    public void InitContent(Content content, WaveForm wave)
    {
      InitContentRaw(content, wave.ChannelData, wave.SampleRate, wave.NumChannels);
    }

    public void InitContentRaw(Content content, byte[] data, int sampleRate, int numChannels)
    {
      int format = GetAlFormatForChannels(numChannels);

      int buffer = 0;
      Al.alGenBuffers(1, out buffer);
      Al.alBufferData(buffer, format, data, data.Length * 2, sampleRate);

      _buffers.Add(content.ContentId, buffer);
    }

    public void ReleaseContent(Content content)
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
        source = GetPlayableSource();

      Al.alSourcei(source, Al.AL_BUFFER, buffer);
      Al.alSourcef(source, Al.AL_GAIN, instance.Volume);
      Al.alSourcef(source, Al.AL_PITCH, instance.Pitch);
      Al.alSource3f(source, Al.AL_POSITION, instance.Pan, 0, -1);

      if (instance.Loop)
        Al.alSourcei(source, Al.AL_LOOPING, Al.AL_TRUE);
      else
        Al.alSourcei(source, Al.AL_LOOPING, Al.AL_FALSE);

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

    private void CleanUpSources()
    {
      foreach (KeyValuePair<int, int> kvp in _sources)
      {
        int src = kvp.Value;
        int state = 0;
        Al.alGetSourceiv(src, Al.AL_SOURCE_STATE, out state);
        if (state != Al.AL_PLAYING && state != Al.AL_PAUSED)
        {
          Al.alDeleteSources(1, ref src);
        }
      }
    }

    private int GetPlayableSource()
    {
      int result = 0;
      foreach (KeyValuePair<int, int> kvp in _sources)
      {
        int src = kvp.Value;
        int state = 0;
        Al.alGetSourceiv(src, Al.AL_SOURCE_STATE, out state);
        if (state != Al.AL_PLAYING && state != Al.AL_PAUSED)
        {
          result = src;
          break;
        }
      }

      if (result == 0)
      {
        Al.alGenSources(1, out result);
      }

      return result;
    }

    /*public void Play(SceneNode node)
    {
      if (node.Content == null)
        throw new ArgumentException("A scene node with no content cannot be played by the sound engine!");

      if (node.Content.Type != ContentType.Sound)
        throw new ArgumentException("The content \"" + node.Content.ContentData.Get<string>("content.name") + "\" cannot be played by the sound engine as it is of type \"" + node.Content.Type.ToString() + "\"!");

      int source = 0;
      if (!node.Content.ContentData.Contains("al.source"))
      {
        //Create source
      }
      else
      {
        //Update source position
        source = node.Content.ContentData.Get<int>("al.source");
      }

      //Al.alSourcePlay(source);
    }*/

  }
}
