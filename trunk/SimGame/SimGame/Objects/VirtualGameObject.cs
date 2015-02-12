using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame.Objects
{
  public class VirtualGameObject : GameObjectBase
  {
    private SimGameMain _main = null;

    public VirtualGameObject(SimGameMain main)
    {
      _main = main;
    }

    public override void TriggerAction(GameObject obj, string actionId, object[] parameters)
    {
      if (actionId == "setstate")
      {
        _main.SetCurrentState(parameters[0] as string);
      }
    }
  }
}
