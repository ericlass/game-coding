using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RougeLike
{
  internal class GameObject
  {
    public string Id { get; set; }
    public int ZIndex { get; set; }
    public IGameObject GameObject { get; set; }

    public Dictionary<string, string> Save()
    {
      StringPairMap result = GameObject.Save();
      result.Add("Id", Id);
      result.Add("ZIndex", ZIndex.ToString());
      return result;
    }

    public void Load(StringPairMap data)
    {
      Id = data["Id"];
      ZIndex = int.Parse(data["ZIndex"]);
      data.Remove("Id");
      data.Remove("ZIndex");
      GameObject.Load(data);
    }

  }
}
