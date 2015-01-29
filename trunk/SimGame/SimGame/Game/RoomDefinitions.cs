using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimGame.Game
{
  public static class RoomDefinitions
  {
    public static RoomDefinition Empty = new RoomDefinition() { Id = "empty", Name = "Empty", BaseType = RoomType.Empty, Fixed = true, NumberOfSpaces = 1 };

    public static RoomDefinition Entrance = new RoomDefinition() { Id = "entrance", Name = "Entrance", BaseType = RoomType.Entrance, Fixed = true, NumberOfSpaces = 1 };

    public static RoomDefinition Stairway = new RoomDefinition() { Id = "stairs", Name = "Stairway", BaseType = RoomType.Stairway, Fixed = false, NumberOfSpaces = 1 };

    public static RoomDefinition LabSmall = new RoomDefinition() { Id = "labsmall", Name = "Small Lab", BaseType = RoomType.Laboratory, Fixed = false, NumberOfSpaces = 1 };
    public static RoomDefinition LabMedium = new RoomDefinition() { Id = "labmedium", Name = "Medium Lab", BaseType = RoomType.Laboratory, Fixed = false, NumberOfSpaces = 2 };
    public static RoomDefinition LabLarge = new RoomDefinition() { Id = "lablarge", Name = "Large Lab", BaseType = RoomType.Laboratory, Fixed = false, NumberOfSpaces = 3 };

    public static RoomDefinition FacilitySmall = new RoomDefinition() { Id = "facilitysmall", Name = "Small Facility", BaseType = RoomType.Facility, Fixed = false, NumberOfSpaces = 1 };
    public static RoomDefinition FacilityMedium = new RoomDefinition() { Id = "facilitymedium", Name = "Medium Facility", BaseType = RoomType.Facility, Fixed = false, NumberOfSpaces = 2 };
    public static RoomDefinition FacilityLarge = new RoomDefinition() { Id = "facilitylarge", Name = "Large Facility", BaseType = RoomType.Facility, Fixed = false, NumberOfSpaces = 3 };

    private static Dictionary<string, RoomDefinition> _definitions = null;

    public static RoomDefinition GetDefinition(string id)
    {
      if (_definitions == null)
      {
        _definitions = new Dictionary<string,RoomDefinition>();
        Type t = typeof(RoomDefinitions);
        Type definitionType = typeof(RoomDefinition);
        FieldInfo[] fields = t.GetFields();
        foreach (FieldInfo field in fields) {
          RoomDefinition def = field.GetValue(null) as RoomDefinition;
          _definitions.Add(def.Id, def);
        }
      }

      if (_definitions.ContainsKey(id))
        return _definitions[id];
      else
        return null;
    }

  }
}
