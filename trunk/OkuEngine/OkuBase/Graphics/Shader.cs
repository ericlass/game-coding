using System;
using System.Collections.Generic;
using System.Text;

namespace OkuBase.Graphics
{
  public class Shader
  {
    private int _id = KeySequence.NextValue(KeySequence.ShaderSequence);
    protected ShaderType _shaderType = ShaderType.None;
    protected string _source = null;

    public Shader(string source, ShaderType shaderType)
    {
      _source = source;
      _shaderType = shaderType;
    }

    public int Id
    {
      get { return _id; }
    }

    public string Source
    {
      get { return _source; }
    }

    public ShaderType ShaderType
    {
      get { return _shaderType; }
    }

  }
}
