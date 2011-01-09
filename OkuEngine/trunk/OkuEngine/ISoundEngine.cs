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

    void InitContent(Content content, Stream data);
    void ReleaseContent(Content content);
  }
}
