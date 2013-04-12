using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OkuEngine.States
{
  /// <summary>
  /// Defines the interface for a state component.
  /// </summary>
  [JsonObjectAttribute(MemberSerialization.OptIn)]
  public interface IStateComponent : IStoreable
  {
    /// <summary>
    /// Gets or sets the ownering state of the component.
    /// </summary>
    State Owner { get; set; }

    /// <summary>
    /// Gets the name of the component type. This must be a
    /// unique identifier as it is used in the XML.
    /// </summary>
    string ComponentTypeName { get; }
  }
}
