using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class PixelShaderContent : Content
  {
    private string _source = null;

    public PixelShaderContent(String source)
    {
      _source = source;
      OkuManagers.Renderer.InitShaderContent(this);
    }

    public string Source
    {
      get { return _source; }
    }

  }
}
