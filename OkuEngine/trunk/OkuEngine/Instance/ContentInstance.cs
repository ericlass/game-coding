using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Base class for content instances.
  /// </summary>
  public class ContentInstance
  {
    private int _instanceId = KeySequence.NextValue(KeySequence.ContentInstanceSequence);

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public ContentInstance()
    {
    }

    /// <summary>
    /// Gets the artificial instance id.
    /// </summary>
    public int InstanceId
    {
      get { return _instanceId; }
    }
  }
}
