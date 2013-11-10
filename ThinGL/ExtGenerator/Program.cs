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
          str = str.Replace("<#rettype>", GetFriendlyName(info.ReturnType));
          str = str.Replace("<#name>", nested.Name.Substring(2));
          str = str.Replace("<#params>", parameters.ToString());
          str = str.Replace("<#delname>", nested.Name);
          str = str.Replace("<#callparams>", callParams.ToString());
          if (info.ReturnType != typeof(void))
            str = str.Replace("<#ret>", "return ");
          else
            str = str.Replace("<#ret>", "");
          
          builder.Append(str);
          builder.Append('\n');
        }
      }
      
      Console.WriteLine(builder.ToString());
      //Console.ReadLine();
    }
    
    public static string GetFriendlyName(Type type)
    {
      Type originalType = type;
      Type arrayType = null;
      Type elementType = type;

      if (originalType.IsByRef)
      {
        elementType = originalType.GetElementType();
      }

      if (elementType.IsArray)
      {
        arrayType = elementType;
        elementType = arrayType.GetElementType();
      }

      string result = null;

      if (elementType == typeof(int))
        result = "int";
      else if (elementType == typeof(uint))
        result = "uint";
      else if (elementType == typeof(short))
        result = "short";
      else if (elementType == typeof(ushort))
        result = "ushort";
      else if (elementType == typeof(byte))
        result = "byte";
      else if (elementType == typeof(sbyte))
        result = "sbyte";
      else if (elementType == typeof(bool))
        result = "bool";
      else if (elementType == typeof(long))
        result = "long";
      else if (elementType == typeof(ulong))
        result = "ulong";
      else if (elementType == typeof(float))
        result = "float";
      else if (elementType == typeof(double))
        result = "double";
      else if (elementType == typeof(decimal))
        result = "decimal";
      else if (elementType == typeof(string))
        result = "string";
      else if (elementType == typeof(void))
        result = "void";
      else
        result = elementType.Name;

      if (arrayType != null)
        result += "[]";

      return result;
    }
    
  }
}