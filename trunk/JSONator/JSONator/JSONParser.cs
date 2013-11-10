using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace JSONator
{
  /// <summary>
  /// Defines a simple parse for a JSON string.
  /// </summary>
  public class JSONParser
  {
    private int _currentPos = 0;
    private char[] _json = null;

    private int _line = 0;
    private HashSet<char> _whiteSpaces = null;
    private HashSet<char> _digits = null;
    private HashSet<char> _hexDigits = null;
    private HashSet<char> _numberChars = null;

    /// <summary>
    /// Creates a new JSON parser.
    /// </summary>
    public JSONParser()
    {
      _whiteSpaces = new HashSet<char>();
      _whiteSpaces.Add(' ');
      _whiteSpaces.Add('\n');
      _whiteSpaces.Add('\r');
      _whiteSpaces.Add('\t');

      _digits = new HashSet<char>();
      _digits.Add('0');
      _digits.Add('1');
      _digits.Add('2');
      _digits.Add('3');
      _digits.Add('4');
      _digits.Add('5');
      _digits.Add('6');
      _digits.Add('7');
      _digits.Add('8');
      _digits.Add('9');

      _hexDigits = new HashSet<char>(_digits);
      _hexDigits.Add('A');
      _hexDigits.Add('B');
      _hexDigits.Add('C');
      _hexDigits.Add('D');
      _hexDigits.Add('E');
      _hexDigits.Add('F');
      _hexDigits.Add('a');
      _hexDigits.Add('b');
      _hexDigits.Add('c');
      _hexDigits.Add('d');
      _hexDigits.Add('e');
      _hexDigits.Add('f');

      _numberChars = new HashSet<char>(_digits);
      _numberChars.Add('.');
      _numberChars.Add('+');
      _numberChars.Add('-');
      _numberChars.Add('e');
      _numberChars.Add('E');
    }

    /// <summary>
    /// Throws an exception that says, that a different character was found than expected.
    /// </summary>
    /// <param name="expected">The expected character(s).</param>
    private void ExpectedError(string expected)
    {
      throw new FormatException("'" + expected + "' expected, but '" + CurrentChar + "' found at line " + _line);
    }

    /// <summary>
    /// Throws an exception that says, that the end of the file has been reached unexpected.
    /// </summary>
    private void EndOfFileError()
    {
      throw new FormatException("Unexpected end of file at line " + _line + "!");
    }

    /// <summary>
    /// Throws a general exception with the given error message.
    /// </summary>
    /// <param name="error"></param>
    private void GeneralError(string error)
    {
      throw new FormatException(error + " (line " + _line + ")");
    }

    /// <summary>
    /// Skips all white space characters.
    /// </summary>
    private void SkipWhiteSpaces()
    {
      while (_whiteSpaces.Contains(CurrentChar))
      {
        if (CurrentChar == '\n')
          _line++;

        _currentPos++;

        if (EOF)
          EndOfFileError();
      }
    }

    /// <summary>
    /// Gets the character the current parse pointer points to.
    /// </summary>
    private char CurrentChar
    {
      get { return _json[_currentPos]; }
    }

    /// <summary>
    /// Parses the given JSON string into an object hierarchy.
    /// </summary>
    /// <param name="json">The JSON string to be parsed.</param>
    /// <returns>The parsed root JSON object.</returns>
    public JSONObjectValue Parse(string json)
    {
      _json = json.ToCharArray();
      _currentPos = 0;
      _line = 1;

      SkipWhiteSpaces();

      if (CurrentChar != '{')
        ExpectedError("{");

      return ReadObject();
    }

    /// <summary>
    /// Gets if the parse pointer has reached the end of the file.
    /// </summary>
    private bool EOF
    {
      get { return _currentPos >= _json.Length; }
    }

    /// <summary>
    /// Read the name of an object member.
    /// </summary>
    /// <returns>The parsed name.</returns>
    private string ReadString()
    {
      _currentPos++;
      StringBuilder builder = new StringBuilder();
      while (CurrentChar != '"' && !EOF)
      {
        if (CurrentChar == '\\')
        {
          //Escape sequences
          _currentPos++;
          switch (CurrentChar)
          {
            case '\\':
              builder.Append('\\');
              break;

            case '"':
              builder.Append('"');
              break;

            case '/':
              builder.Append('/');
              break;

            case 'b':
            case 'B':
              builder.Append('\b');
              break;

            case 'f':
            case 'F':
              builder.Append('\f');
              break;

            case 'n':
            case 'N':
              builder.Append('\n');
              break;

            case 'r':
            case 'R':
              builder.Append('\r');
              break;

            case 't':
            case 'T':
              builder.Append('\t');
              break;

            case 'u':
            case 'U':
              _currentPos++;
              StringBuilder numBuilder = new StringBuilder();
              for (int i = 0; i < 4; i++)
              {
                if (!_hexDigits.Contains(CurrentChar))
                  ExpectedError("Four hex digits");

                numBuilder.Append(CurrentChar);
                _currentPos++;
                if (EOF)
                  EndOfFileError();
              }
              int number = Convert.ToInt32(numBuilder.ToString(), 16);
              builder.Append(Char.ConvertFromUtf32(number));
              _currentPos--;
              break;

            default:
              builder.Append("\\");
              builder.Append(CurrentChar);
              break;
          }
        }
        else
          builder.Append(CurrentChar);

        _currentPos++;
      }
      _currentPos++;

      if (EOF)
        EndOfFileError();

      return builder.ToString();
    }

    /// <summary>
    /// Reads a value. The type is automatically determined and the result is from this special type.
    /// </summary>
    /// <returns>The parsed value.</returns>
    private JSONValue ReadValue()
    {
      switch (CurrentChar)
      {
        case '{':
          return ReadObject();

        case '[':
          return ReadArray();

        case 't':
        case 'T':
        case 'f':
        case 'F':
          return ReadBool();

        case 'n':
        case 'N':
          return ReadNull();

        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
        case '-':
        case '+':
          return ReadNumber();

        case '"':
          return ReadStringValue();

        default:
          GeneralError("Unknown value '" + CurrentChar.ToString() + "'!");
          break;
      }

      return null;
    }

    /// <summary>
    /// Reads an object value including all members that it contains.
    /// </summary>
    /// <returns>The parsed JSON object value.</returns>
    private JSONObjectValue ReadObject()
    {
      _currentPos++;

      SkipWhiteSpaces();

      JSONObjectValue result = new JSONObjectValue();

      if (CurrentChar == '}')
        return result;      

      while (CurrentChar != '}')
      {
        if (CurrentChar != '"')
          ExpectedError("\"");

        string name = ReadString();

        if (name == null || name.Length == 0)
          GeneralError("Member name cannot be empty!");

        SkipWhiteSpaces();

        if (CurrentChar != ':')
          ExpectedError(":");

        _currentPos++;

        SkipWhiteSpaces();

        JSONValue value = ReadValue();

        result.Add(name, value);

        SkipWhiteSpaces();

        bool isComma = CurrentChar == ',';
        if (!isComma && CurrentChar != '}')
          ExpectedError("',' or '}'");

        if (isComma)
        {
          _currentPos++;
          SkipWhiteSpaces();
        }
      }

      _currentPos++;
      return result;
    }

    /// <summary>
    /// Reads an array value including all items.
    /// </summary>
    /// <returns>The parsed JSON array value.</returns>
    private JSONArrayValue ReadArray()
    {
      _currentPos++;
      JSONArrayValue result = new JSONArrayValue();
      while (CurrentChar != ']')
      {
        SkipWhiteSpaces();
        result.Add(ReadValue());
        SkipWhiteSpaces();

        bool isComma = CurrentChar == ',';
        if (!isComma && CurrentChar != ']')
          ExpectedError("',' or ']'");

        if (isComma)
        {
          _currentPos++;
          SkipWhiteSpaces();
        }
      }
      _currentPos++;
      return result;
    }

    /// <summary>
    /// Reads a boolean value.
    /// </summary>
    /// <returns>The parsed JSON boolean value.</returns>
    private JSONBoolValue ReadBool()
    {
      JSONBoolValue result = null;

      if (CurrentChar == 'f' || CurrentChar == 'F')
      {
        result = new JSONBoolValue(false);
        _currentPos += 5; // Skip "false"
      }
      else if (CurrentChar == 't' || CurrentChar == 'T')
      {
        result = new JSONBoolValue(true);
        _currentPos += 4; // Skip "true"
      }
      else
        GeneralError("Unknow boolean value!");

      if (EOF)
        EndOfFileError();

      return result;
    }

    /// <summary>
    /// Reads a null value.
    /// </summary>
    /// <returns>The parsed JSON null value.</returns>
    private JSONNullValue ReadNull()
    {
      StringBuilder builder = new StringBuilder();
      for (int i = 0; i < 4; i++)
      {
        builder.Append(CurrentChar);
        _currentPos++;
      }

      string str = builder.ToString();
      if (str.ToLower() != "null")
        GeneralError("Unknown value \"" + str + "\"!");

      //_currentPos += 4;

      if (EOF)
        EndOfFileError();

      return new JSONNullValue();
    }

    /// <summary>
    /// Reads a number value.
    /// </summary>
    /// <returns>The parsed JSON number value.</returns>
    private JSONNumberValue ReadNumber()
    {
      StringBuilder builder = new StringBuilder();
      while (_numberChars.Contains(CurrentChar) && !EOF)
      {
        builder.Append(CurrentChar);
        _currentPos++;        
      }

      string str = builder.ToString().Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

      if (str == null || str.Length == 0)
        GeneralError("Empty number value!");

      double value = 0.0;
      if (!double.TryParse(str, out value))
        GeneralError("Invalid numer valid!");

      return new JSONNumberValue(value);
    }

    /// <summary>
    /// Reads a string value.
    /// </summary>
    /// <returns>The parsed JSON string value.</returns>
    private JSONStringValue ReadStringValue()
    {
      string value = ReadString();

      //TODO: read escape sequences

      if (value == null)
        value = "";

      return new JSONStringValue(value);
    }

  }
}
