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

    public void InitContent(Content content, Stream data)
    {
      //Pass data to to wave loader to get raw sound data
      //Create buffer
      //put buffer id in content data with name "al.buffer"
    }

    public void ReleaseContent(Content content)
    {
      //Release buffer
      //Release source
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
