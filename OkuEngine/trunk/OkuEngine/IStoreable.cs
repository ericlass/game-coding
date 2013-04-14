using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine
{
  public interface IStoreable
  {
    bool AfterLoad();
  }
}
