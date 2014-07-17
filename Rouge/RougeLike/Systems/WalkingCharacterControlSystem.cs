using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase;
using OkuBase.Geometry;
using RougeLike.Attributes;
using RougeLike.Objects;
using RougeLike.Character;
using RougeLike.Tiles;
using RougeLike.Controller;

namespace RougeLike.Systems
{
  public class WalkingCharacterControlSystem : IGameSystem
  {
    private string _playerId = null; //ID of player object
    private ICharacterController _controller = null;

    private CharacterObject _playerObject = null;
    private float _fallSpeed = 0;
    private float _freezeTime = 0;
    private Vector2f _speed = Vector2f.Zero;
    private float _direction = 1;

    private float _maxWalkSpeed = 300;

    public WalkingCharacterControlSystem(string playerId, ICharacterController controller)
    {
      _playerId = playerId;
      _controller = controller;
    }

    public float MaxWalkSpeed
    {
      get { return _maxWalkSpeed; }
      set { _maxWalkSpeed = value; }
    }

    public string PlayerId
    {
      get { return _playerId; }
      set { _playerId = value; }
    }

    public void Init()
    {
      _playerObject = GameData.Instance.ActiveScene.GameObjects.GetObjectById(_playerId) as CharacterObject;
      _playerObject.OnStateChange += player_OnStateChange;
    }

    private void player_OnStateChange(CharacterState oldState, CharacterState newState)
    {
      System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff") + " - '" + _playerId + "' state change: '" + oldState + "' -> '" + newState + "'");

      switch (newState)
      {
        case CharacterState.Idle:
          break;

        case CharacterState.Walking:
          break;

        case CharacterState.Jumping:
          _fallSpeed = 800;
          break;

        case CharacterState.Falling:
          _fallSpeed = 0;
          break;

        case CharacterState.Frozen:
          _freezeTime = 2000;
          break;

        default:
          break;
      }
    }

    public void Update(float dt)
    {
      switch (_playerObject.CurrentState)
      {
        case CharacterState.Idle:
          HandleIdle(dt);
          break;

        case CharacterState.Walking:
          HandleWalking(dt);
          break;
        
        case CharacterState.Jumping:
          HandleJumping(dt);
          break;

        case CharacterState.Falling:
          HandleFalling(dt);
          break;

        case CharacterState.Frozen:
          HandleFrozen(dt);
          break;

        default:
          break;
      }

      Vector2f scale = _playerObject.Scale;
      scale.X = _direction;
      _playerObject.Scale = scale;
    }

    public void Finish()
    {
      _playerObject = null;
    }

    /// <summary>
    /// Handles the idle state.
    /// </summary>
    /// <param name="dt">The time past since the last frame.</param>
    private void HandleIdle(float dt)
    {
      Rectangle2f hitbox = _playerObject.HitBox;
      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      Vector2f pos = _playerObject.Position;
      Rectangle2f thb = new Rectangle2f(hitbox.Min + pos, hitbox.Max + pos);
      TileType type1 = tileMap.GetTileBelow(new Vector2f(thb.Min.X, thb.Min.Y + 0.001f));
      TileType type2 = tileMap.GetTileBelow(new Vector2f(thb.Max.X, thb.Min.Y + 0.001f));

      if (type1 == TileType.Empty && type2 == TileType.Empty)
      {
        _playerObject.CurrentState = CharacterState.Falling;
        return;
      }

      if (_controller.DoMoveLeft(_playerObject) || _controller.DoMoveRight(_playerObject))
      {
        _playerObject.CurrentState = CharacterState.Walking;
        return;
      }

      if (_controller.DoJump(_playerObject))
      {
        _playerObject.CurrentState = CharacterState.Jumping;
        return;
      }
    }

    /// <summary>
    /// Handles the walking state.
    /// </summary>
    /// <param name="dt">The time past since the last frame.</param>
    private void HandleWalking(float dt)
    {
      if (_controller.DoJump(_playerObject))
      {
        _playerObject.CurrentState = CharacterState.Jumping;
        return;
      }

      float accel = 1500;

      float speed = _speed.X;

      bool leftDown = _controller.DoMoveLeft(_playerObject);
      bool rightDown = _controller.DoMoveRight(_playerObject);

      if (rightDown)
      {
        speed = Math.Min(speed + ((accel * dt)), MaxWalkSpeed);
        _direction = 1;
      }

      if (leftDown)
      {
        speed = Math.Max(speed - ((accel * dt)), -MaxWalkSpeed);
        _direction = -1;
      }

      if (!leftDown && !rightDown)
      {
        speed -= (1000 * dt) * Math.Sign(speed);
        if (speed > -10 && speed < 10)
          speed = 0;
      }

      _speed.X = speed;

      if (Math.Abs(speed) < 0.1f)
      {
        _playerObject.CurrentState = CharacterState.Idle;
        return;
      }

      Rectangle2f hitbox = _playerObject.HitBox;
      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      Vector2f pos = _playerObject.Position;
      Vector2f dv = new Vector2f(speed * dt, 0);

      float bottom = pos.Y + hitbox.Min.Y;
      Vector2f bottomCenter = new Vector2f(pos.X, bottom);

      Rectangle2f thb = new Rectangle2f(hitbox.Min + pos, hitbox.Max + pos);
      TileType type1 = tileMap.GetTileBelow(new Vector2f(thb.Min.X, thb.Min.Y + 0.001f));
      TileType type2 = tileMap.GetTileBelow(new Vector2f(thb.Max.X, thb.Min.Y + 0.001f));

      if (type1 == TileType.Empty && type2 == TileType.Empty)
        _playerObject.CurrentState = CharacterState.Falling;

      Vector2f movement = WalkPlayer(thb, dv.X);

      if (movement.X != dv.X)
        _speed.X = 0;

      _playerObject.Position = pos + movement;
    }

