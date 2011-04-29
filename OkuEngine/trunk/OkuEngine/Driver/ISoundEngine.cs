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
    void Update(float dt);
    void Finish();

    /*void Play(SoundContent sound);
    void Play(SoundContent sound, float volume);
    void Play(SoundContent sound, float pan);
    void Play(SoundContent sound, float pitch);
    void Play(SoundContent sound, float volume, float pan, float pitch);*/

    void Play(SoundInstance instance);
    void Pause(SoundInstance instance);
    void Stop(SoundInstance instance);

    void InitContent(Content content, WaveForm wave);
    void InitContentRaw(Content content, byte[] data, int sampleRate, int numChannels);

    void ReleaseContent(Content content);
  }
}
