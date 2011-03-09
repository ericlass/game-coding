﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OkuEngine
{
  public class SoundContent : Content
  {

    public SoundContent(string filename)
    {
      Init(WaveLoader.LoadWave(filename));
    }

    public SoundContent(Stream stream)
    {
      Init(WaveLoader.LoadWave(stream));
    }

    public SoundContent(byte[] data, int sampleRate, int numChannels)
    {
      WaveForm wave = new WaveForm();
      wave.ChannelData = data;
      wave.NumChannels = numChannels;
      wave.SampleRate = sampleRate;
      Init(wave);
    }

    private void Init(WaveForm wave)
    {
      if (wave != null)
        OkuInterfaces.SoundEngine.InitContent(this, wave);
      else
        ; //TODO: Log error
    }

    public override ContentType Type
    {
      get { return ContentType.Sound; }
    }

  }
}
