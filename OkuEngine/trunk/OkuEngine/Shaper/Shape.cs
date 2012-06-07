using System;
using System.Collections.Generic;
using System.IO;

namespace OkuEngine.Shaper
{
  public static class Shape
  {
    public static void Save(string filename, Vector[] points, MemoryStream image)
    {
      PropertyMap props = new PropertyMap();

      if (image != null)
      {
        String imgString = Convert.ToBase64String(image.ToArray(), Base64FormattingOptions.None);
        props["image"] = imgString;
      }

      props["points"] = points.ToOkuString();

      props.Save(filename);
    }

    public static void Load(string filename, out Vector[] points, out MemoryStream image)
    {
      PropertyMap props = new PropertyMap();
      props.Load(filename);

      image = null;
      if (props.ContainsKey("image"))
      {
        byte[] imgBytes = Convert.FromBase64String(props["image"]);
        image = new MemoryStream(imgBytes);
      }

      points = null;
      if (props.ContainsKey("points"))
      {
        points = Converter.ParseVectors(props["points"]);
      }
    }

  }
}
