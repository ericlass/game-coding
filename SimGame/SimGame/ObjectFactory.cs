﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimGame
{
  public class ObjectFactory<T>
  {
    private Dictionary<string, Func<object[], T>> _constructors = new Dictionary<string, Func<object[], T>>();

    public bool RegisterConstructor(string typeId, Func<object[], T> constructor)
    {
      if (_constructors.ContainsKey(typeId))
        return false;
      
      _constructors.Add(typeId, constructor);
      return true;
    }
  
    public T Create(string typeId, object[] parameters)
    {
      return _constructors[typeId](parameters);
    }
  }
}
