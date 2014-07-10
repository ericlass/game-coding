using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike.Systems
{
  public interface IGameSystem
  {
    void Init();
    void Update(float dt);
    void Finish();
  }
}
