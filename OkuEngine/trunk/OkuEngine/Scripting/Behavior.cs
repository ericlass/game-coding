using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace OkuEngine.Scripting
{
  public class Behavior : StoreableEntity
  {
    private ScriptInstance _script = null;
    private Parameter[] _parameters = null;

    public Behavior()
    {
    }

    public void Execute()
    {
      _script.Run();
    }

    public ScriptInstance Script
    {
      get { return _script; }
      set { _script = value; }
    }

    private Parameter[] LoadParameters(XmlNode node)
    {
      List<Parameter> inputs = new List<Parameter>();

      XmlNode child = node.FirstChild;
      while (child != null)
      {
        if (child.NodeType == XmlNodeType.Element && child.Name.ToLower() == "parameter")
        {
          Parameter param = new Parameter();
          if (param.Load(child))
            inputs.Add(param);
        }

        child = child.NextSibling;
      }

      if (inputs.Count > 0)
        return inputs.ToArray();
      else
        return null;
    }

    public override bool Load(XmlNode node)
    {
      if (!base.Load(node))
        return false;

      XmlNode paramsNode = node["parameters"];
      if (paramsNode != null)
        _parameters = LoadParameters(paramsNode);

      string script = node.GetTagValue("script");
      if (script != null)
      {
        ScriptInstance scriptInst = OkuManagers.ScriptManager.CompileScript(script, _parameters);
        if (scriptInst != null)
          _script = scriptInst;
        else
          return false;
      }
      else
      {
        OkuManagers.Logger.LogError("No script defined for behavior " + _name + "!");
        return false;
      }

      return true;
    }

    private bool SaveParameters(XmlWriter writer, Parameter[] parameters)
    {
      foreach (Parameter param in parameters)
      {
        if (!param.Save(writer))
          return false;
      }
      return true;
    }

    public override bool Save(XmlWriter writer)
    {
      writer.WriteStartElement("behavior");

      if (!base.Save(writer))
        return false;

      if (_parameters != null && _parameters.Length > 0)
      {
        writer.WriteStartElement("parameters");
        SaveParameters(writer, _parameters);
        writer.WriteEndElement();
      }

      writer.WriteStartElement("script");
      writer.WriteCData(_script.Source);
      writer.WriteEndElement();

      writer.WriteEndElement();

      return true;
    }

  }
}
