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
    public const string BufferSequence = "buffers";

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
      AddSequence(BufferSequence);
    }

    /// <summary>
    /// Resets the given sequence to zero.
    /// </summary>
    /// <param name="name">The name of the sequence.</param>
    /// <returns>True if the sequence was reset, false if there is no sequence with the given name.</returns>
    public static bool ResetSequence(string name)
    {
      if (_sequences.ContainsKey(name))
      {
        _sequences[name] = 0;
        return true;
      }
      return false;
    }

    /// <summary>
    /// Resets all sequences to zero.
    /// </summary>
    public static void ResetAll()
    {
      foreach (string seqName in _sequences.Keys)
      {
        _sequences[seqName] = 0;
      }
    }

    /// <summary>
    /// Gets the number of sequences that exist.
    /// </summary>
    public static int Count
    {
      get { return _sequences.Count; }
    }

    /// <summary>
    /// Adds a new sequence with the given name.
    /// The new sequence starts with 1.
    /// </summary>
    /// <param name="name">The name of the sequence.</param>
    /// <returns>True if the sequence was added, false if there already is a sequence with the given name.</returns>
    public static bool AddSequence(string name)
    {
      if (!_sequences.ContainsKey(name))
      {
        _sequences.Add(name, 0);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Gets the next value of a sequence.
    /// </summary>
    /// <param name="sequence">The name of the sequence.</param>
    /// <returns>The next value of the sequence.</returns>
    public static int NextValue(string sequence)
    {
      if (!_sequences.ContainsKey(sequence))
        throw new OkuException("Sequence '" + sequence + "' is unknown!");

      int value = _sequences[sequence] + 1;
      _sequences[sequence] = value;
      return value;
    }

    /// <summary>
    /// Sets the current value of a sequence.
    /// </summary>
    /// <param name="sequence">The name of the sequence.</param>
    /// <param name="value">The value to set the sequence to.</param>
    /// <returns>True if the sequence value was set, False if there is no sequence with the given name.</returns>
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
