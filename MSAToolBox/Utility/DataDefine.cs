using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAToolBox.Utility
{
    public static class DataDefine
    {
        private static string DBC_ROOT_PATH = MainWindow.SERVER_PATH + "dbc/";
        private static int DBC_COLUMN_SIZE = 4;

        public static Dictionary<int, string> ItemQuality = new Dictionary<int, string>()
        {
            {0, "Poor"},
            {1, "Normal"},
            {2, "Uncommon"},
            {3, "Rare"},
            {4, "Epic"},
            {5, "Legendary"},
            {6, "Artifact"},
            {7, "BlizzFxxk"}
        };

        public static Dictionary<int, string> ItemAmmoType = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Arrow"},
            {2, "Bullet"}
        };

        public static Dictionary<int, string> ItemBonding = new Dictionary<int, string>()
        {
            {0, "No Bind"},
            {1, "BOP"},
            {2, "BOE"},
            {3, "BOU"},
            {4, "Quest"},
            {5, "Quest2"}
        };

        public static Dictionary<int, string> ItemDamageSchool = new Dictionary<int, string>()
        {
            {0, "Physical DMG"},
            {1, "Holy DMG"},
            {2, "Fire DMG"},
            {3, "Nature DMG"},
            {4, "Frost DMG"},
            {5, "Shadow DMG"},
            {6, "Arcane DMG"}
        };

        public static Dictionary<int, string> ItemInventoryType = new Dictionary<int, string>()
        {
            {0, "Unequipable"},
            {1, "Head"},
            {2, "Neck"},
            {3, "Shoulder"},
            {4, "Shirt"},
            {5, "Chest"},
            {6, "Waist"},
            {7, "Leg"},
            {8, "Feet"},
            {9, "Wrist"},
            {10, "Hand"},
            {11, "Finger"},
            {12, "Trinket"},
            {13, "Single-Hand"},
            {14, "Off-hand"},
            {15, "Ranged"},
            {16, "Back"},
            {17, "Two-hand"},
            {18, "Bag"},
            {19, "Tabard"},
            {20, "Robe"},
            {21, "Main-hand"},
            {22, "Holdable"},
            {23, "Tome"},
            {24, "Ammo"},
            {25, "Thrown"},
            {26, "Ranged(Gun)"},
            {27, "Quiver"},
            {28, "Relic"}
        };

        public static Dictionary<int, string> ItemSheath = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Back/Point Down"},
            {2, "Back/Point Up"},
            {3, "Side"},
            {4, "Back/Middle"}
        };

        public static Dictionary<int, string> ItemSocketColor = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Meta"},
            {2, "Red"},
            {3, "Yellow"},
            {4, "Blue"}
        };

        public static Dictionary<int, string> ItemSpellTrigger = new Dictionary<int, string>()
        {
            {0, "On Use"},
            {1, "On Equip"},
            {2, "Chance On Hit"},
            {4, "Soulstone"},
            {5, "On Use(No CD)"},
            {6, "Learn"}
        };

        public static Dictionary<int, string> ItemStatType = new Dictionary<int, string>()
        {
            {0, "None/Mana"},
            {1, "Health"},
            {3, "Agility"},
            {4, "Strength"},
            {5, "Intellect"},
            {6, "Spirit"},
            {7, "Stamina"},
            {12, "Defense Rating"},
            {13, "Dodge Rating"},
            {14, "Parry Rating"},
            {15, "Block Rating"},
            {16, "Melee Hit Rating"},
            {17, "Ranged Hit Rating"},
            {18, "Spell Hit Rating"},
            {19, "Melee Crit Rating"},
            {20, "Ranged Crit Rating"},
            {21, "Spell Crit Rating"},
            {22, "Melee Hit Taken Rating"},
            {23, "Ranged Hit Taken Rating"},
            {24, "Spell Hit Taken Rating"},
            {25, "Melee Crit Taken Rating"},
            {26, "Ranged Crit Taken Rating"},
            {27, "Spell Crit Taken Rating"},
            {28, "Melee Haste Rating"},
            {29, "Ranged Haste Rating"},
            {30, "Spell Haste Rating"},
            {31, "Hit Rating"},
            {32, "Crit Rating"},
            {33, "Hit Taken Rating"},
            {34, "Crit Taken Rating"},
            {35, "Resilience Rating"},
            {36, "Haste Rating"},
            {37, "Expertise Rating"},
            {38, "Attack Power"},
            {39, "Ranged Attack Power"},
            {40, "Feral Attack Power(Not used)"},
            {41, "Spell Healing Done"},
            {42, "Spell Damage Done"},
            {43, "Mana Regeneration"},
            {44, "Armor Penetration Rating"},
            {45, "Spell Power"},
            {46, "Health Regeneration"},
            {47, "Spell Penetration"},
            {48, "Block Value"}
        };

        public static Dictionary<int, string> ItemMaterial = new Dictionary<int, string>()
        {
            {-1, "Food/Consumable"},
            {0, "Undefined"},
            {1, "Metal"},
            {2, "Wood"},
            {3, "Liquid"},
            {4, "Jewery"},
            {5, "Mail"},
            {6, "Plate"},
            {7, "Cloth"},
            {8, "Leather"}
        };

        public static Dictionary<int, string> ReputationRank = new Dictionary<int, string>()
        {
            {0, "Hated"},
            {1, "Hostile"},
            {2, "Unfriendly"},
            {3, "Neutral"},
            {4, "Friendly"},
            {5, "Honored"},
            {6, "Revered"},
            {7, "Exalted"}
        };

        public static Dictionary<int, string> GossipIcon = new Dictionary<int, string>()
        {
            {0, "Chat"},
            {1, "Vendor"},
            {2, "Taxi"},
            {3, "Trainer"},
            {4, "Interact1"},
            {5, "Interact2"},
            {6, "MoneyBag"},
            {7, "Talk"},
            {8, "Tabard"},
            {9, "Battle"},
            {10, "Dot"}
        };

        public static Dictionary<int, string> SpellEffect = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Instant Kill"},
            {2, "School Damage"},
            {3, "Dummy"},
            {4, "Portal Teleport (Unused)"},
            {5, "Teleport Unit"},
            {6, "Apply Aura"},
            {7, "Environmental Damage"},
            {8, "Power Drain"},
            {9, "Health Leech"},
            {10, "Heal"},
            {11, "Bind"},
            {12, "Portal"},
            {13, "Ritual Base (Unused)"},
            {14, "Ritual Specialize (Unused)"},
            {15, "Ritual Activate Portal (Unused)"},
            {16, "Quest Complete"},
            {17, "Weapon Damage (No School)"},
            {18, "Resurrect"},
            {19, "Extra Attack"},
            {20, "Dodge (Skill Ability)"},
            {21, "Evade (Skill Ability)"},
            {22, "Parry (Skill Ability)"},
            {23, "Block (Skill Ability)"},
            {24, "Create Item"},
            {25, "Weapon"},
            {26, "Defense (Skill Ability)"},
            {27, "Resistent Area Aura"},
            {28, "Summon"},
            {29, "Leap"},
            {30, "Energize"},
            {31, "Weapon Percent Damage"},
            {32, "Trigger Missle"},
            {33, "Open Lock"},
            {34, "Summon Change Item"},
            {35, "Apply Area Aura Party"},
            {36, "Learn Spell"},
            {37, "Spell Defense (Skill Ability)"},
            {38, "Dispel"},
            {39, "Language"},
            {40, "Dual Wield"},
            {41, "Jump"},
            {42, "Jump Dest"},
            {43, "Teleport Unit Face Caster"},
            {44, "Skill Step"},
            {45, "Add Honor"},
            {46, "Spawn"},
            {47, "Trade Skill"},
            {48, "Stealth (Skill Ability)"},
            {49, "Detect (Skill Ability)"},
            {50, "Trans Door"},
            {51, "Force Crit Hit (Unused)"},
            {52, "Guarantee Hit"},
            {53, "Enchant Item"},
            {54, "Enchant Item Temporary"},
            {55, "Tame Creature"},
            {56, "Summon Pet"},
            {57, "Learn Pet Spell"},
            {58, "Weapon Damage"},
            {59, "Create Random Item"},
            {60, "Proficiency"},
            {61, "Send Event"},
            {62, "Power Burn"},
            {63, "Threat"},
            {64, "Trigger Spell"},
            {65, "Apply Area Aura Raid"},
            {66, "Create Mana Gem"},
            {67, "Heal Max Health"},
            {68, "Interrupt Cast"},
            {69, "Distract"},
            {70, "Pull"},
            {71, "Pickpocket"},
            {72, "Add Farsight"},
            {73, "Untrain Talents"},
            {74, "Apply Glyph"},
            {75, "Heal Mechanical"},
            {76, "Summon Object Wild"},
            {77, "Script Effect"},
            {78, "Attack"},
            {79, "Sanctuary"},
            {80, "Add Combo Point"},
            {81, "Create House"},
            {82, "Bind Sight"},
            {83, "Duel"},
            {84, "Stuck"},
            {85, "Summon Player"},
            {86, "Activate Object"},
            {87, "GameObject Damage"},
            {88, "GameObject Repair"},
            {89, "GameObject Set Destruction State"},
            {90, "Kill Credit"},
            {91, "Threat All"},
            {92, "Enchant Held Item"},
            {93, "Force Deselect"},
            {94, "Self Resurrect"},
            {95, "Skinning"},
            {96, "Charge"},
            {97, "Cast Button"},
            {98, "Knock Back"},
            {99, "Disenchant"},
            {100, "Inebriate"},
            {101, "Feed Pet"},
            {102, "Dismiss Pet"},
            {103, "Reputation"},
            {104, "Summon Object Slot1"},
            {105, "Summon Object Slot2"},
            {106, "Summon Object Slot3"},
            {107, "Summon Object Slot4"},
            {108, "Dispel Mechanic"},
            {109, "Summon Dead Pet"},
            {110, "Destory All Totems"},
            {111, "Durability Damage"},
            {112, "Unsed 112"},
            {113, "Resurrect New"},
            {114, "Attack Me"},
            {115, "Durability Damage Percent"},
            {116, "Remove Insignia"},
            {117, "Spirit Heal"},
            {118, "Skill"},
            {119, "Apply Area Aura Pet"},
            {120, "Teleport Graveyard"},
            {121, "Normalized Weapon Damage"},
            {122, "Unused 122"},
            {123, "Send Texi"},
            {124, "Pull Towards"},
            {125, "Modify Threat Percent"},
            {126, "Steal Beneficial Buff"},
            {127, "Prospecting"},
            {128, "Apply Area Aura Friend"},
            {129, "Apply Area Aura Enemy"},
            {130, "Redirect Threat"},
            {131, "Player Notification"},
            {132, "Play Music"},
            {133, "Unlearn Specialization"},
            {134, "Kill Credit"},
            {135, "Call Pet"},
            {136, "Heal Percent"},
            {137, "Energize Percent"},
            {138, "Leap Back"},
            {139, "Reset Quest Status"},
            {140, "Force Cast"},
            {141, "Force Cast With Value"},
            {142, "Trigger Spell With Value"},
            {143, "Apply Area Aura Owner"},
            {144, "Knock Back Dest"},
            {145, "Pull Towards Dest"},
            {146, "Activate Rune"},
            {147, "Quest Fail"},
            {148, "Trigger Missile Spell With Value"},
            {149, "Charge Dest"},
            {150, "Quest Start"},
            {151, "Trigger Spell 2"},
            {152, "Summon RAF Friend"},
            {153, "Create Tamed Pet"},
            {154, "Discover Taxi"},
            {155, "Titan Grip"},
            {156, "Enchant Item Prismatic"},
            {157, "Create Item 2"},
            {158, "Milling"},
            {159, "Allow Rename Pet"},
            {160, "Unused 160"},
            {161, "Talent Spec Count"},
            {162, "Talent Spec Select"},
            {163, "Unused 163"},
            {164, "Remove Aura"},
            {165, "Power Damage"},
            {166, "Power Heal"},
            {167, "Comprehend Spell"},
            {168, "Grant Base Spellset"},
            {169, "Grant City Resource"},
            {170, "Grant City Magic Power"},
            {171, "Transmogrify"}
        };

        public static Dictionary<int, string> SpellAura = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Bind Sight"},
            {2, "Mod Possess"},
            {3, "Periodic Damage"},
            {4, "Dummy"},
            {5, "Mod Confuse"},
            {6, "Mod Charm"},
            {7, "Mod Fear"},
            {8, "Periodic Heal"},
            {9, "Mod Attack Speed"},
            {10, "Mod Threat"},
            {11, "Mod Taunt"},
            {12, "Mod Stun"},
            {13, "Mod Damage Done"},
            {14, "Mod Damage Taken"},
            {15, "Damage Shield"},
            {16, "Mod Stealth"},
            {17, "Mod Stealth Detect"},
            {18, "Mod Invisibility"},
            {19, "Mod Invisibility Detect"},
            {20, "Mod Health"},
            {21, "Mod Power"},
            {22, "Mod Resistance"},
            {23, "Periodic Trigger Spell"},
            {24, "Periodic Energize"},
            {25, "Mod Pacify"},
            {26, "Mod Root"},
            {27, "Mod Silence"},
            {28, "Reflect Spell"},
            {29, "Mod Stat"},
            {30, "Mod Skill"},
            {31, "Mod Increase Speed"},
            {32, "Mod Increase Mount Speed"},
            {33, "Mod Decrease Speed"},
            {34, "Mod Increase Health"},
            {35, "Mod Increase Power"},
            {36, "Mod Shapeshift"},
            {37, "Effect Immunity"},
            {38, "State Immunity"},
            {39, "School Immunity"},
            {40, "Damage Immunity"},
            {41, "Dispel Immunity"},
            {42, "Proc Trigger Spell"},
            {43, "Proc Trigger Damage"},
            {44, "Track Creature"},
            {45, "Track Resource"},
            {46, "Unused 46"},
            {47, "Mod Parry Chance"},
            {48, "Unused 48"},
            {49, "Mod Dodge Chance"},
            {50, "Mod Critical Healing Amount"},
            {51, "Mod Block Chance"},
            {52, "Mod Weapon Crit Chance"},
            {53, "Periodic Leech"},
            {54, "Mod Weapon Hit Chance"},
            {55, "Mod Spell Hit Chance"},
            {56, "Transform"},
            {57, "Mod Spell Crit Chance"},
            {58, "Mod Increase Swim Speed"},
            {59, "Mod Damage Done Creature"},
            {60, "Mod Pacify Silence"},
            {61, "Mod Scale"},
            {62, "Periodic Health Funnel"},
            {63, "Unused 63"},
            {64, "Periodic Mana Leech"},
            {65, "Mod Casting Speed Not Stack"},
            {66, "Feign Death"},
            {67, "Mod Disarm"},
            {68, "Mod Stalked"},
            {69, "School Absorb"},
            {70, "Extra Attacks"},
            {71, "Mod Spell Crit Chance School"},
            {72, "Mod Power Cost School Percent"},
            {73, "Mod Power Cost School"},
            {74, "Reflect Spell School"},
            {75, "Mod Language"},
            {76, "Far Sight"},
            {77, "Mechanic Immunity"},
            {78, "Mounted"},
            {79, "Mod Damage Percent Done"},
            {80, "Mod Percent Stat"},
            {81, "Split Damage Percent"},
            {82, "Water Breathing"},
            {83, "Mod Base Resistence"},
            {84, "Mod Health Regeneration"},
            {85, "Mod Power Regeneration"},
            {86, "Channel Death Item"},
            {87, "Mod Damage Percent Taken"},
            {88, "Mod Health Regen Percent"},
            {89, "Periodic Damage Percent"},
            {90, "Unused 90"},
            {91, "Mod Detect Range"},
            {92, "Prevents Fleeing"},
            {93, "Mod Unattackable"},
            {94, "Interrupt Regen"},
            {95, "Ghost"},
            {96, "Spell Magnet"},
            {97, "Mana Shield"},
            {98, "Mod Skill Talent"},
            {99, "Mod Attack Power"},
            {100, "Auras Visible"},
            {101, "Mod Resistance Percent"},
            {102, "Mod Melee Attack Power Versus"},
            {103, "Mod Total Threat"},
            {104, "Water Walk"},
            {105, "Feather Fall"},
            {106, "Hover"},
            {107, "Add Flat Modifier"},
            {108, "Add Pct Modifier"},
            {109, "Add Target Trigger"},
            {110, "Mod Power Regen Percent"},
            {111, "Add Caster Hit Trigger"},
            {112, "Override Class Scripts"},
            {113, "Mod Ranged Damage Taken"},
            {114, "Mod Ranged Damage Taken Percent"},
            {115, "Mod Healing Taken"},
            {116, "Mod Health Regen In Combat"},
            {117, "Mod Mechanic Resistance"},
            {118, "Mod Healing Taken Percent"},
            {119, "Unused 119"},
            {120, "Untrackable"},
            {121, "Empathy"},
            {122, "Mod Offhand Damage Percent"},
            {123, "Mod Target Resistance"},
            {124, "Mod Ranged Attack Power"},
            {125, "Mod Melee Damage Taken"},
            {126, "Mod Melee Damage Taken Percent"},
            {127, "Mod Ranged Attack Power Attacker Bonus"},
            {128, "Mod Possess Pet"},
            {129, "Mod Speed Always"},
            {130, "Mod Mounted Speed Always"},
            {131, "Mod Ranged Attack Power Versus"},
            {132, "Mod Increase Power Percent"},
            {133, "Mod Increase Health Percent"},
            {134, "Mod Mana Regen Interrupt"},
            {135, "Mod Healing Done"},
            {136, "Mod Healing Done Percent"},
            {137, "Mod Stat Percent"},
            {138, "Mod Melee Haste"},
            {139, "Force Reaction"},
            {140, "Mod Ranged Haste"},
            {141, "Mod Ranged Ammo Haste"},
            {142, "Mod Base Resistance Percent"},
            {143, "Mod Resistance Exclusive"},
            {144, "Safe Fall"},
            {145, "Mod Pet Talent Points"},
            {146, "Allow Tame Pet Type"},
            {147, "Mechanic Immunity Mask"},
            {148, "Retain Combo Points"},
            {149, "Reduce Pushback"},
            {150, "Mod Shield Block Value Percent"},
            {151, "Track Stealthed"},
            {152, "Mod Detected Range"},
            {153, "Split Damage Flat"},
            {154, "Mod Stealth Level"},
            {155, "Mod Water Breathing"},
            {156, "Mod Reputation Gain"},
            {157, "Pet Damage Multi"},
            {158, "Mod Shield Block Value"},
            {159, "No PvP Credit"},
            {160, "Mod AOE Avoidance"},
            {161, "Mod Health Regen In Combat"},
            {162, "Power Burn"},
            {163, "Mod Crit Damage Bonus"},
            {164, "Unused 164"},
            {165, "Melee Attack Power Attacker Bonus"},
            {166, "Mod Attack Power Percent"},
            {167, "Mod Ranged Attack Power Percent"},
            {168, "Mod Damage Done Versus"},
            {169, "Mod Crit Percent Versus"},
            {170, "Detect Amore"},
            {171, "Mod Speed Not Stack"},
            {172, "Mod Mounted Speed Not Stack"},
            {173, "Unused 173"},
            {174, "Mod Spell Damage of Stat Percent"},
            {175, "Mod Spell Healing of Stat Percent"},
            {176, "Spirit of Redemption"},
            {177, "AOE Charm"},
            {178, "Mod Debuff Resistance"},
            {179, "Mod Attacker Spell Crit Chance"},
            {180, "Mod Flat Spell Damage Versus"},
            {181, "Unused 181"},
            {182, "Mod Resistance of Stat Percent"},
            {183, "Mod Critical Threat"},
            {184, "Mod Attacker Melee Hit Chance"},
            {185, "Mod Attacker Ranged Hit Chance"},
            {186, "Mod Attacker Spell Hit Chance"},
            {187, "Mod Attacker Melee Crit Chance"},
            {188, "Mod Attacker Ranged Crit Chance"},
            {189, "Mod Rating"},
            {190, "Mod Faction Reputation Gain"},
            {191, "Use Normal Movement Speed"},
            {192, "Mod Melee Ranged Haste"},
            {193, "Melee Slow"},
            {194, "Mod Target Absorb School"},
            {195, "Mod Target Ability Absorb School"},
            {196, "Mod Cooldown"},
            {197, "Mod Attacker Spell and Weapon Crit Chance"},
            {198, "Unused 198"},
            {199, "Mod Spell Hit Chance (With Mask Filter)"},
            {200, "Mod XP From Kill Percent"},
            {201, "Fly"},
            {202, "Ignore Combat Result"},
            {203, "Mod Attacker Melee Crit Damage"},
            {204, "Mod Attacker Ranged Crit Damage"},
            {205, "Mod School Crit Damage Taken"},
            {206, "Mod Increase Vehicle Flight Speed"},
            {207, "Mod Increase Mounted Flight Speed"},
            {208, "Mod Increase Flight Speed"},
            {209, "Mod Mounted Flight Speed Always"},
            {210, "Mod Vehicle Speed Always"},
            {211, "Mod Flight Speed Not Stack"},
            {212, "Mod Ranged Attack Power of Stat Percent"},
            {213, "Mod Rage From Damage Dealt"},
            {214, "Unused 214"},
            {215, "Arena Preparation"},
            {216, "Haste Spells"},
            {217, "Mod Melee Haste 2"},
            {218, "Haste Ranged"},
            {219, "Mod Mana Regen From Stat"},
            {220, "Mod Rating From Stat"},
            {221, "Mod Detaunt"},
            {222, "Unused 222"},
            {223, "Raid Proc From Charge"},
            {224, "Unused 224"},
            {225, "Raid Proc From Charge With Value"},
            {226, "Periodic Dummy"},
            {227, "Periodic Trigger Spell With Value"},
            {228, "Detect Stealth"},
            {229, "Mod AOE Damage Avoidance"},
            {230, "Unused 230"},
            {231, "Proc Trigger Spell With Value"},
            {232, "Mod Mechanic Duration"},
            {233, "Change Model for All Humans"},
            {234, "Mod Mechanic Duration Not Stack"},
            {235, "Mod Dispel Resist"},
            {236, "Control Vehicle"},
            {237, "Mod Spell Damage of Attack Power"},
            {238, "Mod Spell Healing of Attack Power"},
            {239, "Mod Scale 2"},
            {240, "Mod Expertise"},
            {241, "Force Move Forward"},
            {242, "Mod Spell Damage From Healing"},
            {243, "Mod Faction"},
            {244, "Comprehend Language"},
            {245, "Mod Aura Duration By Dispel"},
            {246, "Mod Aura Duration By Dispel Not Stack"},
            {247, "Clone Caster"},
            {248, "Mod Combat Result Chance"},
            {249, "Convert Rune"},
            {250, "Mod Increase Health 2"},
            {251, "Mod Enemy Dodge"},
            {252, "Mod Speed Slow All"},
            {253, "Mod Block Crit Chance"},
            {254, "Mod Disarm Offhand"},
            {255, "Mod Mechanic Damage Taken Percent"},
            {256, "No Reagent Use"},
            {257, "Mod Target Resist By Spell Class"},
            {258, "Unused 258"},
            {259, "Mod HOT Percent"},
            {260, "Screen Effect"},
            {261, "Phase"},
            {262, "Ability Ignore Aurastate"},
            {263, "Allow Only Ability"},
            {264, "Unused 264"},
            {265, "Unused 265"},
            {266, "Unused 266"},
            {267, "Mod Immune Aura Apply School"},
            {268, "Mod Attack Power of Stat Percent"},
            {269, "Mod Ignore Target Resist"},
            {270, "Mod Ability Ignore Target Resist"},
            {271, "Mod Damage From Caster"},
            {272, "Ignore Melee Reset"},
            {273, "X Ray"},
            {274, "Ability Consume No Ammo"},
            {275, "Mod Ignore Shapeshift"},
            {276, "Mod Damage Done For Mechanic"},
            {277, "Mod Max Affected Targets"},
            {278, "Mod Disarm Ranged"},
            {279, "Initialize Images"},
            {280, "Mod Armor Penetration Percent"},
            {281, "Mod Honor Gain Percent"},
            {282, "Mod Base Health Percent"},
            {283, "Mod Healing Received By Caster"},
            {284, "Linked"},
            {285, "Mod Attack Power of Armor"},
            {286, "Ability Periodic Crit"},
            {287, "Deflect Spells"},
            {288, "Ignore Hit Direction"},
            {289, "Unused 289"},
            {290, "Mod Crit Chance All"},
            {291, "Mod XP From Quest"},
            {292, "Open Stable"},
            {293, "Override Spells"},
            {294, "Prevent Regenerate Power"},
            {295, "Unused 295"},
            {296, "Set Vehicle ID"},
            {297, "Block Spell Family"},
            {298, "Strangulate"},
            {299, "Unused 299"},
            {300, "Share Damage Percent"},
            {301, "School Heal Absorb"},
            {302, "Unused 302"},
            {303, "Mod Damage Done Versus Aurastate"},
            {304, "Mod Fake Inebriate"},
            {305, "Mod Minimun Speed"},
            {306, "Unused 306"},
            {307, "Heal Absorb Test"},
            {308, "Mod Crit Chance For Caster"},
            {309, "Unused 309"},
            {310, "Mod Creature AOE Damage Avoidance"},
            {311, "Unused 311"},
            {312, "Unused 312"},
            {313, "Unused 313"},
            {314, "Prevent Resurrection"},
            {315, "Underwater Walking"},
            {316, "Periodic Haste"},
            {317, "Unused 317"},
            {318, "Death Escape"},
            {319, "Periodic Power Damage"},
            {320, "Power School Absorb"},
            {321, "Periodic Power Heal"},
            {322, "Periodic Power Leech"},
            {323, "Mod Rest XP Generate Rate"},
            {324, "Mod Dualwield Melee Haste"},
            {325, "Drain Health From Mechanic Damage"},
            {326, "Prevent Power Loss At Percent Not Stack"},
            {327, "Share Heal From Party Not Stack"},
            {328, "Mod Crit Damage Melee"},
            {329, "Mod Crit Damage Ranged"},
            {330, "Mod Crit Damage Spell"},
            {331, "Reduce Mass Damage"},
            {332, "Mod Nether Realm"},
            {339, "Mod Single Phase"},
            {340, "Mod Damage Against Caster"},
            {341, "Mod Salvage Rate"}
        };

        public static Dictionary<int, string> SpellEffectTarget = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "<Unit> Caster"},
            {2, "<Unit> Nearby Enemy"},
            {3, "<Unit> Nearby Party"},
            {4, "<Unit> Nearby Ally"},
            {5, "<Unit> Pet"},
            {6, "<Unit> Target Enemy"},
            {7, "<Unit> Src Area Entry"},
            {8, "<Unit> Dest Area Entry"},
            {9, "<Unit> Dest Home"},
            {11, "<Unit> Src Area Unk11"},
            {15, "<Unit> Src Area Enemy"},
            {16, "<Unit> Dest Area Enemy"},
            {17, "<Dest> DB"},
            {18, "<Dest> Caster"},
            {20, "<Unit> Caster Area Party"},
            {21, "<Unit> Target Ally"},
            {22, "Src Caster"},
            {23, "<Gameobject> Target"},
            {24, "<Unit> Cone Enemy"},
            {25, "<Unit> Target Any"},
            {26, "<Gameobject> Item Target"},
            {27, "<Unit> Master"},
            {28, "<Dest> Dynamic Object Enemy"},
            {29, "<Dest> Dynamic Object Ally"},
            {30, "<Unit> Src Area Ally"},
            {31, "<Unit> Dest Area Ally"},
            {32, "<Dest> Caster Summon"},
            {33, "<Unit> Src Area Party"},
            {34, "<Unit> Dest Area Party"},
            {35, "<Unit> Target Party"},
            {36, "<Dest> Caster Unk36"},
            {37, "<Unit> Last Target Area Party"},
            {38, "<Unit> Nearby Entry"},
            {39, "<Dest> Caster Fishing"},
            {40, "<Gameobject> Nearby Entry"},
            {41, "<Dest> Caster Front Right"},
            {42, "<Dest> Caster Back Right"},
            {43, "<Dest> Caster Back Left"},
            {44, "<Dest> Caster Front Left"},
            {45, "<Unit> Target Chainheal Ally"},
            {46, "<Dest> Nearby Entry"},
            {47, "<Dest> Caster Front"},
            {48, "<Dest> Caster Back"},
            {49, "<Dest> Caster Right"},
            {50, "<Dest> Caster Left"},
            {51, "<Gameobject> Src Area"},
            {52, "<Gameobject> Dest Area"},
            {53, "<Dest> Target Enemy"},
            {54, "<Unit> Cone Enemy"},
            {55, "<Dest> Caster Front Leap"},
            {56, "<Unit> Caster Area Raid"},
            {57, "<Unit> Target Raid"},
            {58, "<Unit> Nearby Raid"},
            {59, "<Unit> Cone Ally"},
            {60, "<Unit> Cone Entry"},
            {61, "<Unit> Target Area Raid Class"},
            {62, "Unk62"},
            {63, "<Dest> Target Any"},
            {64, "<Dest> Target Front"},
            {65, "<Dest> Target Back"},
            {66, "<Dest> Target Right"},
            {67, "<Dest> Target Left"},
            {68, "<Dest> Target Front Right"},
            {69, "<Dest> Target Back Right"},
            {70, "<Dest> Target Back Left"},
            {71, "<Dest> Target Front Left"},
            {72, "<Dest> Caster Random"},
            {73, "<Dest> Caster Radius"},
            {74, "<Dest> Target Random"},
            {75, "<Dest> Target Radius"},
            {76, "<Dest> Channel Target"},
            {77, "<Unit> Channel Target"},
            {78, "<Dest> Dest Front"},
            {79, "<Dest> Dest Back"},
            {80, "<Dest> Dest Right"},
            {81, "<Dest> Dest Left"},
            {82, "<Dest> Dest Front Right"},
            {83, "<Dest> Dest Back Right"},
            {84, "<Dest> Dest Back Left"},
            {85, "<Dest> Dest Front Left"},
            {86, "<Dest> Dest Random"},
            {87, "<Dest> Dest"},
            {88, "<Dest> Dynamic Object None"},
            {89, "<Dest> Traj"},
            {90, "<Unit> Target Mini Pet"},
            {91, "<Dest> Dest Radius"},
            {92, "<Unit> Summoner"},
            {93, "<Corpse> Src Area Enemy"},
            {94, "<Unit> Vehicle"},
            {95, "<Unit> Target Passenger"},
            {96, "<Unit> Passenger0"},
            {97, "<Unit> Passenger1"},
            {98, "<Unit> Passenger2"},
            {99, "<Unit> Passenger3"},
            {100, "<Unit> Passenger4"},
            {101, "<Unit> Passenger5"},
            {102, "<Unit> Passenger6"},
            {103, "<Unit> Passenger7"},
            {104, "<Unit> Cone Enemy"},
            {105, "<Unit> Unk105"},
            {106, "<Dest> Channel Caster"},
            {107, "Dest Area Unk107"},
            {108, "<Gameobject> Cone"},
            {110, "<Dest> Unk110"}
        };

        public static Dictionary<int, string> SpellAuraState = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Defense"},
            {2, "Health Less than 20%"},
            {3, "Berserking"},
            {4, "Frozen"},
            {5, "Judgement"},
            {6, "Unused 6"},
            {7, "Hunter Parry"},
            {8, "Burning(NYI)"},
            {9, "Poisoned(NYI)"},
            {10, "Victory Rush"},
            {11, "Unused 11"},
            {12, "Faerie Fire"},
            {13, "Health Less than 35%"},
            {14, "Conflagrate"},
            {15, "Swiftmend"},
            {16, "Deadly Poison"},
            {17, "Enrage"},
            {18, "Bleeding"},
            {19, "Unused 19"},
            {20, "Unused 20"},
            {21, "Unused 21"},
            {22, "Unused 22"},
            {23, "Health Above 75%"}
        };

        public static Dictionary<int, string> SpellFamily = new Dictionary<int, string>()
        {
            {0, "Generic"},
            {1, "Holiday"},
            {2, "Legacy"},
            {3, "Mage"},
            {4, "Warrior"},
            {5, "Warlock"},
            {6, "Priest"},
            {7, "Druid"},
            {8, "Rogue"},
            {9, "Hunter"},
            {10, "Paladin"},
            {11, "Shaman"},
            {12, "Unused 12"},
            {13, "Potion"},
            {14, "Unused 14"},
            {15, "Deathknight"},
            {16, "Unused 16"},
            {17, "Pet"},
            {18, "Obsolete"}
        };

        public static Dictionary<int, string> SpellDamageClass = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Spell"},
            {2, "Melee"},
            {3, "Ranged"}
        };

        public static Dictionary<int, string> SpellPowerType = new Dictionary<int, string>()
        {
            {-2, "Health"},
            {0, "Mana"},
            {1, "Rage"},
            {2, "Focus"},
            {3, "Energy"},
            {4, "Happiness"},
            {5, "Rune"},
            {6, "Runic Power"}
        };

        public static Dictionary<int, string> ItemGroupSound = new Dictionary<int, string>()
        {
            {7, "Leather"},
            {8, "Metal Small"},
            {9, "Metal Large"},
            {10, "Mail Small"},
            {11, "Mail Large"},
            {12, "Wood Small"},
            {13, "Wood Large"},
            {14, "Ring"},
            {15, "Meat"},
            {16, "Food"},
            {17, "Liquid"},
            {18, "Bag"},
            {19, "Book"},
            {20, "Paper"},
            {21, "Wand"},
            {22, "Ore"},
            {23, "Herb"},
            {24, "Gem"}
        };

        public static Dictionary<int, string> GossipOption = new Dictionary<int, string>()
        {
            {0, "None"},
            {1, "Gossip"},
            {2, "Quest"},
            {3, "Vendor"},
            {4, "Taxi"},
            {5, "Train"},
            {6, "Spirit Healer Revive"},
            {7, "Battle Healer Revive"},
            {8, "Bind Inn"},
            {9, "Bank"},
            {10, "Sign Petition"},
            {11, "Design Tabard"},
            {12, "Queue BG"},
            {13, "Auction"},
            {14, "Stable Pet"},
            {15, "Armorer"},
            {16, "Reset Talent"},
            {17, "Reset Pet Talent"},
            {18, "Learn Dual Talent"},
            {19, "Outdoor PvP"},
            {20, "Learn War School Spell"},
            {21, "Join War School"}
        };

        public static Dictionary<int, string> SpellEffectRadius = LoadDBCDefine("SpellRadius");
        public static Dictionary<int, string> SpellMechanic = LoadDBCDefine("SpellMechanic.dbc", 1, 6, true);
        public static Dictionary<int, string> SpellDispel = LoadDBCDefine("SpellDispelType.dbc", 1, 6);
        public static Dictionary<int, string> TotemCategory = LoadDBCDefine("TotemCategory.dbc", 1, 6, true);
        public static Dictionary<int, string> SpellIcon = LoadDBCDefine("SpellIcon.dbc", 1, 2, false, false);
        public static Dictionary<int, string> SkillLine = LoadDBCDefine("SkillLine.dbc", 1, 8, true);
        public static Dictionary<int, string> ItemClass = LoadDBCDefine("ItemClass.dbc", 1, 8);
        public static Dictionary<int, string> ItemBagFamily = LoadDBCDefine("ItemBagFamily.dbc", 1, 6);
        public static Dictionary<int, string> ItemPetFood = LoadDBCDefine("ItemPetFood.dbc", 1, 6, true);
        public static Dictionary<int, string> HolidayNames = LoadDBCDefine("HolidayNames.dbc", 1, 6, true);
        public static Dictionary<int, string> PageTextMaterial = LoadDBCDefine("PageTextMaterial.dbc", 1, 2, true);
        public static Dictionary<int, string> Language = LoadDBCDefine("Languages.dbc", 1, 6, true);
        public static Dictionary<int, string>[] ItemSubclass = LoadDBCDefine("ItemSubClass.dbc", 1, 2, 15, ItemClass.Count);
        public static Dictionary<int, string> ItemSet = LoadDBCDefine("ItemSet.dbc", 1, 6, true);
        public static Dictionary<int, string> Emotes = LoadDBCDefine("Emotes.dbc", 1, 2);
        public static Dictionary<int, string> SpellDuration = LoadDBCDefine("SpellDuration");
        public static Dictionary<int, string> SpellCastTime = LoadDBCDefine("SpellCastTime");
        public static Dictionary<int, string> SpellRange = LoadDBCDefine("SpellRange");

        /*
        private static Dictionary<int, string> LoadDBDefine(string type)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            switch (type)
            {
                case "ItemQuality":
                    var qualityDefines = from d in DB.DATA.define_item_quality select d;
                    foreach (var define in qualityDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemAmmoType":
                    var ammoTypeDefines = from d in DB.DATA.define_item_ammo_type select d;
                    foreach (var define in ammoTypeDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemBonding":
                    var bondingDefines = from d in DB.DATA.define_item_bonding select d;
                    foreach (var define in bondingDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemDamageSchool":
                    var damageSchoolDefines = from d in DB.DATA.define_item_damage_type select d;
                    foreach (var define in damageSchoolDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemInventoryType":
                    var inventoryTypeDefines = from d in DB.DATA.define_item_inventory_type select d;
                    foreach (var define in inventoryTypeDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemMaterial":
                    var materialDefines = from d in DB.DATA.define_item_material select d;
                    foreach (var define in materialDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemSheath":
                    var sheathDefines = from d in DB.DATA.define_item_sheath select d;
                    foreach (var define in sheathDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemSocketColor":
                    var socketColorDefines = from d in DB.DATA.define_item_socket_color select d;
                    foreach (var define in socketColorDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemSpellTrigger":
                    var spellTriggerDefines = from d in DB.DATA.define_item_spell_trigger select d;
                    foreach (var define in spellTriggerDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemStatType":
                    var statTypeDefines = from d in DB.DATA.define_item_stat_type select d;
                    foreach (var define in statTypeDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ReputationRank":
                    var reputationRankDefines = from d in DB.DATA.define_reputation_rank select d;
                    foreach (var define in reputationRankDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "GossipIcon":
                    var gossipIconDefines = from d in DB.DATA.define_gossip_icon select d;
                    foreach (var define in gossipIconDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "SpellEffect":
                    var spellEffectDefines = from d in DB.DATA.define_spell_effect select d;
                    foreach (var define in spellEffectDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "SpellAura":
                    var spellAuraDefines = from d in DB.DATA.define_spell_aura select d;
                    foreach (var define in spellAuraDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "SpellEffectTarget":
                    var spellEffectTargetDefines = from d in DB.DATA.define_spell_implicit_target select d;
                    foreach (var define in spellEffectTargetDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "SpellAuraState":
                    var spellAuraStateDefines = from d in DB.DATA.define_spell_aura_state select d;
                    foreach (var define in spellAuraStateDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "SpellFamily":
                    var spellFamilyDefines = from d in DB.DATA.define_spell_family select d;
                    foreach (var define in spellFamilyDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "SpellDamageClass":
                    var spellDamageClassDefines = from d in DB.DATA.define_spell_damage_class select d;
                    foreach (var define in spellDamageClassDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "SpellPowerType":
                    var spellPowerTypeDefines = from d in DB.DATA.define_spell_power_type select d;
                    foreach (var define in spellPowerTypeDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                case "ItemGroupSound":
                    var groupSoundDefines = from d in DB.DATA.define_item_group_sound select d;
                    foreach (var define in groupSoundDefines)
                        dict.Add(define.id, define.id + " - " + define.define);
                    break;
                default:
                    break;
            }
            return dict;
        }
        */

        private static Dictionary<int, string> LoadDBCDefine(string type)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            FileStream stream;
            BinaryReader r;
            int records = 0;
            switch (type)
            {
                case "SpellRadius":
                    // 4 columns - 16 bytes per row
                    // 1 for id
                    // 2 for radius
                    // 3 for radius for level
                    // 4 for max radius
                    stream = File.OpenRead(DBC_ROOT_PATH + "SpellRadius.dbc");
                    r = new BinaryReader(stream);
                    stream.Position = 4;
                    records = r.ReadInt32();
                    stream.Position = 20;
                    // no dbc record starts at id 0 so define one.
                    dict.Add(0, "0 Yard");
                    for (int i = 0; i != records; ++i)
                    {
                        int id = r.ReadInt32();
                        float radius = r.ReadSingle();
                        float radiusPerLevel = r.ReadSingle();
                        float radiusMax = r.ReadSingle();
                        string s = String.Format("{3} - {0}Y / +{1} per Level / Max: {2}", radius, radiusPerLevel, radiusMax, id);
                        dict.Add(id, s);
                    }
                    r.Close();
                    stream.Close();
                    break;
                case "SpellDuration":
                    // 4 columns - 16 bytes per row
                    // 1 for id
                    // 2 for base duration
                    // 3 for duration per level
                    // 4 for max duration
                    stream = File.OpenRead(DBC_ROOT_PATH + "SpellDuration.dbc");
                    r = new BinaryReader(stream);
                    stream.Position = 4;
                    records = r.ReadInt32();
                    stream.Position = 20;
                    // no dbc record starts at id 0 so define one.
                    dict.Add(0, "0ms");
                    for (int i = 0; i != records; ++i)
                    {
                        int id = r.ReadInt32();
                        float duration = r.ReadInt32();
                        float durationPerLevel = r.ReadInt32();
                        float durationMax = r.ReadInt32();
                        string s = String.Format("{3} - {0:F1}ms(base) / {1:F1}ms(per level) / {2:F1}ms(max)", duration, durationPerLevel, durationMax, id);
                        dict.Add(id, s);
                    }
                    r.Close();
                    stream.Close();
                    break;
                case "SpellRange":
                    // 40 columns - 160 bytes per row
                    // 1 for id
                    // 2 for min enemy range
                    // 3 for min ally range
                    // 4 for max enemy range
                    // 5 for max ally range
                    stream = File.OpenRead(DBC_ROOT_PATH + "SpellRange.dbc");
                    r = new BinaryReader(stream);
                    stream.Position = 4;
                    records = r.ReadInt32();
                    stream.Position = 20;
                    // no dbc record starts at id 0 so define one.
                    dict.Add(0, "0 - default self only");
                    for (int i = 0; i != records; ++i)
                    {
                        int id = r.ReadInt32();
                        float minEnemyRange = r.ReadSingle();
                        float minAllyRange = r.ReadSingle();
                        float maxEnemyRange = r.ReadSingle();
                        float maxAllyRange = r.ReadSingle();
                        string s = String.Format("{4} - Hostile:{0}~{1} / Friend:{2}~{3}", minAllyRange, maxEnemyRange, minAllyRange, maxAllyRange, id);
                        dict.Add(id, s);
                        stream.Position += 140;
                    }
                    r.Close();
                    stream.Close();
                    break;
                case "SpellCastTime":
                    // 4 columns - 16 bytes per row
                    // 1 for id
                    // 2 for casttime per level
                    // 3 for min casttime
                    stream = File.OpenRead(DBC_ROOT_PATH + "SpellCastTimes.dbc");
                    r = new BinaryReader(stream);
                    stream.Position = 4;
                    records = r.ReadInt32();
                    stream.Position = 20;
                    // no dbc record starts at id 0 so define one.
                    dict.Add(0, "0ms");
                    for (int i = 0; i != records; ++i)
                    {
                        int id = r.ReadInt32();
                        float casttime = r.ReadInt32();
                        float casttimePerLevel = r.ReadInt32();
                        float mincasttime = r.ReadInt32();
                        string s = String.Format("{3} - {0:F1}ms(base) / {1:F1}ms(per level) / {2:F1}ms(min)", casttime, casttimePerLevel, mincasttime, id);
                        dict.Add(id, s);
                    }
                    r.Close();
                    stream.Close();
                    break;
                default:
                    break;
            }
            return dict;
        }

        private static Dictionary<int, string> LoadDBCDefine(string file, int idCol, int nameCol, bool addZeroIndex = false, bool withID = true)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            if (addZeroIndex)
                dict.Add(0, "0 - NA/DEFAULT");

            using (FileStream stream = File.OpenRead(DBC_ROOT_PATH + file))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                stream.Position = 12;
                int rowSize = r.ReadInt32();
                for (int i = 0; i != records; ++i)
                {
                    stream.Position = 20 + rowSize * i + DBC_COLUMN_SIZE * (idCol - 1);
                    int id = r.ReadInt32();
                    stream.Position = 20 + rowSize * i + DBC_COLUMN_SIZE * (nameCol - 1);
                    int nameOfs = r.ReadInt32();
                    stream.Position = 20 + rowSize * records + nameOfs;
                    string s = "";
                    List<byte> blist = new List<byte>();
                    while (true)
                    {
                        byte b = r.ReadByte();
                        if (b == 0)
                            break;
                        blist.Add(b);
                    }
                    if (blist.Count != 0)
                    {
                        byte[] stringBytes = new byte[blist.Count];
                        for (int j = 0; j != blist.Count; ++j)
                            stringBytes[j] = blist[j];
                        s = Encoding.UTF8.GetString(stringBytes);
                    }
                    if (withID)
                        dict.Add(id, id + " - " + s);
                    else
                        dict.Add(id, s);
                }
                r.Close();
                return dict;
            }
        }

        private static Dictionary<int, string>[] LoadDBCDefine(string file, int categoryCol, int idCol, int nameCol, int categoryCount)
        {
            Dictionary<int, string>[] dicts = new Dictionary<int, string>[categoryCount];

            using (FileStream stream = File.OpenRead(DBC_ROOT_PATH + file))
            {
                BinaryReader r = new BinaryReader(stream);
                stream.Position = 4;
                int records = r.ReadInt32();
                stream.Position = 12;
                int rowSize = r.ReadInt32();
                for (int i = 0; i != records; ++i)
                {
                    stream.Position = 20 + rowSize * i + DBC_COLUMN_SIZE * (categoryCol - 1);
                    int category = r.ReadInt32();
                    stream.Position = 20 + rowSize * i + DBC_COLUMN_SIZE * (idCol - 1);
                    int id = r.ReadInt32();
                    stream.Position = 20 + rowSize * i + DBC_COLUMN_SIZE * (nameCol - 1);
                    int nameOfs = r.ReadInt32();
                    stream.Position = 20 + rowSize * records + nameOfs;
                    string s = "";
                    List<byte> blist = new List<byte>();
                    while (true)
                    {
                        byte b = r.ReadByte();
                        if (b == 0)
                            break;
                        blist.Add(b);
                    }
                    if (blist.Count != 0)
                    {
                        byte[] stringBytes = new byte[blist.Count];
                        for (int j = 0; j != blist.Count; ++j)
                            stringBytes[j] = blist[j];
                        s = Encoding.UTF8.GetString(stringBytes);
                    }
                    if (dicts[category] == null)
                        dicts[category] = new Dictionary<int, string>();
                    dicts[category].Add(id, id + " - " + s);
                }
                r.Close();
            }
            return dicts;
        }
    }
}
