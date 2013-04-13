using System;
using System.Collections.Generic;
using System.Text;
using OkuEngine.Actors;
using OkuEngine.Attributes;
using OkuEngine.Scenes;

namespace OkuEngine.Api
{
  /// <summary>
  /// This class contains all API methods for the javascript engine.
  /// The methods are automatically exposed to the script engine
  /// on application start using reflections.
  /// </summary>
  public class OkuApi
  {
    private static OkuApi _instance = null;

    /// <summary>
    /// Gets an instance of the API.
    /// </summary>
    public static OkuApi Instance
    {
      get
      {
        if (_instance == null)
          _instance = new OkuApi();
        return _instance;
      }
    }

    /// <summary>
    /// Private constructor.
    /// </summary>
    private OkuApi()
    {
    }

    /// <summary>
    /// Gets the actor with the given id.
    /// If no such actor exists, an error message is logged.
    /// </summary>
    /// <param name="actorId">The id of the actor to get.</param>
    /// <returns>The actor with the given id or null is there is no actor with this id.</returns>
    private Actor GetActor(int actorId)
    {
      Actor actor = OkuData.Instance.Actors[actorId];
      if (actor == null)
        OkuManagers.Instance.Logger.LogError("No actor with the id " + actorId + " exists!");

      return actor;
    }

    #region Actor Functions

    /// <summary>
    /// Gets the x position of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <returns>The x position of the actor or 0 if there is no actor with this id.</returns>
    public double ActorGetX(int actorId)
    {
      Actor actor = GetActor(actorId);
      if (actor != null && actor.GetTransform() != null)
        return actor.GetTransform().Translation.X;
      else
        return 0;
    }

    /// <summary>
    /// Sets the x psotion of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="x">The new x position of the actor.</param>
    public void ActorSetX(int actorId, double x)
    {
      Actor actor = GetActor(actorId);
      if (actor != null && actor.GetTransform() != null)
        actor.GetTransform().SetX((float)x);
    }

    /// <summary>
    /// Gets the y position of the actor ith the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <returns>The y position of the actor or 0 if there is no actor with this id.</returns>
    public double ActorGetY(int actorId)
    {
      Actor actor = GetActor(actorId);
      if (actor != null && actor.GetTransform() != null)
        return actor.GetTransform().Translation.Y;
      else
        return 0;
    }

    /// <summary>
    /// Sets the y position of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="y">The new y position of the actor.</param>
    public void ActorSetY(int actorId, double y)
    {
      Actor actor = GetActor(actorId);
      if (actor != null && actor.GetTransform() != null)
        actor.GetTransform().SetY((float)y);
    }

    /// <summary>
    /// Sets the x and y position of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="x">The new x position of the actor.</param>
    /// <param name="y">The new y position of the actor.</param>
    public void ActorSetPos(int actorId, double x, double y)
    {
      Actor actor = GetActor(actorId);
      if (actor != null)
      {
        Transformation trans = actor.GetTransform();
        Vector2f pos = trans.Translation;
        pos.X = (float)x;
        pos.Y = (float)y;
        trans.Translation = pos;
      }
    }

    /// <summary>
    /// Gets the rotation angle of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <returns>The angle of the actor.</returns>
    public double ActorGetAngle(int actorId)
    {
      Actor actor = GetActor(actorId);
      if (actor != null && actor.GetTransform() != null)
        return actor.GetTransform().Rotation;
      else
        return 0.0;
    }

    /// <summary>
    /// Sets the rotation angle of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="angle">The new rotation angle of the actor.</param>
    public void ActorSetAngle(int actorId, double angle)
    {
      Actor actor = GetActor(actorId);
      if (actor != null && actor.GetTransform() != null)
        actor.GetTransform().Rotation = (float)angle;
    }

    /// <summary>
    /// Gets the name of the current state of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <returns>The name of the current state.</returns>
    public string ActorGetCurrentState(int actorId)
    {
      Actor actor = GetActor(actorId);
      if (actor != null)
        return actor.States.CurrentStateName;
      else
        return null;
    }

    /// <summary>
    /// Gets the name of the previous state of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <returns>The name of the previous state.</returns>
    public string ActorGetPreviousState(int actorId)
    {
      Actor actor = GetActor(actorId);
      if (actor != null)
        return actor.States.PreviousStateName;
      else
        return null;
    }

    /// <summary>
    /// Sets the current state of the actor with the given id.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="state">The name of the new state.</param>
    /// <returns>True if the state was set, false if there is no state with the given name.</returns>
    public bool ActorSetCurrentState(int actorId, string state)
    {
      Actor actor = GetActor(actorId);
      if (actor != null)
      {
        if (actor.States.SetCurrentState(state))
        {
          return true;
        }
        else
        {
          OkuManagers.Instance.Logger.LogError("There is no actor state with the name " + state + "!");
          return false;
        }
      }
      return false;
    }

    /// <summary>
    /// Gets the value of the actor attribute with the given name.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="attribute">The name of the attribute.</param>
    /// <returns>The value of the actor attribute or null if there is no attribute with the given name.</returns>
    public string ActorGetAttribute(int actorId, string attribute)
    {
      Actor actor = GetActor(actorId);
      if (actor != null)
      {
        AttributeValue value = actor.GetAttributeValue(attribute.Trim().ToLower());
        if (value != null)
          return value.ValueString;
        else
          OkuManagers.Instance.Logger.LogError("The is no actor attribute with the name " + attribute + "!");
      }
      return null;
    }

    /// <summary>
    /// Sets the actor attribute with the given name to the given value.
    /// </summary>
    /// <param name="actorId">The id of the actor.</param>
    /// <param name="attribute">The name of the attribute.</param>
    /// <param name="value">The new value of the attribute.</param>
    public void ActorSetAttribute(int actorId, string attribute, string value)
    {
      Actor actor = GetActor(actorId);
      if (actor != null)
      {
        AttributeValue attrValue = actor.GetAttributeValue(attribute.Trim().ToLower());
        if (attrValue != null)
          attrValue.ValueString = value;
        else
          OkuManagers.Instance.Logger.LogError("The is no actor attribute with the name " + attribute + "!");
      }
    }

    #endregion

    #region Viewport Functions

    /// <summary>
    /// Gets the x component of the current viewport center.
    /// </summary>
    /// <returns>The x component of the current viewport center.</returns>
    public double GetViewportX()
    {
      return OkuData.Instance.SceneManager.ActiveScene.Viewport.Center.X;
    }

    /// <summary>
    /// Gets the y component of the current viewport center.
    /// </summary>
    /// <returns>The y component of the current viewport center.</returns>
    public double GetViewportY()
    {
      return OkuData.Instance.SceneManager.ActiveScene.Viewport.Center.Y;
    }

    /// <summary>
    /// Sets the current position of the viewport center.
    /// </summary>
    /// <param name="x">The x component.</param>
    /// <param name="y">The y component.</param>
    public void SetViewportPosition(double x, double y)
    {
      OkuData.Instance.SceneManager.ActiveScene.Viewport.Center = new Vector2f((float)x, (float)y);
    }

    /// <summary>
    /// Moves the viewport by the given amounts along the x and y axes.
    /// </summary>
    /// <param name="x">The amount to move along the x axis.</param>
    /// <param name="y">The amount to move along the y axis.</param>
    public void MoveViewport(double x, double y)
    {
      Vector2f pos = OkuData.Instance.SceneManager.ActiveScene.Viewport.Center;
      pos.X += (float)x;
      pos.Y += (float)y;
      OkuData.Instance.SceneManager.ActiveScene.Viewport.Center = pos;
    }

    #endregion

  }
}
