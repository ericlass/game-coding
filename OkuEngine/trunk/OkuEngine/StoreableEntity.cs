using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Defines a base class for all entities in the engine that can be stored (load and saved).
  /// </summary>
  public class StoreableEntity : IStoreable
  {
    public const int InvalidId = 0;

    protected int _id = InvalidId;
    protected string _name = null;

    /// <summary>
    /// Gets the unique artificial id.
    /// </summary>
    public int Id
    {
      get { return _id; }
    }

    /// <summary>
    /// Sets the id of the entity.
    /// </summary>
    /// <param name="id">The new id of the entity.</param>
    internal void SetId(int id)
    {
      _id = id;
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    /// <summary>
    /// Loads id and name from the given xml node.
    /// </summary>
    /// <param name="node">The node to load from.</param>
    public virtual void Load(XmlNode node)
    {
      XmlNode child = node.FirstChild;
      while (child != null)
      {
        switch (child.Name.ToLower())
        {
          case "id":
            _id = int.Parse(child.FirstChild.Value);
            break;

          case "name":
            _name = child.FirstChild.Value;
            break;

          default:
            break;
        }
        child = child.NextSibling;
      }
    }

    /// <summary>
    /// Saves the id and name to the current position in the given xml writer.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    public virtual void Save(XmlWriter writer)
    {
      writer.WriteStartElement("id");
      writer.WriteValue(_id);
      writer.WriteEndElement();

      writer.WriteStartElement("name");
      writer.WriteValue(_name);
      writer.WriteEndElement();
    }

  }
}
