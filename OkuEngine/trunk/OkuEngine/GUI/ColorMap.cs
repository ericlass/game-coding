using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class ColorMap
  {
    private Color _backGround;
    private Color _widgetLow;
    private Color _widgetHigh;
    private Color _hotLow;
    private Color _hotHigh;
    private Color _activeLow;
    private Color _activeHigh;
    private Color _borderLow;
    private Color _borderHigh;
    private Color _fontLow;
    private Color _fontHigh;

    public ColorMap()
    {
    }

    public ColorMap(Color backGround, Color widgetLow, Color widgetHigh, Color hotLow, Color hotHigh, Color activeLow, Color activeHigh, Color borderLow, Color borderHigh, Color fontLow, Color fontHigh)
    {
      _backGround = backGround;
      _widgetLow = widgetLow;
      _widgetHigh = widgetHigh;
      _hotLow = hotLow;
      _hotHigh = hotHigh;
      _activeLow = activeLow;
      _activeHigh = activeHigh;
      _borderLow = borderLow;
      _borderHigh = borderHigh;
      _fontLow = fontLow;
      _fontHigh = fontHigh;
    }

    public Color BackGround
    {
      get { return _backGround; }
      set { _backGround = value; }
    }

    public Color WidgetLow
    {
      get { return _widgetLow; }
      set { _widgetLow = value; }
    }
    
    public Color WidgetHigh
    {
      get { return _widgetHigh; }
      set { _widgetHigh = value; }
    }
    
    public Color HotLow
    {
      get { return _hotLow; }
      set { _hotLow = value; }
    }
    
    public Color HotHigh
    {
      get { return _hotHigh; }
      set { _hotHigh = value; }
    }
    
    public Color ActiveLow
    {
      get { return _activeLow; }
      set { _activeLow = value; }
    }
    
    public Color ActiveHigh
    {
      get { return _activeHigh; }
      set { _activeHigh = value; }
    }
    
    public Color BorderLow
    {
      get { return _borderLow; }
      set { _borderLow = value; }
    }
    
    public Color BorderHigh
    {
      get { return _borderHigh; }
      set { _borderHigh = value; }
    }
    
    public Color FontLow
    {
      get { return _fontLow; }
      set { _fontLow = value; }
    }
    
    public Color FontHigh
    {
      get { return _fontHigh; }
      set { _fontHigh = value; }
    }

    public static ColorMap Flash = new ColorMap(
      new Color(51, 51, 51),
      new Color(65, 65, 65),
      new Color(103, 103, 103),
      new Color(85, 85, 85),
      new Color(123, 123, 123),
      new Color(57, 95, 138),
      new Color(102, 163, 226),
      new Color(20, 20, 20),
      new Color(20, 20, 20),
      Color.Silver,
      Color.White);

  }
}
