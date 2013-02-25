using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Driver.Renderer
{
  /// <summary>
  /// Defines a factor that can be used to create a renderer from an XML node.
  /// </summary>
  public class RendererFactory
  {
    private static RendererFactory _instance = null;

    public static RendererFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new RendererFactory();
        return _instance;
      }
    }

    private delegate IRenderer CreateRendererDelegate();

    private Dictionary<string, CreateRendererDelegate> _rendererCreators = new Dictionary<string, CreateRendererDelegate>();

    /// <summary>
    /// Create a new renderer factory.
    /// </summary>
    private RendererFactory()
    {
      _rendererCreators.Add(NullRenderer.RendererName, new CreateRendererDelegate(CreateNullRenderer));
      _rendererCreators.Add(OpenGLRenderer.RendererName, new CreateRendererDelegate(CreateOpenGlRenderer));
    }

    /// <summary>
    /// Creates a new renderer from the given XML node.
    /// </summary>
    /// <param name="rendererNode">The node containing the renderer configuration.</param>
    /// <returns>The created renderer or null if the renderer could not be created.</returns>
    public IRenderer CreateRenderer(RenderSettings settings)
    {
      IRenderer result = null;

      if (_rendererCreators.ContainsKey(settings.Type))
      {
        result = _rendererCreators[settings.Type]();
        result.Initialize(settings);
      }

      return result;
    }

    /// <summary>
    /// Constructor for OpenGL renderers.
    /// </summary>
    /// <returns>A new OpenGL renderer.</returns>
    internal IRenderer CreateOpenGlRenderer()
    {
      return new OpenGLRenderer();
    }

    /// <summary>
    /// Constructor for NULL renderers.
    /// </summary>
    /// <returns>A new NULL renderer.</returns>
    internal IRenderer CreateNullRenderer()
    {
      return new NullRenderer();
    }

  }
}
