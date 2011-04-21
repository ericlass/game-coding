using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  class RootContent : Content
  {
    public override ContentType Type
    {
      get { return ContentType.System; }
    }

    public override int ContentKey
    {
      get { return -1; }
    }

  }
}
