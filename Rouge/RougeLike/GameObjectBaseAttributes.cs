using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RougeLike.Attributes;

namespace RougeLike
{
  public abstract partial class GameObjectBase : IAttributeContainer
  {
    private AttributeMap _attributes = new AttributeMap();

    /// <summary>
    /// Can be overriden by implementing classes to publish additional fixed attributes.
    /// Does not have to call base method.
    /// </summary>
    /// <param name="attribute">The name of the attribute.</param>
    /// <returns>The value of the attribute. Null if there is not attribute with the given name.</returns>
    protected virtual IAttributeValue DoGetAttributeValue(string attribute)
    {
      return null;
    }

    /// <summary>
    /// Can be overriden by implementing classes to be able to set published fixed attributes.
    /// Does not have to call base method.
    /// </summary>
    /// <param name="attribute">The name of the attribute.</param>
    /// <param name="value">The new value of the attribute.</param>
    /// <returns>True if the value was set. False if there is no attribute with the given name.</returns>
    protected virtual bool DoSetAttributeValue(string attribute, IAttributeValue value)
    {
      return false;
    }

    /// <summary>
    /// Can be overriden by implementing classes. Should return the names of all additional available attributes.
    /// Does not have to call base method.
    /// </summary>
    /// <returns>A list of attribute names.</returns>
    protected virtual List<string> DoGetAllAttributes()
    {
      return new List<string>();
    }

    /// <summary>
    /// Gets the fixed attribute values of the game object base.
    /// </summary>
    /// <param name="attribute">The name if the attribute.</param>
    /// <returns>The value of the fixed attribute, null if there is not fixed attribute with the given name.</returns>
    private IAttributeValue GetFixedAttributeValue(string attribute)
    {
      if (attribute == "id")
        return new TextValue(Id);
      else if (attribute == "zindex")
        return new NumberValue(ZIndex);
      else if (attribute == "groupindex")
        return new NumberValue(GroupIndex);
      else if (attribute == "x")
        return new NumberValue(Position.X);
      else if (attribute == "y")
        return new NumberValue(Position.Y);
      else if (attribute == "type")
        return new TextValue(ObjectType);
      else
        return null;
    }

    /// <summary>
    /// Sets the fixed attribute with the given name to the given value.
    /// </summary>
    /// <param name="attribute">The name of the attribute.</param>
    /// <param name="value">The new value of the attribute.</param>
    /// <returns>True if the value was set. False if there is no fixed attribute with the give name.</returns>
    private bool SetFixedAttributeValue(string attribute, IAttributeValue value)
    {
      if (attribute == "id")
      {
        Id = (value as TextValue).Value;
        return true;
      }
      else if (attribute == "zindex")
      {
        ZIndex = (int)((value as NumberValue).Value);
        return true;
      }
      else if (attribute == "groupindex")
      {
        GroupIndex = (int)((value as NumberValue).Value);
        return true;
      }
      else if (attribute == "x")
      {
        _positions.X = (int)((value as NumberValue).Value);
        return true;
      }
      else if (attribute == "y")
      {
        _positions.Y = (int)((value as NumberValue).Value);
        return true;
      }
      else if (attribute == "type")
      {
        //Object type is read only
        return true;
      }

      return false;
    }

    /// <summary>
    /// Gets a list of the names of all attributes of the object.
    /// </summary>
    /// <returns>A list of all attribute names.</returns>
    public List<string> GetAttributeNames()
    {
      //Fixes attributes
      List<string> result = new List<string>() { "id", "zindex", "groupindex", "x", "y" };

      //Fixed attributes of impleneting class
      result.AddRange(DoGetAllAttributes());
      //Dynamic attributes
      result.AddRange(_attributes.Keys);

      return result;
    }

    /// <summary>
    /// Checks if the object contains an attribute with the given name.
    /// </summary>
    /// <param name="attribute">The name of the attribute.</param>
    /// <returns>True if the object contains the attribute, else false.</returns>
    public bool ContainsAttribute(string attribute)
    {
      return GetAttributeNames().Contains(attribute);
    }

    /// <summary>
    /// Gets the value of the attribute with the given name.
    /// </summary>
    /// <param name="attribute">The name of the attribute.</param>
    /// <returns>The value of the attribute. Null if there is no attribute with the given name.</returns>
    public IAttributeValue GetAttributeValue(string attribute)
    {
      //First, check for fixed attributes
      IAttributeValue result = GetFixedAttributeValue(attribute);
      if (result != null)
        return result;

      //Then, check attributes of implementing class.
      result = DoGetAttributeValue(attribute);
      if (result != null)
        return result;

      //Finally, check dynamic attributes
      if (_attributes.ContainsKey(attribute))
        return _attributes[attribute];

      return null;
    }

    /// <summary>
    /// Gets the value of the attribute with given name as the given type.
    /// </summary>
    /// <typeparam name="T">The type of the attribute.</typeparam>
    /// <param name="attribute">The name of the attribute.</param>
    /// <returns>The value of the attribute. Null if there is no attribute with the given name.</returns>
    public T GetAttributeValue<T>(string attribute) where T : class, IAttributeValue
    {
      return GetAttributeValue(attribute) as T;
    }

    /// <summary>
    /// Set the attribute with the given name to the given value.
    /// </summary>
    /// <param name="attribute">The name of the attribute. Case sensitive!</param>
    /// <param name="value">The new value of the attribute. Passing null removes the attribute.</param>
    /// <returns>True if the attribute was added, false if it only was updated.</returns>
    public bool SetAttributeValue(string attribute, IAttributeValue value)
    {
      //First, set fixed attributes
      if (SetFixedAttributeValue(attribute, value))
        return false;

      //Then, set attributes of implementing class
      if (DoSetAttributeValue(attribute, value))
        return false;

      //Finally, set dynamic attributes
      if (_attributes.ContainsKey(attribute))
      {
        if (value == null)
          _attributes.Remove(attribute);
        else
          _attributes[attribute] = value;

        return false;
      }
      else
      {
        _attributes.Add(attribute, value);
        return true;
      }
    }

    /// <summary>
    /// Extract dynamic attribute values from the given data set.
    /// </summary>
    /// <param name="data">The data set.</param>
    private void ExtractDynamicAttributes(StringPairMap data)
    {
      //This works because at this point (loading data) there are no dynamic attributes yet. At least in theory.
      HashSet<string> nameSet = new HashSet<string>(GetAttributeNames());

      foreach (KeyValuePair<string, string> value in data)
      {
        if (!nameSet.Contains(value.Key))
          _attributes.Add(value.Key, AttributeValueFactory.Instance.CreateAttributeValue(value.Value));
      }
    }

    /// <summary>
    /// Add the dynamic attributes to the given data set.
    /// </summary>
    /// <param name="data">The data set.</param>
    private void AddDynamicAttributes(StringPairMap data)
    {
      foreach (var value in _attributes)
        data.Add(value.Key, value.Value.GetValueForSaving());
    }

  }
}
