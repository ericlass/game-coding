using System;
using OkuMath;
using OkuBase.Graphics;
using OkuEngine;
using OkuEngine.Assets;
using OkuEngine.Events;
using OkuEngine.Components;
using OkuEngine.Levels;

namespace OkuTestApp
{
  public class PhysicsLevel : Level
  {
    protected override void Init()
    {
      var entity = new Entity("box");

      entity.AddComponent(new PositionComponent(new Vector2f(), false));
      entity.AddComponent(new PhysicsComponent(1.0f, 0.5f, 1.0f));
      entity.AddComponent(new VelocityComponent());

      

      var mesh = Engine.GetMeshForImage(32, 32);
      var meshId = MeshCache.CreateEntry();
      MeshCache.BufferData(meshId, mesh);

      entity.AddComponent(new SimpleMeshComponent(meshId));

      var boxShape = Engine.GetBoxShape(32, 32);
      var shapeId = ShapeCache.CreateEntry();
      ShapeCache.BufferData(shapeId, boxShape);

      entity.AddComponent(new SimpleShapeComponent(shapeId));

      var image = Engine.LoadImage("D:\\Temp\\Icons\\iconex_ap\\128x128\\plain\\bullet_square_grey.png");
      var imageHandle = Assets.AddAsset(new ImageAsset(image));
      var materialId = Assets.AddAsset(new MaterialAsset(imageHandle, Color.Blue));
      entity.AddComponent(new MaterialComponent(materialId));

      Engine.AddEntity(entity);

      //#########################################################

      var entity2 = new Entity("floor");

      entity2.AddComponent(new PositionComponent(new Vector2f(0, -50), false));
      entity2.AddComponent(new SimpleMeshComponent(meshId));
      entity2.AddComponent(new SimpleShapeComponent(shapeId));

      materialId = Assets.AddAsset(new MaterialAsset(imageHandle, Color.Green));
      entity2.AddComponent(new MaterialComponent(materialId));

      Engine.AddEntity(entity2);

      //#########################################################

      var eventName = EventNames.GetGenericInputEventName(System.Windows.Forms.Keys.Space, OkuEngine.Input.InputAction.Down);
      var listener = new EventListener(eventName, ev => entity.GetComponent<VelocityComponent>().Velocity = new Vector2f(0, 50));
      Engine.AddEventListener(listener);
    }

    protected override void Finish()
    {      
    }    
  }
}
