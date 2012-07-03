using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Driver.Audio
{
  /// <summary>
  /// Defines a sound engine that does not do anything.
  /// No sound will be played and no sound engine will be initialized.
  /// </summary>
  public class NullSoundEngine : ISoundEngine
  {
    public const string EngineName = "null";

    public float Volume
    {
      get { return 0.0f; }
      set { }
    }

    public bool Initialize(XmlNode soundNode)
    {
      return true;
    }

    public void Update(float dt)
    {
    }

    public void Finish()
    {
    }

    public void Play(SoundInstance instance)
    {
    }

    public void Pause(SoundInstance instance)
    {
    }

    public void Stop(SoundInstance instance)
    {
    }

    public void InitContent(SoundContent content, WaveForm wave)
    {
    }

    public void InitContentRaw(SoundContent content, byte[] data, int sampleRate, int numChannels)
    {
    }

    public void ReleaseContent(SoundContent content)
    {
    }

  }
}
