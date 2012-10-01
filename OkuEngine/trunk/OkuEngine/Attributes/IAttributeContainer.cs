using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Attributes
{
  /// <summary>
  /// Defines the members that are necessary for an attribute container.
  /// </summary>
  public interface IAttributeContainer
  {
    /// <summary>
    /// Gets the attribute definition with the given id.
    /// If no definition is found with the given id, null is returned.
    /// </summary>
    /// <param name="id">The id of the attribute definition.</param>
    /// <returns>The attribute definition wit the given id or null if there is no definition with that id.</returns>
    AttributeDefinition GetAttributeDefinition(int id);
  }
}
