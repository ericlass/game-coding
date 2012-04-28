using System;

namespace OkuEngine
{
  /// <summary>
  /// Stores a string key value pair.
  /// </summary>
  public class PropertiesEntry
  {
    private string _key = null;
    private string _value = null;
  
    /// <summary>
    /// Creates a new entry with the given key and value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public PropertiesEntry(string key, string value)
    {
      _key = key;
      _value = value;
    }
    
    /// <summary>
    /// Gets the key.
    /// </summary>
    public string Key 
    {
      get { return _key; }
    }    
    
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public string Value
    {
      get { return _value; }
      set { _value = value; }
    }
    
    /// <summary>
    /// Converts the key value pair to a string in the format key=value.
    /// </summary>
    /// <returns>The key value pair in the format key=value.</returns>
    public override string ToString()
    {
      return _key + "=" + _value;
    }
    
  }
}
