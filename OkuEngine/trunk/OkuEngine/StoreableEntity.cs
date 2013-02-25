using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine
{
  /// <summary>
  /// Defines a base class for all entities in the engine that can be stored (load and saved).
  /// </summary>
  public abstract class StoreableEntity : IStoreable
  {
    public const int InvalidId = 0;

    protected string _name = null;
    protected int _id = InvalidId;

    /// <summary>
    /// Gets the unique artificial id.
    /// </summary>
    [JsonPropertyAttribute]
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [JsonPropertyAttribute]
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public abstract bool AfterLoad();

  }
}
