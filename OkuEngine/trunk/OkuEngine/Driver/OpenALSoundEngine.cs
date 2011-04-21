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
    private Dictionary<int, int> _buffers = new Dictionary<int, int>(); //Maps content keys to open al buffer id's
    private Dictionary<SceneNode, int> _sources = new Dictionary<SceneNode, int>(); //Maps scene nodes to open al source id's

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

    public void Finish()
    {
      //Go through all sound content and release all buffers and sources

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

      _buffers.Add(content.ContentKey, buffer);
    }

    public void ReleaseContent(Content content)
    {
      if (_buffers.ContainsKey(content.ContentKey))
      {
        //Release buffer
        int buffer = _buffers[content.ContentKey];
        Al.alDeleteBuffers(1, ref buffer);
        //Release source
        //TODO: How?
        //Al.alDeleteSources();
        
      }
    }

    public void Play(SceneNode node)
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
    }

  }
}
