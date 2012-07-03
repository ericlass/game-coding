using System;
using System.Xml;
using System.IO;

namespace OkuEngine.Driver.Audio
{
  /// <summary>
  /// Specifies all necessary methods to play sounds.
  /// </summary>
  public interface ISoundEngine
  {
    /// <summary>
    /// Gets or set the volume of playback in the range 0.0...1.0.
    /// </summary>
    float Volume { get; set; }

    /// <summary>
    /// Initializes the sound engine.
    /// </summary>
    bool Initialize(XmlNode soundNode);
    /// <summary>
    /// Updates the sounds that are currently played.
    /// </summary>
    /// <param name="dt"></param>
    void Update(float dt);
    /// <summary>
    /// Frees all resources used by the sound engine.
    /// </summary>
    void Finish();

    /// <summary>
    /// Plays the given sound.
    /// </summary>
    /// <param name="instance"></param>
    void Play(SoundInstance instance);
    /// <summary>
    /// Pauses the given sound.
    /// </summary>
    /// <param name="instance"></param>
    void Pause(SoundInstance instance);
    /// <summary>
    /// Stops the given sound.
    /// </summary>
    /// <param name="instance"></param>
    void Stop(SoundInstance instance);

    /// <summary>
    /// Initializes content with the given wave forma data.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="wave">The wave form data.</param>
    void InitContent(SoundContent content, WaveForm wave);

    /// <summary>
    /// Initializes content from raw sample data.
    /// </summary>
    /// <param name="content">The content to be initialized.</param>
    /// <param name="data">The raw sample data.</param>
    /// <param name="sampleRate">The sample rate of the sound in KHz.</param>
    /// <param name="numChannels">The number of channels.</param>
    void InitContentRaw(SoundContent content, byte[] data, int sampleRate, int numChannels);

    void ReleaseContent(SoundContent content);
  }
}