    /// <summary>
    /// Handles the jumping state.
    /// </summary>
    /// <param name="dt">The time past since the last frame.</param>
    private void HandleJumping(float dt)
    {
      float speedx = _speed.X;

      if (_controller.DoMoveLeft(_playerObject))
        speedx -= 200 * dt;

      if (_controller.DoMoveRight(_playerObject))
        speedx += 200 * dt;

      speedx = GameUtil.Clamp(speedx, -MaxWalkSpeed, MaxWalkSpeed);

      _speed.X = speedx;

      //Make sure entity is facing into the correct direction
      if (speedx > 0)
        _direction = 1;
      else if (speedx < 0)
        _direction = -1;

      Vector2f pos = _playerObject.Position;
      Vector2f dv = new Vector2f(speedx * dt, _fallSpeed * dt);

      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      Rectangle2f hitbox = new Rectangle2f(_playerObject.HitBox.Min + pos, _playerObject.HitBox.Max + pos);

      float xBound = dv.X > 0 ? hitbox.Max.X : hitbox.Min.X;
      Vector2f topPoint = new Vector2f(hitbox.GetCenter().X, hitbox.Max.Y);
      Vector2f forwardPoint = new Vector2f(xBound, hitbox.GetCenter().Y);

      Vector2f maxMove;
      if (tileMap.CollideMovingPoint(topPoint, dv, out maxMove))
      {
        dv.Y = maxMove.Y;
        _fallSpeed = 0;
      }

      if (tileMap.CollideMovingPoint(forwardPoint, dv, out maxMove))
      {
        dv.X = maxMove.X;
        _speed.X = 0;
      }

      pos += dv;
      _fallSpeed -= 1500 * dt;
      _playerObject.Position = pos;

      if (_fallSpeed <= 0)
        _playerObject.CurrentState = CharacterState.Falling;
    }

    /// <summary>
    /// Handles the falling state.
    /// </summary>
    /// <param name="dt">The time past since the last frame.</param>
    private void HandleFalling(float dt)
    {
      _fallSpeed = Math.Min(_fallSpeed + (1500 * dt), 800);

      float speedx = _speed.X;

      if (_controller.DoMoveLeft(_playerObject))
        speedx -= 200 * dt;

      if (_controller.DoMoveRight(_playerObject))
        speedx += 200 * dt;

      speedx = GameUtil.Clamp(speedx, -MaxWalkSpeed, MaxWalkSpeed);

      _speed.X = speedx;

      //Make sure entity is facing into the correct direction
      if (speedx > 0)
        _direction = 1;
      else if (speedx < 0)
        _direction = -1;

      Vector2f movement = new Vector2f(speedx * dt, -_fallSpeed * dt);

      TileMapObject tilemap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      Vector2f pos = _playerObject.Position;
      Rectangle2f hitbox = new Rectangle2f(_playerObject.HitBox.Min + pos, _playerObject.HitBox.Max + pos);

      float xBound = movement.X > 0 ? hitbox.Max.X : hitbox.Min.X;
      Vector2f bottomPoint = new Vector2f(hitbox.GetCenter().X, hitbox.Min.Y);
      Vector2f forwardPoint = new Vector2f(xBound, hitbox.GetCenter().Y);

      Vector2f dv = movement;
      Vector2f realMovement;
      if (tilemap.CollideMovingPoint(bottomPoint, movement, out realMovement))
      {
        dv.Y = realMovement.Y;
        _playerObject.CurrentState = CharacterState.Walking;
      }

      if (tilemap.CollideMovingPoint(forwardPoint, movement, out realMovement))
      {
        dv.X = realMovement.X;
        _speed.X = 0;
      }

      pos = _playerObject.Position;
      pos += dv;
      _playerObject.Position = pos;
    }

    /// <summary>
    /// Handles the frozen state.
    /// </summary>
    /// <param name="dt">The time past since the last frame.</param>
    private void HandleFrozen(float dt)
    {
      _freezeTime -= dt;
      if (_freezeTime <= 0)
        _playerObject.CurrentState = CharacterState.Falling;
    }

