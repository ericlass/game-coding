using System;
using System.Collections.Generic;
using System.Threading;
using OkuEngine;

namespace OkuTest
{
  public class AnimationTestGame : OkuGame
  {
    private Animation _anim = null;
    private Animation _coin = null;

    public override void Initialize()
    {
      _anim = new Animation();
      _anim.Loop = true;
      
      ImageContent image = new ImageContent(".\\content\\impact0.png");
      _anim.Frames.Add(new AnimationFrame(image.Id, 100));

      image = new ImageContent(".\\content\\impact1.png");
      _anim.Frames.Add(new AnimationFrame(image.Id, 100));

      image = new ImageContent(".\\content\\impact2.png");
      _anim.Frames.Add(new AnimationFrame(image.Id, 100));

      _coin = new Animation();
      _coin.Loop = true;

      List<ImageContent> images = ImageContent.LoadSheet(".\\content\\coin_animation.png", 64);
      for (int i = 0; i < images.Count - 1; i++)
      {
        _coin.Frames.Add(new AnimationFrame(images[i].Id, 50));
      }
    }

    public override void Update(float dt)
    {
      _anim.Update(dt);
      _coin.Update(dt);

      //Thread.Sleep(400);
    }

    public override void Render(int pass)
    {
      OkuManagers.Renderer.DrawImage(_coin.CurrentImage, Vector2f.Zero);
      OkuManagers.Renderer.DrawImage(_anim.CurrentImage, Vector2f.Zero);
    }

  }
}
