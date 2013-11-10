using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine.Resources
{
  public class Resource
  {
    private string _name = null;

    public Resource(string name)
    {
      if (name == null)
        throw new OkuException();

      _name = name.Trim().ToLower();
    }

    public string Name
    {
      get { return _name; }
    }

  }
}
