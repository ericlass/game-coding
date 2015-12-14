using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  public class Failer : Decorator
  {
    public override BehaviorResult Decorate(BehaviorResult result)
    {
      return BehaviorResult.Fail;
    }
  }
}
