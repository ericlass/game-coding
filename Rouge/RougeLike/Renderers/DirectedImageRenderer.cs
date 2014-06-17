using System;
using System.Collections.Generic;
using OkuBase.Graphics;
using RougeLike.Objects;
using RougeLike.Attributes;

namespace RougeLike.Renderers
{
  public class DirectedImageRenderer : IEntityRenderer
  {
    private string _imageName = null;    private Image _image = null;

    public DirectedImageRenderer(string imageName)    {      _imageName = imageName;    }    public string ImageName
    {
      get { return _imageName; }
      set { _imageName = value; }
    }      public void Init()    {      _image = GameUtil.LoadImage(_imageName);    }        public void Begin(EntityObject entity)    {    }        public void Update(float dt, EntityObject entity)    {    }        public void Render(EntityObject entity)    {
      float direction = entity.GetAttributeValue<NumberValue>("direction").Value;
      OkuBase.OkuManager.Instance.Graphics.DrawImage(_image, 0, 0, 0, direction, 1, Color.White);    }        public void End(EntityObject entity)    {    }        public void Finish()    {      OkuBase.OkuManager.Instance.Graphics.ReleaseImage(_image);    }
  }
}
