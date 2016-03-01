using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Behavior
{
  /// <summary>
  /// Decorator that always fails, no matter if the child failed or succeeded.
  /// </summary>
  public class Failer : Decorator
  {
    public override BehaviorResult Decorate(BehaviorResult result)
    {
      return BehaviorResult.Fail;
    }
  }
}
