﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Driver.Renderer;

namespace OkuEngine.Actors.Components
{
  public abstract class RenderComponent : ActorComponent
  {
    public const int ComponentId = 2;
    public const string ComponentName = "renderable";

    protected Vector[] _points = null;
    protected Vector[] _texCoords = null;
    protected Color[] _colors = null;
    protected DrawMode _mode = DrawMode.None;
    protected int _image = 0;

    public Vector[] Points
    {
      get { return _points; }
      set { _points = value; }
    }

    public Vector[] TexCoords
    {
      get { return _texCoords; }
      set { _texCoords = value; }
    }

    public Color[] Colors
    {
      get { return _colors; }
      set { _colors = value; }
    }

    public DrawMode Mode
    {
      get { return _mode; }
      set { _mode = value; }
    }

    public int Image
    {
      get { return _image; }
      set { _image = value; }
    }

    public override int GetComponentId()
    {
      return ComponentId;
    }

    public abstract bool PreRender();
    public abstract bool PostRender();

    public abstract override bool Load(XmlNode node);
    public abstract override bool Save(XmlWriter writer);

  }
}
