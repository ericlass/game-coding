using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace OkuEngine
{
  /// <summary>
  /// Caches all content (images, sound etc) that are used by the game.
  /// </summary>
  public class ContentProvider
  {
    private Dictionary<string, Content> _content = new Dictionary<string, Content>();
    private int _nextContentKey = 0;

    public ContentProvider()
    {
    }

    /// <summary>
    /// Used to create a sequence of unique content keys.
    /// </summary>
    /// <returns>A new content key.</returns>
    private int GetNextContentKey()
    {
      _nextContentKey++;
      return _nextContentKey;
    }

    /// <summary>
    /// Creates a new content object with the correct data.
    /// </summary>
    /// <param name="type">The content type.</param>
    /// <returns>The new content type object.</returns>
    private Content GetNewContent(ContentType type, string name)
    {
      Content result = new Content(type, GetNextContentKey());
      result.ContentData.Set<string>("content.name", name);
      return result;
    }

    /// <summary>
    /// Gets image content lazily. If the content has been loaded before it is directly returned
    /// from the internal cache. If it is loaded the first time it is loaded, cached and then returned.
    /// </summary>
    /// <param name="name">The name of the image content to load.</param>
    /// <returns>The content or null if the content is not in the cache and cannot be loaded automatically.</returns>
    public Content GetImage(string name)
    {
      return Get(name, ContentType.Image);
    }

    /// <summary>
    /// Gets sound content lazily. If the content has been loaded before it is directly returned
    /// from the internal cache. If it is loaded the first time it is loaded, cached and then returned.
    /// </summary>
    /// <param name="name">The name of the sound content to load.</param>
    /// <returns>The content or null if the content is not in the cache and cannot be loaded automatically.</returns>
    public Content GetSound(string name)
    {
      return Get(name, ContentType.Sound);
    }

    /// <summary>
    /// Gets teh content with the specified name and type lazily. If the content has been loaded before it is directly returned
    /// from the internal cache. If it is loaded the first time it is loaded, cached and then returned.
    /// </summary>
    /// <param name="name">The name of the content.</param>
    /// <param name="type">The type of content.</param>
    /// <returns>The content or null if the content is not in the cache and cannot be loaded automatically.</returns>
    public Content Get(string name, ContentType type)
    {
      if (_content.ContainsKey(name))
      {
        return _content[name];
      }
      else
      {
        if (ContentExists(name))
        {
          Content result = GetNewContent(type, name);
          Stream data = GetBytes(name);

          if (type == ContentType.Image)
          {
            OkuInterfaces.Renderer.InitContent(result, data);
          }
          else if (type == ContentType.Sound)
          {
            OkuInterfaces.SoundEngine.InitContent(result, data);
          }

          data.Close();
          _content.Add(name, result);
          return result;
        }
        else
          return null;
      }
    }

    /// <summary>
    /// Removes the given content from the internal cache.
    /// </summary>
    /// <param name="content">The content to be removed.</param>
    /// <returns>True if the content was removed. False if the content is not cached.</returns>
    public bool Remove(Content content)
    {
      return _content.Remove(content.ContentData.Get<string>("content.name"));
    }

    /// <summary>
    /// Checks if the given content is currently cached in the internal cache.
    /// </summary>
    /// <param name="content">The content to be checked.</param>
    /// <returns>True the content is currently cached, else false.</returns>
    public bool Contains(Content content)
    {
      return _content.ContainsKey(content.ContentData.Get<string>("content.name"));
    }

    /// <summary>
    /// Gets the file path for the content with the given name.
    /// </summary>
    /// <param name="name">The name of the content.</param>
    /// <returns>The fully qualified path to the content.</returns>
    private string GetContentPath(string name)
    {
      return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "content\\" + name);
    }

    /// <summary>
    /// Gets the raw data of content from whatever source.
    /// </summary>
    /// <param name="name">The name of the content.</param>
    /// <returns>The content data as stream.</returns>
    public Stream GetBytes(string name)
    {
      return GetBytesInternal(name);
    }

    /// <summary>
    /// Gets the raw data of content. Can be overriden to load data from any source like
    /// hard disks, databases or some server on the internet.
    /// </summary>
    /// <param name="name">The of the content to be loaded.</param>
    /// <returns>The raw content data as a stream.</returns>
    protected Stream GetBytesInternal(string name)
    {
      return new FileStream(GetContentPath(name), FileMode.Open);
    }

    /// <summary>
    /// Used internally to check if a given content exists and can be loaded.
    /// Must be overriden too if <code>GetBytesInternal</code> is overriden.
    /// </summary>
    /// <param name="name">The name of the content.</param>
    /// <returns>True if the content exists, else false.</returns>
    protected bool ContentExists(string name)
    {
      return File.Exists(GetContentPath(name));
    }

  }
}
