using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace OkuEngine.GCC.Scripting
{
  class ScriptManager
  {
    private CSharpCodeProvider _provider = new CSharpCodeProvider();

    public ScriptManager()
    {
    }

    public ScriptInstance CompileScript(string code)
    {
      string source =
        "using System;\n" +
        "using OkuEngine;\n" +
        "\n" +
        "namespace OkuScripts\n" +
        "{\n" +
        "  public class Script" + KeySequence.NextValue + "\n" + //Append sequence number to script class name
        "  {\n" +
        code + "\n" +
        "  }\n" +
        "}\n";

      CompilerParameters param = new CompilerParameters();
      param.GenerateExecutable = false;
      param.GenerateInMemory = true;
      param.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
      param.ReferencedAssemblies.Add(Assembly.GetAssembly(typeof(ScriptManager)).Location);

      //JUST FOR TESTING!!!
      //param.ReferencedAssemblies.Add("C:\\Windows\\Microsoft.NET\\Framework\\v2.0.50727\\System.Windows.Forms.dll");

      CompilerResults result = _provider.CompileAssemblyFromSource(param, source);

      if (result.Errors.HasErrors)
      {
        //throw script compile exception
      }

      if (result.Errors.HasWarnings)
      {
        //log warnings
      }

      ScriptInstance instance = new ScriptInstance(result.CompiledAssembly);
      if (!instance.Init())
      {
        //LOG: the error
        return null;
      }
      return instance;
    }
  }
}
