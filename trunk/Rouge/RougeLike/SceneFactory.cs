using System;
using System.Collections.Generic;
using System.IO;
using OkuBase;
using OkuBase.Geometry;
using OkuBase.Graphics;

namespace RougeLike
{
  /// <summary>
  /// Handles the creation of scenes.
  /// </summary>
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

    private RenderComponent RenderComponentFromFile(string path, string filename)
    {
      Animation anim = new Animation();
      anim.Loop = true;
      anim.FrameTime = 120;

      List<string> files = new List<string>(Directory.EnumerateFiles(path, filename + "*"));
      files.Sort();
      
      foreach (string file in files)
      {
        ImageData data = ImageData.FromFile(file);
        Image img = OkuManager.Instance.Graphics.NewImage(data);
        anim.Frames.Add(img);
      }

      RenderComponent result = new RenderComponent();
      result.Animation = anim;
      return result;
    }

    /// <summary>
    /// Creates a hard coded example scene. This is only for testing purposes.
    /// </summary>
    /// <returns>A hard coded testing scene.</returns>
    public Scene GetHardCodedExampleScene()
    {
      Scene result = new Scene("example");

      //Add player
      Entity ent = new Entity("player");

      TransformComponent trans = new TransformComponent();
      ent.AddComponent(trans);

      ent.StateMachine.States.Add(new State("up_idle"));
      ent.StateMachine.States.Add(new State("down_idle"));
      ent.StateMachine.States.Add(new State("left_idle"));
      ent.StateMachine.States.Add(new State("right_idle"));

      ent.StateMachine.States.Add(new State("up_move"));
      ent.StateMachine.States.Add(new State("down_move"));
      ent.StateMachine.States.Add(new State("left_move"));
      ent.StateMachine.States.Add(new State("right_move"));

      ent.StateMachine.States.Add(new State("up_attack"));
      ent.StateMachine.States.Add(new State("down_attack"));
      ent.StateMachine.States.Add(new State("left_attack"));
      ent.StateMachine.States.Add(new State("right_attack"));
      
      ent.AddStateComponent("up_idle", RenderComponentFromFile("./Content/Graphics", "player_up_idle"));
      ent.AddStateComponent("down_idle", RenderComponentFromFile("./Content/Graphics", "player_down_idle"));
      ent.AddStateComponent("left_idle", RenderComponentFromFile("./Content/Graphics", "player_left_idle"));
      ent.AddStateComponent("right_idle", RenderComponentFromFile("./Content/Graphics", "player_right_idle"));

      ent.AddStateComponent("up_move", RenderComponentFromFile("./Content/Graphics", "player_up_move"));
      ent.AddStateComponent("down_move", RenderComponentFromFile("./Content/Graphics", "player_down_move"));
      ent.AddStateComponent("left_move", RenderComponentFromFile("./Content/Graphics", "player_left_move"));
      ent.AddStateComponent("right_move", RenderComponentFromFile("./Content/Graphics", "player_right_move"));

      ent.AddStateComponent("up_attack", RenderComponentFromFile("./Content/Graphics", "player_up_attack"));
      ent.AddStateComponent("down_attack", RenderComponentFromFile("./Content/Graphics", "player_down_attack"));
      ent.AddStateComponent("left_attack", RenderComponentFromFile("./Content/Graphics", "player_left_attack"));
      ent.AddStateComponent("right_attack", RenderComponentFromFile("./Content/Graphics", "player_right_attack"));
      
      ent.StateMachine.CurrentStateId = "down_idle";

      result.Entities.Add(ent);

      //Add player controller
      PlayerController cont = new PlayerController();
      cont.Entities.Add(ent);
      result.Processes.Add(cont);

      //SimpleEnemyController enemyCont = new SimpleEnemyController();
      //result.Processes.Add(enemyCont);

      //Add enemies
      /*Random rand = new Random();
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
        //enemyCont.Entities.Add(ent);
      }      */

      return result;
    }

  }
}
