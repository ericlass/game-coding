using System;
using System.Text;
using System.Reflection;
using ThinGL;

namespace ExtGenerator
{
  class Program
  {
    private const string MethodTemplate = 
      "public static <#rettype> <#name>(<#params>)\n" +
      "{\n" +
      "  <#delname> del = (<#delname>)GetProc<<#delname>>();\n" +
      "  <#ret>del(<#callparams>);\n" +
      "}\n";
      
    
    public static void Main(string[] args)
    {
      Type extType = typeof(GlExt);
      Type[] nestedTypes = extType.GetNestedTypes(BindingFlags.NonPublic);
      
      StringBuilder builder = new StringBuilder();
      foreach (Type nested in nestedTypes)
      {
        if (typeof(Delegate).IsAssignableFrom(nested))
        {
          MethodInfo info = nested.GetMethod("Invoke");
          
          StringBuilder parameters = new StringBuilder();
          StringBuilder callParams = new StringBuilder();
          
          ParameterInfo[] paramers = info.GetParameters();
          
          for (int i = 0; i < paramers.Length; i++)
          {
            ParameterInfo paramInfo = paramers[i];
            
            if (i > 0)
            {
              parameters.Append(", ");
              callParams.Append(", ");
            }
            
            if (paramInfo.IsOut)
            {
              parameters.Append("out ");
              callParams.Append("out ");
            }
            if (paramInfo.ParameterType.IsByRef)
            {
              parameters.Append("ref ");
              callParams.Append("ref ");
            }
              
            parameters.Append(GetFriendlyName(paramInfo.ParameterType));
            parameters.Append(' ');
            parameters.Append(paramInfo.Name);
            
            callParams.Append(paramInfo.Name);            
          }
          
          string str = MethodTemplate;
          str = str.Replace("<#rettype>", info.ReturnType.ToString());
          str = str.Replace("<#name>", nested.Name.Substring(2));
          str = str.Replace("<#params>", parameters.ToString());
          str = str.Replace("<#delname>", nested.Name);
          str = str.Replace("<#callparams>", callParams.ToString());
          if (info.ReturnType != typeof(void))
            str = str.Replace("<#ret>", "return ");
          
          builder.Append(str);
        }
      }
      
      Console.WriteLine(builder.ToString());
      Console.ReadLine();
    }
    
    public static string GetFriendlyName(Type type)
    {
      if (type == typeof(int))
          return "int";
      else if (type == typeof(short))
          return "short";
      else if (type == typeof(byte))
          return "byte";
      else if (type == typeof(bool)) 
          return "bool";
      else if (type == typeof(long))
          return "long";
      else if (type == typeof(float))
          return "float";
      else if (type == typeof(double))
          return "double";
      else if (type == typeof(decimal))
          return "decimal";
      else if (type == typeof(string))
          return "string";
      else
          return type.Name;
    }
    
  }
}