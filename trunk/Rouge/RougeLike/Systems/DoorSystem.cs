using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RougeLike.Objects;

namespace RougeLike.Systems
{
  public class DoorSystem : IGameSystem
  {
    private int _doorGroup = 0;

    public DoorSystem()
    {
    }

    public DoorSystem(int doorGroup)
    {
      _doorGroup = doorGroup;
    }

    public int DoorGroup
    {
      get { return _doorGroup; }
      set { _doorGroup = value; }
    }

    public void Init()
    {
    }

    public void Update(float dt)
    {
      if (OkuBase.OkuManager.Instance.Input.Keyboard.KeyPressed(Keys.T))
      {
        List<GameObjectBase> objects = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfGroup(_doorGroup);
        foreach (GameObjectBase obj in objects)
        {
          DoorObject door = obj as DoorObject;
          if (door.CurrentState == DoorState.Opened)
            door.Close();
          else if (door.CurrentState == DoorState.Closed)
            door.Open();
        }
      }
    }

    public void Finish()
    {
    }

  }
}
