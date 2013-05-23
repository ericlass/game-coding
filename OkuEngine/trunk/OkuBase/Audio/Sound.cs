using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuBase.Audio
{
  /// <summary>
  /// Contains a wave form including some information about the format and the sample data itself.
  /// </summary>
  public class Sound
  {
    private int _id = 0;
    private uint _numberOfSamples = 0;
    private int _sampleRate = 0;
    private int _numChannels = 0;
    private byte[] _channelData = null;

    public Sound()
    {
      _id = KeySequence.NextValue(KeySequence.SoundSequence);
    }

    public int Id
    {
      get { return _id; }
    }

    public uint NumberOfSamples
    {
      get { return _numberOfSamples; }
      set { _numberOfSamples = value; }
    }

    public int SampleRate
    {
      get { return _sampleRate; }
      set { _sampleRate = value; }
    }

    public int NumChannels
    {
      get { return _numChannels; }
      set { _numChannels = value; }
    }

    public byte[] ChannelData
    {
      get { return _channelData; }
      set { _channelData = value; }
    }

    public static Sound FromFile(string filename)
    {
      return WaveLoader.LoadWave(filename);
    }

    public static Sound FromStream(Stream stream)
    {
      return WaveLoader.LoadWave(stream);
    }

    public static Sound FromRaw(uint numSamples, int sampleRate, int numChannels, byte[] data)
    {
      Sound result = new Sound();

      result.NumberOfSamples = numSamples;
      result.SampleRate = sampleRate;
      result.NumChannels = numChannels;
      result.ChannelData = data;

      return result;
    }

  }
}
