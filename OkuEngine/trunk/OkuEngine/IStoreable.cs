using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine
{
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public interface IStoreable
  {
    bool AfterLoad();
  }
}
