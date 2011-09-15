using System;
using System.Collections.Generic;
using System.Drawing;
using OkuEngine;

namespace OkuTest
{
  public class NoiseTestGame : OkuGame
  {
    private PerlinNoise _noise = new PerlinNoise(3);
    private float _zoom = 1.0f;
    private int _octaves = 5;

    private ImageContent _content = null;

    private Bitmap GetNoiseTexture(float zoom)
    {
      Bitmap image = new Bitmap(512, 512, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      for (int y = 0; y < image.Height; y++)
      {
        float zy = y / zoom;
        for (int x = 0; x < image.Width; x++)
        {
          float zx = x / zoom;

          /*float dens = y - 128;
          dens += _noise.Noise(zx, zy, _octaves) * 20;
          int value = (int)Math.Max(0, Math.Min(255, dens));*/

          int value = Math.Max(0, Math.Min(255, (int)(_noise.Noise(zx, zy, _octaves) * 128 + 128)));

          /*if (value >= 128)
            value = 255;
          if (value < 128)
            value = 0;*/

          image.SetPixel(x, y, System.Drawing.Color.FromArgb(value, value, value));
        }
      }
      return image;
    }
    
    public override void Initialize()
    {
      _content = new ImageContent(GetNoiseTexture(_zoom));
      OkuDrivers.Renderer.MainForm.Text = "Done";
    }

    public override void Update(float dt)
    {
      float zoomFactor = 1.2f;
      bool zoomed = false;

      if (OkuDrivers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Add))
      {
        _zoom *= zoomFactor;
        zoomed = true;
      }
      if (OkuDrivers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Subtract))
      {
        _zoom /= zoomFactor;
        zoomed = true;
      }

      if (zoomed)
      {
        _content.Update(0, 0, _content.Width, _content.Height, GetNoiseTexture(_zoom));
      }
    }

    public override void Render()
    {
      OkuDrivers.Renderer.DrawImage(_content, Vector.Zero);
      OkuDrivers.Renderer.DrawPoint(Vector.Zero, 3, OkuEngine.Color.Red);
    }

  }
}