    private Vector2f WalkPlayer(Rectangle2f hitbox, float dx)
    {
      if (dx == 0)
        return Vector2f.Zero;

      Vector2f bottomCenter = new Vector2f(hitbox.GetCenter().X, hitbox.Min.Y + 0.0001f);

      TileMapObject tileMap = GameData.Instance.ActiveScene.GameObjects.GetObjectById("tilemap") as TileMapObject;

      float possibleX = dx;
      //Check if movement means collision
      if (possibleX > 0)
      {
        Vector2f topTile = tileMap.WorldToTile(hitbox.Max);
        Vector2f leftTile = tileMap.WorldToTile(bottomCenter);
        Vector2f rightTile = tileMap.WorldToTile(new Vector2f(hitbox.Max.X + dx, bottomCenter.Y));

        int left = (int)leftTile.X;
        int right = (int)rightTile.X;
        int bottom = (int)leftTile.Y;
        int top = (int)topTile.Y;

        for (int y = bottom; y <= top; y++)
        {
          for (int x = left; x <= right; x++)
          {
            Tile tile = tileMap.TileData[x, y];
            Tile tileLeft = tileMap.TileData[x - 1, y];
            if (tile.TileType == TileType.Filled || tile.TileType == TileType.NorthEast || tile.TileType == TileType.NorthWest)
            {
              if (tileLeft.TileType != TileType.SouthEast)
              {
                Rectangle2f tileRect = tileMap.GetTileRect(x, y);
                possibleX = tileRect.Min.X - hitbox.Max.X;
              }
            }
          }
        }
      }
      else
      {
        Vector2f topTile = tileMap.WorldToTile(hitbox.Max);
        Vector2f rightTile = tileMap.WorldToTile(bottomCenter);
        Vector2f leftTile = tileMap.WorldToTile(new Vector2f(hitbox.Min.X + dx, bottomCenter.Y));

        int left = (int)leftTile.X;
        int right = (int)rightTile.X;
        int bottom = (int)leftTile.Y;
        int top = (int)topTile.Y;

        for (int y = bottom; y <= top; y++)
        {
          for (int x = right; x >= left; x--)
          {
            Tile tile = tileMap.TileData[x, y];
            Tile tileRight = tileMap.TileData[x + 1, y];
            if (tile.TileType == TileType.Filled || tile.TileType == TileType.NorthEast || tile.TileType == TileType.NorthWest)
            {
              if (tileRight.TileType != TileType.SouthWest)
              {
                Rectangle2f tileRect = tileMap.GetTileRect(x, y);
                possibleX = (tileRect.Max.X - hitbox.Min.X) + 0.0f;
              }
            }
          }
        }
      }

      // Move player along terrain
      Vector2f startTile = tileMap.WorldToTile(bottomCenter);
      Vector2f endTile = tileMap.WorldToTile(new Vector2f(bottomCenter.X + possibleX, bottomCenter.Y));

      int startX = (int)startTile.X;
      int endX = (int)endTile.X;
      int ty = (int)startTile.Y;

      Vector2f result = new Vector2f(possibleX, 0);

      for (int x = startX; x <= endX; x++)
      {
        Tile tile = tileMap.TileData[x, ty];
        Rectangle2f tileRect = tileMap.GetTileRect(x, ty);

        float moveStartX = 0;
        float moveEndX = 0;

        if (possibleX > 0)
        {
          moveStartX = Math.Max(bottomCenter.X, tileRect.Min.X);
          moveEndX = Math.Min(bottomCenter.X + possibleX, tileRect.Max.X);
        }
        else
        {
          moveStartX = Math.Min(bottomCenter.X, tileRect.Max.X);
          moveEndX = Math.Max(bottomCenter.X + possibleX, tileRect.Min.X);
        }

        float moveDX = moveEndX - moveStartX;

        switch (tile.TileType)
        {
          case TileType.Empty:
            Tile tileBelow = tileMap.TileData[x, ty - 1];
            Rectangle2f tileBelowRect = tileMap.GetTileRect(x, ty - 1);

            if (tileBelow.TileType == TileType.SouthWest)
              result.Y -= moveDX > 0 ? Math.Min(moveDX, bottomCenter.Y - tileBelowRect.Min.Y) : Math.Max(moveDX, tileBelowRect.Max.Y - bottomCenter.Y);
            else if (tileBelow.TileType == TileType.SouthEast)
              result.Y += moveDX > 0 ? Math.Min(moveDX, tileBelowRect.Max.Y - bottomCenter.Y) : Math.Max(moveDX, tileBelowRect.Min.Y - bottomCenter.Y);

            break;

          case TileType.Filled:
          case TileType.NorthEast:
          case TileType.NorthWest:
            result.Y = tileRect.Max.Y - bottomCenter.Y;
            break;

          case TileType.SouthEast:
            result.Y += moveDX > 0 ? Math.Min(moveDX, tileRect.Max.Y - bottomCenter.Y) : Math.Max(moveDX, tileRect.Min.Y - bottomCenter.Y);
            break;

          case TileType.SouthWest:
            result.Y -= moveDX > 0 ? Math.Min(moveDX, bottomCenter.Y - tileRect.Min.Y) : Math.Max(moveDX, bottomCenter.Y - tileRect.Max.Y);
            break;

          default:
            throw new NotSupportedException("Unsupported tile type: " + tile.TileType.ToString());
        }
      }

      return result;
    }

  }
}
