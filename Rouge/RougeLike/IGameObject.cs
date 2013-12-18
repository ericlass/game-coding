using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  public interface IGameObject
  {
    string ObjectType { get; }
    void Init();
    void Update(float dt);
    void Render(float dt);
    void Finish();
    StringPairMap Save();
    void Load(StringPairMap data);
  }
}
