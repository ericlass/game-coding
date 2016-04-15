using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Input;

namespace OkuEngine.Input
{
  public class InputContext
  {
    private List<InputActionMapping> _actionMappings = new List<InputActionMapping>();

    //TODO: State Mappings
    //TODO: Axis Mappings

    public InputContext()
    {      
    }

    public List<InputActionMapping> ActionMappings
    {
      get { return _actionMappings; }
    }

  }
}
