using System;
using System.IO;
using System.Windows.Forms;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine;
using OkuEngine.Assets;
using OkuEngine.Components;
using OkuEngine.Events;
using OkuEngine.Input;
using OkuEngine.Levels;

namespace OkuTestApp
{
  public class TilemapLevel : Level
  {
    private Entity tileMapEntity = null;
    private Entity player = null;

    protected override void Init()
    {
      OkuBase.OkuManager.Instance.Graphics.Viewport.Center = new Vector2f(256, 256);

      //Tilemap
      tileMapEntity = new Entity("tilemap");

      String imagePath;
      TilemapAsset tilemap = TilemapAsset.LoadFromTiledXml(new FileStream("D:\\Graphics\\Tilemaps\\Collision\\collisiontest.tmx", FileMode.Open), out imagePath);
      int tileMapHandle = Assets.AddAsset(tilemap);

      Image image = API.LoadImage(Path.Combine("D:\\Graphics\\Tilemaps\\Collision", imagePath));
      var handle = Assets.AddAsset(new ImageAsset(image));

      var materialhandle = Assets.AddAsset(new MaterialAsset(handle, Color.White));
      tileMapEntity.AddComponent(new MaterialComponent(materialhandle));

      TilemapMeshComponent tileMapComp = new TilemapMeshComponent(tileMapHandle, handle);
      tileMapEntity.AddComponent(tileMapComp);

      PositionComponent position = new PositionComponent(Vector2f.Zero, false);
      tileMapEntity.AddComponent(position);

      API.AddEntity(tileMapEntity);

      //Player
      player = new Entity("player");
      player.AddComponent(new PositionComponent(new Vector2f(16, 64), false));
      player.AddComponent(new ScaleComponent(new Vector2f(2.0f, 2.0f)));

      var imageData = API.LoadImage("D:\\Graphics\\white.png");
      var imageHandle = Assets.AddAsset(new ImageAsset(imageData));

      MaterialAsset material = new MaterialAsset(imageHandle, Color.Blue);
      var materialHandle = Assets.AddAsset(material);

      player.AddComponent(new MaterialComponent(materialHandle));

      MeshAsset mesh = API.GetMeshForImage(imageData.Width, imageData.Height, true);
      var meshHandle = Assets.AddAsset(mesh);

      player.AddComponent(new SimpleMeshComponent(meshHandle));

      API.AddEntity(player);

      //Camera Movement
      InputAxisMapping vertical = new InputAxisMapping("camera_vertical");
      vertical.Axes.Add(new KeyInputAxis(InputKey.KeyboardW, -1.0f));
      vertical.Axes.Add(new KeyInputAxis(InputKey.KeyboardS, 1.0f));

      InputAxisMapping horizontal = new InputAxisMapping("camera_horizontal");
      horizontal.Axes.Add(new KeyInputAxis(InputKey.KeyboardD, -1.0f));
      horizontal.Axes.Add(new KeyInputAxis(InputKey.KeyboardA, 1.0f));

      //Player movement
      InputAxisMapping playerVert = new InputAxisMapping("player_vertical");
      playerVert.Axes.Add(new KeyInputAxis(InputKey.KeyboardUp, 1.0f));
      playerVert.Axes.Add(new KeyInputAxis(InputKey.KeyboardDown, -1.0f));

      InputAxisMapping playerHorz = new InputAxisMapping("player_horizontal");
      playerHorz.Axes.Add(new KeyInputAxis(InputKey.KeyboardRight, 1.0f));
      playerHorz.Axes.Add(new KeyInputAxis(InputKey.KeyboardLeft, -1.0f));

      InputContext context = new InputContext();
      context.AxisMappings.Add(vertical);
      context.AxisMappings.Add(horizontal);
      context.AxisMappings.Add(playerVert);
      context.AxisMappings.Add(playerHorz);

      API.SetInputContext(0, context);

      //const float trans = 200;
      //API.AddEventListener(new EventListener(EventNames.EveryFrame, ev => position.Position += new Vector2f(0, trans * API.GetAxisValue("camera_vertical") * (float)ev.Data[0])));
      //API.AddEventListener(new EventListener(EventNames.EveryFrame, ev => position.Position += new Vector2f(trans * API.GetAxisValue("camera_horizontal") * (float)ev.Data[0], 0)));

      API.AddEventListener(new EventListener(EventNames.EveryFrame, MovePlayerSAT));
    }

    private void MovePlayerSAT(Event ev)
    {
      float dt = (float)ev.Data[0];

      float speed = 200.0f * dt;
      float vx = API.GetAxisValue("player_horizontal") * speed;
      float vy = API.GetAxisValue("player_vertical") * speed;
      Vector2f v = new Vector2f(vx, vy);

      var tilemapComp = tileMapEntity.GetComponent<TilemapMeshComponent>();
      var playerPos = player.GetComponent<PositionComponent>();

      playerPos.Position += v;

      Vector2f playerMin = playerPos.Position - new Vector2f(7.9f, 7.9f);
      Vector2f playMax = playerPos.Position + new Vector2f(7.9f, 7.9f);

      TilemapAsset tilemap = Assets.GetAsset<TilemapAsset>(tilemapComp.Tilemap);
      Vector2f mv = tilemap.GetMaxMovementSAT(playerMin, playMax);
        
      if (mv.SquaredMagnitude > 0)
        System.Diagnostics.Debug.WriteLine("MTD: " + mv);

      playerPos.Position += mv;
    }

    protected override void Finish()
    {
      throw new NotImplementedException();
    }

  }
}
