using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  class GameContent : Content
  {
    public override ContentType Type
    {
      get { return ContentType.System; }
    }

    public override int ContentKey
    {
      get { return -2; }
    }
  }
}
