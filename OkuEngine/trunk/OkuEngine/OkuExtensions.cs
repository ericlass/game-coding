using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace OkuEngine
{
  public static class OkuExtensions
  {
    /// <summary>
    /// Calculates a random float value in the range [-1.0,+1.0].
    /// </summary>
    /// <param name="rand">The random number generator to use.</param>
    /// <returns>A random float value in the range [-1.0,+1.0].</returns>
    public static float RandomFloat(this Random rand)
    {
      return (float)rand.NextDouble() * 2.0f - 1.0f;
    }

    /// <summary>
    /// Converts the vector array to a string.
    /// </summary>
    /// <param name="vectors">The vector array to be converted.</param>
    /// <returns>The string representation of the vector array.</returns>
    public static string ToOkuString(this Vector[] vectors)
    {
      StringBuilder builder = new StringBuilder();
      for (int i = 0; i < vectors.Length; i++)
      {
        if (i > 0)
          builder.Append(";");
        builder.Append(vectors[i].ToString());
      }
      return builder.ToString();
    }

    /// <summary>
    /// Converts the color array to a string.
    /// </summary>
    /// <param name="colors">The color array to convert.</param>
    /// <returns>A string representation of the color array.</returns>
    public static string ToOkuString(this Color[] colors)
    {
      StringBuilder builder = new StringBuilder();
      for (int i = 0; i < colors.Length; i++)
      {
        if (i > 0)
          builder.Append(";");
        builder.Append(colors[i].ToString());
      }
      return builder.ToString();
    }

    /// <summary>
    /// Calculates the point in the array that is closest to the given point.
    /// </summary>
    /// <param name="vectors">The array of vectors.</param>
    /// <param name="point">The point to find the closest point for.</param>
    /// <param name="distance">The distance is of the closest point is returned here.</param>
    /// <returns>The index of the closest point. -1 if vectors does not contain any points.</returns>
    public static int ClosestPoint(this Vector[] vectors, Vector point, out float distance)
    {
      distance = 0.0f;

      int closest = -1;
      float nearest = float.MaxValue;
      for (int i = 0; i < vectors.Length; i++)
      {
        float dist = (vectors[i] - point).Magnitude;
        if (dist < nearest)
        {
          nearest = dist;
          closest = i;
        }
      }
      distance = nearest;
      return closest;
    }

    /// <summary>
    /// Gets the value of the attribute with the given name.
    /// If there is no attribute with the given name, the given default is returned.
    /// </summary>
    /// <param name="attributes">The attributes to search in.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="defaultIfNull">The default value.</param>
    /// <returns>The value of the attribute, or the given default value if there is 
    /// no attribute with the given name.</returns>
    public static string GetAttributeValue(this XmlAttributeCollection attributes, string name, string defaultIfNull)
    {
      string result = defaultIfNull;
      foreach (XmlAttribute attrib in attributes)
      {
        if (attrib.Name == name)
        {
          result = attrib.Value;
          break;
        }
      }
      return result;
    }

    /// <summary>
    /// Gets the attribute with the given name in float format.
    /// If there is no attribute with the given name or its value cannot be
    /// converted to a float, the given default is returned.
    /// </summary>
    /// <param name="attributes">The attributes to search in.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="defaultIfNull">The default value.</param>
    /// <returns>The float value of the attribute, or the given default value if there is 
    /// no attribute with the given name or its value cannot be converted to a float.</returns>
    public static float GetFloat(this XmlAttributeCollection attributes, string name, float defaultIfNull)
    {
      string value = attributes.GetAttributeValue(name, null);
      if (value != null)
      {
        return Converter.StrToFloat(value);
      }
      return defaultIfNull;
    }

    /// <summary>
    /// Gets the attribute with the given name in int format.
    /// If there is no attribute with the given name or its value cannot be
    /// converted to a int, the given default is returned.
    /// </summary>
    /// <param name="attributes">The attributes to search in.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="defaultIfNull">The default value.</param>
    /// <returns>The int value of the attribute, or the given default value if there is 
    /// no attribute with the given name or its value cannot be converted to a int.</returns>
    public static int GetInt(this XmlAttributeCollection attributes, string name, int defaultIfNull)
    {
      string value = attributes.GetAttributeValue(name, null);
      if (value != null)
      {
        int result = 0;
        if (int.TryParse(value, out result))
          return result;
      }
      return defaultIfNull;
    }

    /// <summary>
    /// Removes the item at index 0 and returns it.
    /// </summary>
    /// <typeparam name="T">The type if the list.</typeparam>
    /// <param name="list">The list to change.</param>
    /// <returns>The item at index 0.</returns>
    public static T PopFirst<T>(this List<T> list)
    {
      if (list.Count > 0)
      {
        T result = list[0];
        list.RemoveAt(0);
        return result;
      }
      return default(T);
    }

    /// <summary>
    /// Removes the item at the end of the list and returns it.
    /// </summary>
    /// <typeparam name="T">The type if the list.</typeparam>
    /// <param name="list">The list to change.</param>
    /// <returns>The item at the end of the list.</returns>
    public static T PopLast<T>(this List<T> list)
    {
      if (list.Count > 0)
      {
        int index = list.Count - 1;
        T result = list[index];
        list.RemoveAt(index);
        return result;
      }
      return default(T);
    }

    /// <summary>
    /// Gets the value between the opening and the closing tag.
    /// </summary>
    /// <param name="node">The node to read from.</param>
    /// <param name="name">The name of the child tag to read the value from.</param>
    /// <returns>The value of the tag or null if there is no such tag.</returns>
    public static string GetTagValue(this XmlNode node, string name)
    {
      XmlNode child = node[name];
      if (child != null && child.FirstChild != null)
        return child.FirstChild.Value;

      return null;
    }

    /// <summary>
    /// Gets the dotted path of the given XML node as a string.
    /// The name of the node itself is included.
    /// </summary>
    /// <param name="node">The node the get the path for.</param>
    /// <returns>The dotted path of the given node.</returns>
    public static string GetPath(this XmlNode node)
    {
      XmlNode parent = node;
      StringBuilder builder = new StringBuilder();
      bool first = true;
      while (parent != null && parent.NodeType != XmlNodeType.Document)
      {
        if (first)
          first = false;
        else
          builder.Append(".");

        builder.Insert(0, parent.Name.ToLower());        
        parent = parent.ParentNode;
      }

      return builder.ToString();
    }

    /// <summary>
    /// Writes and openening tag, a value and a closing tag in one step.
    /// </summary>
    /// <param name="writer">The writer to use.</param>
    /// <param name="name">The of the tag to write.</param>
    /// <param name="value">The value to write into the tag.</param>
    public static void WriteValueTag(this XmlWriter writer, string name, string value)
    {
      writer.WriteStartElement(name);
      writer.WriteValue(value);
      writer.WriteEndElement();
    }

  }
}
