﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using OkuBase.Driver;
using OkuBase.Settings;

namespace OkuBase.Driver
{
  /// <summary>
  /// Manages loading of drivers from assemblies that must be stored 
  /// in the same path as the executing assembly (usualy the .exe file).
  /// Only one driver of each type can be loaded at a time.
  /// </summary>
  public class DriverManager : Manager
  {
    private IGraphicsDriver _graphicsDriver = null;
    private IAudioDriver _audioDriver = null;
    private AppDomain _graphicsDomain = null;
    private AppDomain _audioDomain = null;

    public override void Initialize(OkuSettings settings)
    {
      _graphicsDriver = null;
      _audioDriver = null;

      //Get path of executing assembly
      string basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

      //Get all dll files in the directory
      string[] dllFiles = Directory.GetFiles(basePath, "*.dll");
      foreach (string dll in dllFiles)
      {
        //Create new app domain
        AppDomain domain = AppDomain.CreateDomain("DriverDomain");
        
        //Load assembly into appdomain
        AssemblyName assemblyName = AssemblyName.GetAssemblyName(dll);
        Assembly assembly = domain.Load(assemblyName);

        bool containsDriver = false;

        //Get all types of the assembly and check if any type implements one of the driver interfaces
        Type[] allTypes = assembly.GetTypes();
        foreach (Type t in allTypes)
        {
          Type[] interfaces = t.GetInterfaces();
          foreach (Type itf in interfaces)
          {
            //Check for graphics drivers
            if (_graphicsDriver == null && itf.Equals(typeof(IGraphicsDriver)))
            {
              IGraphicsDriver graphicsDriver = (IGraphicsDriver)assembly.CreateInstance(t.FullName);

              if (graphicsDriver.DriverName != null && graphicsDriver.DriverName.Equals(settings.Graphics.DriverName, StringComparison.CurrentCultureIgnoreCase))
              {
                _graphicsDriver = graphicsDriver;
                _graphicsDomain = domain;
                containsDriver = true;
              }

              continue;
            }

            //Check for audio drivers
            if (_audioDriver == null && itf.Equals(typeof(IAudioDriver)))
            {
              IAudioDriver audioDriver = (IAudioDriver)assembly.CreateInstance(t.FullName);

              if (audioDriver.DriverName != null && audioDriver.DriverName.Equals(settings.Audio.DriverName, StringComparison.CurrentCultureIgnoreCase))
              {
                _audioDriver = audioDriver;
                _audioDomain = domain;
                containsDriver = true;
              }

              continue;
            }
          }
        }

        //Unload appdomain including assemblies if the assembly did not contain one of the desired drivers
        if (!containsDriver)
          AppDomain.Unload(domain);
      }

      //Check that the desired graphics driver was found
      if (_graphicsDriver == null)
        throw new OkuException("Could not load the graphics driver with the name \"" + settings.Graphics.DriverName + "\"!");

      //Check that the desired audio driver was found
      if (_audioDriver == null)
        throw new OkuException("Could not load the audio driver with the name \"" + settings.Audio.DriverName + "\"!");
    }

    public IGraphicsDriver GraphicsDriver
    {
      get { return _graphicsDriver; }
    }

    public IAudioDriver AudioDriver
    {
      get { return _audioDriver; }
    }

    public override void Finish()
    {
      bool sameDomain = _graphicsDomain == _audioDomain;

      if (_graphicsDomain != null)
      {
        AppDomain.Unload(_graphicsDomain);
        _graphicsDomain = null;
      }

      if (!sameDomain && _audioDomain != null)
      {
        AppDomain.Unload(_audioDomain);
        _audioDomain = null;
      }
    }
 
    public override void Update(float dt)
    {
      _graphicsDriver.Update(dt);
      _audioDriver.Update(dt);
    }

  }
}
