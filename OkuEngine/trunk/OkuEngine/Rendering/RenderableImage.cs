using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using OkuEngine.Scenes;

namespace OkuEngine.Rendering
{
  public class RenderableImage : IRenderable
  {
    private ImageContent _image = null;
    private int _imageId = 0;

    private AABB _boundingBox = new AABB();
    private bool _aabbValid = false;

    public void Update(float dt)
    {
      //Nothing to do for an image
    }

    public void Render(Scene scene)
    {
      if (_image != null)
        OkuManagers.Renderer.DrawImage(_image, Vector.Zero);
    }

    public AABB GetBoundingBox()
    {
      if (!_aabbValid)
      {
        _boundingBox = new AABB(_image.Width * -0.5f, _image.Height  * -0.5f, _image.Width, _image.Height);
        _aabbValid = true;
      }
      return _boundingBox;
    }

    public bool Load(XmlNode node)
    {
      _aabbValid = false;

      string value = node.GetTagValue("image");
      if (value != null)
      {
        int imageId = 0;
        if (int.TryParse(value, out imageId))
        {
          _imageId = imageId;
          _image = OkuData.Images[_imageId];
          if (_image == null)
          {
            OkuManagers.Logger.LogError("There is no image with the id " + imageId + "! " + node.OuterXml);
            return false;
          }
        }
        else
        {
          OkuManagers.Logger.LogError("The image id " + imageId + " is not a valid number! " + node.OuterXml);
          return false;
        }
      }
      else
      {
        OkuManagers.Logger.LogError("No image given for image renderable! " + node.OuterXml);
        return false;
      }      

      return true;
    }

    public bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("renderable");

      writer.WriteStartAttribute("type");
      writer.WriteValue("image");
      writer.WriteEndAttribute();

      writer.WriteValueTag("image", _imageId.ToString());

      writer.WriteEndElement();

      return true;
    }

  }
}
