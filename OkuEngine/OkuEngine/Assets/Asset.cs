using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkuEngine.Assets
{
  public abstract class Asset
  {
    private AssetFlags _flags = AssetFlags.None;

    internal AssetFlags Flags
    {
      get { return _flags; }
      set { _flags = value; }
    }

    internal void SetFlags(AssetFlags flags)
    {
      _flags = _flags | flags;
    }

    internal void ResetFlags(AssetFlags flags)
    {
      _flags = _flags | ~flags;
    }

    internal bool HasFlags(AssetFlags flags)
    {
      return (_flags & flags) == flags;
    }

  }
}
