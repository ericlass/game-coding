using System;
using System.Collections.Generic;
using System.IO;

namespace OkuEngine
{
  public class VirtualFileSystem
  {
    private Dictionary<uint, VirtualFile> _files = null;

    public VirtualFileSystem()
    {
      Init();
    }

    private void Init()
    {
      _files = new Dictionary<uint, VirtualFile>();

      VirtualFile root = new VirtualFile();
      root.Name = "Root";
      root.Id = 0;
      root.Type = VirtualFileType.Directory;
      _files.Add(0, root);
    }

    public void AddFile(string name, Stream data)
    {
      AddFile(0, name, data);
    }

    public void AddFile(uint parent, string name, Stream data)
    {
      if (parent < 0 || parent >= _files.Count)
        throw new ArgumentException("The given parent id (" + parent + ") does not belong to an existing file!");

      if (_files[parent].Type != VirtualFileType.Directory)
        throw new ArgumentException("The given parent (" + parent + ") is not a directory! Only directories are allowed to have children.");

      VirtualFile file = new VirtualFile();
      file.Data = data;
      file.Id = (uint)_files.Count;
      file.Length = (ulong)data.Length;
      file.Name = name;
      file.ParentId = parent;
      file.Type = VirtualFileType.File;
      _files.Add(file.Id, file);
    }

  }
}
