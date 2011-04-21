using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OkuEngine
{
  public interface ISoundEngine
  {
    float Volume { get; set; }

    void Initialize();
    void Finish();

    void Play(SceneNode node);

    void InitContent(Content content, WaveForm wave);
    void InitContentRaw(Content content, byte[] data, int sampleRate, int numChannels);

    void ReleaseContent(Content content);
  }
}
