using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SimGame.Content
{
  public class ContentCache
  {
    private string _baseFolder = null;
    private Dictionary<Type, string> _typeFolders = null;
    private Dictionary<Type, Dictionary<string, object>> _cache = null;

    public ContentCache(string baseFolder)
    {
      _baseFolder = baseFolder;
      _typeFolders = new Dictionary<Type, string>();
      _cache = new Dictionary<Type, Dictionary<string, object>>();
    }

    public void RegisterType(Type t, string folder)
    {
      if (_typeFolders.ContainsKey(t))
        throw new ArgumentException("Content Type " + t + " already registered!");

      _typeFolders.Add(t, folder);
    }

    public T Get<T>(string id) where T : IContent, new()
    {
      Type t = typeof(T);
      if (!_typeFolders.ContainsKey(t))
        throw new ArgumentException("Content type " + t + " has not been registered!");

      string path = Path.Combine(_baseFolder, _typeFolders[t], id);
      //TODO: Load JSON file

      T result = Activator.CreateInstance<T>();
      result.Load(); //TODO: Pass JSON content

      return result;
    }

  }
}
