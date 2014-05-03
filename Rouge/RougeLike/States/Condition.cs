using System;
using System.Collections.Generic;
using System.Text;
using RougeLike.Attributes;

namespace RougeLike.States
{
  /// <summary>
  /// Defines a single attribute condition.
  /// </summary>
  public class Condition
  {
    private Func<IAttributeContainer, bool> _compareValues = null;

    public Condition()
    {
    }

    public Condition(string attribute, string op, IAttributeValue value)
    {
      AttributeName = attribute;
      Operator = op;
      Value = value;
    }

    /// <summary>
    /// Gets or sets the name of the attribute to check.
    /// </summary>
    public string AttributeName { get; set; }

    /// <summary>
    /// Gets or sets the comparison operator. Can be "==", "!=", ">", "&lt;", ">=" or "&lt;=".
    /// </summary>
    public string Operator { get; set; }

    /// <summary>
    /// Gets or sets the target attribute value.
    /// </summary>
    public IAttributeValue Value { get; set; }    

    /// <summary>
    /// Checks if the given attribute container matches the condition.
    /// </summary>
    /// <param name="container">The attribute container to check.</param>
    /// <returns>True if the condition matches, else false.</returns>
    public bool Matches(IAttributeContainer container)
    {
      if (!container.ContainsAttribute(AttributeName))
        throw new OkuBase.OkuException("The given attribute container does not have the attribute '" + AttributeName + "' to check!");

      if (_compareValues == null)
      {
        if (Operator == "==")
          _compareValues = (go) => Value.CompareTo(go.GetAttributeValue(AttributeName)) == 0;
        else if (Operator == "!=")
          _compareValues = (go) => Value.CompareTo(go.GetAttributeValue(AttributeName)) != 0;
        else if (Operator == ">")
          _compareValues = (go) => Value.CompareTo(go.GetAttributeValue(AttributeName)) > 0;
        else if (Operator == "<")
          _compareValues = (go) => Value.CompareTo(go.GetAttributeValue(AttributeName)) < 0;
        else if (Operator == ">=")
          _compareValues = (go) => Value.CompareTo(go.GetAttributeValue(AttributeName)) >= 0;
        else if (Operator == "<=")
          _compareValues = (go) => Value.CompareTo(go.GetAttributeValue(AttributeName)) <= 0;
        else
          throw new OkuBase.OkuException("Unsupported conditional operator '" + Operator + "'!");
      }

      return _compareValues(container);
    }

    /// <summary>
    /// Parses a condition string in the format [attributename][operator][attributetype]"|"[attributevalue].
    /// </summary>
    /// <param name="str">The condition string to parse.</param>
    public void FromString(string str)
    {
      HashSet<char> operatorChars = new HashSet<char>() { '=', '!', '>', '<' };

      StringBuilder builder = new StringBuilder();
      int i = 0;

      //Read attribute name
      char current = str[i];
      while (!operatorChars.Contains(current))
      {
        builder.Append(current);
        i++;
        current = str[i];
      }
      string attribute = builder.ToString();

      //Read operator
      builder.Clear();
      while (operatorChars.Contains(current))
      {
        builder.Append(current);
        i++;
        current = str[i];
      }
      string op = builder.ToString().Trim();

      //Read value
      builder.Clear();
      while (i < str.Length)
      {
        builder.Append(current);
        i++;
        current = str[i];
      }
      string value = builder.ToString().Trim();

      AttributeName = attribute;
      Operator = op;
      Value = AttributeValueFactory.Instance.CreateAttributeValue(value);
    }

    /// <summary>
    /// Returns the condition as a string in the format [attributename][operator][attributetype]"|"[attributevalue].
    /// </summary>
    /// <returns>The condition as a string.</returns>
    public override string ToString()
    {
      return AttributeName + Operator + Value.GetValueForSaving();
    }

  }
}
