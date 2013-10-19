using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace JSONator
{
  public class JSONWriter
  {
    private bool _readable = false;
    private int _currentIndent = 0;

    public JSONWriter()
    {
    }

    public JSONWriter(bool readable)
    {
      _readable = readable;
    }

    public bool Readable
    {
      get { return _readable; }
      set { _readable = value; }
    }

    private string CurrentIndent
    {
      get { return _readable ? new string(' ', _currentIndent * 2) : ""; }
    }

    public string WriteJson(JSONObjectValue root)
    {
      StringBuilder builder = new StringBuilder();

      WriteValue(root, builder);

      return builder.ToString().Trim();
    }

    private void WriteValue(JSONValue value, StringBuilder builder)
    {
      switch (value.ValueType)
      {
        case JSONValueType.Null:
          WriteNull(builder);
          break;
        case JSONValueType.Bool:
          WriteBool(value as JSONBoolValue, builder);
          break;
        case JSONValueType.Number:
          WriteNumber(value as JSONNumberValue, builder);
          break;
        case JSONValueType.String:
          WriteString(value as JSONStringValue, builder);
          break;
        case JSONValueType.Object:
          WriteObject(value as JSONObjectValue, builder);
          break;
        case JSONValueType.Array:
          WriteArray(value as JSONArrayValue, builder);
          break;
        default:
          throw new FormatException("Onknown JSON value type: '" + value.ValueType + "'!");
      }
    }

    private void WriteNull(StringBuilder builder)
    {
      builder.Append("null");
    }

    private void WriteBool(JSONBoolValue value, StringBuilder builder)
    {
      builder.Append(value.Value.ToString());
    }

    private void WriteNumber(JSONNumberValue value, StringBuilder builder)
    {
      builder.Append(value.Value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, "."));
    }

    private void WriteString(JSONStringValue value, StringBuilder builder)
    {
      builder.Append('"');
      builder.Append(value.Value);
      builder.Append('"');
    }

    private void WriteArray(JSONArrayValue value, StringBuilder builder)
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

    private void WriteObject(JSONObjectValue value, StringBuilder builder)
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
