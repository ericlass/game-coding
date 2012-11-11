using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines a pixel shader.
  /// </summary>
  public class PixelShaderContent : Content
  {
    private string _source = null;

    /// <summary>
    /// Create a new pixel shader with the given shader source.
    /// </summary>
    /// <param name="source"></param>
    public PixelShaderContent(String source)
    {
      _source = source;
      OkuManagers.Renderer.InitShaderContent(this);
    }

    /// <summary>
    /// Gets the source of the pixel shader.
    /// </summary>
    public string Source
    {
      get { return _source; }
    }

  }
}
