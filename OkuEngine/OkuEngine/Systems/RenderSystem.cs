using System;
using OkuBase;
using OkuBase.Graphics;
using OkuEngine.Assets;
using OkuEngine.Levels;

namespace OkuEngine.Systems
{
  public class RenderSystem : GameSystem
  {
    public const string VertexShaderSource = 
      "void main()\n" +
      "{\n" +
      "  gl_Position    = gl_ModelViewProjectionMatrix * gl_Vertex;\n" +
      "  gl_FrontColor  = vec4(1.0, 1.0, 1.0, 1.0);\n" +
      "  gl_TexCoord[0] = gl_MultiTexCoord0;\n" +
      "}";

    public const string FragmentShaderSource =
      "uniform sampler2D texture;\n" +
      "uniform vec4 tint;\n" +
      "void main()\n" +
      "{\n" +
      "  vec4 texColor = texture2D(texture, gl_TexCoord[0]);\n" +
      "  gl_FragColor = texColor * tint;\n" +
      "}";

    public override void Init()
    {
      Shader vertexShader = new Shader(VertexShaderSource, ShaderType.VertexShader);
      Shader fragmentShader = new Shader(FragmentShaderSource, ShaderType.PixelShader);

      ShaderProgram shader = OkuManager.Instance.Graphics.NewShaderProgram(vertexShader, fragmentShader);

      OkuManager.Instance.Graphics.Shader = shader;
    }

    public override void Execute(Level currentLevel)
    {
      GraphicsManager graphics = OkuManager.Instance.Graphics;

      try
      {
        currentLevel.RenderQueue.Sort(CompareRenderTasks);

        int lastMeshId = -1;
        int meshPointCount = -1;
        int lastMatId = -1;
        //Iterate render queue and execute render tasks
        foreach (var task in currentLevel.RenderQueue)
        {
          if (task.Mesh > 0)
          {
            if (lastMeshId != task.Mesh)
            {
              MeshAsset mesh = currentLevel.Assets.GetAsset<MeshAsset>(task.Mesh);

              graphics.VertexPositions = mesh.Positions;
              graphics.VertexTexCoords = mesh.TexCoords;
              graphics.VertexColors = mesh.Colors;
              graphics.PrimitiveType = mesh.PrimitiveType;

              lastMeshId = task.Mesh;
              meshPointCount = mesh.Positions.Length;
            }

            graphics.ScreenSpace = task.ScreenSpace;

            if (task.Material > 0)
            {
              if (lastMatId != task.Material)
              {
                var material = currentLevel.Assets.GetAsset<MaterialAsset>(task.Material);

                if (material.Texture > 0)
                {
                  var texture = currentLevel.Assets.GetAsset<ImageAsset>(material.Texture);
                  graphics.SetShaderValue("texture", texture.Image);
                }

                graphics.SetShaderValue("tint", material.Tint.R / 255.0f, material.Tint.G / 255.0f, material.Tint.B / 255.0f, material.Tint.A / 255.0f);

                lastMatId = task.Material;
              }
            }

            graphics.PushTransform();

            graphics.Translation = task.Translation;
            graphics.Scale = task.Scale;
            graphics.Angle = task.Angle;

            graphics.Draw(0, meshPointCount);

            graphics.PopTransform();
          }


        }
      }
      finally
      {
        currentLevel.RenderQueue.Clear();
      }
    }

    private static int CompareRenderTasks(RenderTask x, RenderTask y)
    {
      if (x == null)
      {
        if (y == null)
        {
          return 0;
        }
        else
        {
          return -1;
        }
      }
      else
      {
        if (y == null)
        {
          return 1;
        }
        else
        {
          int diff = x.Layer - y.Layer;
          if (diff != 0)
            return diff;

          diff = CompareAssetHandles(x.Mesh, y.Mesh);
          if (diff != 0)
            return diff;

          return CompareAssetHandles(x.Material, y.Material);
        }
      }
    }

    private static int CompareAssetHandles(int x, int y)
    {
      return x - y;
    }

  }
}
