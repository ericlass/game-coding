using System;
using System.Collections.Generic;

namespace OkuBase
{
  /// <summary>
  /// Internal sequence class that is used to generate content ids and 
  /// other artifical ids.
  /// </summary>
  internal static class KeySequence
  {
    public const int InvalidId = 0;

    //Default system sequences
    public const string ImageSequence = "images";
    public const string TimerSequence = "timers";
    public const string SoundSequence = "sounds";
    public const string SourceSequence = "sources";
    public const string ShaderSequence = "shaders";
    public const string ProgramSequence = "programs";
    public const string WidgetSequence = "widgets";
    public const string ParticleSequence = "particles";

    private static Dictionary<string, int> _sequences = new Dictionary<string, int>();

    public static void Initialize()
    {
      //Initialize default sequences
      AddSequence(ImageSequence);
      AddSequence(TimerSequence);
      AddSequence(SoundSequence);
      AddSequence(SourceSequence);
      AddSequence(ShaderSequence);
      AddSequence(ProgramSequence);
      AddSequence(WidgetSequence);
      AddSequence(ParticleSequence);
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
      return false;
    }

    public static int NextValue(string sequence)
    {
      if (!_sequences.ContainsKey(sequence))
        throw new OkuException("Sequence '" + sequence + "' is unknown!");

      int value = _sequences[sequence] + 1;
      _sequences[sequence] = value;
      return value;
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
