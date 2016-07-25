using System;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  public class MaterialComponent : IComponent
  {
    private int _material = 0;

    public MaterialComponent(int material)
    {
      _material = material;
    }

    public int Material
    {
      get { return _material; }
      set { _material = value; }
    }

    public bool IsMultiAssignable
    {
      get { return false; }
    }

    public string Name
    {
      get { return "material"; }
    }

    public IComponent Copy()
    {
      return new MaterialComponent(_material);
    }

  }
}
