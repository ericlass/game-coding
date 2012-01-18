using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OkuEngine
{
  /// <summary>
  /// Supplies functions to work with config files that store the configuration
  /// in the format "key"="value". Lines that start with a # are ignored. It is
  /// not allowed to have anything before a #.
  /// </summary>
  class ConfigFile
  {
    private Dictionary<String, String> _values = new Dictionary<string,string>();

    /// <summary>
    /// Creates a new cinfog file.
    /// </summary>
    public ConfigFile()
    {
    }

    /// <summary>
    /// Converts the given float value to a string. The decimal separator will always be ".".
    /// </summary>
    /// <param name="value">The float to be converted.</param>
    /// <returns>The string represenation of the given float value.</returns>
    private string FloatToString(double value)
    {
      string result = value.ToString("0");
      result += "." + value.ToString(".0##################################").Substring(1);
      return result;
    }

    /// <summary>
    /// Converts the given string to a float value. The decimal separator has to be a ".".
    /// </summary>
    /// <param name="str">The string to be converted to a float.</param>
    /// <returns>The converted float value.</returns>
    private double StrToFloat(string str)
    {
      string[] parts = str.Split('.');
      double result = double.Parse(parts[0]);
      double fraction = double.Parse(parts[1]);
      while (fraction > 0.0)
        fraction /= 10.0;
      result += fraction;
      return result;
    }

    /// <summary>
    /// Creates a string containing the key and the value of a key value pair in
    /// the format "key"="value".
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The key and value separated by a "=".</returns>
    private string GetKeyValueString(string key)
    {
      return key + "=" + _values[key];
    }

    /// <summary>
    /// Gets the count of key value pairs that are stored in this config file.
    /// </summary>
    public int Count
    {
      get { return _values.Count; }
    }

    /// <summary>
    /// Loads the contents of the given config file into the internal buffer.
    /// </summary>
    /// <param name="fileName">The full or relative path to the file to load.</param>
    public void LoadFile(string fileName)
    {
      StreamReader reader = new StreamReader(fileName);
      String fileContent = reader.ReadToEnd();
      reader.Close();
      LoadString(fileContent);
    }

    /// <summary>
    /// Loads the config values from the given string. The string is expected to
    /// have exavtly one key value pair per line.
    /// </summary>
    /// <param name="str">The string to be loaded.</param>
    public void LoadString(string str)
    {
      StringReader reader = new StringReader(str);
      string line = reader.ReadLine();
      while (line != null)
      {
        line = line.Trim();
        if (!line.StartsWith("#"))
        {
          string[] parts = line.Split('=');
          if (parts.Length >= 2)
            _values.Add(parts[0].Trim(), parts[1].Trim());
          else
            ; //TODO: Log warning
        }
        line = reader.ReadLine();
      }
      reader.Close();
    }

    /// <summary>
    /// Saves the contents of the internal buffer to the given file.
    /// The structure of the file will not be changed. Comments will also
    /// not be removed. All values are written to the line where they already are.
    /// Values that are currently not in the file are appended to the end of the file.
    /// </summary>
    /// <param name="fileName">The full or relative path to the file.</param>
    /// <returns>True if the file has been written successfully, else false.</returns>
    public bool SaveToFile(string fileName)
    {
      string finalFile = null;
      if (File.Exists(fileName))
      {
        StringBuilder builder = new StringBuilder();
        List<string> written = new List<string>();

        //load file
        StreamReader stream = new StreamReader(fileName);
        StringReader reader = new StringReader(stream.ReadToEnd());
        stream.Close();
        string line = reader.ReadLine();
        //for each line in file
        while (line != null)
        {
          //check if line contains a key value pair by checkung for "="
          if (line.Contains('=') && !line.Trim().StartsWith("#"))
          {
            string[] parts = line.Split('=');
            string key = parts[0].Trim();
            //check if the key is in the internal buffer
            if (_values.ContainsKey(key))
            {
              //write line with value from buffer
              builder.AppendLine(GetKeyValueString(key));
              //remember the value as written
              written.Add(key);
            }
            else
              builder.AppendLine(line);
          }
          else
            builder.AppendLine(line);

          line = reader.ReadLine();
        }

        //Write value that have not been written yet
        foreach (KeyValuePair<string, string> pair in _values)
        {
          if (!written.Contains(pair.Key))
            builder.AppendLine(GetKeyValueString(pair.Key));
        }

        finalFile = builder.ToString();
      }
      else
      {
        finalFile = ToString();
      }

      try
      {
        //Finally write contents to file
        StreamWriter writer = new StreamWriter(fileName);
        writer.Write(finalFile);
        writer.Flush();
        writer.Close();
      }
      catch (Exception ex)
      {
        //TODO: Log error
        return false;
      }

      return true;
    }

    /// <summary>
    /// Checks if a value with the given name is in the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value to check.</param>
    /// <returns>True if the buffer contains a value with the given name, else false.</returns>
    public bool Contains(string name)
    {
      return _values.ContainsKey(name);
    }

    /// <summary>
    /// Removes the value with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value to be removed.</param>
    /// <returns>True if the value was removed or false if there is no value with the given name.</returns>
    public bool Remove(string name)
    {
      return _values.Remove(name);
    }

    /// <summary>
    /// Sets the given string value in the internal buffer. If the internal buffer
    /// does not contain a value with the given name, the value is added to it.
    /// If the internal buffer already contains a value with the given name,
    /// the value is updated.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="value">The string value.</param>
    public void Set(string name, string value)
    {
      if (_values.ContainsKey(name))
        _values[name] = value;
      else
        _values.Add(name, value);
    }

    /// <summary>
    /// Sets the given int value in the internal buffer. If the internal buffer
    /// does not contain a value with the given name, the value is added to it.
    /// If the internal buffer already contains a value with the given name,
    /// the value is updated.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="value">The int value.</param>
    public void SetInt(string name, int value)
    {
      if (_values.ContainsKey(name))
        _values[name] = value.ToString();
      else
        _values.Add(name, value.ToString());
    }

    /// <summary>
    /// Sets the given float value in the internal buffer. If the internal buffer
    /// does not contain a value with the given name, the value is added to it.
    /// If the internal buffer already contains a value with the given name,
    /// the value is updated.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="value">The float value.</param>
    public void SetFloat(string name, float value)
    {
      if (_values.ContainsKey(name))
        _values[name] = FloatToString(value);
      else
        _values.Add(name, FloatToString(value));
    }

    /// <summary>
    /// Sets the given double value in the internal buffer. If the internal buffer
    /// does not contain a value with the given name, the value is added to it.
    /// If the internal buffer already contains a value with the given name,
    /// the value is updated.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="value">The double value.</param>
    public void SetDouble(string name, double value)
    {
      if (_values.ContainsKey(name))
        _values[name] = FloatToString(value);
      else
        _values.Add(name, FloatToString(value));
    }

    /// <summary>
    /// Sets the given vector in the internal buffer. If the internal buffer
    /// does not contain a value with the given name, the value is added to it.
    /// If the internal buffer already contains a value with the given name,
    /// the value is updated.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="value">The vector.</param>
    public void SetVector(string name, Vector value)
    {
      string str = FloatToString(value.X) + "," + FloatToString(value.Y);
      if (_values.ContainsKey(name))
        _values[name] = str;
      else
        _values.Add(name, str);
    }

    /// <summary>
    /// Sets the given matrix in the internal buffer. If the internal buffer
    /// does not contain a value with the given name, the value is added to it.
    /// If the internal buffer already contains a value with the given name,
    /// the value is updated.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="value">The matrix value.</param>
    public void SetMatrix(string name, Matrix3 value)
    {
      StringBuilder builder = new StringBuilder();

      builder.Append(FloatToString(value.V00));
      builder.Append(",");
      builder.Append(FloatToString(value.V01));
      builder.Append(",");
      builder.Append(FloatToString(value.V02));
      builder.Append(",");
      builder.Append(FloatToString(value.V10));
      builder.Append(",");
      builder.Append(FloatToString(value.V11));
      builder.Append(",");
      builder.Append(FloatToString(value.V12));

      if (_values.ContainsKey(name))
        _values[name] = builder.ToString();
      else
        _values.Add(name, builder.ToString());
    }

    /// <summary>
    /// Sets the given boolean value in the internal buffer. If the internal buffer
    /// does not contain a value with the given name, the value is added to it.
    /// If the internal buffer already contains a value with the given name,
    /// the value is updated.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <param name="value">The boolean value.</param>
    public void SetBool(string name, bool value)
    {
      if (_values.ContainsKey(name))
        _values[name] = value.ToString();
      else
        _values.Add(name, value.ToString());
    }

    /// <summary>
    /// Get the string value with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The string value with the given name.</returns>
    public string Get(string name)
    {
      return _values[name];
    }

    /// <summary>
    /// Get the int value with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The int value with the given name.</returns>
    public int GetInt(string name)
    {
      return int.Parse(_values[name]);
    }

    /// <summary>
    /// Get the float value with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The float value with the given name.</returns>
    public float GetFloat(string name)
    {
      return (float)StrToFloat(_values[name]);
    }

    /// <summary>
    /// Get the double value with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The double value with the given name.</returns>
    public double GetDouble(string name)
    {
      return StrToFloat(_values[name]);
    }

    /// <summary>
    /// Get the vector with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The vector with the given name.</returns>
    public Vector GetVector(string name)
    {
      string[] parts = _values[name].Split(',');
      Vector result = new Vector();
      result.X = (float)StrToFloat(parts[0]);
      result.Y = (float)StrToFloat(parts[1]);
      return result;
    }

    /// <summary>
    /// Get the matrix with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The name of the value.</param>
    /// <returns>The matrix with the given name.</returns>
    public Matrix3 GetMatrix(string name)
    {
      string[] parts = _values[name].Split(',');
      Matrix3 result = new Matrix3();
      result.V00 = (float)StrToFloat(parts[0]);
      result.V01 = (float)StrToFloat(parts[1]);
      result.V02 = (float)StrToFloat(parts[2]);
      result.V10 = (float)StrToFloat(parts[3]);
      result.V11 = (float)StrToFloat(parts[4]);
      result.V12 = (float)StrToFloat(parts[5]);
      return result;
    }

    /// <summary>
    /// Gets the boolean value with the given name from the internal buffer.
    /// </summary>
    /// <param name="name">The of the the value.</param>
    /// <returns>The value of the boolean value or false if there no such value or the value could not be parsed.</returns>
    public bool GetBool(string name)
    {
      bool result;
      if (_values.ContainsKey(name) && Boolean.TryParse(_values[name], out result))
        return result;
      return false; //Return false by default
    }

    /// <summary>
    /// Returns a complete string representation of the config file
    /// which includes all values with their names separated by a
    /// "=".
    /// </summary>
    /// <returns>A complete string representation of the config file.</returns>
    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      foreach (KeyValuePair<string, string> pair in _values)
      {
        builder.Append(pair.Key);
        builder.Append("=");
        builder.AppendLine(pair.Value);
      }
      return builder.ToString();
    }

  }
}
