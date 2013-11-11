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

      //Add player
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

      //Add player controllers
      PlayerController cont = new PlayerController();
      cont.Entities.Add(ent);
      result.Processes.Add(cont);

      EnemyController enemyCont = new EnemyController();
      result.Processes.Add(enemyCont);

      //Add enemies
      Random rand = new Random();
      for (int i = 0; i < 5; i++)
      {
        ent = new Entity("enemy" + i);

        trans = new TransformComponent();
        trans.Translation = new Vector2f(rand.RandomFloat() * 310, rand.RandomFloat() * 170);
        ent.AddComponent(trans);

        state = new State("idle");
        ent.StateMachine.States.Add(state);
        state = new State("up_attack");
        ent.StateMachine.States.Add(state);
        state = new State("down_attack");
        ent.StateMachine.States.Add(state);
        state = new State("left_attack");
        ent.StateMachine.States.Add(state);
        state = new State("right_attack");
        ent.StateMachine.States.Add(state);

        ent.AddStateComponent("idle", RenderComponentFromFile("./Content/Graphics/enemy_idle.png"));
        ent.AddStateComponent("up_attack", RenderComponentFromFile("./Content/Graphics/enemy_up_attack.png"));
        ent.AddStateComponent("down_attack", RenderComponentFromFile("./Content/Graphics/enemy_down_attack.png"));
        ent.AddStateComponent("left_attack", RenderComponentFromFile("./Content/Graphics/enemy_left_attack.png"));
        ent.AddStateComponent("right_attack", RenderComponentFromFile("./Content/Graphics/enemy_right_attack.png"));
        ent.StateMachine.CurrentStateId = "idle";

        result.Entities.Add(ent);
        enemyCont.Entities.Add(ent);
      }      

      return result;
    }

  }
}
