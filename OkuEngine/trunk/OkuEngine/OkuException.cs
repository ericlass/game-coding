using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkuEngine
{
  public class OkuException : Exception
  {
    public OkuException()
    {
    }

    public OkuException(string message) : base(message)
    {      
    }

    public OkuException(int code)
    {
      Code = code;
    }

    public OkuException(string message, int code) : base(message)
    {
      Code = code;
    }

    public int Code { get; set; }

  }
}
