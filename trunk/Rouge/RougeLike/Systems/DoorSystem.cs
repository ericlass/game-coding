using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Geometry;
using OkuBase.Graphics;
using RougeLike.Character;
using RougeLike.Objects;

namespace RougeLike.Systems
{
  public class DoorSystem : IGameSystem
  {
    private int _doorGroup = 0;
    private string _playerId = null;

    public DoorSystem()
    {
    }

    public DoorSystem(int doorGroup, string playerId)
    {
      _doorGroup = doorGroup;
      _playerId = playerId;
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
      CharacterObject player = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_playerId) as CharacterObject;

      List<GameObjectBase> objects = GameData.Instance.ActiveScene.GameObjects.GetObjectsOfGroup(_doorGroup);

      if (objects != null)
      {
        float minDist = float.MaxValue;
        DoorObject minDoor = null;
        foreach (GameObjectBase obj in objects)
        {
          DoorObject door = obj as DoorObject;
          door.RenderDescription.Tint = Color.White;

          float distance = (player.Position - door.Position).Magnitude;
          if (distance < 40 && distance < minDist)
          {
            minDist = distance;
            minDoor = door;
          }
        }

        if (minDoor != null)
        {
          minDoor.RenderDescription.Tint = Color.Yellow;

          if (OkuBase.OkuManager.Instance.Input.Keyboard.KeyPressed(Keys.E))
          {
            if (minDoor.CurrentState == DoorState.Closed)
              minDoor.Open();
            else if (minDoor.CurrentState == DoorState.Opened)
              minDoor.Close();
          }
        }
      }
    }

    public void Finish()
    {
    }

  }
}
