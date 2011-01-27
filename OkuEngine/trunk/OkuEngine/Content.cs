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
    Sound,
    /// <summary>
    /// Content is used by the system and cannot be edited.
    /// </summary>
    System
  }

  /// <summary>
  /// Basic game content like sounds and images. User type content can also be created.
  /// </summary>
  public abstract class Content
  {
    private int _contentKey = KeySequence.NextValue;
    private VariableList _contentData = null;

    /// <summary>
    /// Creates a new content with the given 
    /// </summary>
    public Content()
    {
    }

    /// <summary>
    /// Gets the type of the content.
    /// </summary>
    public abstract ContentType Type { get; }

    /// <summary>
    /// Gets the artificial content key.
    /// </summary>
    public virtual int ContentKey
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
