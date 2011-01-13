using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OkuEngine;

namespace OkuTest
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      OkuGame game = new OkuGame();

      //OkuData.Scene.Game.ActionHandler.OnAction = new ActionHandleDelegate(SimpleTransformAction);
      //OkuData.Scene.Game.ActionHandler.OnAction = new ActionHandleDelegate(RotationAction);
      OkuData.Scene.Game.ActionHandler.OnAction = new ActionHandleDelegate(ParticleGameAction);

      game.Run();
    }

    public static void SimpleTransformAction(SceneNode node, ActionType type)
    {
      switch (type)
      {
        case ActionType.Init:
          Content image = OkuData.Content.Get("car.png", ContentType.Image);
          SceneNode testNode = OkuData.Scene.Add(OkuData.Scene.World, image);
          testNode.Transform.Translation = new Vector(50, 50);
          testNode.ActionHandler.OnAction = new ActionHandleDelegate(SimpleTransformNodeAction);
          break;

        case ActionType.Update:
          
          break;

        case ActionType.Finish:
          break;

        default:
          break;
      }
    }

    #region Simple Transform Test

    public static void SimpleTransformNodeAction(SceneNode node, ActionType type)
    {
      if (type == ActionType.Update)
      {
        float dt = OkuData.Globals.Get<float>("oku.timedelta");
        float speed = 250 * dt;
        float angVel = 90 * dt;
        float scaleVel = 0.5f * dt;

        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Right))
          node.Transform.Translation.X += speed;
        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Left))
          node.Transform.Translation.X -= speed;
        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Up))
          node.Transform.Translation.Y -= speed;
        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Down))
          node.Transform.Translation.Y += speed;

        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad6))
          node.Transform.Rotation -= angVel;
        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad4))
          node.Transform.Rotation += angVel;

        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad8))
        {
          node.Transform.Scale.X += scaleVel;
          node.Transform.Scale.Y += scaleVel;
        }
        if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad2))
        {
          node.Transform.Scale.X -= scaleVel;
          node.Transform.Scale.Y -= scaleVel;
        }
      }
    }

    #endregion

    #region Hierachical Rotation Test

    public static void RotationAction(SceneNode node, ActionType type)
    {
      switch (type)
      {
        case ActionType.Init:
          Content image = OkuData.Content.Get("earth.png", ContentType.Image);

          SceneNode test1 = OkuData.Scene.Add(OkuData.Scene.World, image);
          test1.Transform.Translation = new Vector(400, 300);
          test1.ActionHandler.OnAction = new ActionHandleDelegate(NodeRotationAction);
          test1.ActionHandler.Locals.Set<float>("rotation", 45);

          SceneNode test2 = OkuData.Scene.Add(test1, image);
          test2.Transform.Translation = new Vector(100, 0);
          test2.ActionHandler.OnAction = new ActionHandleDelegate(NodeRotationAction);
          test2.ActionHandler.Locals.Set<float>("rotation", -180);

          SceneNode test3 = OkuData.Scene.Add(test2, image);
          test3.Transform.Translation = new Vector(-60, 0);
          test3.ActionHandler.OnAction = new ActionHandleDelegate(NodeRotationAction);
          test3.ActionHandler.Locals.Set<float>("rotation", 0);

          break;
        case ActionType.Update:
          break;
        case ActionType.Finish:
          break;
        default:
          break;
      }
    }

    public static void NodeRotationAction(SceneNode node, ActionType type)
    {
      if (type == ActionType.Update)
      {
        float dt = OkuData.Globals.Get<float>("oku.timedelta");
        float rotation = OkuData.Locals.Get<float>("rotation");
        //System.Diagnostics.Debug.WriteLine(dt.ToString("0.######"));
        node.Transform.Rotation += rotation * dt;
      }
    }

    #endregion

    #region Particle Test

    private static SceneNode _parent = null;

    public static void ParticleGameAction(SceneNode node, ActionType type)
    {
      switch (type)
      {
        case ActionType.Init:
          int numParticles = 5000;
          Random rand = new Random();
          Content image = OkuData.Content.Get("smiley.png", ContentType.Image);
          ActionHandleDelegate action = new ActionHandleDelegate(ParticleNodeAction);

          _parent = OkuData.Scene.Add(OkuData.Scene.World, null);
          _parent.Transform.Translation = new Vector(OkuInterfaces.Renderer.ScreenWidth / 2, OkuInterfaces.Renderer.ScreenHeight / 2);

          for (int i = 0; i < numParticles; i++)
          {
            float rotation = (float)((rand.NextDouble() * 2) - 1) * 360;
            float scale = (float)rand.NextDouble() * 0.6f + 0.7f;
            Vector velocity = new Vector((float)((rand.NextDouble() * 2) - 1) * 200, (float)((rand.NextDouble() * 2) - 1) * 200);

            SceneNode particle = OkuData.Scene.Add(_parent, image);
            particle.ActionHandler.Locals.Set<float>("rotation", rotation);
            particle.ActionHandler.Locals.Set<Vector>("velocity", velocity);
            particle.Transform.Scale = new Vector(scale, scale);
            particle.ActionHandler.OnAction = action;
          }
          break;

        case ActionType.Update:
          float dt = OkuData.Globals.Get<float>("oku.timedelta");
          float speed = 250 * dt;
          float angVel = 90 * dt;
          float scaleVel = 0.5f * dt;

          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Right))
            _parent.Transform.Translation.X += speed;
          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Left))
            _parent.Transform.Translation.X -= speed;
          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Up))
            _parent.Transform.Translation.Y -= speed;
          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.Down))
            _parent.Transform.Translation.Y += speed;

          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad6))
            _parent.Transform.Rotation -= angVel;
          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad4))
            _parent.Transform.Rotation += angVel;

          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad8))
          {
            _parent.Transform.Scale.X += scaleVel;
            _parent.Transform.Scale.Y += scaleVel;
          }
          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad2))
          {
            _parent.Transform.Scale.X -= scaleVel;
            _parent.Transform.Scale.Y -= scaleVel;
          }

          if (OkuInterfaces.Input.Keyboard.ButtonIsDown(Keys.NumPad0))
          {
            _parent.Transform.Translation = new Vector(OkuInterfaces.Renderer.ScreenWidth / 2, OkuInterfaces.Renderer.ScreenHeight / 2);
            _parent.Transform.Rotation = 0;
            _parent.Transform.Scale.X = 1;
            _parent.Transform.Scale.Y = 1;
          }

          break;

        default:
          break;
      }
    }

    public static void ParticleNodeAction(SceneNode node, ActionType type)
    {
      float dt = OkuData.Globals.Get<float>("oku.timedelta");
      float rotation = OkuData.Locals.Get<float>("rotation");
      Vector velocity = OkuData.Locals.Get<Vector>("velocity");

      node.Transform.Rotation += rotation * dt;
      node.Transform.Translation += new Vector(velocity.X * dt, velocity.Y * dt);

      int size = 300;
      int nsize = -size;

      if (node.Transform.Translation.X >= size)
      {
        node.Transform.Translation.X = size - (node.Transform.Translation.X - size);
        velocity.X *= -1;
      }

      if (node.Transform.Translation.X <= nsize)
      {
        node.Transform.Translation.X = nsize - (node.Transform.Translation.X - nsize);
        velocity.X *= -1;
      }

      if (node.Transform.Translation.Y >= size)
      {
        node.Transform.Translation.Y = size - (node.Transform.Translation.Y - size);
        velocity.Y *= -1;
      }

      if (node.Transform.Translation.Y <= nsize)
      {
        node.Transform.Translation.Y = nsize - (node.Transform.Translation.Y - nsize);
        velocity.Y *= -1;
      }

      OkuData.Locals.Set<Vector>("velocity", velocity);
    }

    #endregion

  }
}
