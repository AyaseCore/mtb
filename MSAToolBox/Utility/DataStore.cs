using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAToolBox.Utility
{
    public class DB
    {
        private static LegacyWorldEntities _LEGACY;
        //private static LegacyDataEntities _DATA;

        public static LegacyWorldEntities LEGACY
        {
            get
            {
                if (_LEGACY == null)
                    _LEGACY = new LegacyWorldEntities();
                return _LEGACY;
            }
            set
            {
                _LEGACY = value;
            }
        }

        //public static LegacyDataEntities DATA
        //{
        //    get
        //    {
        //        if (_DATA == null)
        //            _DATA = new LegacyDataEntities();
        //        return _DATA;
        //    }
        //    set
        //    {
        //        _DATA = value;
        //    }
        //}

        public static void Refresh()
        {
            _LEGACY = new LegacyWorldEntities();
            //_DATA = new LegacyDataEntities();
        }
    }

    // preload defines

    public class DBCache
    {
        private static List<ItemInfo> Items { get; set; }
        private static List<CreatureInfo> Creatures { get; set; }

        private static void LoadItems()
        {
            Items = new List<ItemInfo>();
            var items = from d in DB.LEGACY.item_template orderby d.entry select d;
            foreach (var item in items)
                Items.Add(new ItemInfo()
                {
                    Entry = item.entry,
                    Class = item.@class,
                    SubClass = item.subclass,
                    Name = item.name,
                    Quality = item.Quality,
                });
            DB.Refresh();
        }

        public static List<ItemInfo> GetItems()
        {
            if (Items == null)
                LoadItems();
            return Items;
        }

        public static void AddItem(int entry, int _class, int subclass, string name, int quality)
        {
            if (Items == null)
                LoadItems();
            Items.Add(new ItemInfo()
            {
                Entry = entry,
                Class = _class,
                SubClass = subclass,
                Name = name,
                Quality = quality,
            });
        }

        public static void DeleteItem(int entry)
        {
            if (Items == null)
                LoadItems();
            var item = (from i in Items where i.Entry == entry select i).SingleOrDefault();
            if (item != null)
                Items.Remove(item);
        }

        public static void UpdateItem(int entry, int _class, int subclass, string name, int quality)
        {
            DeleteItem(entry);
            AddItem(entry, _class, subclass, name, quality);
        }

        private static void LoadCreatures()
        {
            Creatures = new List<CreatureInfo>();
            var creatures = from d in DB.LEGACY.creature_template orderby d.entry select d;
            foreach (var c in creatures)
                Creatures.Add(new CreatureInfo()
                {
                    Entry = c.entry,
                    Name = c.name,
                    MinLevel = c.minlevel,
                    MaxLevel = c.maxlevel,
                    Rank = c.rank
                });
            DB.Refresh();
        }

        public static List<CreatureInfo> GetCreatures()
        {
            if (Creatures == null)
                LoadCreatures();
            return Creatures;
        }

        public static void AddCreature(int entry, string name, int minlevel, int maxlevel, int rank)
        {
            if (Creatures == null)
                LoadCreatures();

            Creatures.Add(new CreatureInfo()
            {
                Entry = entry,
                Name = name,
                MinLevel = minlevel,
                MaxLevel = maxlevel,
                Rank = rank
            });
        }
        public static void UpdateCreature(int entry, string name, int minlevel, int maxlevel, int rank)
        {
            DeleteCreature(entry);
            AddCreature(entry, name, minlevel, maxlevel, rank);
        }

        public static void DeleteCreature(int entry)
        {
            if (Creatures == null)
                LoadCreatures();
            var creature = (from c in Creatures where c.Entry == entry select c).SingleOrDefault();
            if (creature != null)
                Creatures.Remove(creature);
        }
    }

    // get or set world game data.
    public static class LegacyWorld
    {
        private const int MAX_GOSSIP_ITEM = 32;
        #region GENERIC
        public static Dictionary<int, string> GetLanguages()
        {
            return DataDefine.Language;
        }

        public static Dictionary<int, string> GetEmotes()
        {
            return DataDefine.Emotes;
        }
        #endregion
        #region ITEM
        public static ItemTemplate GetItemTemplate(int entry)
        {
            var itemDB = (from d in DB.LEGACY.item_template where d.entry == entry select d).SingleOrDefault();
            if (itemDB == null)
                return null;
            else
            {
                ItemTemplate item = new ItemTemplate();
                item.Entry = itemDB.entry;
                item.Class = itemDB.@class;
                item.Subclass = itemDB.subclass;
                item.SoundOverrideSubclass = itemDB.SoundOverrideSubclass;
                item.Name = itemDB.name;
                item.DisplayID = itemDB.displayid;
                item.Quality = itemDB.Quality;
                item.Flags = itemDB.Flags;
                item.FlagsExtra = itemDB.FlagsExtra;
                item.BuyCount = itemDB.BuyCount;
                item.BuyPrice = itemDB.BuyPrice;
                item.SellPrice = itemDB.SellPrice;
                item.InventoryType = itemDB.InventoryType;
                item.AllowableClass = itemDB.AllowableClass;
                item.AllowableRace = itemDB.AllowableRace;
                item.ItemLevel = itemDB.ItemLevel;
                item.RequiredLevel = itemDB.RequiredLevel;
                item.RequiredSkill = itemDB.RequiredSkill;
                item.RequiredSkillRank = itemDB.RequiredSkillRank;
                item.RequiredCityRank = itemDB.RequiredCityRank;
                item.RequiredReputationFaction = itemDB.RequiredReputationFaction;
                item.RequiredReputationRank = itemDB.RequiredReputationRank;
                item.MaxCount = itemDB.maxcount;
                item.Stackable = itemDB.stackable;
                item.ContainerSlot = itemDB.ContainerSlots;
                item.StatsCount = itemDB.StatsCount;
                item.StatType[0] = itemDB.stat_type1;
                item.StatType[1] = itemDB.stat_type2;
                item.StatType[2] = itemDB.stat_type3;
                item.StatType[3] = itemDB.stat_type4;
                item.StatType[4] = itemDB.stat_type5;
                item.StatType[5] = itemDB.stat_type6;
                item.StatType[6] = itemDB.stat_type7;
                item.StatType[7] = itemDB.stat_type8;
                item.StatType[8] = itemDB.stat_type9;
                item.StatType[9] = itemDB.stat_type10;
                item.StatValue[0] = itemDB.stat_value1;
                item.StatValue[1] = itemDB.stat_value2;
                item.StatValue[2] = itemDB.stat_value3;
                item.StatValue[3] = itemDB.stat_value4;
                item.StatValue[4] = itemDB.stat_value5;
                item.StatValue[5] = itemDB.stat_value6;
                item.StatValue[6] = itemDB.stat_value7;
                item.StatValue[7] = itemDB.stat_value8;
                item.StatValue[8] = itemDB.stat_value9;
                item.StatValue[9] = itemDB.stat_value10;
                item.ScalingStatDistribution = itemDB.ScalingStatDistribution;
                item.ScalingStatValue = itemDB.ScalingStatValue;
                item.DamageMin[0] = itemDB.dmg_min1;
                item.DamageMin[1] = itemDB.dmg_min2;
                item.DamageMax[0] = itemDB.dmg_max1;
                item.DamageMax[1] = itemDB.dmg_max2;
                item.DamageSchool[0] = itemDB.dmg_type1;
                item.DamageSchool[1] = itemDB.dmg_type2;
                item.Armor = itemDB.armor;
                item.HolyResistance = itemDB.holy_res;
                item.FireResistance = itemDB.fire_res;
                item.NatureResistance = itemDB.nature_res;
                item.FrostResistance = itemDB.frost_res;
                item.ShadowResistance = itemDB.shadow_res;
                item.ArcaneResistance = itemDB.arcane_res;
                item.Speed = itemDB.delay;
                item.AmmoType = itemDB.ammo_type;
                item.RangedModRange = itemDB.RangedModRange;
                item.Spell[0] = itemDB.spellid_1;
                item.Spell[1] = itemDB.spellid_2;
                item.Spell[2] = itemDB.spellid_3;
                item.Spell[3] = itemDB.spellid_4;
                item.Spell[4] = itemDB.spellid_5;
                item.SpellTrigger[0] = itemDB.spelltrigger_1;
                item.SpellTrigger[1] = itemDB.spelltrigger_2;
                item.SpellTrigger[2] = itemDB.spelltrigger_3;
                item.SpellTrigger[3] = itemDB.spelltrigger_4;
                item.SpellTrigger[4] = itemDB.spelltrigger_5;
                item.SpellCharges[0] = itemDB.spellcharges_1;
                item.SpellCharges[1] = itemDB.spellcharges_2;
                item.SpellCharges[2] = itemDB.spellcharges_3;
                item.SpellCharges[3] = itemDB.spellcharges_4;
                item.SpellCharges[4] = itemDB.spellcharges_5;
                item.SpellPPM[0] = itemDB.spellppmRate_1;
                item.SpellPPM[1] = itemDB.spellppmRate_2;
                item.SpellPPM[2] = itemDB.spellppmRate_3;
                item.SpellPPM[3] = itemDB.spellppmRate_4;
                item.SpellPPM[4] = itemDB.spellppmRate_5;
                item.SpellCooldown[0] = itemDB.spellcooldown_1;
                item.SpellCooldown[1] = itemDB.spellcooldown_2;
                item.SpellCooldown[2] = itemDB.spellcooldown_3;
                item.SpellCooldown[3] = itemDB.spellcooldown_4;
                item.SpellCooldown[4] = itemDB.spellcooldown_5;
                item.SpellCategory[0] = itemDB.spellcategory_1;
                item.SpellCategory[1] = itemDB.spellcategory_2;
                item.SpellCategory[2] = itemDB.spellcategory_3;
                item.SpellCategory[3] = itemDB.spellcategory_4;
                item.SpellCategory[4] = itemDB.spellcategory_5;
                item.SpellCategoryCooldown[0] = itemDB.spellcategorycooldown_1;
                item.SpellCategoryCooldown[1] = itemDB.spellcategorycooldown_2;
                item.SpellCategoryCooldown[2] = itemDB.spellcategorycooldown_3;
                item.SpellCategoryCooldown[3] = itemDB.spellcategorycooldown_4;
                item.SpellCategoryCooldown[4] = itemDB.spellcategorycooldown_5;
                item.Bonding = itemDB.bonding;
                item.Description = itemDB.description;
                item.PageText = itemDB.PageText;
                item.LanguageID = itemDB.LanguageID;
                item.PageMaterial = itemDB.PageMaterial;
                item.StartQuest = itemDB.startquest;
                item.LockID = itemDB.lockid;
                item.Material = itemDB.Material;
                item.Sheath = itemDB.sheath;
                item.RandomProperty = itemDB.RandomProperty;
                item.RandomSuffix = itemDB.RandomSuffix;
                item.Block = itemDB.block;
                item.ItemSet = itemDB.itemset;
                item.MaxDurability = itemDB.MaxDurability;
                item.Area = itemDB.area;
                item.Map = itemDB.Map;
                item.BagFamily = itemDB.BagFamily;
                item.TotemCategory = itemDB.TotemCategory;
                item.SocketColor[0] = itemDB.socketColor_1;
                item.SocketColor[1] = itemDB.socketColor_2;
                item.SocketColor[2] = itemDB.socketColor_3;
                item.SocketContent[0] = itemDB.socketContent_1;
                item.SocketContent[1] = itemDB.socketContent_2;
                item.SocketContent[2] = itemDB.socketContent_3;
                item.SocketBonus = itemDB.socketBonus;
                item.GemProperty = itemDB.GemProperties;
                item.RequiredDisenchantSkill = itemDB.RequiredDisenchantSkill;
                item.ArmorDamageModifier = itemDB.ArmorDamageModifier;
                item.Duration = itemDB.duration;
                item.ItemLimitCategory = itemDB.ItemLimitCategory;
                item.HolidayID = itemDB.HolidayId;
                item.ScriptName = itemDB.ScriptName;
                item.DisenchantID = itemDB.DisenchantID;
                item.FoodType = itemDB.FoodType;
                item.MinMoneyLoot = itemDB.minMoneyLoot;
                item.MaxMoneyLoot = itemDB.maxMoneyLoot;
                item.CustomFlags = itemDB.flagsCustom;
                item.VerifiedBuild = itemDB.VerifiedBuild;
                return item;
            }
        }

        public static ItemTemplate SaveItemTemplate(ItemTemplate item, bool newItem = false)
        {
            if (item == null)
                return null;

            int maxid = (from d in DB.LEGACY.item_template select d.entry).Max() + 1;

            if (item.Entry == 0 || newItem)
            {
                item.Entry = maxid;
                DBCache.AddItem(item.Entry, item.Class, item.Subclass, item.Name, item.Quality);
            }
            else
            {
                var oldItem = (from d in DB.LEGACY.item_template where d.entry == item.Entry select d).SingleOrDefault();
                if (oldItem != null)
                    DB.LEGACY.item_template.Remove(oldItem);
                DBCache.UpdateItem(item.Entry, item.Class, item.Subclass, item.Name, item.Quality);
            }

            DB.LEGACY.item_template.Add(new item_template()
            {
                entry = item.Entry,
                @class = (byte)item.Class,
                subclass = (byte)item.Subclass,
                SoundOverrideSubclass = (sbyte)item.SoundOverrideSubclass,
                name = item.Name,
                displayid = item.DisplayID,
                Quality = (byte)item.Quality,
                Flags = item.Flags,
                FlagsExtra = item.FlagsExtra,
                BuyCount = item.BuyCount,
                BuyPrice = item.BuyPrice,
                SellPrice = item.SellPrice,
                InventoryType = (byte)item.InventoryType,
                AllowableClass = item.AllowableClass,
                AllowableRace = item.AllowableRace,
                ItemLevel = item.ItemLevel,
                RequiredLevel = item.RequiredLevel,
                RequiredSkill = item.RequiredSkill,
                RequiredSkillRank = item.RequiredSkillRank,
                RequiredCityRank = item.RequiredCityRank,
                RequiredReputationFaction = item.RequiredReputationFaction,
                RequiredReputationRank = item.RequiredReputationRank,
                maxcount = item.MaxCount,
                stackable = item.Stackable,
                ContainerSlots = item.ContainerSlot,
                StatsCount = item.StatsCount,
                stat_type1 = (byte)item.StatType[0],
                stat_type2 = (byte)item.StatType[1],
                stat_type3 = (byte)item.StatType[2],
                stat_type4 = (byte)item.StatType[3],
                stat_type5 = (byte)item.StatType[4],
                stat_type6 = (byte)item.StatType[5],
                stat_type7 = (byte)item.StatType[6],
                stat_type8 = (byte)item.StatType[7],
                stat_type9 = (byte)item.StatType[8],
                stat_type10 = (byte)item.StatType[9],
                stat_value1 = item.StatValue[0],
                stat_value2 = item.StatValue[1],
                stat_value3 = item.StatValue[2],
                stat_value4 = item.StatValue[3],
                stat_value5 = item.StatValue[4],
                stat_value6 = item.StatValue[5],
                stat_value7 = item.StatValue[6],
                stat_value8 = item.StatValue[7],
                stat_value9 = item.StatValue[8],
                stat_value10 = item.StatValue[9],
                ScalingStatDistribution = item.ScalingStatDistribution,
                ScalingStatValue = item.ScalingStatValue,
                dmg_min1 = item.DamageMin[0],
                dmg_min2 = item.DamageMin[1],
                dmg_max1 = item.DamageMax[0],
                dmg_max2 = item.DamageMax[1],
                dmg_type1 = (byte)item.DamageSchool[0],
                dmg_type2 = (byte)item.DamageSchool[1],
                armor = item.Armor,
                holy_res = item.HolyResistance,
                fire_res = item.FireResistance,
                nature_res = item.NatureResistance,
                frost_res = item.FrostResistance,
                shadow_res = item.ShadowResistance,
                arcane_res = item.ArcaneResistance,
                delay = item.Speed,
                ammo_type = (byte)item.AmmoType,
                RangedModRange = item.RangedModRange,
                spellid_1 = item.Spell[0],
                spellid_2 = item.Spell[1],
                spellid_3 = item.Spell[2],
                spellid_4 = item.Spell[3],
                spellid_5 = item.Spell[4],
                spelltrigger_1 = (byte)item.SpellTrigger[0],
                spelltrigger_2 = (byte)item.SpellTrigger[1],
                spelltrigger_3 = (byte)item.SpellTrigger[2],
                spelltrigger_4 = (byte)item.SpellTrigger[3],
                spelltrigger_5 = (byte)item.SpellTrigger[4],
                spellcharges_1 = item.SpellCharges[0],
                spellcharges_2 = item.SpellCharges[1],
                spellcharges_3 = item.SpellCharges[2],
                spellcharges_4 = item.SpellCharges[3],
                spellcharges_5 = item.SpellCharges[4],
                spellppmRate_1 = item.SpellPPM[0],
                spellppmRate_2 = item.SpellPPM[1],
                spellppmRate_3 = item.SpellPPM[2],
                spellppmRate_4 = item.SpellPPM[3],
                spellppmRate_5 = item.SpellPPM[4],
                spellcooldown_1 = item.SpellCooldown[0],
                spellcooldown_2 = item.SpellCooldown[1],
                spellcooldown_3 = item.SpellCooldown[2],
                spellcooldown_4 = item.SpellCooldown[3],
                spellcooldown_5 = item.SpellCooldown[4],
                spellcategory_1 = item.SpellCategory[0],
                spellcategory_2 = item.SpellCategory[1],
                spellcategory_3 = item.SpellCategory[2],
                spellcategory_4 = item.SpellCategory[3],
                spellcategory_5 = item.SpellCategory[4],
                spellcategorycooldown_1 = item.SpellCategoryCooldown[0],
                spellcategorycooldown_2 = item.SpellCategoryCooldown[1],
                spellcategorycooldown_3 = item.SpellCategoryCooldown[2],
                spellcategorycooldown_4 = item.SpellCategoryCooldown[3],
                spellcategorycooldown_5 = item.SpellCategoryCooldown[4],
                bonding = (byte)item.Bonding,
                description = item.Description,
                PageText = item.PageText,
                LanguageID = item.LanguageID,
                PageMaterial = (byte)item.PageMaterial,
                startquest = item.StartQuest,
                lockid = item.LockID,
                Material = (sbyte)item.Material,
                sheath = (byte)item.Sheath,
                RandomProperty = item.RandomProperty,
                RandomSuffix = item.RandomSuffix,
                block = item.Block,
                itemset = item.ItemSet,
                MaxDurability = item.MaxDurability,
                area = item.Area,
                Map = item.Map,
                BagFamily = item.BagFamily,
                TotemCategory = item.TotemCategory,
                socketColor_1 = (sbyte)item.SocketColor[0],
                socketColor_2 = (sbyte)item.SocketColor[1],
                socketColor_3 = (sbyte)item.SocketColor[2],
                socketContent_1 = item.SocketContent[0],
                socketContent_2 = item.SocketContent[1],
                socketContent_3 = item.SocketContent[2],
                socketBonus = item.SocketBonus,
                GemProperties = item.GemProperty,
                RequiredDisenchantSkill = item.RequiredDisenchantSkill,
                ArmorDamageModifier = item.ArmorDamageModifier,
                duration = item.Duration,
                ItemLimitCategory = item.ItemLimitCategory,
                HolidayId = item.HolidayID,
                ScriptName = item.ScriptName,
                DisenchantID = item.DisenchantID,
                FoodType = (byte)item.FoodType,
                minMoneyLoot = item.MinMoneyLoot,
                maxMoneyLoot = item.MaxMoneyLoot,
                flagsCustom = item.CustomFlags,
                VerifiedBuild = item.VerifiedBuild
            });
            DB.LEGACY.SaveChanges();
            DB.Refresh();
            return item;
        }

        public static List<ItemInfo> GetItemList()
        {
            return DBCache.GetItems();
        }

        public static ItemTemplate CreateItemTemplate()
        {
            return SaveItemTemplate(new ItemTemplate()
            {
                Entry = 0,
                Class = 0,
                Subclass = 0,
                SoundOverrideSubclass = 0,
                Name = "",
                DisplayID = 0,
                Quality = 0,
                Flags = 0,
                FlagsExtra = 0,
                BuyCount = 0,
                BuyPrice = 0,
                InventoryType = 0,
                AllowableClass = -1,
                AllowableRace = -1,
                ItemLevel = 0,
                RequiredLevel = 0,
                RequiredSkill = 0,
                RequiredSkillRank = 0,
                RequiredCityRank = 0,
                RequiredReputationFaction = 0,
                RequiredReputationRank = 0,
                MaxCount = 0,
                Stackable = 0,
                ContainerSlot = 0,
                StatsCount = 0,
                ScalingStatDistribution = 0,
                ScalingStatValue = 0,
                Armor = 0,
                HolyResistance = 0,
                FireResistance = 0,
                NatureResistance = 0,
                FrostResistance = 0,
                ShadowResistance = 0,
                ArcaneResistance = 0,
                Speed = 0,
                AmmoType = 0,
                RangedModRange = 0,
                Bonding = 0,
                Description = "",
                PageText = 0,
                LanguageID = 0,
                PageMaterial = 0,
                StartQuest = 0,
                LockID = 0,
                Material = 0,
                Sheath = 0,
                RandomProperty = 0,
                RandomSuffix = 0,
                Block = 0,
                ItemSet = 0,
                MaxDurability = 0,
                Area = 0,
                Map = 0,
                BagFamily = 0,
                TotemCategory = 0,
                SocketBonus = 0,
                GemProperty = 0,
                RequiredDisenchantSkill = 0,
                ArmorDamageModifier = 0,
                Duration = 0,
                ItemLimitCategory = 0,
                HolidayID = 0,
                ScriptName = "",
                DisenchantID = 0,
                FoodType = 0,
                MinMoneyLoot = 0,
                MaxMoneyLoot = 0,
                CustomFlags = 0,
                VerifiedBuild = 0,
            });
        }

        public static void DeleteItemTemplate(int entry)
        {
            var item = (from d in DB.LEGACY.item_template where d.entry == entry select d).SingleOrDefault();
            if (item != null)
            {
                DB.LEGACY.item_template.Remove(item);
                DB.LEGACY.SaveChanges();
                DBCache.DeleteItem(entry);
            }
        }

        public static ItemTemplate CopyItemTemplate(int entry)
        {
            ItemTemplate newItem = SaveItemTemplate(GetItemTemplate(entry), true);
            return newItem;
        }

        public static List<ItemDBC> GenerateItemDBC()
        {
            List<ItemDBC> list = new List<ItemDBC>();
            var items = from d in DB.LEGACY.item_template select d;
            foreach (var item in items)
                list.Add(new ItemDBC(item.entry, item.@class, item.subclass, item.SoundOverrideSubclass, item.Material, item.displayid, item.InventoryType, item.sheath));
            DB.Refresh();
            return list;
        }
        #endregion
        #region CREATURE GOSSIP
        public static Dictionary<int, string> GetGossipMenuOptionTypes()
        {
            return DataDefine.GossipOption;
        }

        public static Dictionary<int, string> GetGossipIconDefines()
        {
            return DataDefine.GossipIcon;
        }

        public static Dictionary<int, string> GetCreatureNames()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            var creatureNames = from d in DB.LEGACY.creature_template select d;
            foreach (var creatureName in creatureNames)
                dict.Add(creatureName.entry, creatureName.name);
            DB.Refresh();
            return dict;
        }
        #endregion
        #region CREATURE VENDOR
        public static List<VendorInfo> GetVendorList(int entry)
        {
            List<VendorInfo> list = new List<VendorInfo>();
            var vendor = from d in DB.LEGACY.npc_vendor where d.entry == entry select d;
            foreach (var v in vendor)
            {
                list.Add(new VendorInfo()
                {
                    Slot = v.slot,
                    Item = v.item,
                    MaxCount = v.maxcount,
                    IncrTime = v.incrtime,
                    ExtendedCost = v.ExtendedCost,
                    VerifiedBuild = v.VerifiedBuild
                });
            }
            return list;
        }

        public static List<VendorInfo> GetVendorListAll()
        {
            List<VendorInfo> list = new List<VendorInfo>();
            var vendors = from d in DB.LEGACY.npc_vendor select d;
            foreach (var v in vendors)
            {
                list.Add(new VendorInfo()
                {
                    Slot = v.slot,
                    Item = v.item,
                    MaxCount = v.maxcount,
                    IncrTime = v.incrtime,
                    ExtendedCost = v.ExtendedCost,
                    VerifiedBuild = v.VerifiedBuild
                });
            }
            return list;
        }

        public static void AppendVendorInfo(int relatedItem, VendorInfo vendor)
        {
            var relation = (from d in DB.LEGACY.npc_vendor where d.item == relatedItem select d).ToList();
            if (relation.Count == 0) return;

            foreach (var rel in relation)
            {
                var oldVendor = (from d in DB.LEGACY.npc_vendor where d.entry == rel.entry && d.item == vendor.Item select d).SingleOrDefault();
                if (oldVendor != null)
                    DB.LEGACY.npc_vendor.Remove(oldVendor);

                DB.LEGACY.npc_vendor.Add(new npc_vendor()
                {
                    entry = rel.entry,
                    slot = vendor.Slot,
                    item = vendor.Item,
                    maxcount = vendor.MaxCount,
                    incrtime = vendor.IncrTime,
                    ExtendedCost = vendor.ExtendedCost,
                    VerifiedBuild = vendor.VerifiedBuild
                });
            }
            DB.LEGACY.SaveChanges();
        }

        public static bool SaveVendorList(int npcEntry, List<VendorInfo> list)
        {
            if (list.Count == 0)
            {
                var creature = (from d in DB.LEGACY.creature_template where d.entry == npcEntry select d).SingleOrDefault();
                if (creature != null)
                {
                    creature.npcflag ^= 128;
                    DB.LEGACY.SaveChanges();
                    return true;
                }
            }

            var npc = (from d in DB.LEGACY.creature_template where d.entry == npcEntry select d).SingleOrDefault();
            if (npc == null)
                return false;
            else
                npc.npcflag |= 128;

            var oldVendor = from d in DB.LEGACY.npc_vendor where d.entry == npcEntry select d;
            if (oldVendor.Count() != 0)
            {
                foreach (var v in oldVendor)
                    DB.LEGACY.npc_vendor.Remove(v);
            }

            foreach (var vendor in list)
            {
                DB.LEGACY.npc_vendor.Add(new npc_vendor()
                {
                    entry = npcEntry,
                    slot = vendor.Slot,
                    item = vendor.Item,
                    maxcount = vendor.MaxCount,
                    incrtime = vendor.IncrTime,
                    ExtendedCost = vendor.ExtendedCost,
                    VerifiedBuild = vendor.VerifiedBuild
                });
            }

            DB.LEGACY.SaveChanges();

            return true;
        }
        #endregion
        #region CREATURE TEMPLATE
        public static CreatureTemplate GetCreatureTemplate(int entry)
        {
            var c = (from d in DB.LEGACY.creature_template where d.entry == entry select d).SingleOrDefault();
            if (c == null)
                return null;

            CreatureTemplate creature = new CreatureTemplate();
            creature.Entry[0] = c.entry;
            creature.Entry[1] = c.difficulty_entry_1;
            creature.Entry[2] = c.difficulty_entry_2;
            creature.Entry[3] = c.difficulty_entry_3;
            creature.KillCredit[0] = c.KillCredit1;
            creature.KillCredit[1] = c.KillCredit2;
            creature.Model[0] = c.modelid1;
            creature.Model[1] = c.modelid2;
            creature.Model[2] = c.modelid3;
            creature.Model[3] = c.modelid4;
            creature.Name = c.name;
            creature.Subname = c.subname;
            creature.IconName = c.IconName;
            creature.GossipMenuID = c.gossip_menu_id;
            creature.MinLevel = c.minlevel;
            creature.MaxLevel = c.maxlevel;
            creature.Expansion = c.exp;
            creature.Faction = c.faction;
            creature.NpcFlags = c.npcflag;
            creature.SpeedWalk = c.speed_walk;
            creature.SpeedRun = c.speed_run;
            creature.Scale = c.scale;
            creature.Rank = c.rank;
            creature.DamageSchool = c.dmgschool;
            creature.BaseAttackTime = c.BaseAttackTime;
            creature.RangedAttackTime = c.RangeAttackTime;
            creature.BaseVariance = c.BaseVariance;
            creature.RangedVariance = c.RangeVariance;
            creature.UnitClass = c.unit_class;
            creature.UnitFlags = c.unit_flags;
            creature.UnitFlags2 = c.unit_flags2;
            creature.DynamicFlags = c.dynamicflags;
            creature.Family = c.family;
            creature.TrainerType = c.trainer_type;
            creature.TrainerSpell = c.trainer_spell;
            creature.TrainerClass = c.trainer_class;
            creature.TrainerRace = c.trainer_race;
            creature.Type = c.type;
            creature.TypeFlags = c.type_flags;
            creature.LootID = c.lootid;
            creature.PickpocketLoot = c.pickpocketloot;
            creature.SkinLoot = c.skinloot;
            creature.Resistance[0] = c.resistance1;
            creature.Resistance[1] = c.resistance2;
            creature.Resistance[2] = c.resistance3;
            creature.Resistance[3] = c.resistance4;
            creature.Resistance[4] = c.resistance5;
            creature.Resistance[5] = c.resistance6;
            creature.Spell[0] = c.spell1;
            creature.Spell[1] = c.spell2;
            creature.Spell[2] = c.spell3;
            creature.Spell[3] = c.spell4;
            creature.Spell[4] = c.spell5;
            creature.Spell[5] = c.spell6;
            creature.Spell[6] = c.spell7;
            creature.Spell[7] = c.spell8;
            creature.PetSpellDataID = c.PetSpellDataId;
            creature.VehicleID = c.VehicleId;
            creature.MinMoneyLoot = c.mingold;
            creature.MaxMoneyLoot = c.maxgold;
            creature.AIName = c.AIName;
            creature.MovementType = c.MovementType;
            creature.InhabitType = c.InhabitType;
            creature.HoverHeight = c.HoverHeight;
            creature.HealthModifier = c.HealthModifier;
            creature.ManaModifier = c.ManaModifier;
            creature.ArmorModifier = c.ArmorModifier;
            creature.DamageModifier = c.DamageModifier;
            creature.ExperienceModifier = c.ExperienceModifier;
            creature.IsRacialLeader = c.RacialLeader != 0 ? true : false;
            creature.QuestItem[0] = c.questItem1;
            creature.QuestItem[1] = c.questItem2;
            creature.QuestItem[2] = c.questItem3;
            creature.QuestItem[3] = c.questItem4;
            creature.QuestItem[4] = c.questItem5;
            creature.QuestItem[5] = c.questItem6;
            creature.MovementID = c.movementId;
            creature.RegenerateHealth = c.RegenHealth != 0 ? true : false;
            creature.MechanicImmuneMask = c.mechanic_immune_mask;
            creature.ExtraFlags = c.flags_extra;
            creature.ScriptName = c.ScriptName;
            creature.VerifiedBuild = c.VerifiedBuild;
            creature.WarSchool = c.WarSchool;
            creature.ResearchSet[0] = c.ResearchSet1;
            creature.ResearchSet[1] = c.ResearchSet2;
            creature.ResearchSet[2] = c.ResearchSet3;
            creature.ResearchSet[3] = c.ResearchSet4;
            creature.ResearchSet[4] = c.ResearchSet5;
            creature.ResearchSet[5] = c.ResearchSet6;
            DB.Refresh();
            return creature;
        }

        public static CreatureTemplate SaveCreatureTemplate(CreatureTemplate creature)
        {
            if (creature.Entry[0] != 0)
            {
                int entry = creature.Entry[0];
                var c = (from d in DB.LEGACY.creature_template where d.entry == entry select d).SingleOrDefault();

                if (c != null)
                    DB.LEGACY.creature_template.Remove(c);
            }
            else
                creature.Entry[0] = (from d in DB.LEGACY.creature_template select d.entry).Max() + 1;

            DBCache.UpdateCreature(creature.Entry[0], creature.Name, creature.MinLevel, creature.MaxLevel, creature.Rank);

            DB.LEGACY.creature_template.Add(new creature_template()
            {
                entry = creature.Entry[0],
                difficulty_entry_1 = creature.Entry[1],
                difficulty_entry_2 = creature.Entry[2],
                difficulty_entry_3 = creature.Entry[3],
                KillCredit1 = creature.KillCredit[0],
                KillCredit2 = creature.KillCredit[1],
                modelid1 = creature.Model[0],
                modelid2 = creature.Model[1],
                modelid3 = creature.Model[2],
                modelid4 = creature.Model[3],
                name = creature.Name,
                subname = creature.Subname,
                IconName = creature.IconName,
                gossip_menu_id = creature.GossipMenuID,
                minlevel = creature.MinLevel,
                maxlevel = creature.MaxLevel,
                exp = creature.Expansion,
                faction = creature.Faction,
                npcflag = creature.NpcFlags,
                speed_walk = creature.SpeedWalk,
                speed_run = creature.SpeedRun,
                scale = creature.Scale,
                rank = creature.Rank,
                dmgschool = creature.DamageSchool,
                BaseAttackTime = creature.BaseAttackTime,
                RangeAttackTime = creature.RangedAttackTime,
                BaseVariance = creature.BaseVariance,
                RangeVariance = creature.RangedVariance,
                unit_class = creature.UnitClass,
                unit_flags = creature.UnitFlags,
                unit_flags2 = creature.UnitFlags2,
                dynamicflags = creature.DynamicFlags,
                family = creature.Family,
                trainer_type = creature.TrainerType,
                trainer_spell = creature.TrainerSpell,
                trainer_class = creature.TrainerClass,
                trainer_race = creature.TrainerRace,
                type = creature.Type,
                type_flags = creature.TypeFlags,
                lootid = creature.LootID,
                pickpocketloot = creature.PickpocketLoot,
                skinloot = creature.SkinLoot,
                resistance1 = creature.Resistance[0],
                resistance2 = creature.Resistance[1],
                resistance3 = creature.Resistance[2],
                resistance4 = creature.Resistance[3],
                resistance5 = creature.Resistance[4],
                resistance6 = creature.Resistance[5],
                spell1 = creature.Spell[0],
                spell2 = creature.Spell[1],
                spell3 = creature.Spell[2],
                spell4 = creature.Spell[3],
                spell5 = creature.Spell[4],
                spell6 = creature.Spell[5],
                spell7 = creature.Spell[6],
                spell8 = creature.Spell[7],
                PetSpellDataId = creature.PetSpellDataID,
                VehicleId = creature.VehicleID,
                mingold = creature.MinMoneyLoot,
                maxgold = creature.MaxMoneyLoot,
                AIName = creature.AIName,
                MovementType = creature.MovementType,
                InhabitType = creature.InhabitType,
                HoverHeight = creature.HoverHeight,
                HealthModifier = creature.HealthModifier,
                ManaModifier = creature.ManaModifier,
                ArmorModifier = creature.ArmorModifier,
                DamageModifier = creature.DamageModifier,
                ExperienceModifier = creature.ExperienceModifier,
                RacialLeader = creature.IsRacialLeader == true ? (byte)1 : (byte)0,
                questItem1 = creature.QuestItem[0],
                questItem2 = creature.QuestItem[1],
                questItem3 = creature.QuestItem[2],
                questItem4 = creature.QuestItem[3],
                questItem5 = creature.QuestItem[4],
                questItem6 = creature.QuestItem[5],
                movementId = creature.MovementID,
                RegenHealth = creature.RegenerateHealth == true ? (byte)1 : (byte)0,
                mechanic_immune_mask = creature.MechanicImmuneMask,
                flags_extra = creature.ExtraFlags,
                ScriptName = creature.ScriptName,
                VerifiedBuild = creature.VerifiedBuild,
                WarSchool = creature.WarSchool,
                ResearchSet1 = creature.ResearchSet[0],
                ResearchSet2 = creature.ResearchSet[1],
                ResearchSet3 = creature.ResearchSet[2],
                ResearchSet4 = creature.ResearchSet[3],
                ResearchSet5 = creature.ResearchSet[4],
                ResearchSet6 = creature.ResearchSet[5]
            });

            DB.LEGACY.SaveChanges();

            return creature;
        }

        public static List<CreatureInfo> GetCreatureList()
        {
            return DBCache.GetCreatures();
        }

        public static void DeleteCreatureTemplate(int entry)
        {
            var creature = (from d in DB.LEGACY.creature_template where d.entry == entry select d).SingleOrDefault();
            if (creature != null)
            {
                DB.LEGACY.creature_template.Remove(creature);
                DB.LEGACY.SaveChanges();
                DBCache.DeleteCreature(entry);
            }
        }

        public static List<Creature> GetSpawnInfo(int entry)
        {
            List<Creature> list = new List<Creature>();

            var creatures = from d in DB.LEGACY.creature where d.id == entry select d;
            if (creatures.Count() == 0)
                return list;

            foreach (var c in creatures)
                list.Add(new Creature()
                {
                    Guid = c.guid,
                    Map = c.map,
                    Zone = c.zoneId,
                    Area = c.areaId,
                    SpawnMask = c.spawnMask,
                    PhaseMask = c.phaseMask,
                    Model = c.modelid,
                    EquipmentID = c.equipment_id,
                    PositionX = c.position_x,
                    PositionY = c.position_y,
                    PositionZ = c.position_z,
                    Orientation = c.orientation,
                    SpawnTime = c.spawntimesecs,
                    SpawnDistance = c.spawndist,
                    CurrentWaypoint = c.currentwaypoint,
                    CurrentHealth = c.curhealth,
                    CurrentMana = c.curmana,
                    MovementType = c.MovementType,
                    NpcFlags = c.npcflag,
                    UnitFlags = c.unit_flags,
                    DynamicFlags = c.dynamicflags,
                    VerifiedBuild = c.VerifiedBuild
                });
            return list;
        }

        public static void SaveSpawnInfo(int entry, List<Creature> list)
        {
            if (list == null || list.Count == 0)
                return;

            var oldSpawns = from d in DB.LEGACY.creature where d.id == entry select d;
            if (oldSpawns.Count() != 0)
            {
                foreach (var spawn in oldSpawns)
                    DB.LEGACY.creature.Remove(spawn);
            }

            if (list.Count != 0)
            {
                foreach (var spawn in list)
                {
                    DB.LEGACY.creature.Add(new creature()
                    {
                        guid = spawn.Guid,
                        id = entry,
                        map = spawn.Map,
                        zoneId = spawn.Zone,
                        areaId = spawn.Area,
                        spawnMask = spawn.SpawnMask,
                        phaseMask = spawn.PhaseMask,
                        modelid = spawn.Model,
                        equipment_id = spawn.EquipmentID,
                        position_x = spawn.PositionX,
                        position_y = spawn.PositionY,
                        position_z = spawn.PositionZ,
                        orientation = spawn.Orientation,
                        spawntimesecs = spawn.SpawnTime,
                        spawndist = spawn.SpawnDistance,
                        currentwaypoint = spawn.CurrentWaypoint,
                        curhealth = spawn.CurrentHealth,
                        curmana = spawn.CurrentMana,
                        MovementType = spawn.MovementType,
                        npcflag = spawn.NpcFlags,
                        unit_flags = spawn.UnitFlags,
                        dynamicflags = spawn.DynamicFlags,
                        VerifiedBuild = spawn.VerifiedBuild
                    });
                }
            }

            DB.LEGACY.SaveChanges();
        }
        #endregion
        #region CREATURE TRAINER
        public static List<NpcTrainerInfo> GetCreatureTrainerInfo(int entry)
        {
            List<NpcTrainerInfo> list = new List<NpcTrainerInfo>();
            var trainerInfo = from d in DB.LEGACY.npc_trainer where d.entry == entry select d;
            if (trainerInfo.Count() == 0)
                return list;
            foreach (var info in trainerInfo)
            {
                NpcTrainerInfo cti = new NpcTrainerInfo();
                cti.Cost = info.spellcost;
                cti.Entry = info.entry;
                cti.Level = info.reqlevel;
                cti.Skill = info.reqskill;
                cti.SkillValue = info.reqskillvalue;
                cti.Spell = info.spell;
                cti.CityRank = info.reqcityrank;
                list.Add(cti);
            }

            List<NpcTrainerInfo> list2 = new List<NpcTrainerInfo>();
            foreach (var item in list)
            {
                if (item.Spell < 0)
                {
                    int realentry = -item.Spell;
                    var realInfo = from d in DB.LEGACY.npc_trainer where d.entry == realentry select d;
                    foreach (var rInfo in realInfo)
                    {
                        NpcTrainerInfo cti2 = new NpcTrainerInfo();
                        cti2.Entry = rInfo.entry;
                        cti2.Cost = rInfo.spellcost;
                        cti2.Level = rInfo.reqlevel;
                        cti2.Skill = rInfo.reqskill;
                        cti2.SkillValue = rInfo.reqskillvalue;
                        cti2.Spell = rInfo.spell;
                        cti2.CityRank = rInfo.reqcityrank;
                        list2.Add(cti2);
                    }
                }
            }

            if (list2.Count != 0)
            {
                foreach (var item in list2)
                    list.Add(item);
            }

            return list;
        }

        public static void SaveCreatureTrainerInfo(List<NpcTrainerInfo> list)
        {
            if (list == null || list.Count == 0)
                return;

            foreach (var info in list)
            {
                var old = from d in DB.LEGACY.npc_trainer where d.entry == info.Entry select d;
                if (old.Count() != 0)
                {
                    foreach (var o in old)
                        DB.LEGACY.npc_trainer.Remove(o);
                }
                DB.LEGACY.npc_trainer.Add(new npc_trainer()
                {
                    entry = info.Entry,
                    spell = info.Spell,
                    spellcost = info.Cost,
                    reqskill = info.Skill,
                    reqskillvalue = info.SkillValue,
                    reqlevel = info.Level,
                    reqcityrank = info.CityRank
                });
            }

            DB.LEGACY.SaveChanges();
        }
        #endregion
        #region CREATURE LOOT
        public static List<Loot> GetCreatureLoot(int entry, bool onlyRef)
        {
            List<Loot> list = new List<Loot>();
            if (onlyRef)
            {
                var refloots = from d in DB.LEGACY.reference_loot_template where d.Entry == entry select d;
                foreach (var refloot in refloots)
                {
                    Loot lo = new Loot();
                    lo.Entry = refloot.Entry;
                    lo.Item = refloot.Item;
                    lo.Reference = refloot.Reference;
                    lo.Chance = refloot.Chance;
                    lo.QuestRequired = refloot.QuestRequired;
                    lo.LootMode = refloot.LootMode;
                    lo.GroupID = refloot.GroupId;
                    lo.MinCount = refloot.MinCount;
                    lo.MaxCount = refloot.MaxCount;
                    lo.Comment = refloot.Comment;
                    lo.IsRef = true;
                    list.Add(lo);
                }
                return list;
            }
            else
            {
                var loots = from d in DB.LEGACY.creature_loot_template where d.Entry == entry select d;
                foreach (var loot in loots)
                {
                    Loot l = new Loot();
                    l.Entry = loot.Entry;
                    l.Item = loot.Item;
                    l.Reference = loot.Reference;
                    l.Chance = loot.Chance;
                    l.QuestRequired = loot.QuestRequired;
                    l.LootMode = loot.LootMode;
                    l.GroupID = loot.GroupId;
                    l.MinCount = loot.MinCount;
                    l.MaxCount = loot.MaxCount;
                    l.Comment = loot.Comment;
                    l.IsRef = false;
                    list.Add(l);
                }

                List<Loot> refList = new List<Loot>();
                foreach (var l in list)
                {
                    if (l.Reference != 0)
                    {
                        var refloots = from d in DB.LEGACY.reference_loot_template where d.Entry == l.Reference select d;
                        foreach (var refloot in refloots)
                        {
                            Loot lo = new Loot();
                            lo.Entry = refloot.Entry;
                            lo.Item = refloot.Item;
                            lo.Reference = refloot.Reference;
                            lo.Chance = refloot.Chance;
                            lo.QuestRequired = refloot.QuestRequired;
                            lo.LootMode = refloot.LootMode;
                            lo.GroupID = refloot.GroupId;
                            lo.MinCount = refloot.MinCount;
                            lo.MaxCount = refloot.MaxCount;
                            lo.Comment = refloot.Comment;
                            lo.IsRef = true;
                            refList.Add(lo);
                        }
                    }
                }

                foreach (var lo in refList)
                    list.Add(lo);

                return list;
            }
        }

        public static void SaveCreatureLoot(List<Loot> list)
        {
            var creatureLoots = from d in list where d.IsRef == false select d;
            foreach (var creatureLoot in creatureLoots)
            {
                var oldLoot = from d in DB.LEGACY.creature_loot_template where d.Entry == creatureLoot.Entry && d.Item == creatureLoot.Item select d;
                foreach (var ol in oldLoot)
                    DB.LEGACY.creature_loot_template.Remove(ol);
                DB.LEGACY.creature_loot_template.Add(new creature_loot_template()
                {
                    Entry = creatureLoot.Entry,
                    Item = creatureLoot.Item,
                    Reference = creatureLoot.Reference,
                    Chance = creatureLoot.Chance,
                    QuestRequired = creatureLoot.QuestRequired,
                    LootMode = creatureLoot.LootMode,
                    GroupId = creatureLoot.GroupID,
                    MinCount = creatureLoot.MinCount,
                    MaxCount = creatureLoot.MaxCount,
                    Comment = creatureLoot.Comment,
                });
            }
            var refLoots = from d in list where d.IsRef == true select d;
            foreach (var refLoot in refLoots)
            {
                var oldLoot = from d in DB.LEGACY.reference_loot_template where d.Entry == refLoot.Entry && d.Item == refLoot.Item select d;
                foreach (var ol in oldLoot)
                    DB.LEGACY.reference_loot_template.Remove(ol);
                DB.LEGACY.reference_loot_template.Add(new reference_loot_template()
                {
                    Entry = refLoot.Entry,
                    Item = refLoot.Item,
                    Reference = refLoot.Reference,
                    Chance = refLoot.Chance,
                    QuestRequired = refLoot.QuestRequired,
                    LootMode = refLoot.LootMode,
                    GroupId = refLoot.GroupID,
                    MinCount = refLoot.MinCount,
                    MaxCount = refLoot.MaxCount,
                    Comment = refLoot.Comment,
                });
            }
            DB.LEGACY.SaveChanges();
            DB.Refresh();
        }
        #endregion
        #region SMARTSCRIPT
        public static List<SmartScript> GetSmartScript(int type, int entry)
        {
            List<SmartScript> list = new List<SmartScript>();
            var scripts = from d in DB.LEGACY.smart_scripts where d.source_type == type && d.entryorguid == entry select d;
            if (scripts.Count() == 0)
                return list;

            foreach (var script in scripts)
            {
                SmartScript smartScript = new SmartScript();
                smartScript.Entry = script.entryorguid;
                smartScript.SourceType = script.source_type;
                smartScript.ID = script.id;
                smartScript.Link = script.link;
                smartScript.Event = script.event_type;
                smartScript.Chance = script.event_chance;
                smartScript.EventPhase = script.event_phase_mask;
                smartScript.EventFlags = script.event_flags;
                smartScript.EventParam[0] = script.event_param1;
                smartScript.EventParam[1] = script.event_param2;
                smartScript.EventParam[2] = script.event_param3;
                smartScript.EventParam[3] = script.event_param4;
                smartScript.Action = script.action_type;
                smartScript.ActionParam[0] = script.action_param1;
                smartScript.ActionParam[1] = script.action_param2;
                smartScript.ActionParam[2] = script.action_param3;
                smartScript.ActionParam[3] = script.action_param4;
                smartScript.ActionParam[4] = script.action_param5;
                smartScript.ActionParam[5] = script.action_param6;
                smartScript.Target = script.target_type;
                smartScript.TargetParam[0] = script.target_param1;
                smartScript.TargetParam[1] = script.target_param2;
                smartScript.TargetParam[2] = script.target_param3;
                smartScript.TargetPosition[0] = script.target_x;
                smartScript.TargetPosition[1] = script.target_y;
                smartScript.TargetPosition[2] = script.target_z;
                smartScript.TargetPosition[3] = script.target_o;
                smartScript.Comment = script.comment;
                list.Add(smartScript);
            }

            return list;
        }

        public static void SaveSmartScript(List<SmartScript> list)
        {
            //var oldScripts = from d in DB.LEGACY.smart_scripts where d.source_type == type && d.entryorguid == entry select d;
            //if (oldScripts.Count() != 0)
            //{
            //    foreach (var script in oldScripts)
            //        DB.LEGACY.smart_scripts.Remove(script);
            //}
            foreach (var script in list)
            {
                DB.LEGACY.smart_scripts.Add(new smart_scripts()
                {
                    entryorguid = script.Entry,
                    source_type = script.SourceType,
                    id = script.ID,
                    link = script.Link,
                    event_type = script.Event,
                    event_phase_mask = script.EventPhase,
                    event_chance = script.Chance,
                    event_flags = script.EventFlags,
                    event_param1 = script.EventParam[0],
                    event_param2 = script.EventParam[1],
                    event_param3 = script.EventParam[2],
                    event_param4 = script.EventParam[3],
                    action_type = script.Action,
                    action_param1 = script.ActionParam[0],
                    action_param2 = script.ActionParam[1],
                    action_param3 = script.ActionParam[2],
                    action_param4 = script.ActionParam[3],
                    action_param5 = script.ActionParam[4],
                    action_param6 = script.ActionParam[5],
                    target_type = script.Target,
                    target_param1 = script.TargetParam[0],
                    target_param2 = script.TargetParam[1],
                    target_param3 = script.TargetParam[2],
                    target_x = script.TargetPosition[0],
                    target_y = script.TargetPosition[1],
                    target_z = script.TargetPosition[2],
                    target_o = script.TargetPosition[3],
                    comment = script.Comment
                });
            }
        }
        #endregion

        public static List<ItemEnchantmentTemplate> GetItemEnchants()
        {
            List<ItemEnchantmentTemplate> list = new List<ItemEnchantmentTemplate>();
            var enchants = from d in DB.LEGACY.item_enchantment_template select d;
            foreach (var enchant in enchants)
            {
                ItemEnchantmentTemplate ench = new ItemEnchantmentTemplate();
                ench.ID = enchant.entry;
                ench.Enchant = enchant.ench;
                ench.Chance = enchant.chance;
                list.Add(ench);
            }
            return list;
        }

        public static void SaveItemEnchants(List<ItemEnchantmentTemplate> list)
        {
            var olds = from d in DB.LEGACY.item_enchantment_template select d;
            foreach (var old in olds)
                DB.LEGACY.item_enchantment_template.Remove(old);

            foreach (var _new in list)
            {
                DB.LEGACY.item_enchantment_template.Add(new item_enchantment_template()
                {
                    entry = _new.ID,
                    ench = _new.Enchant,
                    chance = _new.Chance
                });
            }

            DB.LEGACY.SaveChanges();
        }

        public static BroadCastText GetBroadCastText(int entry)
        {
            var bct = (from d in DB.LEGACY.broadcast_text where d.ID == entry select d).SingleOrDefault();
            if (bct == null)
                return null;

            BroadCastText text = new BroadCastText();
            text.ID = bct.ID;
            text.Language = bct.Language;
            text.MaleText = bct.MaleText;
            text.FemaleText = bct.FemaleText;
            text.Emote0 = bct.EmoteID0;
            text.Emote1 = bct.EmoteID1;
            text.Emote2 = bct.EmoteID2;
            text.EmoteDelay0 = bct.EmoteDelay0;
            text.EmoteDelay1 = bct.EmoteDelay1;
            text.EmoteDelay2 = bct.EmoteDelay2;
            text.SoundID = bct.SoundId;
            return text;
        }

        public static BroadCastText SaveBroadCastText(BroadCastText text, bool createNew = false)
        {
            int maxID = (from d in DB.LEGACY.broadcast_text select d.ID).Max() + 1;

            if (createNew)
                text.ID = maxID;
            else
            {
                var oldEntry = (from d in DB.LEGACY.broadcast_text where d.ID == text.ID select d).SingleOrDefault();
                if (oldEntry != null)
                    DB.LEGACY.broadcast_text.Remove(oldEntry);
            }

            DB.LEGACY.broadcast_text.Add(new broadcast_text()
            {
                ID = text.ID,
                Language = text.Language,
                MaleText = text.MaleText,
                FemaleText = text.FemaleText,
                EmoteID0 = text.Emote0,
                EmoteID1 = text.Emote1,
                EmoteID2 = text.Emote2,
                EmoteDelay0 = text.EmoteDelay0,
                EmoteDelay1 = text.EmoteDelay1,
                EmoteDelay2 = text.EmoteDelay2,
                Unk1 = 0,
                Unk2 = 1,
                VerifiedBuild = 10000
            });

            DB.LEGACY.SaveChanges();

            return text;
        }

        public static List<GossipMenu> GetGossipMenu(int entry)
        {
            List<GossipMenu> menu = new List<GossipMenu>();
            var gossips = from d in DB.LEGACY.gossip_menu where d.entry == entry select d;
            foreach (var gossip in gossips)
            {
                GossipMenu m = new GossipMenu();
                m.Menu = gossip.entry;
                m.NpcText = gossip.text_id;
            }
            return menu;
        }

        public static void SaveGossipMenu(GossipMenu menu)
        {
            if (menu == null)
                return;

            var oldMenu = (from d in DB.LEGACY.gossip_menu where d.entry == menu.Menu && d.text_id == menu.NpcText select d).SingleOrDefault();
            if (oldMenu != null)
                DB.LEGACY.gossip_menu.Remove(oldMenu);
            DB.LEGACY.gossip_menu.Add(new gossip_menu()
            {
                entry = menu.Menu,
                text_id = menu.NpcText,
                Comment = menu.Comment
            });

            DB.LEGACY.SaveChanges();
        }

        public static List<GossipMenuItem> GetGossipMenuItems(int menuID)
        {
            List<GossipMenuItem> menuItems = new List<GossipMenuItem>();
            var items = from d in DB.LEGACY.gossip_menu_option where d.menu_id == menuID select d;
            if (items.Count() != 0)
            {
                foreach (var item in items)
                {
                    GossipMenuItem it = new GossipMenuItem();
                    it.Menu = item.menu_id;
                    it.ID = item.id;
                    it.Icon = item.option_icon;
                    it.GossipTextID = item.OptionBroadcastTextID;
                    it.OptionID = item.option_id;
                    it.NpcFlags = item.npc_option_npcflag;
                    it.ToMenu = item.action_menu_id;
                    it.POI = item.action_poi_id;
                    it.BoxCoded = item.box_coded != 0;
                    it.BoxMoney = item.box_money;
                    it.BoxTextID = item.BoxBroadcastTextID;
                    it.SingleTimeCheck = item.SingleTimeCheck != 0;
                    menuItems.Add(it);
                }
            }
            return menuItems;
        }

        public static void SaveGossipMenuItem(GossipMenuItem menuItem)
        {
            if (menuItem == null)
                return;

            var oldMenuItem = (from d in DB.LEGACY.gossip_menu_option where d.menu_id == menuItem.Menu && d.id == menuItem.ID select d).SingleOrDefault();
            if (oldMenuItem != null)
                DB.LEGACY.gossip_menu_option.Remove(oldMenuItem);

            DB.LEGACY.gossip_menu_option.Add(new gossip_menu_option()
            {
                menu_id = menuItem.Menu,
                id = menuItem.ID,
                option_icon = menuItem.Icon,
                OptionBroadcastTextID = menuItem.GossipTextID,
                option_id = menuItem.OptionID,
                npc_option_npcflag = menuItem.NpcFlags,
                action_menu_id = menuItem.ToMenu,
                action_poi_id = menuItem.POI,
                box_coded = (byte)(menuItem.BoxCoded ? 1 : 0),
                box_money = menuItem.BoxMoney,
                BoxBroadcastTextID = menuItem.BoxTextID,
                SingleTimeCheck = (byte)(menuItem.SingleTimeCheck ? 1 : 0)
            });
            DB.LEGACY.SaveChanges();
        }

        public static List<GossipMenu> GetAllGossipMenu()
        {
            List<GossipMenu> list = new List<GossipMenu>();
            var gossips = from d in DB.LEGACY.gossip_menu orderby d.entry select d;
            foreach (var gossip in gossips)
            {
                GossipMenu menu = new GossipMenu();
                menu.Menu = gossip.entry;
                menu.NpcText = gossip.text_id;
                menu.Comment = gossip.Comment;
                list.Add(menu);
            }
            return list;
        }

        public static NpcText GetGossipNpcText(int id)
        {
            var text = (from d in DB.LEGACY.npc_text where d.ID == id select d).SingleOrDefault();
            if (text == null)
                return null;

            NpcText t = new NpcText();
            t.Entry = text.ID;
            t.Text[0] = text.BroadcastTextID0;
            t.Text[1] = text.BroadcastTextID1;
            t.Text[2] = text.BroadcastTextID2;
            t.Text[3] = text.BroadcastTextID3;
            t.Text[4] = text.BroadcastTextID4;
            t.Text[5] = text.BroadcastTextID5;
            t.Text[6] = text.BroadcastTextID6;
            t.Text[7] = text.BroadcastTextID7;
            t.Chance[0] = text.prob0;
            t.Chance[1] = text.prob1;
            t.Chance[2] = text.prob2;
            t.Chance[3] = text.prob3;
            t.Chance[4] = text.prob4;
            t.Chance[5] = text.prob5;
            t.Chance[6] = text.prob6;
            t.Chance[7] = text.prob7;

            return t;
        }

        public static void SaveNpcText(NpcText text)
        {
            if (text == null)
                return;

            var oldText = (from d in DB.LEGACY.npc_text where d.ID == text.Entry select d).SingleOrDefault();
            if (oldText != null)
                DB.LEGACY.npc_text.Remove(oldText);

            DB.LEGACY.npc_text.Add(new npc_text()
            {
                ID = text.Entry,
                BroadcastTextID0 = text.Text[0],
                BroadcastTextID1 = text.Text[1],
                BroadcastTextID2 = text.Text[2],
                BroadcastTextID3 = text.Text[3],
                BroadcastTextID4 = text.Text[4],
                BroadcastTextID5 = text.Text[5],
                BroadcastTextID6 = text.Text[6],
                BroadcastTextID7 = text.Text[7],
                prob0 = text.Chance[0],
                prob1 = text.Chance[1],
                prob2 = text.Chance[2],
                prob3 = text.Chance[3],
                prob4 = text.Chance[4],
                prob5 = text.Chance[5],
                prob6 = text.Chance[6],
                prob7 = text.Chance[7]
            });

            DB.LEGACY.SaveChanges();
        }

        public static GossipMenu CreateNewGossipMenu()
        {
            int menuId = (from d in DB.LEGACY.gossip_menu select d.entry).Max() + 1;
            int textId = (from d in DB.LEGACY.npc_text select d.ID).Max() + 1;

            BroadCastText bct = CreateNewBroadcastText("bct for menu " + menuId);

            DB.LEGACY.gossip_menu.Add(new gossip_menu()
            {
                entry = menuId,
                text_id = textId,
                Comment = "New Menu " + menuId
            });

            DB.LEGACY.npc_text.Add(new npc_text()
            {
                ID = textId,
                BroadcastTextID0 = bct.ID,
                BroadcastTextID1 = 0,
                BroadcastTextID2 = 0,
                BroadcastTextID3 = 0,
                BroadcastTextID4 = 0,
                BroadcastTextID5 = 0,
                BroadcastTextID6 = 0,
                BroadcastTextID7 = 0,
                prob0 = 1,
                prob1 = 0,
                prob2 = 0,
                prob3 = 0,
                prob4 = 0,
                prob5 = 0,
                prob6 = 0,
                prob7 = 0,
                VerifiedBuild = 10000
            });

            DB.LEGACY.SaveChanges();

            GossipMenu menu = new GossipMenu();
            menu.Menu = menuId;
            menu.NpcText = textId;
            menu.Comment = "New Menu " + menuId;
            return menu;
        }

        public static void CreateNewGossipMenuItem(int menu)
        {
            int id = 0;
            var menuItems = from d in DB.LEGACY.gossip_menu_option where d.menu_id == menu select d.id;
            if (menuItems.Count() != 0)
                id = menuItems.Max() + 1;

            BroadCastText text = CreateNewBroadcastText("new gossip item");

            DB.LEGACY.gossip_menu_option.Add(new gossip_menu_option()
            {
                menu_id = menu,
                id = id,
                option_icon = 0,
                OptionBroadcastTextID = text.ID,
                option_id = 0,
                npc_option_npcflag = 0,
                action_menu_id = 0,
                action_poi_id = 0,
                box_coded = 0,
                box_money = 0,
                BoxBroadcastTextID = 0,
                SingleTimeCheck = 0
            });

            DB.LEGACY.SaveChanges();
        }

        public static BroadCastText CreateNewBroadcastText(string text = "new bct")
        {
            BroadCastText t = new BroadCastText();
            t.ID = 0;
            t.Language = 0;
            t.MaleText = text;
            t.FemaleText = text;
            t.Emote0 = 0;
            t.Emote1 = 0;
            t.Emote2 = 0;
            t.EmoteDelay0 = 0;
            t.EmoteDelay1 = 0;
            t.EmoteDelay2 = 0;
            t.SoundID = 0;
            return SaveBroadCastText(t, true);
        }

        public static void DeleteGossipMenuItem(int menu, int id)
        {
            var item = (from d in DB.LEGACY.gossip_menu_option where d.menu_id == menu && d.id == id select d).SingleOrDefault();
            if (item != null)
            {
                DB.LEGACY.gossip_menu_option.Remove(item);
                DB.LEGACY.SaveChanges();
            }
        }

        public static void DeleteGossipMenuItem(GossipMenuItem item)
        {
            var it = (from d in DB.LEGACY.gossip_menu_option where d.menu_id == item.Menu && d.id == item.ID select d).SingleOrDefault();
            if (it != null)
            {
                DB.LEGACY.gossip_menu_option.Remove(it);
                DB.LEGACY.SaveChanges();
            }
        }
    }
}
