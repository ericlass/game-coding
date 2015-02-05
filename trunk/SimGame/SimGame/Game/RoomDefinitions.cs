using System;
using System.Collections.Generic;
using System.Reflection;
using OkuBase.Graphics;

namespace SimGame.Game
{
  public static class RoomDefinitions
  {
    public static RoomDefinition Empty = new RoomDefinition() 
    {
      Id = "empty",
      Name = "Empty",
      BaseType = RoomType.Empty,
      Fixed = true,
      NumberOfSpaces = 1,
      BaseColor = new Color(128, 128, 128)
    };

    public static RoomDefinition Entrance = new RoomDefinition() 
    { 
      Id = "entrance", 
      Name = "Entrance", 
      BaseType = 
      RoomType.Entrance, 
      Fixed = true, 
      NumberOfSpaces = 1,
      BaseColor = Color.Green
    };

    public static RoomDefinition Stairway = new RoomDefinition() 
    { 
      Id = "stairs", 
      Name = "Stairway", 
      BaseType = RoomType.Stairway,
      Fixed = false,
      NumberOfSpaces = 1,
      BaseColor = Color.Cyan
    };

    public static RoomDefinition Administration = new RoomDefinition()
    {
      Id = "administration",
      Name = "Administration",
      BaseType = RoomType.Administration,
      Fixed = false,
      NumberOfSpaces = 1,
      BaseColor = new Color(255, 128, 0)
    };

    public static RoomDefinition Security = new RoomDefinition()
    {
      Id = "security",
      Name = "Security",
      BaseType = RoomType.Security,
      Fixed = false,
      NumberOfSpaces = 1,
      BaseColor = Color.Red
    };

    public static RoomDefinition StorageSmall = new RoomDefinition()
    {
      Id = "storagesmall",
      Name = "Small Storage",
      BaseType = RoomType.Storage,
      Fixed = false,
      NumberOfSpaces = 1,
      BaseColor = new Color(64, 64, 64)
    };
    public static RoomDefinition StorageMedium = new RoomDefinition()
    {
      Id = "storagemedium",
      Name = "Medium Storage",
      BaseType = RoomType.Storage,
      Fixed = false,
      NumberOfSpaces = 2,
      BaseColor = new Color(64, 64, 64)
    };
    public static RoomDefinition StorageLarge = new RoomDefinition()
    {
      Id = "storagelarge",
      Name = "Large Storage",
      BaseType = RoomType.Storage,
      Fixed = false,
      NumberOfSpaces = 3,
      BaseColor = new Color(64, 64, 64)
    };

    public static RoomDefinition LabSmall = new RoomDefinition() 
    { 
      Id = "labsmall", 
      Name = "Small Lab", 
      BaseType = 
      RoomType.Laboratory, 
      Fixed = false,
      NumberOfSpaces = 1,
      BaseColor = Color.Blue
    };
    public static RoomDefinition LabMedium = new RoomDefinition() 
    { 
      Id = "labmedium", 
      Name = "Medium Lab", 
      BaseType = RoomType.Laboratory, 
      Fixed = false,
      NumberOfSpaces = 2,
      BaseColor = Color.Blue
    };
    public static RoomDefinition LabLarge = new RoomDefinition() 
    { 
      Id = "lablarge", 
      Name = "Large Lab", 
      BaseType = RoomType.Laboratory, 
      Fixed = false,
      NumberOfSpaces = 3,
      BaseColor = Color.Blue
    };

    public static RoomDefinition FacilitySmall = new RoomDefinition() 
    { 
      Id = "facilitysmall", 
      Name = "Small Facility", 
      BaseType = RoomType.Facility, 
      Fixed = false,
      NumberOfSpaces = 1,
      BaseColor = Color.Yellow
    };
    public static RoomDefinition FacilityMedium = new RoomDefinition() 
    { 
      Id = "facilitymedium", 
      Name = "Medium Facility", 
      BaseType = RoomType.Facility, 
      Fixed = false,
      NumberOfSpaces = 2,
      BaseColor = Color.Yellow
    };
    public static RoomDefinition FacilityLarge = new RoomDefinition() 
    { 
      Id = "facilitylarge", 
      Name = "Large Facility", 
      BaseType = RoomType.Facility, 
      Fixed = false,
      NumberOfSpaces = 3,
      BaseColor = Color.Yellow
    };

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
