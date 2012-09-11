using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using OkuEngine;
using OkuEngine.Actors;
using OkuEngine.Processes;
using OkuEngine.Resources;
using OkuEngine.Scripting;

namespace OkuTest
{
  public class GCCTestGame : OkuGame
  {
    protected override string GetConfigFileName()
    {
      return "okugame.xml";
    }

    protected override void SetupResourceCache(ref ResourceCacheParams resourceParams)
    {
      resourceParams.ResourceFile = new FileSystemResourceFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "content"));
      resourceParams.SizeInMb = 64;
    }

    public override void Initialize()
    {
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(
        "<behaviors>\n" +
        "  <behavior>\n" +
        "    <id>1</id>\n" +
        "    <name>Test Behavior</name>\n" +
        "    <parameters>\n" +
        "      <parameter>\n" +
        "        <name>In01</name>\n" +
        "        <type>Integer</type>\n" +
        "        <input>yes</input>\n" +
        "        <value>5</value>\n" +
        "      </parameter>\n" +
        "      <parameter>\n" +
        "        <name>Out01</name>\n" +
        "        <type>Integer</type>\n" +
        "        <input>no</input>\n" +
        "      </parameter>\n" +
        "    </parameters>\n" +
        "    <script>\n" +
        "      <![CDATA[Out01 = In01 * 3;]]>\n" +
        "    </script>\n" +
        "  </behavior>\n" +
        "</behaviors>");

      Behavior behave = new Behavior();
      behave.Load(doc.DocumentElement.FirstChild);

      behave.Script["In01"].ValueInteger = 7;
      behave.Execute();
      MessageBox.Show(behave.Script["Out01"].ValueInteger.ToString());

    }

    public override void Update(float dt)
    {
    }

    public override void Render(int pass)
    {
    }

  }
}
