﻿using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using RougeLike.Objects;
using RougeLike.Attributes;

namespace RougeLike.Renderers
{
  public class DirectedImageRenderer : IEntityRenderer
  {
    private string _imageName = null;

    public DirectedImageRenderer(string imageName)
    {
      get { return _imageName; }
      set { _imageName = value; }
    }
      float direction = entity.GetAttributeValue<NumberValue>("direction").Value;
      OkuBase.OkuManager.Instance.Graphics.DrawImage(_image, 0, 0, 0, direction, 1, Color.White);
  }
}