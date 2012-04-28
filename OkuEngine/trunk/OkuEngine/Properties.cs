using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Manages a set of string key value pairs.
  /// </summary>
  public class Properties
  {
    private List<PropertiesEntry> _entries = new List<PropertiesEntry>();
    private Dictionary<string, int> _nameIndexes = new Dictionary<string, int>();
    
    /// <summary>
    /// Creates a new, empty properties manager.
    /// </summary>
    public Properties()
    {
    }
    
    /// <summary>
    /// Adds the given value with the given key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value. Can be null.</param>
    private void Add(string key, string value)
    {
      _entries.Add(new PropertiesEntry(key, value));
      _nameIndexes.Add(key, _entries.Count - 1);
    }
    
    /// <summary>
    /// Gets or sets the value with the given key.
    /// If no value with the given key exists, it is either
    /// added or null is returned.
    /// </summary>
    public string this[string key]
    {
      get 
      {
        if (_nameIndexes.ContainsKey(key))
          return _entries[_nameIndexes[key]].Value;
        else
          return null;
      }
      set
      {
        if (_nameIndexes.ContainsKey(key))
          _entries[_nameIndexes[key]].Value = value;
        else
          Add(key, value);
      }
    }
    
    /// <summary>
    /// Checks if there is a value with the given key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>True if there is a value with the given key, else False.</returns>
    public bool ContainsKey(string key)
    {
      return _nameIndexes.ContainsKey(key);
    }
    
    /// <summary>
    /// Removes the value with the given key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>True if the value existed and was removed, else false.</returns>
    public bool Remove(string key)
    {
      if (_nameIndexes.ContainsKey(key))
      {
        int index = _nameIndexes[key];
        _nameIndexes.Remove(key);
        _entries.RemoveAt(index);
        return true;
      }
      return false;
    }
    
    /// <summary>
    /// Clears all data contained in this property manager.
    /// </summary>
    public void Clear()
    {
      _nameIndexes.Clear();
      _entries.Clear();
    }
    
    /// <summary>
    /// Saves the values in the property manager to the given file.
    /// </summary>
    /// <param name="filename">The name and path of the file.</param>
    public void Save(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
      try {
        Save(stream);
      } finally {
        stream.Close();
      }
    }
    
    /// <summary>
    /// Saves the values in the property mamanger to the given stream.
    /// </summary>
    /// <param name="stream">The stream to save to.</param>
    public void Save(Stream stream)
    {
      StreamWriter writer = new StreamWriter(stream);
      foreach (PropertiesEntry entry in _entries)
      {
        writer.WriteLine(entry.ToString());
      }
      writer.Flush();
    }
    
    /// <summary>
    /// Loads the values from the given file. The values read
    /// from the file are added to the current values. Values
    /// that already exist are overwritten with the ones from the file.
    /// </summary>
    /// <param name="filename">The name and path of the file.</param>
    public void Load(string filename)
    {
      FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
      try {
        Load(stream);
      } finally {
        stream.Close();
      }
    }
    
    /// <summary>
    /// Splits the given string by the first equal sign.
    /// </summary>
    /// <param name="str">The string to split.</param>
    /// <returns>An array with the first item set to the key and 
    /// the second set to the value, or an empty array if the string
    /// could not be split.</returns>
    private string[] SplitKeyValue(string str)
    {
      int index = str.IndexOf('=');
      if (index >= 0)
      {
        string key = str.Substring(0, index);
        string value = str.Substring(index + 1);
        
        return new string[2] { key, value };
      }
      return new string[0];
    }
    
    /// <summary>
    /// Loads the values from the given stream. The values read
    /// from the stream are added to the current values. Values
    /// that already exist are overwritten with the ones from the stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    public void Load(Stream stream)
    {
      StreamReader reader = new StreamReader(stream);
      string line = reader.ReadLine();
      while (line != null)
      {
        string[] parts = line.Split('=');
        
        string key = null;
        string value = null;
        
        if (parts.Length > 0)
          key = parts[0];
        if (parts.Length > 1)
          value = parts[1];
        
        if (key != null)
          this[key] = value;
        
        line = reader.ReadLine();
      }
    }
    
  }
}
