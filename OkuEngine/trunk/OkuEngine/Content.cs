using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public enum ContentType
  {
    /// <summary>
    /// Placeholder for nodes that do not contain content.
    /// </summary>
    None,
    /// <summary>
    /// Content is an image that will be rendered to the screen.
    /// </summary>
    Image,
    /// <summary>
    /// Content is a sound that can be played.
    /// </summary>
    Sound
  }

  /// <summary>
  /// Basic game content like sounds and images. User type content can also be created.
  /// </summary>
  public class Content
  {
    private ContentType _type = default(ContentType);
    private int _contentKey = 0;
    private VariableList _contentData = null;

    /// <summary>
    /// Creates a new content with the given 
    /// </summary>
    /// <param name="type">The type of content.</param>
    /// <param name="contentKey">The artificial content key.</param>
    public Content(ContentType type, int contentKey)
    {
      _type = type;
      _contentKey = contentKey;
    }

    /// <summary>
    /// Gets the type of the content.
    /// </summary>
    public ContentType Type
    {
      get { return _type; }
    }

    /// <summary>
    /// Gets the artificial content key.
    /// </summary>
    public int ContentKey
    {
      get { return _contentKey; }
    }

    /// <summary>
    /// Gets or sets the data for this content. What will be in this list depends on the type of content.
    /// Don't mess around with this unless you really know what you are doing.
    /// </summary>
    public VariableList ContentData
    {
      get 
      {
        if (_contentData == null)
          _contentData = new VariableList();
        return _contentData; 
      }
      set { _contentData = value; }
    }

  }
}
