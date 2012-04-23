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
    private Color _widgetDark;
    private Color _widgetLight;
    private Color _hotDark;
    private Color _hotLight;
    private Color _activeDark;
    private Color _activeLight;
    private Color _borderDark;
    private Color _borderLight;
    private Color _fontDark;
    private Color _fontLight;
    private Color _windowDark;
    private Color _windowLight;

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
    /// <param name="widgetDark">The dark color for widgets.</param>
    /// <param name="widgetLight">The light color for widgets.</param>
    /// <param name="hotDark">The dark color for hot widgets.</param>
    /// <param name="hotLight">The light color for hot widgets.</param>
    /// <param name="activeDark">The dark color for active widgets.</param>
    /// <param name="activeLight">The light color for active widgets.</param>
    /// <param name="borderDark">The dark color for widget borders.</param>
    /// <param name="borderLight">The light color for widget borders.</param>
    /// <param name="fontDark">The dark color for the widget font.</param>
    /// <param name="fontLight">The light color for the widget font.</param>
    public ColorMap(Color backGround, Color widgetDark, Color widgetLight, Color hotDark, Color hotLight, Color activeDark, Color activeLight, Color borderDark, Color borderLight, Color fontDark, Color fontLight, Color windowDark, Color windowLight)
    {
      _backGround = backGround;
      _widgetDark = widgetDark;
      _widgetLight = widgetLight;
      _hotDark = hotDark;
      _hotLight = hotLight;
      _activeDark = activeDark;
      _activeLight = activeLight;
      _borderDark = borderDark;
      _borderLight = borderLight;
      _fontDark = fontDark;
      _fontLight = fontLight;
      _windowDark = windowDark;
      _windowLight = windowLight;
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
    /// Gets the sets the dark color for widgets.
    /// </summary>
    public Color WidgetDark
    {
      get { return _widgetDark; }
      set { _widgetDark = value; }
    }

    /// <summary>
    /// Gets the sets the light color for widgets.
    /// </summary>
    public Color WidgetLight
    {
      get { return _widgetLight; }
      set { _widgetLight = value; }
    }
    
    /// <summary>
    /// Gets or sets the dark color for hot widgets.
    /// </summary>
    public Color HotDark
    {
      get { return _hotDark; }
      set { _hotDark = value; }
    }

    /// <summary>
    /// Gets or sets the light color for hot widgets.
    /// </summary>
    public Color HotLight
    {
      get { return _hotLight; }
      set { _hotLight = value; }
    }

    /// <summary>
    /// Gets or sets the dark color for active widgets.
    /// </summary>
    public Color ActiveDark
    {
      get { return _activeDark; }
      set { _activeDark = value; }
    }

    /// <summary>
    /// Gets or sets the light color for active widgets.
    /// </summary>
    public Color ActiveLight
    {
      get { return _activeLight; }
      set { _activeLight = value; }
    }
    
    /// <summary>
    /// Gets or sets the dark color for widget borders.
    /// </summary>
    public Color BorderDark
    {
      get { return _borderDark; }
      set { _borderDark = value; }
    }

    /// <summary>
    /// Gets or sets the light color for widget borders.
    /// </summary>
    public Color BorderLight
    {
      get { return _borderLight; }
      set { _borderLight = value; }
    }

    /// <summary>
    /// Gets or sets the dark color for the widget font.
    /// </summary>
    public Color FontDark
    {
      get { return _fontDark; }
      set { _fontDark = value; }
    }

    /// <summary>
    /// Gets or sets the light color for the widget font.
    /// </summary>
    public Color FontLight
    {
      get { return _fontLight; }
      set { _fontLight = value; }
    }

    /// <summary>
    /// Gets or set the light color for windows like text boxes.
    /// </summary>
    public Color WindowDark
    {
      get { return _windowDark; }
      set { _windowDark = value; }
    }

    /// <summary>
    /// Gets or set the bright color for windows like text boxes.
    /// </summary>
    public Color WindowLight
    {
      get { return _windowLight; }
      set { _windowLight = value; }
    }

    /// <summary>
    /// Gets the font color that has more contrast on
    /// the given background color.
    /// </summary>
    /// <param name="background">The background color of the text.</param>
    /// <returns>Either the dark or light font color, depending on the given background color.</returns>
    public Color GetContrastFontColor(Color background)
    {
      return Color.GetContrastColor(background, _fontLight, _fontDark);
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
      Color.Black,
      Color.White,
      new Color(113, 113, 113),
      new Color(198, 198, 198));

  }
}
