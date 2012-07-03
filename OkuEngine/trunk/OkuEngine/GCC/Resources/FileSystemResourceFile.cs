using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OkuEngine.GCC.Resources
{
  public class FileSystemResourceFile : IResourceFile
  {
    private string _basePath = null;

    public FileSystemResourceFile()
    {
      _basePath = Path.GetDirectoryName(Application.ExecutablePath);
    }

    public FileSystemResourceFile(string basePath)
    {
      _basePath = basePath;
    }

    public string BasePath
    {
      get { return _basePath; }
    }

    private string GetFullResourcePath(Resource resource)
    {
      return Path.Combine(_basePath, resource.Name);
    }

    public bool Open()
    {
      return Directory.Exists(_basePath);
    }    

    public long GetRawResourceSize(Resource resource)
    {
      string fullPath = GetFullResourcePath(resource);
      if (File.Exists(fullPath))
      {
        FileInfo info = new FileInfo(fullPath);
        return info.Length;
      }
      return 0;
    }

    public long GetRawResource(Resource resource, Stream buffer)
    {
      string fullPath = GetFullResourcePath(resource);
      if (File.Exists(fullPath))
      {
        FileStream fileStream = new FileStream(fullPath, FileMode.Open);
        try
        {
          byte[] data = new byte[fileStream.Length];
          fileStream.Read(data, 0, (int)fileStream.Length);
          buffer.Write(data, 0, data.Length);
          return data.Length;
        }
        finally
        {
          fileStream.Close();
        }
      }
      return 0;
    }

    public int GetNumResources()
    {
      string[] files = Directory.GetFiles(_basePath, "*.*", SearchOption.AllDirectories);
      return files.Length;
    }

    public string GetResourceName(int index)
    {
      string[] files = Directory.GetFiles(_basePath, "*.*", SearchOption.AllDirectories);
      return files[index].Trim().ToLower();
    }

  }
}
