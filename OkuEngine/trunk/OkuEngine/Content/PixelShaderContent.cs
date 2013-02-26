using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine
{
  /// <summary>
  /// Defines a pixel shader.
  /// </summary>
  public class PixelShaderContent : StoreableEntity
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
    [JsonPropertyAttribute]
    public string Source
    {
      get { return _source; }
      set { _source = value; }
    }

    public override bool AfterLoad()
    {
      OkuManagers.Renderer.InitShaderContent(this);
      return true;
    }

  }
}
