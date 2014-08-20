using System;
using System.Collections.Generic;
using OkuBase.Graphics;

namespace RougeLike.Objects
{
  public enum DoorState
  {
    Closed,
    Opened,
    Closing,
    Opening
  }

  public class DoorObject : GameObjectBase
  {
    private string _openAnimName = null;
    private string _closeAnimName = null;
    private string _openImageName = null;
    private string _closedImageName = null;
    private Vector2i _baseTile = new Vector2i();

    private Animation _openAnim = null;
    private Animation _closeAnim = null;
    private Image _openImage = null;
    private Image _closedImage = null;
    private DoorState _state = DoorState.Closed;
    private Animation _currentAnim = null;

    public string OpenAnimationName
    {
      get { return _openAnimName; }
      set { _openAnimName = value; }
    }

    public string CloseAnimationName
    {
      get { return _closeAnimName; }
      set { _closeAnimName = value; }
    }

    public string OpenedImageName
    {
      get { return _openImageName; }
      set { _openImageName = value; }
    }

    public string ClosedImageName
    {
      get { return _closedImageName; }
      set { _closedImageName = value; }
    }

    public Vector2i BaseTile
    {
      get { return _baseTile; }
      set { _baseTile = value; }
    }

    public DoorState CurrentState
    {
      get { return _state; }
      set { _state = value; }
    }

    public void Open()
    {
      _currentAnim = _openAnim;
      _currentAnim.Restart();
      _state = DoorState.Opening;

      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      for (int i = 0; i < 3; i++)
      {
        tilemap.TileData.Tiles[_baseTile.X, _baseTile.Y + i].TileType = Tiles.TileType.Empty;
      }
    }

    public void Close()
    {
      _currentAnim = _closeAnim;
      _currentAnim.Restart();
      _state = DoorState.Closing;

      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;
      for (int i = 0; i < 3; i++)
      {
        tilemap.TileData.Tiles[_baseTile.X, _baseTile.Y + i].TileType = Tiles.TileType.Filled;
      }
    }

    public override string ObjectType
    {
      get { return "door"; }
    }

    public override void Init()
    {
      _openAnim = GameData.Instance.ActiveScene.Content.GetAnimation(_openAnimName);
      _closeAnim = GameData.Instance.ActiveScene.Content.GetAnimation(_closeAnimName);

      _openImage = GameData.Instance.ActiveScene.Content.GetImage(_openImageName);
      _closedImage = GameData.Instance.ActiveScene.Content.GetImage(_closedImageName);

      RenderDescription.Image = _closedImage;
    }

    public override void Update(float dt)
    {
      switch (_state)
      {
        case DoorState.Closing:
          _currentAnim.Update(dt);
          RenderDescription.Image = _currentAnim.CurrentFrame;
          if (_currentAnim.Finished)
          {
            _currentAnim = null;
            _state = DoorState.Closed;
            RenderDescription.Image = _closedImage;
          }            
          break;

        case DoorState.Opening:
          _currentAnim.Update(dt);
          RenderDescription.Image = _currentAnim.CurrentFrame;
          if (_currentAnim.Finished)
          {
            _currentAnim = null;
            _state = DoorState.Opened;
            RenderDescription.Image = _openImage;
          }
          break;

        default:
          break;
      }
    }

    public override void Finish()
    {
    }

    protected override StringPairMap DoSave()
    {
      return null;
    }

    protected override void DoLoad(StringPairMap data)
    {
    }

  }
}
