using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public SceneList GetHardCodedScene()
    {
      SceneList result = new SceneList();

      PlayerGameObject player = new PlayerGameObject();

      SquareObject square = new SquareObject();

      Scene scene = new Scene();
      scene.Name = "Test";

      scene.GameObjects.Add(player);
      scene.GameObjects.Add(square);

      result.Add(scene);
      return result;
    }

  }
}
