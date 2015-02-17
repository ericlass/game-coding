using System;
using System.Collections.Generic;
using OkuBase.Input;
using OkuBase.Geometry;

namespace SimGame.Mouse
{
  public class MouseProcessor
  {
    private Action<string, MouseEvent, MouseButton> _handler = null;
    private InputContext _input = null;
    private SortedList<string, Rectangle2f> _regions = null;
    
    private string _activeRegion = null;

    public MouseProcessor(Action<string, MouseEvent, MouseButton> handler, InputContext inputContext)
    {
      if (handler == null)
        throw new ArgumentException("Handler cannot be null!");

      _input = inputContext == null ? new InputContext() : inputContext;

      _regions = new SortedList<string, Rectangle2f>();
      _handler = handler;
    }

    public void AddRegion(string id, Rectangle2f area)
    {
      if (_regions.ContainsKey(id))
        return;

      _regions.Add(id, area);
    }

    public bool RemoveRegion(string id)
    {
      return _regions.Remove(id);
    }

    public void ClearRegions()
    {
      _regions.Clear();
    }

    private OkuBase.OkuManager Oku
    {
      get { return OkuBase.OkuManager.Instance; }
    }

    public Action<string, MouseEvent, MouseButton> Handler
    {
      get { return _handler; }
    }

    public void Update()
    {
      Vector2f pos = Oku.Graphics.ScreenToWorld(_input.MouseX, _input.MouseY);
      int x = (int)pos.X;
      int y = (int)pos.Y;

      string currentRegion = null;
      foreach (var region in _regions)
      {
        if (region.Value.IsInside(pos))
        {
          currentRegion = region.Key;
          break;
        }
      }

      if (currentRegion != _activeRegion)
      {
        if (_activeRegion != null)
          _handler(_activeRegion, MouseEvent.Leave, MouseButton.Left);
        if (currentRegion != null)
          _handler(currentRegion, MouseEvent.Enter, MouseButton.Left);
      }

      _activeRegion = currentRegion;

      if (_activeRegion != null)
      {
        List<MouseButton> pressed = _input.GetPressedButtons();
        foreach (var button in pressed)
          _handler(_activeRegion, MouseEvent.ButtonDown, button);

        List<MouseButton> raised = _input.GetRaisedButtons();
        foreach (var button in raised)
          _handler(_activeRegion, MouseEvent.ButtonUp, button);
      }
    }

  }
}
