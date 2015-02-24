using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OkuBase.Input;
using OkuBase.Geometry;

namespace SimGame.Input
{
  /// <summary>
  /// Lets you specify regions in world space and then get informed when the
  /// mouse cursor enters or leaves a region or any of the regions is clicked.
  /// The region that was clicked last also receives keyboard input.
  /// Regions can be layered by using a z-index.
  /// </summary>
  public class InputProcessor
  {
    private InputContext _input = null;
    private List<Region> _regions = null;
    private Dictionary<string, Region> _regionMap = null; // Set for fast checking if id is already used.

    private Region _activeRegion = null;
    private Region _focusedRegion = null;

    private int lastX = 0;
    private int lastY = 0;

    /// <summary>
    /// Creates a new mouse processor with the given input context and event handler.
    /// </summary>
    /// <param name="handler">A handler that receives messages about mouse events.</param>
    /// <param name="inputContext">The input context to use.</param>
    public InputProcessor(InputContext inputContext)
    {
      _input = inputContext == null ? new InputContext() : inputContext;
      _regions = new List<Region>();
      _regionMap = new Dictionary<string, Region>();
    }

    /// <summary>
    /// Adds a new region to the mouse processor.
    /// </summary>
    /// <param name="id">The id of the region.</param>
    /// <param name="area">The area of the region.</param>
    /// <param name="zIndex">The z-index of the region.</param>
    /// <param name="handler">The handler to be called when this region receives an event.</param>
    public void AddRegion(Region region)
    {
      if (region.Id == null)
        throw new ArgumentException("A region cannot have null as id!");

      if (_regionMap.ContainsKey(region.Id))
        throw new ArgumentException("There already is a region with the id '" + region.Id + "'! Ids must be unique.");

      //Insert new regions sorted descending by zindex. This way, the ones with the highest zindex are selected first later.
      int i = 0;
      while (i < _regions.Count && _regions[i].ZIndex > region.ZIndex)
        i++;

      _regions.Insert(i, region);
      _regionMap.Add(region.Id, region);
    }

    /// <summary>
    /// Checks if the input processor already contains a region with the given key or not.
    /// </summary>
    /// <param name="id">The id of the region.</param>
    /// <returns>True if the input processor contains the region, else false.</returns>
    public bool ContainsRegion(string id)
    {
      return _regionMap.ContainsKey(id);
    }

    /// <summary>
    /// Gets the region with the given id.
    /// </summary>
    /// <param name="id">The if of the region.</param>
    /// <returns>The region with the given id or null if there is no region with the given id.</returns>
    public Region this[string id]
    {
      get
      {
        if (_regionMap.ContainsKey(id))
          return _regionMap[id];

        return null;
      }
    }

    /// <summary>
    /// Removes the id of the region with the given id.
    /// </summary>
    /// <param name="id">The id of the region.</param>
    /// <returns>True if the region was removed, else False.</returns>
    public bool RemoveRegion(string id)
    {
      if (!_regionMap.ContainsKey(id))
        return false;

      Region region = _regionMap[id];
      _regionMap.Remove(id);
      _regions.Remove(region);

      return true;
    }

    /// <summary>
    /// Clears all regions.
    /// </summary>
    public void ClearRegions()
    {
      _regions.Clear();
      _regionMap.Clear();
    }

    public List<Region> Regions
    {
      get { return _regions; }
    }

    /// <summary>
    /// Updates the mouse processor and therefore checks for and fires the mouse events.
    /// </summary>
    public void Update()
    {
      //Calculate mouse position in world space
      Vector2f pos = OkuBase.OkuManager.Instance.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);
      int x = (int)pos.X;
      int y = (int)pos.Y;

      //Find region currently under mouse cursor
      Region currentRegion = null;
      foreach (var region in _regions)
      {
        if (region.Area.IsInside(pos))
        {
          currentRegion = region;
          break;
        }
      }

      //If region has changed, fire leave/enter events accordingly
      if (currentRegion != _activeRegion)
      {
        if (_activeRegion != null)
          _activeRegion.MouseHandler(_activeRegion.Id, MouseEvent.Leave, MouseButton.Left);
        if (currentRegion != null)
          currentRegion.MouseHandler(currentRegion.Id, MouseEvent.Enter, MouseButton.Left);
      }

      //Check for mouse movement and fire event accordingly
      if (_activeRegion != null && _activeRegion == currentRegion)
      {
        int dx = x - lastX;
        int dy = y - lastY;
        if (dx != 0 || dy != 0)
          _activeRegion.MouseHandler(_activeRegion.Id, MouseEvent.Move, MouseButton.Left);
      }

      _activeRegion = currentRegion;

      //Check for button clicks
      if (_activeRegion != null)
      {
        if (_input.MouseButtonPressed(MouseButton.Left))
          _focusedRegion = _activeRegion;

        List<MouseButton> pressed = _input.GetPressedButtons();
        foreach (var button in pressed)
          _activeRegion.MouseHandler(_activeRegion.Id, MouseEvent.ButtonDown, button);

        List<MouseButton> raised = _input.GetRaisedButtons();
        foreach (var button in raised)
          _activeRegion.MouseHandler(_activeRegion.Id, MouseEvent.ButtonUp, button);
      }

      lastX = x;
      lastY = y;

      if (_focusedRegion != null && _focusedRegion.KeyboardHandler != null)
      {
        List<Keys> pressedKeys = _input.GetPressedKeys();
        foreach (var key in pressedKeys)
          _focusedRegion.KeyboardHandler(_focusedRegion.Id, KeyboardEvent.KeyPressed, key);

        List<Keys> raisedKey = _input.GetRaisedKeys();
        foreach (var key in raisedKey)
          _focusedRegion.KeyboardHandler(_focusedRegion.Id, KeyboardEvent.KeyRaised, key);
      }
    }

  }
}
