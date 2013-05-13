using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using OkuBase.Driver.Audio;
using OkuBase.Driver.Graphics;

namespace OkuBase.Driver
{
  /// <summary>
  /// Manages loading of drivers from assemblies that must be stored 
  /// in the same path as the executing assembly (usualy the .exe file).
  /// Only one driver of each type can be loaded at a time.
  /// </summary>
  public class DriverManager : Manager
  {
    private class DriverInfo
    {
      public DriverInfo()
      {
      }

      public DriverInfo(string assemblyPath, string typeName)
      {
        AssemblyPath = assemblyPath;
        TypeName = typeName;
      }

      public string AssemblyPath { get; set; }
      public string TypeName { get; set; }
    }

    private Dictionary<string, DriverInfo> _graphicsDrivers = new Dictionary<string, DriverInfo>();
    private Dictionary<string, DriverInfo> _audioDrivers = new Dictionary<string, DriverInfo>();
    private AppDomain _graphicsDomain = null;
    private AppDomain _audioDomain = null;

    public override void Initialize()
    {
      _graphicsDrivers.Clear();
      _audioDrivers.Clear();

      //Get path of executing assembly
      string basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

      //Get all dll files in the directory
      string[] dllFiles = Directory.GetFiles(basePath, "*.dll");
      foreach (string dll in dllFiles)
      {
        if (dll != "OkuBase.dll") //Ignore own assembly
        {
          //Create new app domain
          AppDomain domain = AppDomain.CreateDomain("DriverDomain");

          //Get full path of assembly
          string fullPath = Path.Combine(basePath, dll);
          
          //Load assembly into appdomain
          AssemblyName assemblyName = AssemblyName.GetAssemblyName(fullPath);
          Assembly assembly = domain.Load(assemblyName);

          //Get all types of the assembly and check if any type implements one of the driver interfaces
          Type[] allTypes = assembly.GetTypes();
          foreach (Type t in allTypes)
          {
            Type[] interfaces = t.GetInterfaces();
            foreach (Type itf in interfaces)
            {
              //Check for graphics drivers
              if (itf.Equals(typeof(IGraphicsDriver)))
              {
                IGraphicsDriver graphicsDriver = (IGraphicsDriver)assembly.CreateInstance(t.FullName);

                if (graphicsDriver.DriverName == null && !_graphicsDrivers.ContainsKey(graphicsDriver.DriverName))
                  _graphicsDrivers.Add(graphicsDriver.DriverName, new DriverInfo(fullPath, t.FullName));

                continue;
              }

              //Check for audio drivers
              if (itf.Equals(typeof(IAudioDriver)))
              {
                IAudioDriver audioDriver = (IAudioDriver)assembly.CreateInstance(t.FullName);

                if (audioDriver.DriverName == null && !_audioDrivers.ContainsKey(audioDriver.DriverName))
                  _audioDrivers.Add(audioDriver.DriverName, new DriverInfo(fullPath, t.FullName));

                continue;
              }
            }
          }

          //Unload appdomain including assemblies
          AppDomain.Unload(domain);
        }
      }
    }

    /// <summary>
    /// Gets the renderer with the given driver name.
    /// </summary>
    /// <param name="driverName">The unique driver name that identifies a specific driver.</param>
    /// <returns>The driver with the given name or null if there is no driver with this name.</returns>
    public IGraphicsDriver GetGraphicsDriver(string driverName)
    {
      if (!_graphicsDrivers.ContainsKey(driverName))
        return null;

      if (_graphicsDomain != null)
      {
        AppDomain.Unload(_graphicsDomain);
        _graphicsDomain = null;
      }

      DriverInfo info = _graphicsDrivers[driverName];
      _graphicsDomain = AppDomain.CreateDomain("GraphicsDomain");

      AssemblyName assemblyName = AssemblyName.GetAssemblyName(info.AssemblyPath);
      Assembly assembly = _graphicsDomain.Load(assemblyName);
      IGraphicsDriver result = (IGraphicsDriver)assembly.CreateInstance(info.TypeName);

      return result;
    }

    /// <summary>
    /// Gets the audio driver with the given driver name.
    /// </summary>
    /// <param name="driverName">The unique driver name that identifies a specific driver.</param>
    /// <returns>The driver with the given name or null if there is no driver with this name.</returns>
    public IAudioDriver GetAudioDriver(string driverName)
    {
      if (!_audioDrivers.ContainsKey(driverName))
        return null;

      if (_audioDomain != null)
      {
        AppDomain.Unload(_audioDomain);
        _audioDomain = null;
      }

      DriverInfo info = _audioDrivers[driverName];
      _audioDomain = AppDomain.CreateDomain("AudioDomain");

      AssemblyName assemblyName = AssemblyName.GetAssemblyName(info.AssemblyPath);
      Assembly assembly = _audioDomain.Load(assemblyName);
      IAudioDriver result = (IAudioDriver)assembly.CreateInstance(info.TypeName);

      return result;
    }

    public override void Finish()
    {
      if (_graphicsDomain != null)
      {
        AppDomain.Unload(_graphicsDomain);
        _graphicsDomain = null;
      }

      if (_audioDomain != null)
      {
        AppDomain.Unload(_audioDomain);
        _audioDomain = null;
      }
    }

  }
}
