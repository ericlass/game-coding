using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scenes.Backdrops
{
  /// <summary>
  /// Defines a singleton factory for scene layer backdrops.
  /// </summary>
  public class BackdropFactory
  {
    private static BackdropFactory _instance = null;

    /// <summary>
    /// Gets the singleton instance of the backdrop factory.
    /// </summary>
    public static BackdropFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new BackdropFactory();
        return _instance;
      }
    }

    /// <summary>
    /// Constructor delegate for backdrops.
    /// </summary>
    /// <returns>A new backdrop.</returns>
    private delegate Backdrop BackdropCreatorDelegate();

    private Dictionary<string, BackdropCreatorDelegate> _creators = new Dictionary<string, BackdropCreatorDelegate>();

    /// <summary>
    /// Private constructor.
    /// </summary>
    private BackdropFactory()
    {
      _creators.Add("freeform", new BackdropCreatorDelegate(CreateImageBackdrop));
    }

    /// <summary>
    /// Creates a new backdrop and initializes it from the given XML node.
    /// </summary>
    /// <param name="node">The node with the backdrop configuration.</param>
    /// <returns>The newly created an initialised backdrop or null if something went wrong.</returns>
    public Backdrop CreateBackdrop(XmlNode node)
    {
      if (node != null && node.NodeType == XmlNodeType.Element && node.Name.Trim().ToLower() == "backdrop")
      {
        string type = node.Attributes.GetAttributeValue("type", null);
        if (type != null && _creators.ContainsKey(type))
        {
          Backdrop result = _creators[type]();
          result.Load(node);
          return result;
        }
        OkuManagers.Logger.LogError("Could not create backdrop. Unknown or no type given. " + node.OuterXml);
      }

      return null;
    }

    /// <summary>
    /// Creates a new image based backdrop.
    /// </summary>
    /// <returns>A new image based backdrop.</returns>
    private Backdrop CreateImageBackdrop()
    {
      return new FreeFormBackdrop();
    }

  }
}
