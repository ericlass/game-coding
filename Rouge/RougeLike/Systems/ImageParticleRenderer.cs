using System;
using System.Collections.Generic;
using OkuBase;
using OkuBase.Graphics;
using OkuBase.Particles;

namespace RougeLike.Systems
{
  public class ImageParticleRenderer : IParticleRenderer
  {
    private ImageBase _image = null;

    public ImageParticleRenderer(ImageBase image)
    {
      _image = image;
    }

    public void Render(List<Particle> particles)
    {
      foreach (Particle p in particles)
      {
        OkuManager.Instance.Graphics.DrawImage(_image, p.Position.X, p.Position.Y, 0, p.Scale, p.Scale, p.Color);
      }
    }

  }
}
