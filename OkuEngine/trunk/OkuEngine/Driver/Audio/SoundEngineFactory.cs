using System;
using System.Collections.Generic;
using System.Xml;
using OkuEngine;

namespace OkuEngine.Driver.Audio
{
  /// <summary>
  /// Defines a factor for creating sound engines from an XML node.
  /// </summary>
  internal class SoundEngineFactory
  {
    private delegate ISoundEngine CreateSoundEngineDelegate();

    private Dictionary<string, CreateSoundEngineDelegate> _soundCreators = new Dictionary<string, CreateSoundEngineDelegate>();

    /// <summary>
    /// Creates a new sound engine factory.
    /// </summary>
    public SoundEngineFactory()
    {
      _soundCreators.Add(NullSoundEngine.EngineName, new CreateSoundEngineDelegate(CreateNullEngine));
      _soundCreators.Add(OpenALSoundEngine.EngineName, new CreateSoundEngineDelegate(CreateOpenAlEngine));
    }

    /// <summary>
    /// Create a new sound engine using the given XML node.
    /// </summary>
    /// <param name="engineNode">The XML node to load the sound engine from.</param>
    /// <returns>The created sound engine or null if the sound engine could not be created.</returns>
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

    /// <summary>
    /// Constructor for an OpenAL sound engine.
    /// </summary>
    /// <returns>A new OpenAL sound engine.</returns>
    internal ISoundEngine CreateOpenAlEngine()
    {
      return new OpenALSoundEngine();
    }

    /// <summary>
    /// Constructor for a NULL sound engine.
    /// </summary>
    /// <returns>A new NULL sound engine.</returns>
    internal ISoundEngine CreateNullEngine()
    {
      return new NullSoundEngine();
    }
  }
}
