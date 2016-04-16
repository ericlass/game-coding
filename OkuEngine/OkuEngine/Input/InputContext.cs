using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Input;

namespace OkuEngine.Input
{
  public class InputContext
  {
    private List<InputActionMapping> _actionMappings = new List<InputActionMapping>();
    private List<InputAxisMapping> _axisMappings = new List<InputAxisMapping>();

    //TODO: State Mappings

    public InputContext()
    {      
    }

    public List<InputActionMapping> ActionMappings
    {
      get { return _actionMappings; }
    }

    public List<InputAxisMapping> AxisMappings
    {
      get { return _axisMappings; }
    }

  }
}
