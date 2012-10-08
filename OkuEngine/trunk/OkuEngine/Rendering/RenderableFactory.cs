﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Rendering
{
  public class RenderableFactory
  {
    public static RenderableFactory _instance = null;

    public static RenderableFactory Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new RenderableFactory();
        }
        return _instance;
      }
    }

    private delegate IRenderable RenderableCreatorDelegate();

    private Dictionary<string, RenderableCreatorDelegate> _creators = new Dictionary<string, RenderableCreatorDelegate>();

    private RenderableFactory()
    {
      _creators.Add("image", new RenderableCreatorDelegate(CreateRenderableImage));
      _creators.Add("line", new RenderableCreatorDelegate(CreateRenderableLines));
    }

    public IRenderable CreateRenderable(XmlNode node)
    {
      string type = node.Attributes.GetAttributeValue("type", null);
      if (type != null)
      {
        type = type.Trim().ToLower();
        if (_creators.ContainsKey(type))
        {
          return _creators[type]();
        }
      }
      return null;
    }

    private IRenderable CreateRenderableImage()
    {
      return new RenderableImage();
    }

    private IRenderable CreateRenderableLines()
    {
      return new RenderableLines();
    }

  }
}
