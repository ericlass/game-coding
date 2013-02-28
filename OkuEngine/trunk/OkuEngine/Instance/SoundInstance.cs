using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines an instance of a sounde.
  /// </summary>
  public class SoundInstance : ContentInstance
  {
    private SoundContent _content = null;
    private float _volume = 1.0f;
    private float _pitch = 1.0f;
    private float _pan = 0.0f;
    private bool _loop = false;

    /// <summary>
    /// Creates a new sound instance for the given sound content.
    /// </summary>
    /// <param name="content"></param>
    public SoundInstance(SoundContent content)
    {
      _content = content;
    }

    /// <summary>
    /// Plays the sound.
    /// </summary>
    public void Play()
    {
      OkuDrivers.Instance.SoundEngine.Play(this);
    }

    /// <summary>
    /// Pauses the sound.
    /// </summary>
    public void Pause()
    {
      OkuDrivers.Instance.SoundEngine.Pause(this);
    }

    /// <summary>
    /// Stop the sound.
    /// </summary>
    public void Stop()
    {
      OkuDrivers.Instance.SoundEngine.Stop(this);
    }

    /// <summary>
    /// Gets or sets the sound content.
    /// </summary>
    public SoundContent Content
    {
      get { return _content; }
      set { _content = value; }
    }

    /// <summary>
    /// Gets or set the volumne of the sound.
    /// </summary>
    public float Volume
    {
      get { return _volume; }
      set { _volume = value; }
    }

    /// <summary>
    /// Gets or set the pitch of the sound.
    /// </summary>
    public float Pitch
    {
      get { return _pitch; }
      set { _pitch = value; }
    }

    /// <summary>
    /// Gets or sets the panning of the sound.
    /// </summary>
    public float Pan
    {
      get { return _pan; }
      set { _pan = value; }
    }

    /// <summary>
    /// Gets or sets if the sound is looped or not.
    /// </summary>
    public bool Loop
    {
      get { return _loop; }
      set { _loop = value; }
    }

  }
}
