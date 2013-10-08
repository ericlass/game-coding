using System;
using OkuBase.Geometry;

namespace RougeLike
{
  public abstract class BehaviorComponent : IComponent
  {
    private Entity _owner = null;
    
    public abstract string Id { get; }
    
    public Entity Owner
    {
      get { return _owner; }
      set { _owner = value; }
    }
    
    public abstract void Update(float dt);
    
    protected float DistanceToPlayer()
    {
      TransformComponent playerTransform = GameManager.Instance.PlayerEntity.GetComponent<TransformComponent>(TransformComponent.ComponentId);
      if (playerTransform == null)
        return float.MaxValue;
        
      TransformComponent ownerTransform = Owner.GetComponent<TransformComponent>(TransformComponent.ComponentId);
      if (ownerTransform == null)
        return float.MaxValue;
        
      return Vector2f.Distance(ownerTransform.Translation, playerTransform.Translation);
    }
    
    protected bool CanMoveTo(Vector2f pos)
    {
      //Ask tile map if target point is accessible
      return true;
    }
    
    protected void MoveTo(Vector2f pos)
    {
      TransformComponent ownerTransform = Owner.GetComponent<TransformComponent>(TransformComponent.ComponentId);
      if (ownerTransform == null)
        return;
        
      ownerTransform.Translation = pos;
    }
    
    protected void SwitchState(string stateId)
    {
      Owner.StateMachine.CurrentStateId = stateId;
    }
    
    protected bool TouchesPlayer()
    {
      BoundingBoxComponent playerBB = GameManager.Instance.PlayerEntity.GetComponent<BoundingBoxComponent>(BoundingBoxComponent.ComponentId);
      if (playerBB == null)
        return false;
        
      BoundingBoxComponent ownerBB = Owner.GetComponent<BoundingBoxComponent>(BoundingBoxComponent.ComponentId);
      if (ownerBB == null)
        return false;
        
      return IntersectionTests.Rectangles(ownerBB.AABB.Min, ownerBB.AABB.Max, playerBB.AABB.Min, playerBB.AABB.Max);
    }
    
    protected float DamagePlayer(float points)
    {
      StatsComponent playerStats = GameManager.Instance.PlayerEntity.GetComponent<StatsComponent>(StatsComponent.ComponentId);
      if (playerStats == null)
        return -1.0f;
        
      playerStats.Health -= points;
      return playerStats.Health;
    }
    
    protected string CurrentState
    {
      get { return _owner.StateMachine.CurrentStateId; }
    }
    
    protected string Spawn(string sourceId)
    {
      //Find entity by id
      //Copy
      //Return new id
      return null;
    }
    
    protected void AddItem(string itemId, int amount)
    {
      InventoryComponent inventory = GameManager.Instance.PlayerEntity.GetComponent<InventoryComponent>(InventoryComponent.ComponentId);
      if (inventory == null)
        return;
        
      inventory.AddItem(itemId, amount);
    }
    
    protected void KillMe()
    {
      //Inform entity container that entity should be removed
    }
    
    protected void QueueEvent(EventId eventId, int data)
    {
      GameManager.Instance.EventQueue.QueueEvent(eventId, data);
    }
    
  }
}
