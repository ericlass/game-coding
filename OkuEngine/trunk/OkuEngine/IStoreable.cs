using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine
{
  public interface IStoreable
  {
    bool Load(XmlNode node);
    bool Save(XmlWriter writer);
  }
}
