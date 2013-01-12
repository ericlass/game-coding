using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using OkuEngine;

namespace OkuTest
{
  public class NoiseTestGame : OkuGame
  {
    private PerlinNoise _noise = new PerlinNoise(1);
    private float _zoom = 100.0f;
    private int _octaves = 5;

    private ImageContent _content = null;

    private Bitmap GetNoiseTexture(float zoom)
    {
      Bitmap image = new Bitmap(512, 512, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      BitmapData data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

      int i = 0;
      int x = 0;
      int y = 0;
      unsafe
      {
        int* p = (int*)data.Scan0.ToPointer();
        float min = float.MaxValue;
        float max = float.MinValue;

        while (i < (image.Width * image.Height))
        {

          x = i % image.Width;
          y = i / image.Width;

          /*float dens = y - 128;
          dens += ((_noise.Noise(x, y, _octaves, _zoom) + 1.0f) / 2.0f) * 60;
          int value = (int)Math.Max(0, Math.Min(255, dens));

          if (value >= 128)
            value = 255;
          if (value < 128)
            value = 0;*/

          float noise = _noise.Noise(x, y, _octaves, _zoom);
          min = Math.Min(min, noise);
          max = Math.Max(max, noise);
          int value = Math.Max(0, Math.Min(255, (int)(noise * 128 + 128)));

          *p = System.Drawing.Color.FromArgb(value, value, value).ToArgb();

          p++;
          i++;
        }

        OkuManagers.Renderer.Display.Text = "Min: " + min + "; Max: " + max;
      }

      image.UnlockBits(data);

      return image;
    }
    
    public override void Initialize()
    {
      _content = new ImageContent(GetNoiseTexture(_zoom));
    }

    public override void Update(float dt)
    {
      float zoomFactor = 1.2f;
      bool zoomed = false;

      if (OkuManagers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Add))
      {
        _zoom *= zoomFactor;
        zoomed = true;
      }
      if (OkuManagers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Subtract))
      {
        _zoom /= zoomFactor;
        zoomed = true;
      }
      if (OkuManagers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Divide))
      {
        _octaves -= 1;
        zoomed = true;
      }
      if (OkuManagers.Input.Keyboard.KeyPressed(System.Windows.Forms.Keys.Multiply))
      {
        _octaves += 1;
        zoomed = true;
      }

      if (zoomed)
        _content.Update(0, 0, _content.Width, _content.Height, GetNoiseTexture(_zoom));
    }

    public override void Render(int pass)
    {
      OkuManagers.Renderer.DrawImage(_content, Vector2f.Zero);
      OkuManagers.Renderer.DrawPoint(Vector2f.Zero, 3, OkuEngine.Color.Red);
    }

  }
}
