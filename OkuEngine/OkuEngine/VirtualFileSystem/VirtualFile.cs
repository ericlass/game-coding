using System;
using System.Collections.Generic;
using System.IO;

namespace OkuEngine
{
  public class VirtualFile
  {
    private string _name = null;
    private uint _id = 0;
    private VirtualFileType _type = VirtualFileType.Directory;
    private uint _parentId = 0;
    private DateTime _created = DateTime.Now;
    private DateTime _modified = DateTime.Now;
    private uint _target = 0;
    private ulong _length = 0;
    private Stream _data = null;

    public VirtualFile()
    {
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public uint Id
    {
      get { return _id; }
      set { _id = value; }
    }

    public VirtualFileType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    public uint ParentId
    {
      get { return _parentId; }
      set { _parentId = value; }
    }

    public DateTime Created
    {
      get { return _created; }
      set { _created = value; }
    }

    public DateTime Modified
    {
      get { return _modified; }
      set { _modified = value; }
    }

    public uint Target
    {
      get { return _target; }
      set { _target = value; }
    }

    public ulong Length
    {
      get { return _length; }
      set { _length = value; }
    }

    public Stream Data
    {
      get { return _data; }
      set { _data = value; }
    }

  }
}
