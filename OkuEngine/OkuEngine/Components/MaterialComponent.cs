using System;
using OkuEngine.Assets;

namespace OkuEngine.Components
{
  public class MaterialComponent : Component
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

    public override bool IsMultiAssignable
    {
      get { return false; }
    }

    public override string Name
    {
      get { return "material"; }
    }

    public override Component Copy()
    {
      return new MaterialComponent(_material);
    }

  }
}
