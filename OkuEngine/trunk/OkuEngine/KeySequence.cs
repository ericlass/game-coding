using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Internal sequence class that is used to generate content ids and 
  /// other artifical ids.
  /// </summary>
  internal static class KeySequence
  {
    public const int InvalidId = 0;

    //Default system sequences
    public const string ActorSequence = "actors";
    public const string ActorTypeSequence = "actortypes";
    public const string SceneSequence = "scenes";
    public const string LayerSequence = "layers";
    public const string ContentSequence = "content";
    public const string ContentInstanceSequence = "contentinstances";
    public const string ImageSequence = "images";
    public const string AnimationSequence = "animations";
    public const string WidgetSequence = "widgets";
    public const string ParticleSequence = "particles";
    public const string ScriptSequence = "scripts";
    public const string UserEventSequence = "userevents";
    public const string BehaviorSequence = "behaviors";
    public const string BrushSequence = "brushes";
    public const string SceneObjectSequence = "sceneobjects";

    //TODO: Find a better name. Everything is an entity!
    public const string EntitySequence = "entities"; //collision world

    private static Dictionary<string, int> _sequences = new Dictionary<string, int>();

    public static void Initialize()
    {
      //Initialize default sequences
      AddSequence(ActorSequence);
      AddSequence(ActorTypeSequence);
      AddSequence(SceneSequence);
      AddSequence(LayerSequence);
      AddSequence(ContentSequence);
      AddSequence(ContentInstanceSequence);
      AddSequence(ImageSequence);
      AddSequence(AnimationSequence);
      AddSequence(WidgetSequence);
      AddSequence(ParticleSequence);
      AddSequence(ScriptSequence);
      AddSequence(EntitySequence);
      AddSequence(UserEventSequence);
      AddSequence(BehaviorSequence);
      AddSequence(BrushSequence);
      AddSequence(SceneObjectSequence);
    }

    public static bool ResetSequence(string name)
    {
      if (_sequences.ContainsKey(name))
      {
        _sequences[name] = 0;
        return true;
      }
      return false;
    }

    public static void ResetAll()
    {
      foreach (string seqName in _sequences.Keys)
      {
        _sequences[seqName] = 0;
      }
    }

    public static int Count
    {
      get { return _sequences.Count; }
    }

    public static bool AddSequence(string name)
    {
      if (!_sequences.ContainsKey(name))
      {
        _sequences.Add(name, 0);
        return true;
      }
      else
      {
        OkuManagers.Logger.LogError("Trying to add the sequence '" + name + "' twice!");
      }
      return false;
    }

    public static int NextValue(string sequence)
    {
      if (_sequences.ContainsKey(sequence))
      {
        int value = _sequences[sequence] + 1;
        _sequences[sequence] = value;
        return value;
      }

      throw new OkuException("Sequence '" + sequence + "' is unknown!");
    }

    public static bool SetCurrentValue(string sequence, int value)
    {
      if (_sequences.ContainsKey(sequence))
      {
        if (_sequences[sequence] < value)
        {
          _sequences[sequence] = value;
          return true;
        }
      }
      return false;
    }

  }
}
