﻿using System;
using System.Collections.Generic;
using System.Text;
using OkuBase;

namespace OkuBase.Graphics
{
  public class ShaderProgram
  {
    private int _id = KeySequence.NextValue(KeySequence.ProgramSequence);
    private Shader _vertexShader = null;
    private Shader _pixelShader = null;

    internal ShaderProgram(Shader vertexShader, Shader pixelShader)
    {
      if (vertexShader == null || pixelShader == null)
        throw new OkuException("Both vertex and pixel shader must be given for a shader program!");

      if (vertexShader.ShaderType != ShaderType.VertexShader)
        throw new OkuException("Trying to set a " + vertexShader.ShaderType + " as a VertexShader! ID: " + vertexShader.Id);

      if (pixelShader.ShaderType != ShaderType.PixelShader)
        throw new OkuException("Trying to set a " + pixelShader.ShaderType + " as a PixelShader! ID: " + pixelShader.Id);

      _vertexShader = vertexShader;
      _pixelShader = pixelShader;
    }

    public int Id
    {
      get { return _id; }
    }

    public Shader VertexShader
    {
      get { return _vertexShader; }
    }

    public Shader PixelShader
    {
      get { return _pixelShader; }
    }

  }
}
