using System;
using System.Collections.Generic;
using System.Reflection;

namespace RougeLike.Attributes
{
  public class AttributeValueFactory
  {
    private static AttributeValueFactory _instance = null;

    public static AttributeValueFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new AttributeValueFactory();

        return _instance;
      }
    }

    private Dictionary<string, Func<IAttributeValue>> _constructors = new Dictionary<string, Func<IAttributeValue>>();

    private AttributeValueFactory()
    {
      //Load all type that implement IAttributeValue and create constructor delegates for them
      List<Type> valueTypes = GameUtil.GetTypesImplementingInterface(typeof(IAttributeValue), this.GetType().Assembly);

      foreach (Type vt in valueTypes)
      {
        IAttributeValue value = this.GetType().Assembly.CreateInstance(vt.FullName) as IAttributeValue;
        RegisterAttributeValueType(value.TypeName, () => vt.Assembly.CreateInstance(vt.FullName) as IAttributeValue);
      }
    }

    public void RegisterAttributeValueType(string typeName, Func<IAttributeValue> constructor)
    {
      _constructors.Add(typeName, constructor);
    }

    public IAttributeValue CreateAttributeValue(string str)
    {
      int index = str.IndexOf('|');

      if (index < 0)
        throw new OkuBase.OkuException("The type-value separator '|' was not found in the string '" + str + "'! Maybe it is not an attribute value string.");

      string type = str.Substring(0, index);
      if (!_constructors.ContainsKey(type))
        throw new OkuBase.OkuException("Unsupported attribute value type '" + type + "'!");

      string value = str.Substring(index + 1);
      IAttributeValue result = _constructors[type]();
      result.SetValueFromString(value);

      return result;
    }

  }
}
