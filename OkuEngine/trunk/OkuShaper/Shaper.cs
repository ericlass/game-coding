using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OkuEngine;

namespace OkuShaper
{
  public class Shaper : OkuGame
  {
    public override void Setup(ref RendererParams renderParams)
    {
      renderParams.ClearColor = Color.White;
      renderParams.Width = 1280;
      renderParams.Height = 800;
    }

    public override void Initialize()
    {
    }

    public override void Update(float dt)
    {
      
    }

    public override void Render(int pass)
    {
      
    }

  }
}
