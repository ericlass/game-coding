using System;
using JSONator;

namespace Test
{
  class Program
  {
    static void Main(string[] args)
    {
      string json =
        "{\n" +
        "  \"Herausgeber\": \"Xema\",\n" +
        "  \"Nummer\": \"1234-5678-9012-3456\",\n" +
        "  \"Deckung\": 2e+6,\n" +
        "  \"Währung\": \"EURO\",\n" +
        "  \"Inhaber\": {\n" +
        "    \"Name\": \"Mustermann\",\n" +
        "    \"Vorname\": \"Max\",\n" +
        "    \"männlich\": true,\n" +
        "    \"Hobbys\": [ \"Reiten\", \"Golfen\", \"Lesen\" ],\n" +
        "    \"Alter\": 42,\n" +
        "    \"Kinder\": [],\n" +
        "    \"Partner\": null\n" +
        "  }\n" +
        "}";

      JSONParser parser = new JSONParser();
      JSONObjectValue obj = parser.Parse(json);

      Console.ReadLine();
    }
  }
}
