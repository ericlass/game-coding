using System;
using System.Collections.Generic;

namespace OkuEngine.Input
{
  public class InputAxisMapping
  {
    private string _name = null;
    private List<IInputAxis> _axes = new List<IInputAxis>();

    public InputAxisMapping(string name)
    {
      _name = name;
    }

    public string Name
    {
      get { return _name; }
    }

    public List<IInputAxis> Axes
    {
      get { return _axes; }
    }

  }
}
