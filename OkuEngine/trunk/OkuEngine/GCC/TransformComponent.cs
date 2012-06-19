using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.GCC
{
  public class TransformComponent : ActorComponent
  {
    public const int ComponentId = 2;
    public const string ComponentName = "transform";

    public Vector _position = Vector.Zero;
    public Vector _scale = Vector.Zero;
    public float _rotation = 0.0f;

    public override int GetComponentId()
    {
      return ComponentId;
    }

    public override bool Init(XmlNode node)
    {
      if (node.Name != ComponentName)
        return false;

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name)
        {
          case "position":
            _position.X = child.Attributes.GetFloat("x", 0.0f);
            _position.Y = child.Attributes.GetFloat("y", 0.0f);
            break;

          case "scale":
            _scale.X = child.Attributes.GetFloat("x", 0.0f);
            _scale.Y = child.Attributes.GetFloat("y", 0.0f);
            break;

          case "rotation":
            _rotation = child.Attributes.GetFloat("angle", 0.0f);
            break;

          default:
            break;
        }

        child = child.NextSibling;
      }

      return true;
    }

    public Vector Position 
    {
      get { return _position; }
      set { _position = value; }
    }
    public Vector Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }
    public float Rotation
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

  }
}
