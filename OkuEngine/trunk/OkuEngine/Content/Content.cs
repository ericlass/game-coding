using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  /// <summary>
  /// Basic game content like sounds and images. User type content can also be created.
  /// </summary>
  public abstract class Content
  {
    private int _contentId = KeySequence.NextValue(KeySequence.ContentSequence);

    /// <summary>
    /// Creates a new content.
    /// </summary>
    public Content()
    {
    }

    /// <summary>
    /// Gets the artificial content id.
    /// </summary>
    public int ContentId
    {
      get { return _contentId; }
    }

  }
}
