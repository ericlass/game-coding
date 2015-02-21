using System;
using System.Collections.Generic;
using OkuBase.Input;
using OkuBase.Geometry;

namespace SimGame.Mouse
{
  /// <summary>
  /// Lets you specify regions in world space end then get informed when the
  /// mouse cursor enters or leaves a region or any of the regions is clicked.
  /// Regions can be layered by sing a z-index.
  /// </summary>
  public class MouseProcessor
  {
    /// <summary>
    /// Internal class for regions data.
    /// </summary>
    private class Region
    {
      public Region(string id, Rectangle2f area, int zIndex, Action<string, MouseEvent, MouseButton> handler)
      {
        Id = id;
        Area = area;
        ZIndex = zIndex;
        Handler = handler;
      }

      public string Id { get; set; }
      public Rectangle2f Area { get; set; }
      public int ZIndex { get; set; }
      public Action<string, MouseEvent, MouseButton> Handler { get; set; }
    }

    private InputContext _input = null;
    private List<Region> _regions = null;
    private HashSet<string> _usedIds = null; // Set for fast checking if id is already used.

    private Region _activeRegion = null;

    /// <summary>
    /// Creates a new mouse processor with the given input context and event handler.
    /// </summary>
    /// <param name="handler">A handler that receives messages about mouse events.</param>
    /// <param name="inputContext">The input context to use.</param>
    public MouseProcessor(InputContext inputContext)
    {
      _input = inputContext == null ? new InputContext() : inputContext;
      _regions = new List<Region>();
      _usedIds = new HashSet<string>();
    }

    /// <summary>
    /// Adds a new region to the mouse processor.
    /// </summary>
    /// <param name="id">The id of the region.</param>
    /// <param name="area">The area of the region.</param>
    /// <param name="zIndex">The z-index of the region.</param>
    /// <param name="handler">The handler to be called when this region receives an event.</param>
    public void AddRegion(string id, Rectangle2f area, int zIndex, Action<string, MouseEvent, MouseButton> handler)
    {
      if (_usedIds.Contains(id))
        throw new ArgumentException("There already is a region with the id '" + id + "'! Ids must be unique.");

      //Insert new regions sorted descending by zindex. This way, the ones with the highest zindex are selected first later.
      int i = 0;
      while (i < _regions.Count && _regions[i].ZIndex > zIndex)
        i++;

      _regions.Insert(i, new Region(id, area, zIndex, handler));
    }

    /// <summary>
    /// Removes the id of the region with the given id.
    /// </summary>
    /// <param name="id">The id of the region.</param>
    /// <returns>True if the region was removed, else False.</returns>
    public bool RemoveRegion(string id)
    {
      if (!_usedIds.Contains(id))
        return false;
      else
        _usedIds.Remove(id);

      for (int i = 0; i < _regions.Count; i++)
      {
        if (_regions[i].Id == id)
        {
          _regions.RemoveAt(i);
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Clears all regions.
    /// </summary>
    public void ClearRegions()
    {
      _regions.Clear();
    }

    /// <summary>
    /// Updates the mouse processor and therefore checks for and fires the mouse events.
    /// </summary>
    public void Update()
    {
      Vector2f pos = OkuBase.OkuManager.Instance.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);
      int x = (int)pos.X;
      int y = (int)pos.Y;

      Region currentRegion = null;
      foreach (var region in _regions)
      {
        if (region.Area.IsInside(pos))
        {
          currentRegion = region;
          break;
        }
      }

      if (currentRegion != _activeRegion)
      {
        if (_activeRegion != null)
          _activeRegion.Handler(_activeRegion.Id, MouseEvent.Leave, MouseButton.Left);
        if (currentRegion != null)
          currentRegion.Handler(currentRegion.Id, MouseEvent.Enter, MouseButton.Left);
      }

      _activeRegion = currentRegion;

      if (_activeRegion != null)
      {
        List<MouseButton> pressed = _input.GetPressedButtons();
        foreach (var button in pressed)
          _activeRegion.Handler(_activeRegion.Id, MouseEvent.ButtonDown, button);

        List<MouseButton> raised = _input.GetRaisedButtons();
        foreach (var button in raised)
          _activeRegion.Handler(_activeRegion.Id, MouseEvent.ButtonUp, button);
      }
    }

  }
}
