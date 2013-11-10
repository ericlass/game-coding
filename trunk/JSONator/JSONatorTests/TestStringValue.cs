using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONator;

namespace JSONatorTests
{
  /// <summary>
  /// Zusammenfassungsbeschreibung für TestStringValue
  /// </summary>
  [TestClass]
  public class TestStringValue
  {
    public TestStringValue()
    {      
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Ruft den Textkontext mit Informationen über
    ///den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
    ///</summary>
    public TestContext TestContext
    {
      get { return testContextInstance; }
      set { testContextInstance = value; }
    }

    #region Zusätzliche Testattribute
    //
    // Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
    //
    // Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen. 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    private JSONObjectValue _obj = null;

    [TestInitialize]
    public void Init()
    {
      JSONParser parser = new JSONParser();
      string testValue = "{\"Test\":\"ABC\\u0044\\\"\"}";
      _obj = parser.Parse(testValue);
    }

    [TestMethod]
    public void TestMemberExists()
    {
      Assert.IsTrue(_obj.Contains("Test"), "Member \"Test\" not parsed");
    }

    [TestMethod]
    public void TestValueHasCorrectType()
    {
      Assert.IsTrue(_obj["Test"] is JSONStringValue, "Member \"Test\" has wrong type");
    }

    [TestMethod]
    public void TestValueTypeIsCorrect()
    {
      Assert.IsTrue(_obj["Test"].ValueType == JSONValueType.String, "Value type is not correct");
    }

    [TestMethod]
    public void TestParsedValueCorrect()
    {
      JSONStringValue value = _obj["Test"] as JSONStringValue;
      Assert.AreEqual(value.Value, "ABCD\"", false, "Member value is not correct");
    }

  }
}
