using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using OkuBase;
using OkuBase.Graphics;
using JSONator;

namespace SimGame.Content
{
  /// <summary>
  /// General content cache for the game. You provide a base folder
  /// and then load the different content using the corresponding methods.
  /// </summary>
  public class ContentCache
  {
    private string _baseFolder = null;
    private Dictionary<string, Dictionary<string, object>> _cache = null; //Maps content types to map of content ids to actual content

    /// <summary>
    /// Creates a new content cache with the given base folder.
    /// </summary>
    /// <param name="baseFolder"></param>
    public ContentCache(string baseFolder)
    {
      _baseFolder = baseFolder;
      _cache = new Dictionary<string, Dictionary<string, object>>();
    }

    public void Clear()
    {
      _cache.Clear();
      //TODO: Somehow clean up resource like OpenGL Images!
    }

    private T GetContent<T>(string id, string folder, Func<string, T> loader)
    {
      if (!_cache.ContainsKey(folder))
        _cache.Add(folder, new Dictionary<string, object>());

      if (_cache[folder].ContainsKey(id))
        return (T)(_cache[folder][id]);

      string path = Path.Combine(_baseFolder, folder, id);
      if (!File.Exists(path))
        throw new FileNotFoundException("Content file not found: " + path);

      T result = loader(path);

      _cache[folder].Add(id, result);

      return result;
    }

    public Image GetImage(string id)
    {
      return GetContent<Image>(id, "images",
        delegate(string path)
        {
          ImageData data = ImageData.FromFile(path);
          return OkuManager.Instance.Graphics.NewImage(data);
        }
      );
    }

    private JSONObject GetJson(string folder, string id)
    {
      return GetContent<JSONObject>(id, folder,
        delegate(string path)
        {
          StreamReader reader = new StreamReader(path);
          string jsonStr = reader.ReadToEnd();
          reader.Close();

          JSONParser parser = new JSONParser();
          return parser.Parse(jsonStr);
        }
      );
    }

  }
}
