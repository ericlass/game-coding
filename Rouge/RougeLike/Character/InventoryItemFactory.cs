using System;
using System.Collections.Generic;
using JSONator;
using OkuBase.Utils;

namespace RougeLike.Character
{
  public class InventoryItemFactory
  {
    private static InventoryItemFactory _instance = null;

    public static InventoryItemFactory Instance
    {
      get
      {
        if (_instance == null)
          _instance = new InventoryItemFactory();
        return _instance;
      }
    }

    private delegate InventoryItemDefinition CreateItemDelegate(JSONObjectValue data);

    private Dictionary<InventoryItemType, CreateItemDelegate> _creators = new Dictionary<InventoryItemType, CreateItemDelegate>();

    private InventoryItemFactory()
    {
      _creators.Add(InventoryItemType.Ammo, new CreateItemDelegate(CreateBasicInventoryItem));
      _creators.Add(InventoryItemType.Armor, new CreateItemDelegate(CreateArmorItem));
      _creators.Add(InventoryItemType.Collectible, new CreateItemDelegate(CreateBasicInventoryItem));
      _creators.Add(InventoryItemType.Weapon, new CreateItemDelegate(CreateWeaponItem));
    }

    public InventoryItemDefinition CreateInventoryItem(JSONObjectValue data)
    {
      InventoryItemType itemType = OkuBase.Utils.Converter.ParseEnum<InventoryItemType>(data.GetString("itemtype").Value);
      return _creators[itemType](data);
    }

    private void LoadBasicInventoryItem(JSONObjectValue data, InventoryItemDefinition item)
    {
      item.Id = data.GetString("id").Value;
      item.Name = data.GetString("name").Value;
      item.Description = data.GetString("description").Value;
      item.ItemType = Converter.ParseEnum<InventoryItemType>(data.GetString("itemtype").Value);
      item.Image = data.GetString("image").Value;
      item.Weight = (float)data.GetNumber("weight").Value;
      item.Droppable = data.GetBool("droppable").Value;
    }

    private InventoryItemDefinition CreateBasicInventoryItem(JSONObjectValue data)
    {
      InventoryItemDefinition result = new InventoryItemDefinition();
      LoadBasicInventoryItem(data, result);
      return result;
    }

    private InventoryItemDefinition CreateWeaponItem(JSONObjectValue data)
    {
      WeaponDefinition result = new WeaponDefinition();
      LoadBasicInventoryItem(data, result);

      result.WeaponType = Converter.ParseEnum<WeaponType>(data.GetString("weapontype").Value);
      result.RateOfFire = (float)data.GetNumber("rateoffire").Value;
      result.Damage = (float)data.GetNumber("damage").Value;
      result.ProjectileSpeed = (float)data.GetNumber("projectilespeed").Value;
      result.ProjectileSize = (float)data.GetNumber("projectilesize").Value;
      result.Continuous = data.GetBool("continuous").Value;
      result.Effect = Converter.ParseEnum<WeaponEffect>(data.GetString("effect").Value);
      result.MuzzleFlashAnim = data.GetString("muzzleanim").Value;
      result.ProjectileAnim = data.GetString("projectileanim").Value;
      result.HitAnim = data.GetString("hitanim").Value;
      result.TrailAnim = data.GetString("trailanim").Value;
      result.Sound = data.GetString("sound").Value;

      return result;
    }

    private InventoryItemDefinition CreateArmorItem(JSONObjectValue data)
    {
      ArmorDefinition result = new ArmorDefinition();
      LoadBasicInventoryItem(data, result);

      result.BeamRating = (float)data.GetNumber("beamrating").Value;
      result.ProjectileRating = (float)data.GetNumber("projectilerating").Value;

      JSONObjectValue buffData = data.GetObject("buffs");
      SkillSet buffs = new SkillSet();
      buffs.Run = (float)buffData.GetNumber("run").Value;
      buffs.Jump = (float)buffData.GetNumber("jump").Value;
      buffs.BeamWeapons = (float)buffData.GetNumber("beamweapons").Value;
      buffs.ProjectileWeapons = (float)buffData.GetNumber("projectileweapons").Value;
      buffs.Strength = (float)buffData.GetNumber("strength").Value;
      buffs.Armor = (float)buffData.GetNumber("armor").Value;
      result.Buffs = buffs;

      List<WeaponEffect> immunities = new List<WeaponEffect>();
      JSONArrayValue immData = data.GetArray("immunities");
      for (int i = 0; i < immData.Count; i++)
      {
        immunities.Add(Converter.ParseEnum<WeaponEffect>(immData.GetString(i).Value));
      }
      result.Immunities = immunities;

      return result;
    }

  }
}
