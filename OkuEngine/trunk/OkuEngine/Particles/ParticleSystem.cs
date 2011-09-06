using System;
using System.Collections.Generic;

namespace OkuEngine
{
  public class ParticleSystem<E, C, R>
    where E : ParticleEmitter
    where C : IParticleController
    where R : IParticleRenderer
  {
    private E _emitter = default(E);
    private C _contoller = default(C);
    private R _renderer = default(R);
    private List<Particle> _particles = new List<Particle>();

    public ParticleSystem()
    {
    }

    public ParticleSystem(E emitter, C controller, R renderer)
    {
      _emitter = emitter;
      _contoller = controller;
      _renderer = renderer;
    }

    public E Emitter
    {
      get { return _emitter; }
      set { _emitter = value; }
    }

    public C Controller
    {
      get { return _contoller; }
      set { _contoller = value; }
    }

    public R Renderer
    {
      get { return _renderer; }
      set { _renderer = value; }
    }

    public void Update(float dt)
    {
      _contoller.Update(_particles, dt);
      _emitter.Emit(_particles, dt);
    }

    public void Draw()
    {
      _renderer.Render(_particles);
    }

  }
}
