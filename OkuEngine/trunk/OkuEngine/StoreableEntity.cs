﻿using System;
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
    public virtual bool Load(XmlNode node)
    {
      string value = node.GetTagValue("id");
      if (value != null)
      {
        int test = 0;
        if (int.TryParse(value, out test))
          _id = test;
        else
          return false;
      }

      _name = node.GetTagValue("name");

      return _id != InvalidId;
    }

    /// <summary>
    /// Saves the id and name to the current position in the given xml writer.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    public virtual bool Save(XmlWriter writer)
    {
      writer.WriteValueTag("id", _id.ToString());
      writer.WriteValueTag("name", _name);

      return true;
    }

  }
}