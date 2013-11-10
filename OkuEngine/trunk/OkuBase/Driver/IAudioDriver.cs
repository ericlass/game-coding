using System;
using System.Collections.Generic;
using System.Text;
using OkuBase.Audio;
using OkuBase.Settings;

namespace OkuBase.Driver
{
  public interface IAudioDriver
  {
    string DriverName { get; }

    /// <summary>
    /// Gets or set the global volume of playback in the range 0.0...1.0.
    /// </summary>
    float Volume { get; set; }

    /// <summary>
    /// Initializes the sound engine.
    /// </summary>
    bool Initialize(AudioSettings settings);
    /// <summary>
    /// Updates the sounds that are currently played.
    /// </summary>
    /// <param name="dt">The time passed since the last update.</param>
    void Update(float dt);
    /// <summary>
    /// Frees all resources used by the sound engine.
    /// </summary>
    void Finish();

    /// <summary>
    /// Plays the given sound.
    /// </summary>
    /// <param name="source">The source to be played.</param>
    void Play(Source source);
    /// <summary>
    /// Pauses the given sound.
    /// </summary>
    /// <param name="source">The source to be paused.</param>
    void Pause(Source source);
    /// <summary>
    /// Stops the given sound.
    /// </summary>
    /// <param name="source">The source to be stopped.</param>
    void Stop(Source source);

    /// <summary>
    /// Initializes the given source.
    /// </summary>
    /// <param name="source">The source to be initialized.</param>
    void LoadSource(Source source);

    /// <summary>
    /// Updates an existing sources properties. Does not update the underlying sound.
    /// </summary>
    /// <param name="source">The source to be updated.</param>
    void UpdateSource(Source source);

    /// <summary>
    /// Releases the given source. It cannot be played afterwards.
    /// </summary>
    /// <param name="source">The source to be released.</param>
    void ReleaseSource(Source source);

  }
}
