using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Collections;

namespace OkuEngine.Attributes
{
  /// <summary>
  /// Defines an inheriting dictionary of attribute names to attribute values.
  /// </summary>
  public class AttributeMap : InheritingDictionary<string, AttributeValue>, IStoreable
  {
    /// <summary>
    /// Adds the given attribute value to the map.
    /// </summary>
    /// <param name="value">The value to be added.</param>
    /// <returns>True fi the value was added, false if there already is a value with the same name.</returns>
    public bool Add(AttributeValue value)
    {
      if (!ContainsKey(value.Name.ToLower()))
      {
        Add(value.Name.ToLower(), value);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Adds all values of the given attribte map to the map.
    /// The overwrite parameter determines if existing values are
    /// overwritten.
    /// </summary>
    /// <param name="other">The map to read values from.</param>
    /// <param name="overwrite">determines if existing values are overwritten or not.</param>
    public void AddAll(AttributeMap other, bool overwrite)
    {
      if (other != this)
      {
        foreach (AttributeValue value in other.Values)
        {
          if (!Add(value) && overwrite)
            this[value.Name.ToLower()] = value;
        }
      }
    }

    /// <summary>
    /// Creates a copy of the attribute map and all
    /// contained attributes.
    /// </summary>
    /// <returns>A copy of the attribute map.</returns>
    public AttributeMap Copy()
    {
      AttributeMap result = new AttributeMap();
      foreach (KeyValuePair<string, AttributeValue> attribute in this)
      {
        result.Add(attribute.Value.Copy());
      }
      return result;
    }

    public bool AfterLoad()
    {
      foreach (AttributeValue value in this.Values)
      {
        if (!value.AfterLoad())
          return false;
      }
      return true;
    }

  }
}
