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

    public Scene GetHardCodedExampleScene()
    {
      Scene result = new Scene("example");

      Entity ent = new Entity("ent01");

      TransformComponent trans = new TransformComponent();
      ent.AddComponent(trans);

      ImageData data = ImageData.FromFile("./Content/Graphics/square.png");
      Image img = OkuManager.Instance.Graphics.NewImage(data);
      RenderComponent render = new RenderComponent();
      render.Mesh = Mesh.ForImage(img, Color.Blue);
      ent.AddComponent(render);

      result.Entities.Add(ent);

      SimpleMovementController cont = new SimpleMovementController();
      cont.Entities.Add(ent);
      result.Processes.Add(cont);

      return result;
    }

  }
}
