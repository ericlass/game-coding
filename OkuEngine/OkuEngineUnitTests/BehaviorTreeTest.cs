using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OkuEngine.Behavior;

namespace OkuEngineUnitTests
{
  [TestClass]
  public class BehaviorTreeTest
  {
    [TestMethod]
    public void TestBehaviorTreeBasic()
    {
      Sequence seq = new Sequence();
      seq
        .Add(new Delay(1))
        .Add(new LogText("Delay 1 finished"))
        .Add(new Delay(2))
        .Add(new LogText("Delay 2 finished"))
        .Add(new Sequence()
          .Add(new Delay(3))
          .Add(new LogText("Delay 3 finished"))
          .Add(new Delay(4))
          .Add(new LogText("Delay 4 finished")))
        .Add(new LogText("Tree finished"));

      while (seq.Update(0.5f) != BehaviorResult.Success) ;
    }

  }
}
