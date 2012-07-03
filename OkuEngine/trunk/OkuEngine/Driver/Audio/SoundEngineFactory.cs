using System;
using System.Collections.Generic;
using System.Xml;
using OkuEngine;

namespace OkuEngine.Driver.Audio
{
  class SoundEngineFactory
  {
    private delegate ISoundEngine CreateSoundEngineDelegate();

    private Dictionary<string, CreateSoundEngineDelegate> _soundCreators = new Dictionary<string, CreateSoundEngineDelegate>();

    public SoundEngineFactory()
    {
      _soundCreators.Add(NullSoundEngine.EngineName, new CreateSoundEngineDelegate(CreateNullEngine));
      _soundCreators.Add(OpenALSoundEngine.EngineName, new CreateSoundEngineDelegate(CreateOpenAlEngine));
    }

    public ISoundEngine CreateSoundEngine(XmlNode engineNode)
    {
      string type = engineNode.Attributes.GetAttributeValue("type", OpenALSoundEngine.EngineName);
      ISoundEngine result = null;

      if (_soundCreators.ContainsKey(type))
      {
        result = _soundCreators[type]();
        result.Initialize(engineNode);
      }

      return result;
    }

    internal ISoundEngine CreateOpenAlEngine()
    {
      return new OpenALSoundEngine();
    }

    internal ISoundEngine CreateNullEngine()
    {
      return new NullSoundEngine();
    }
  }
}
