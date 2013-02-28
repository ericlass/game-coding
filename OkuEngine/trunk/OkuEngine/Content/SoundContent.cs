using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OkuEngine
{
  /// <summary>
  /// Defins a single sound.
  /// </summary>
  public class SoundContent : StoreableEntity
  {
    /// <summary>
    /// Create a new sound from the given file.
    /// </summary>
    /// <param name="filename">The name or path of a .wav file.</param>
    public SoundContent(string filename)
    {
      Init(WaveLoader.LoadWave(filename));
    }

    /// <summary>
    /// Creates a new sound from the given stream.
    /// </summary>
    /// <param name="stream">The stream of a .wav file.</param>
    public SoundContent(Stream stream)
    {
      Init(WaveLoader.LoadWave(stream));
    }

    /// <summary>
    /// Creates a sound from raw sound data.
    /// </summary>
    /// <param name="data">The raw sound data of all channels.</param>
    /// <param name="sampleRate">The sample rate of the sound.</param>
    /// <param name="numChannels">The number of channels.</param>
    public SoundContent(byte[] data, int sampleRate, int numChannels)
    {
      WaveForm wave = new WaveForm();
      wave.ChannelData = data;
      wave.NumChannels = numChannels;
      wave.SampleRate = sampleRate;
      Init(wave);
    }

    /// <summary>
    /// Intializes the sound.
    /// </summary>
    /// <param name="wave">The waveform to use.</param>
    private void Init(WaveForm wave)
    {
      if (wave != null)
        OkuDrivers.Instance.SoundEngine.InitContent(this, wave);
      else
        OkuManagers.Instance.Logger.LogInfo("Trying to init a null waveform!");
    }

    public override bool AfterLoad()
    {
      throw new NotImplementedException();
    }
  }
}
