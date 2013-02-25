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
    private static SoundEngineFactory _instance = null;

    public static SoundEngineFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new SoundEngineFactory();
        return _instance;
      }
    }

    private delegate ISoundEngine CreateSoundEngineDelegate();

    private Dictionary<string, CreateSoundEngineDelegate> _soundCreators = new Dictionary<string, CreateSoundEngineDelegate>();

    /// <summary>
    /// Creates a new sound engine factory.
    /// </summary>
    private SoundEngineFactory()
    {
      _soundCreators.Add(NullSoundEngine.EngineName, new CreateSoundEngineDelegate(CreateNullEngine));
      _soundCreators.Add(OpenALSoundEngine.EngineName, new CreateSoundEngineDelegate(CreateOpenAlEngine));
    }

    /// <summary>
    /// Create a new sound engine using the given XML node.
    /// </summary>
    /// <param name="settings">The settings for the sound engine.</param>
    /// <returns>The created sound engine or null if the sound engine could not be created.</returns>
    public ISoundEngine CreateSoundEngine(AudioSettings settings)
    {
      string type = settings.Type;
      ISoundEngine result = null;

      if (_soundCreators.ContainsKey(type))
      {
        result = _soundCreators[type]();
        result.Initialize(settings);
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
