using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONator
{
  /// <summary>
  /// Base class for all JSON values.
  /// </summary>
  public abstract class JSONValue
  {
    /// <summary>
    /// Gets the type of the value this JSON value stores.
    /// </summary>
    public abstract JSONValueType ValueType { get; }
  }
}
