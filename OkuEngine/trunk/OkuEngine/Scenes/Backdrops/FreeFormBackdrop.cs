using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Geometry;
using OkuEngine.Rendering;

namespace OkuEngine.Scenes.Backdrops
{
  public class FreeFormBackdrop : Backdrop
  {
    private IRenderable _renderable = null;
    private Polygon[] _shapes = null;

    public override Polygon[] Shapes
    {
      get { return _shapes; }
    }

    public override void Update(float dt)
    {
      if (_renderable != null)
        _renderable.Update(dt);
    }

    public override void Render(Scene scene)
    {
      if (_renderable != null)
        _renderable.Render(scene);        
    }

    public override bool Load(XmlNode node)
    {
      XmlNode renderNode = node["renderable"];
      if (renderNode != null)
      {
        _renderable = RenderableFactory.Instance.CreateRenderable(renderNode);
        if (_renderable == null)
          return false;
      }

      XmlNode shapesNode = node["shapes"];
      if (shapesNode != null)
      {
        List<Polygon> shapes = new List<Polygon>();
        XmlNode polyNode = node.FirstChild;
        while (polyNode != null)
        {
          if (polyNode.NodeType == XmlNodeType.Element && polyNode.Name.Trim().ToLower() == "polygon")
          {
            Polygon poly = new Polygon();
            if (!poly.Load(polyNode))
              return false;
            shapes.Add(poly);
          }

          polyNode = polyNode.NextSibling;
        }
        _shapes = shapes.ToArray();
      }

      if (_renderable == null && (_shapes == null || _shapes.Length == 0))
      {
        OkuManagers.Logger.LogError("FreeFormBackdrop has no shape and no renderable! " + node.OuterXml);
      }

      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      throw new NotImplementedException();
    }
  }
}
