using System;
using System.Collections.Generic;

namespace OkuBase.Particles
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
    private List<IParticleEffector> _effectors = new List<IParticleEffector>();

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

    public List<IParticleEffector> Effectors
    {
      get { return _effectors; }
      set { _effectors = value; }
    }

    public void Update(float dt)
    {
      foreach (Particle p in _particles)
      {
        if (!p.IsDead)
        {
          _contoller.Update(p, dt);
          foreach (IParticleEffector eff in _effectors)
          {
            if (eff.Enabled)
              eff.Effect(p, dt);
          }
        }
      }
      
      _emitter.Emit(_particles, dt);
    }

    public void Draw()
    {
      _renderer.Render(_particles);
    }

  }
}
