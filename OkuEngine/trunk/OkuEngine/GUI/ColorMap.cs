using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines a color map for a widget container.
  /// </summary>
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

    /// <summary>
    /// Creates a new color map where all colors are black.
    /// </summary>
    public ColorMap()
    {
    }

    /// <summary>
    /// Creates a new color map with the givne colors.
    /// </summary>
    /// <param name="backGround">The color for the background.</param>
    /// <param name="widgetLow">The low color for widgets.</param>
    /// <param name="widgetHigh">The high color for widgets.</param>
    /// <param name="hotLow">The low color for hot widgets.</param>
    /// <param name="hotHigh">The high color for hot widgets.</param>
    /// <param name="activeLow">The low color for active widgets.</param>
    /// <param name="activeHigh">The high color for active widgets.</param>
    /// <param name="borderLow">The low color for widget borders.</param>
    /// <param name="borderHigh">The high color for widget borders.</param>
    /// <param name="fontLow">The low color for the widget font.</param>
    /// <param name="fontHigh">The high color for the widget font.</param>
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

    /// <summary>
    /// Gets or sets the color used for clearing the screen.
    /// </summary>
    public Color BackGround
    {
      get { return _backGround; }
      set { _backGround = value; }
    }

    /// <summary>
    /// Gets the sets the low color for widgets.
    /// </summary>
    public Color WidgetLow
    {
      get { return _widgetLow; }
      set { _widgetLow = value; }
    }

    /// <summary>
    /// Gets the sets the high color for widgets.
    /// </summary>
    public Color WidgetHigh
    {
      get { return _widgetHigh; }
      set { _widgetHigh = value; }
    }
    
    /// <summary>
    /// Gets or sets the low color for hot widgets.
    /// </summary>
    public Color HotLow
    {
      get { return _hotLow; }
      set { _hotLow = value; }
    }

    /// <summary>
    /// Gets or sets the high color for hot widgets.
    /// </summary>
    public Color HotHigh
    {
      get { return _hotHigh; }
      set { _hotHigh = value; }
    }

    /// <summary>
    /// Gets or sets the low color for active widgets.
    /// </summary>
    public Color ActiveLow
    {
      get { return _activeLow; }
      set { _activeLow = value; }
    }

    /// <summary>
    /// Gets or sets the high color for active widgets.
    /// </summary>
    public Color ActiveHigh
    {
      get { return _activeHigh; }
      set { _activeHigh = value; }
    }
    
    /// <summary>
    /// Gets or sets the low color for widget borders.
    /// </summary>
    public Color BorderLow
    {
      get { return _borderLow; }
      set { _borderLow = value; }
    }

    /// <summary>
    /// Gets or sets the high color for widget borders.
    /// </summary>
    public Color BorderHigh
    {
      get { return _borderHigh; }
      set { _borderHigh = value; }
    }

    /// <summary>
    /// Gets or sets the low color for the widget font.
    /// </summary>
    public Color FontLow
    {
      get { return _fontLow; }
      set { _fontLow = value; }
    }

    /// <summary>
    /// Gets or sets the high color for the widget font.
    /// </summary>
    public Color FontHigh
    {
      get { return _fontHigh; }
      set { _fontHigh = value; }
    }

    /// <summary>
    /// A predefined color map that looks quite like the flash GUI.
    /// </summary>
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
