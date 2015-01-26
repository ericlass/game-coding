using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace JSONator
{
  /// <summary>
  /// Defines a JSON writer that can be used to convert JSON objects into a JSON string.
  /// Supports creation of minified or indented JSON strings.
  /// </summary>
  public class JSONWriter
  {
    private bool _readable = false;
    private int _currentIndent = 0;

    /// <summary>
    /// Creates a new JSON writer that create minified JSON.
    /// </summary>
    public JSONWriter()
    {
    }

    /// <summary>
    /// Creates a new JSON writer and allows to define if minified or indented JSON should be created.
    /// </summary>
    /// <param name="readable">True for indented JSON. False for minified.</param>
    public JSONWriter(bool readable)
    {
      _readable = readable;
    }

    /// <summary>
    /// Gets or sets if the generated JSON is minified (false) or indented (true).
    /// </summary>
    public bool Readable
    {
      get { return _readable; }
      set { _readable = value; }
    }

    /// <summary>
    /// Gets the current indentation as a string.
    /// </summary>
    private string CurrentIndent
    {
      get { return _readable ? new string(' ', _currentIndent * 2) : ""; }
    }

    /// <summary>
    /// Creates a JSON string from the given JSON object.
    /// </summary>
    /// <param name="root">The root object of the JSON.</param>
    /// <returns>A string represenation of the JSON object and all its members.</returns>
    public string WriteJson(JSONObject root)
    {
      StringBuilder builder = new StringBuilder();

      WriteValue(root, builder);

      return builder.ToString().Trim();
    }

    /// <summary>
    /// Writes a JSON value to the given string builder.
    /// </summary>
    /// <param name="value">The value to be written.</param>
    /// <param name="builder">The builder to write to.</param>
    private void WriteValue(JSONValue value, StringBuilder builder)
    {
      switch (value.ValueType)
      {
        case JSONValueType.Null:
          WriteNull(builder);
          break;
        case JSONValueType.Bool:
          WriteBool(value as JSONBool, builder);
          break;
        case JSONValueType.Number:
          WriteNumber(value as JSONNumber, builder);
          break;
        case JSONValueType.String:
          WriteString(value as JSONString, builder);
          break;
        case JSONValueType.Object:
          WriteObject(value as JSONObject, builder);
          break;
        case JSONValueType.Array:
          WriteArray(value as JSONArray, builder);
          break;
        default:
          throw new FormatException("Onknown JSON value type: '" + value.ValueType + "'!");
      }
    }

    /// <summary>
    /// Writes a null value to the given string builder.
    /// </summary>
    /// <param name="builder">The builder to write to.</param>
    private void WriteNull(StringBuilder builder)
    {
      builder.Append("null");
    }

    /// <summary>
    /// Writes a bool value to the given string builder.
    /// </summary>
    /// <param name="value">The bool value to be written.</param>
    /// <param name="builder">The builder to write to.</param>
    private void WriteBool(JSONBool value, StringBuilder builder)
    {
      builder.Append(value.ToString());
    }

    /// <summary>
    /// Writes a number value to the given string builder.
    /// </summary>
    /// <param name="value">The number value to be written.</param>
    /// <param name="builder">The builder to write to.</param>
    private void WriteNumber(JSONNumber value, StringBuilder builder)
    {
      builder.Append(value.Value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, "."));
    }

    /// <summary>
    /// Writes a string value to the given string builder.
    /// </summary>
    /// <param name="value">The string value to be written.</param>
    /// <param name="builder">The builder to write to.</param>
    private void WriteString(JSONString value, StringBuilder builder)
    {
      builder.Append('"');
      builder.Append(value.Value);
      builder.Append('"');
    }

    /// <summary>
    /// Writes an array value to the given string builder.
    /// </summary>
    /// <param name="value">The array value to be written.</param>
    /// <param name="builder">The builder to write to.</param>
    private void WriteArray(JSONArray value, StringBuilder builder)
    {
      if (value.Count == 0)
      {
        builder.Append("[]");
        return;
      }

      if (_readable)
        builder.Append('\n');

      builder.Append(CurrentIndent);
      builder.Append('[');

      if (_readable)
        builder.Append('\n');

      _currentIndent++;
      for (int i = 0; i < value.Count; i++)
      {
        builder.Append(CurrentIndent);
        WriteValue(value[i], builder);
        if (i < value.Count - 1)
          builder.Append(',');
        
        if (_readable)
          builder.Append('\n');
      }
      _currentIndent--;

      builder.Append(CurrentIndent);
      builder.Append(']');
    }

    /// <summary>
    /// Writes an object value to the given string builder.
    /// </summary>
    /// <param name="value">The object value to be written.</param>
    /// <param name="builder">The builder to write to.</param>
    private void WriteObject(JSONObject value, StringBuilder builder)
    {
      if (_readable)
        builder.Append('\n');

      builder.Append(CurrentIndent);
      builder.Append('{');

      if (_readable)
        builder.Append('\n');

      _currentIndent++;

      List<string> names = value.Names;
      for (int i = 0; i < names.Count; i++)
			{
        string name = names[i];
        builder.Append(CurrentIndent);
        builder.Append('"');
        builder.Append(name);
        builder.Append('"');
        builder.Append(':');

        WriteValue(value[name], builder);

        if (i < names.Count - 1)
          builder.Append(',');

        if (_readable)
          builder.Append('\n');
      }
      _currentIndent--;
      builder.Append(CurrentIndent);
      builder.Append('}');      
    }

  }
}
