using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OkuEngine.States;

namespace OkuEngineUnitTests
{
  [TestClass]
  public class StateMachineTest
  {
    [TestMethod]
    public void TestStateMachineBasic()
    {
      //Initialize state machine
      StateMachine sm = new StateMachine();
      sm.States.Add("init");
      sm.States.Add("s1");
      sm.States.Add("s2");

      sm.Transitions.Add(new Transition("init", "s1", 1, bb => bb["v1"] != null));
      sm.Transitions.Add(new Transition("s1", "s2", 1, bb => bb["v2"] != null));
      sm.Transitions.Add(new Transition("s2", "init", 1, bb => bb["v3"] != null));

      sm.InitialState = "init";

      //Run verification
      Assert.IsTrue(sm.Verify());

      //Test first transition
      sm.Update();
      Assert.AreEqual("init", sm.CurrentState);

      sm.Blackboard["v1"] = "a";
      sm.Update();
      Assert.AreEqual("s1", sm.CurrentState);

      sm.Update();
      Assert.AreEqual("s1", sm.CurrentState);

      //Test second transition
      sm.Blackboard["v2"] = "b";
      sm.Update();
      Assert.AreEqual("s2", sm.CurrentState);

      sm.Update();
      Assert.AreEqual("s2", sm.CurrentState);

      //Test third transition
      sm.Blackboard["v3"] = "c";
      sm.Update();
      Assert.AreEqual("init", sm.CurrentState);

      //Cycle through states once more
      sm.Update();
      Assert.AreEqual("s1", sm.CurrentState);
      sm.Update();
      Assert.AreEqual("s2", sm.CurrentState);
      sm.Update();
      Assert.AreEqual("init", sm.CurrentState);
    }

  }
}
