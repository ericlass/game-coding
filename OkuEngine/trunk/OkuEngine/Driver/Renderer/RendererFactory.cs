using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Driver.Renderer
{
  public class RendererFactory
  {
    private delegate IRenderer CreateRendererDelegate();

    private Dictionary<string, CreateRendererDelegate> _rendererCreators = new Dictionary<string, CreateRendererDelegate>();

    public RendererFactory()
    {
      _rendererCreators.Add(NullRenderer.RendererName, new CreateRendererDelegate(CreateNullRenderer));
      _rendererCreators.Add(OpenGLRenderer.RendererName, new CreateRendererDelegate(CreateOpenGlRenderer));
    }

    public IRenderer CreateRenderer(XmlNode rendererNode)
    {
      string type = rendererNode.Attributes.GetAttributeValue("type", OpenGLRenderer.RendererName);
      IRenderer result = null;

      if (_rendererCreators.ContainsKey(type))
      {
        result = _rendererCreators[type]();
        result.Initialize(rendererNode);
      }

      return result;
    }

    internal IRenderer CreateOpenGlRenderer()
    {
      return new OpenGLRenderer();
    }

    internal IRenderer CreateNullRenderer()
    {
      return new NullRenderer();
    }

  }
}
