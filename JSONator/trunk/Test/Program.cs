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
        "  \"Deckung\": 2.5e+6,\n" +
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

      json =
        "{\n" +
        "    \"firstName\": \"John\",\n" +
        "    \"lastName\": \"Smith\",\n" +
        "    \"age\": 25,\n" +
        "    \"address\": {\n" +
        "        \"streetAddress\": \"21 2nd Street\",\n" +
        "        \"city\": \"New York\",\n" +
        "        \"state\": \"NY\",\n" +
        "        \"postalCode\": 10021\n" +
        "    },\n" +
        "    \"phoneNumbers\": [\n" +
        "        {\n" +
        "            \"type\": \"home\",\n" +
        "            \"number\": \"212 555-1234\"\n" +
        "        },\n" +
        "        {\n" +
        "            \"type\": \"fax\",\n" +
        "            \"number\": \"646 555-4567\"\n" +
        "        }\n" +
        "    ]\n" +
        "}";

      JSONParser parser = new JSONParser();
      JSONObjectValue obj = parser.Parse(json);

      JSONWriter writer = new JSONWriter(true);
      string str = writer.WriteJson(obj);
      Console.WriteLine(str);

      Console.ReadLine();
    }
  }
}
