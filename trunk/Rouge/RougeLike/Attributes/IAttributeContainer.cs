using System;
using System.Collections.Generic;

namespace RougeLike.Attributes
{
  public interface IAttributeContainer
  {
    List<string> GetAttributeNames();
    bool ContainsAttribute(string attribute);
    IAttributeValue GetAttributeValue(string attribute);
    T GetAttributeValue<T>(string attribute) where T : class, IAttributeValue;
    bool SetAttributeValue(string attribute, IAttributeValue value);
  }
}
