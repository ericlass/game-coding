using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike
{
  public class SceneFactory
  {
    private static SceneFactory _instance = null;

    public static SceneFactory Instance
    {
      get 
      {
        if (_instance == null)
          _instance = new SceneFactory();
        return _instance;
      }
    }

    private SceneFactory()
    {
    }

    private RenderComponent RenderComponentFromFile(string filename)
    {
      ImageData data = ImageData.FromFile(filename);
      Image img = OkuManager.Instance.Graphics.NewImage(data);
      RenderComponent result = new RenderComponent();
      result.Mesh = Mesh.ForImage(img, Color.White);
      return result;
    }

    public Scene GetHardCodedExampleScene()
    {
      Scene result = new Scene("example");

      Entity ent = new Entity("player");

      TransformComponent trans = new TransformComponent();
      ent.AddComponent(trans);

      State state = new State("idle");
      ent.StateMachine.States.Add(state);
      state = new State("up_attack");
      ent.StateMachine.States.Add(state);
      state = new State("down_attack");
      ent.StateMachine.States.Add(state);
      state = new State("left_attack");
      ent.StateMachine.States.Add(state);
      state = new State("right_attack");
      ent.StateMachine.States.Add(state);
      
      ent.AddStateComponent("idle", RenderComponentFromFile("./Content/Graphics/player_idle.png"));
      ent.AddStateComponent("up_attack", RenderComponentFromFile("./Content/Graphics/player_up_attack.png"));
      ent.AddStateComponent("down_attack", RenderComponentFromFile("./Content/Graphics/player_down_attack.png"));
      ent.AddStateComponent("left_attack", RenderComponentFromFile("./Content/Graphics/player_left_attack.png"));
      ent.AddStateComponent("right_attack", RenderComponentFromFile("./Content/Graphics/player_right_attack.png"));
      ent.StateMachine.CurrentStateId = "idle";

      result.Entities.Add(ent);

      SimpleMovementController cont = new SimpleMovementController();
      cont.Entities.Add(ent);
      result.Processes.Add(cont);

      return result;
    }

  }
}
