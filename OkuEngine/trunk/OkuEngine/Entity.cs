using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class Entity
  {
    public const int InvalidId = 0;

    protected int _id = InvalidId;
    
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

  }
}
