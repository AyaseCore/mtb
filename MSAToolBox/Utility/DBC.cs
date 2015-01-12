﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAToolBox.Utility
{
    class DBC
    {
        public static void WriteDBCHeader(BinaryWriter w, int records, int fields, int rowSize, int stringBlockSize = 0)
        {
            w.Write(0x43424457);
            w.Write(records);
            w.Write(fields);
            w.Write(rowSize);
            w.Write(stringBlockSize);
        }

        public static string ReadString(BinaryReader r, int ofs)
        {
            int pos = r.ReadInt32();
            long rec = r.BaseStream.Position;
            r.BaseStream.Position = pos + ofs;
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
            r.BaseStream.Position = rec;
            return s;
        }

        public static void WriteZeros(BinaryWriter w, int count)
        {
            if (count < 0) return;
            for (int i = 0; i != count; ++i)
                w.Write(0);
        }
    }

    public enum SpellAttribute
    {
        FOOD_OR_DRINK_SPELL             = 0x00000001, //  0
        REQ_AMMO                        = 0x00000002, //  1 on next ranged
        ON_NEXT_SWING                   = 0x00000004, //  2
        IS_REPLENISHMENT                = 0x00000008, //  3 not set in 3.0.3
        ABILITY                         = 0x00000010, //  4 client puts 'ability' instead of 'spell' in game strings for these spells
        TRADESPELL                      = 0x00000020, //  5 trade spells (recipes), will be added by client to a sublist of profession spell
        PASSIVE                         = 0x00000040, //  6 Passive spell
        HIDDEN_CLIENTSIDE               = 0x00000080, //  7 Spells with this attribute are not visible in spellbook or aura bar
        HIDE_IN_COMBAT_LOG              = 0x00000100, //  8 This attribite controls whether spell appears in combat logs
        TARGET_MAINHAND_ITEM            = 0x00000200, //  9 Client automatically selects item from mainhand slot as a cast target
        ON_NEXT_SWING_2                 = 0x00000400, // 10
        UNK11                           = 0x00000800, // 11
        DAYTIME_ONLY                    = 0x00001000, // 12 only useable at daytime, not set in 2.4.2
        NIGHT_ONLY                      = 0x00002000, // 13 only useable at night, not set in 2.4.2
        INDOORS_ONLY                    = 0x00004000, // 14 only useable indoors, not set in 2.4.2
        OUTDOORS_ONLY                   = 0x00008000, // 15 Only useable outdoors.
        NOT_SHAPESHIFT                  = 0x00010000, // 16 Not while shapeshifted
        ONLY_STEALTHED                  = 0x00020000, // 17 Must be in stealth
        DONT_AFFECT_SHEATH_STATE        = 0x00040000, // 18 client won't hide unit weapons in sheath on cast/channel
        LEVEL_DAMAGE_CALCULATION        = 0x00080000, // 19 spelldamage depends on caster level
        STOP_ATTACK_TARGET              = 0x00100000, // 20 Stop attack after use this spell (and not begin attack if use)
        IMPOSSIBLE_DODGE_PARRY_BLOCK    = 0x00200000, // 21 Cannot be dodged/parried/blocked
        CAST_TRACK_TARGET               = 0x00400000, // 22 Client automatically forces player to face target when casting
        CASTABLE_WHILE_DEAD             = 0x00800000, // 23 castable while dead?
        CASTABLE_WHILE_MOUNTED          = 0x01000000, // 24 castable while mounted
        DISABLED_WHILE_ACTIVE           = 0x02000000, // 25 Activate and start cooldown after aura fade or remove summoned creature or go
        NEGATIVE_1                      = 0x04000000, // 26 Many negative spells have this attr
        CASTABLE_WHILE_SITTING          = 0x08000000, // 27 castable while sitting
        CANT_USED_IN_COMBAT             = 0x10000000, // 28 Cannot be used in combat
        UNAFFECTED_BY_INVULNERABILITY   = 0x20000000, // 29 unaffected by invulnerability (hmm possible not...)
        HEARTBEAT_RESIST_CHECK          = 0x40000000, // 30 random chance the effect will end TODO: implement core support
        //CANT_CANCEL                     = 0x80000000  // 31 positive aura can't be canceled
    }

    public enum SpellAttributeEx
    {
        DISMISS_PET                     = 0x00000001, //  0 for spells without this flag client doesn't allow to summon pet if caster has a pet
        DRAIN_ALL_POWER                 = 0x00000002, //  1 use all power (Only paladin Lay of Hands and Bunyanize)
        CHANNELED_1                     = 0x00000004, //  2 clientside checked? cancelable?
        CANT_BE_REDIRECTED              = 0x00000008, //  3
        UNK4                            = 0x00000010, //  4 stealth and whirlwind
        NOT_BREAK_STEALTH               = 0x00000020, //  5 Not break stealth
        CHANNELED_2                     = 0x00000040, //  6
        CANT_BE_REFLECTED               = 0x00000080, //  7
        CANT_TARGET_IN_COMBAT           = 0x00000100, //  8 can target only out of combat units
        MELEE_COMBAT_START              = 0x00000200, //  9 player starts melee combat after this spell is cast
        NO_THREAT                       = 0x00000400, // 10 no generates threat on cast 100% (old NO_INITIAL_AGGRO)
        UNK11                           = 0x00000800, // 11 aura
        IS_PICKPOCKET                   = 0x00001000, // 12 Pickpocket
        FARSIGHT                        = 0x00002000, // 13 Client removes farsight on aura loss
        CHANNEL_TRACK_TARGET            = 0x00004000, // 14 Client automatically forces player to face target when channeling
        DISPEL_AURAS_ON_IMMUNITY        = 0x00008000, // 15 remove auras on immunity
        UNAFFECTED_BY_SCHOOL_IMMUNE     = 0x00010000, // 16 on immuniy
        UNAUTOCASTABLE_BY_PET           = 0x00020000, // 17
        UNK18                           = 0x00040000, // 18 stun, polymorph, daze, hex
        CANT_TARGET_SELF                = 0x00080000, // 19
        REQ_COMBO_POINTS1               = 0x00100000, // 20 Req combo points on target
        UNK21                           = 0x00200000, // 21
        REQ_COMBO_POINTS2               = 0x00400000, // 22 Req combo points on target
        UNK23                           = 0x00800000, // 23
        IS_FISHING                      = 0x01000000, // 24 only fishing spells
        UNK25                           = 0x02000000, // 25
        UNK26                           = 0x04000000, // 26 works correctly with [target=focus] and [target=mouseover] macros?
        UNK27                           = 0x08000000, // 27 melee spell?
        DONT_DISPLAY_IN_AURA_BAR        = 0x10000000, // 28 client doesn't display these spells in aura bar
        CHANNEL_DISPLAY_SPELL_NAME      = 0x20000000, // 29 spell name is displayed in cast bar instead of 'channeling' text
        ENABLE_AT_DODGE                 = 0x40000000, // 30 Overpower
        //UNK31                           = 0x80000000  // 31
    }

    public enum SpellAttributeEx2
    {
        CAN_TARGET_DEAD                 = 0x00000001, //  0 can target dead unit or corpse
        UNK1                            = 0x00000002, //  1 vanish, shadowform, Ghost Wolf and other
        CAN_TARGET_NOT_IN_LOS           = 0x00000004, //  2 26368 4.0.1 dbc change
        UNK3                            = 0x00000008, //  3
        DISPLAY_IN_STANCE_BAR           = 0x00000010, //  4 client displays icon in stance bar when learned, even if not shapeshift
        AUTOREPEAT_FLAG                 = 0x00000020, //  5
        CANT_TARGET_TAPPED              = 0x00000040, //  6 target must be tapped by caster
        UNK7                            = 0x00000080, //  7
        UNK8                            = 0x00000100, //  8 not set in 3.0.3
        UNK9                            = 0x00000200, //  9
        UNK10                           = 0x00000400, // 10 related to tame
        HEALTH_FUNNEL                   = 0x00000800, // 11
        UNK12                           = 0x00001000, // 12 Cleave, Heart Strike, Maul, Sunder Armor, Swipe
        PRESERVE_ENCHANT_IN_ARENA       = 0x00002000, // 13 Items enchanted by spells with this flag preserve the enchant to arenas
        UNK14                           = 0x00004000, // 14
        UNK15                           = 0x00008000, // 15 not set in 3.0.3
        TAME_BEAST                      = 0x00010000, // 16
        NOT_RESET_AUTO_ACTIONS          = 0x00020000, // 17 don't reset timers for melee autoattacks (swings) or ranged autoattacks (autoshoots)
        REQ_DEAD_PET                    = 0x00040000, // 18 Only Revive pet and Heart of the Pheonix
        NOT_NEED_SHAPESHIFT             = 0x00080000, // 19 does not necessarly need shapeshift
        UNK20                           = 0x00100000, // 20
        DAMAGE_REDUCED_SHIELD           = 0x00200000, // 21 for ice blocks, pala immunity buffs, priest absorb shields, but used also for other spells -> not sure!
        UNK22                           = 0x00400000, // 22 Ambush, Backstab, Cheap Shot, Death Grip, Garrote, Judgements, Mutilate, Pounce, Ravage, Shiv, Shred
        IS_ARCANE_CONCENTRATION         = 0x00800000, // 23 Only mage Arcane Concentration have this flag
        UNK24                           = 0x01000000, // 24
        UNK25                           = 0x02000000, // 25
        UNK26                           = 0x04000000, // 26 unaffected by school immunity
        UNK27                           = 0x08000000, // 27
        UNK28                           = 0x10000000, // 28
        CANT_CRIT                       = 0x20000000, // 29 Spell can't crit
        TRIGGERED_CAN_TRIGGER_PROC      = 0x40000000, // 30 spell can trigger even if triggered
        //FOOD_BUFF                       = 0x80000000  // 31 Food or Drink Buff (like Well Fed)
    }

    public enum SpellAttributeEx3
    {
        UNK0                            = 0x00000001, //  0
        UNK1                            = 0x00000002, //  1
        UNK2                            = 0x00000004, //  2
        BLOCKABLE_SPELL                 = 0x00000008, //  3 Only dmg class melee in 3.1.3
        IGNORE_RESURRECTION_TIMER       = 0x00000010, //  4 you don't have to wait to be resurrected with these spells
        UNK5                            = 0x00000020, //  5
        UNK6                            = 0x00000040, //  6
        STACK_FOR_DIFF_CASTERS          = 0x00000080, //  7 separate stack for every caster
        ONLY_TARGET_PLAYERS             = 0x00000100, //  8 can only target players
        TRIGGERED_CAN_TRIGGER_PROC_2    = 0x00000200, //  9 triggered from effect?
        MAIN_HAND                       = 0x00000400, // 10 Main hand weapon required
        BATTLEGROUND                    = 0x00000800, // 11 Can only be cast in battleground
        ONLY_TARGET_GHOSTS              = 0x00001000, // 12
        DONT_DISPLAY_CHANNEL_BAR        = 0x00002000, // 13 Clientside attribute - will not display channeling bar
        IS_HONORLESS_TARGET             = 0x00004000, // 14 "Honorless Target" only this spells have this flag
        UNK15                           = 0x00008000, // 15 Auto Shoot, Shoot, Throw,  - this is autoshot flag
        CANT_TRIGGER_PROC               = 0x00010000, // 16 confirmed with many patchnotes
        NO_INITIAL_AGGRO                = 0x00020000, // 17 Soothe Animal, 39758, Mind Soothe
        IGNORE_HIT_RESULT               = 0x00040000, // 18 Spell should always hit its target
        DISABLE_PROC                    = 0x00080000, // 19 during aura proc no spells can trigger (20178, 20375)
        DEATH_PERSISTENT                = 0x00100000, // 20 Death persistent spells
        UNK21                           = 0x00200000, // 21 unused
        REQ_WAND                        = 0x00400000, // 22 Req wand
        UNK23                           = 0x00800000, // 23
        REQ_OFFHAND                     = 0x01000000, // 24 Req offhand weapon
        UNK25                           = 0x02000000, // 25 no cause spell pushback ?
        CAN_PROC_WITH_TRIGGERED         = 0x04000000, // 26 auras with this attribute can proc from triggered spell casts with TRIGGERED_CAN_TRIGGER_PROC_2 (67736 + 52999)
        DRAIN_SOUL                      = 0x08000000, // 27 only drain soul has this flag
        UNK28                           = 0x10000000, // 28
        NO_DONE_BONUS                   = 0x20000000, // 29 Ignore caster spellpower and done damage mods?  client doesn't apply spellmods for those spells
        DONT_DISPLAY_RANGE              = 0x40000000, // 30 client doesn't display range in tooltip for those spells
        //UNK31                           = 0x80000000  // 31
    }

    public enum SpellAttributeEx4
    {
        IGNORE_RESISTANCES              = 0x00000001, //  0 spells with this attribute will completely ignore the target's resistance (these spells can't be resisted)
        PROC_ONLY_ON_CASTER             = 0x00000002, //  1 proc only on effects with TARGET_UNIT_CASTER?
        UNK2                            = 0x00000004, //  2
        UNK3                            = 0x00000008, //  3
        UNK4                            = 0x00000010, //  4 This will no longer cause guards to attack on use??
        UNK5                            = 0x00000020, //  5
        NOT_STEALABLE                   = 0x00000040, //  6 although such auras might be dispellable, they cannot be stolen
        TRIGGERED                       = 0x00000080, //  7 spells forced to be triggered
        FIXED_DAMAGE                    = 0x00000100, //  8 Ignores resilience and any (except mechanic related) damage or % damage taken auras on target.
        TRIGGER_ACTIVATE                = 0x00000200, //  9 initially disabled / trigger activate from event (Execute, Riposte, Deep Freeze end other)
        SPELL_VS_EXTEND_COST            = 0x00000400, // 10 Rogue Shiv have this flag
        UNK11                           = 0x00000800, // 11
        UNK12                           = 0x00001000, // 12
        UNK13                           = 0x00002000, // 13
        DAMAGE_DOESNT_BREAK_AURAS       = 0x00004000, // 14 doesn't break auras by damage from these spells
        UNK15                           = 0x00008000, // 15
        NOT_USABLE_IN_ARENA             = 0x00010000, // 16
        USABLE_IN_ARENA                 = 0x00020000, // 17
        AREA_TARGET_CHAIN               = 0x00040000, // 18 (NYI)hits area targets one after another instead of all at once
        UNK19                           = 0x00080000, // 19 proc dalayed, after damage or don't proc on absorb?
        NOT_CHECK_SELFCAST_POWER        = 0x00100000, // 20 supersedes message "More powerful spell applied" for self casts.
        UNK21                           = 0x00200000, // 21 Pally aura, dk presence, dudu form, warrior stance, shadowform, hunter track
        UNK22                           = 0x00400000, // 22 Seal of Command (42058, 57770) and Gymer's Smash 55426
        UNK23                           = 0x00800000, // 23
        UNK24                           = 0x01000000, // 24 some shoot spell
        IS_PET_SCALING                  = 0x02000000, // 25 pet scaling auras
        CAST_ONLY_IN_OUTLAND            = 0x04000000, // 26 Can only be used in Outland.
        UNK27                           = 0x08000000, // 27
        UNK28                           = 0x10000000, // 28 Aimed Shot - maybe hide castbar? test it. - nope.
        UNK29                           = 0x20000000, // 29
        UNK30                           = 0x40000000, // 30
        //UNK31                           = 0x80000000  // 31 Polymorph (chicken) 228 and Sonic Boom (38052, 38488)
    }

    public enum SpellAttributeEx5
    {
        UNK0                            = 0x00000001, //  0
        NO_REAGENT_WHILE_PREP           = 0x00000002, //  1 not need reagents if UNIT_FLAG_PREPARATION
        UNK2                            = 0x00000004, //  2
        USABLE_WHILE_STUNNED            = 0x00000008, //  3 usable while stunned
        UNK4                            = 0x00000010, //  4
        SINGLE_TARGET_SPELL             = 0x00000020, //  5 Only one target can be apply at a time
        UNK6                            = 0x00000040, //  6
        UNK7                            = 0x00000080, //  7
        UNK8                            = 0x00000100, //  8
        START_PERIODIC_AT_APPLY         = 0x00000200, //  9 begin periodic tick at aura apply
        HIDE_DURATION                   = 0x00000400, // 10 do not send duration to client
        ALLOW_TARGET_OF_TARGET_AS_TARGET = 0x00000800, // 11 (NYI) uses target's target as target if original target not valid (intervene for example)
        UNK12                           = 0x00001000, // 12 Cleave related?
        HASTE_AFFECT_DURATION           = 0x00002000, // 13 haste effects decrease duration of this
        UNK14                           = 0x00004000, // 14
        UNK15                           = 0x00008000, // 15 Inflits on multiple targets?
        SPECIAL_ITEM_CLASS_CHECK        = 0x00010000, // 16 this allows spells with EquippedItemClass to affect spells from other items if the required item is equipped
        USABLE_WHILE_FEARED             = 0x00020000, // 17 usable while feared
        USABLE_WHILE_CONFUSED           = 0x00040000, // 18 usable while confused
        DONT_TURN_DURING_CAST           = 0x00080000, // 19 Blocks caster's turning when casting (client does not automatically turn caster's model to face UNIT_FIELD_TARGET)
        UNK20                           = 0x00100000, // 20
        UNK21                           = 0x00200000, // 21
        UNK22                           = 0x00400000, // 22
        UNK23                           = 0x00800000, // 23
        UNK24                           = 0x01000000, // 24
        UNK25                           = 0x02000000, // 25
        UNK26                           = 0x04000000, // 26 aoe related - Boulder, Cannon, Corpse Explosion, Fire Nova, Flames, Frost Bomb, Living Bomb, Seed of Corruption, Starfall, Thunder Clap, Volley
        DONT_SHOW_AURA_IF_SELF_CAST     = 0x08000000, // 27 Auras with this attribute are not visible on units that are the caster
        DONT_SHOW_AURA_IF_NOT_SELF_CAST = 0x10000000, // 28 Auras with this attribute are not visible on units that are not the caster
        UNK29                           = 0x20000000, // 29
        UNK30                           = 0x40000000, // 30
        //UNK31                           = 0x80000000  // 31 Forces all nearby enemies to focus attacks caster
    }

    public enum SpellAttributeEx6
    {
        DONT_DISPLAY_COOLDOWN           = 0x00000001, //  0 client doesn't display cooldown in tooltip for these spells
        ONLY_IN_ARENA                   = 0x00000002, //  1 only usable in arena
        IGNORE_CASTER_AURAS             = 0x00000004, //  2
        ASSIST_IGNORE_IMMUNE_FLAG       = 0x00000008, //  3 skips checking UNIT_FLAG_IMMUNE_TO_PC and UNIT_FLAG_IMMUNE_TO_NPC flags on assist
        UNK4                            = 0x00000010, //  4
        UNK5                            = 0x00000020, //  5
        USE_SPELL_CAST_EVENT            = 0x00000040, //  6 Auras with this attribute trigger SPELL_CAST combat log event instead of SPELL_AURA_START (clientside attribute)
        UNK7                            = 0x00000080, //  7
        CANT_TARGET_CROWD_CONTROLLED    = 0x00000100, //  8
        UNK9                            = 0x00000200, //  9
        CAN_TARGET_POSSESSED_FRIENDS    = 0x00000400, // 10 NYI!
        NOT_IN_RAID_INSTANCE            = 0x00000800, // 11 not usable in raid instance
        CASTABLE_WHILE_ON_VEHICLE       = 0x00001000, // 12 castable while caster is on vehicle
        CAN_TARGET_INVISIBLE            = 0x00002000, // 13 ignore visibility requirement for spell target (phases, invisibility, etc.)
        UNK14                           = 0x00004000, // 14
        UNK15                           = 0x00008000, // 15 only 54368, 67892
        UNK16                           = 0x00010000, // 16
        UNK17                           = 0x00020000, // 17 Mount spell
        CAST_BY_CHARMER                 = 0x00040000, // 18 client won't allow to cast these spells when unit is not possessed && charmer of caster will be original caster
        UNK19                           = 0x00080000, // 19 only 47488, 50782
        ONLY_VISIBLE_TO_CASTER          = 0x00100000, // 20 Auras with this attribute are only visible to their caster (or pet's owner)
        CLIENT_UI_TARGET_EFFECTS        = 0x00200000, // 21 it's only client-side attribute
        UNK22                           = 0x00400000, // 22 only 72054
        UNK23                           = 0x00800000, // 23
        CAN_TARGET_UNTARGETABLE         = 0x01000000, // 24
        UNK25                           = 0x02000000, // 25 Exorcism, Flash of Light
        UNK26                           = 0x04000000, // 26 related to player castable positive buff
        UNK27                           = 0x08000000, // 27
        UNK28                           = 0x10000000, // 28 Death Grip
        NO_DONE_PCT_DAMAGE_MODS         = 0x20000000, // 29 ignores done percent damage mods?
        UNK30                           = 0x40000000, // 30
        //IGNORE_CATEGORY_COOLDOWN_MODS   = 0x80000000  // 31 Spells with this attribute skip applying modifiers to category cooldowns
    }

    public enum SpellAttributeEx7
    {
        UNK0                            = 0x00000001, //  0 Shaman's new spells (Call of the ...), Feign Death.
        IGNORE_DURATION_MODS            = 0x00000002, //  1 Duration is not affected by duration modifiers
        REACTIVATE_AT_RESURRECT         = 0x00000004, //  2 Paladin's auras and 65607 only.
        IS_CHEAT_SPELL                  = 0x00000008, //  3 Cannot cast if caster doesn't have UnitFlag2 & UNIT_FLAG2_ALLOW_CHEAT_SPELLS
        UNK4                            = 0x00000010, //  4 Only 47883 (Soulstone Resurrection) and test spell.
        SUMMON_PLAYER_TOTEM             = 0x00000020, //  5 Only Shaman player totems.
        NO_PUSHBACK_ON_DAMAGE           = 0x00000040, //  6 Does not cause spell pushback on damage
        UNK7                            = 0x00000080, //  7 66218 (Launch) spell.
        HORDE_ONLY                      = 0x00000100, //  8 Teleports, mounts and other spells.
        ALLIANCE_ONLY                   = 0x00000200, //  9 Teleports, mounts and other spells.
        DISPEL_CHARGES                  = 0x00000400, // 10 Dispel and Spellsteal individual charges instead of whole aura.
        INTERRUPT_ONLY_NONPLAYER        = 0x00000800, // 11 Only non-player casts interrupt, though Feral Charge - Bear has it.
        UNK12                           = 0x00001000, // 12 Not set in 3.2.2a.
        UNK13                           = 0x00002000, // 13 Not set in 3.2.2a.
        UNK14                           = 0x00004000, // 14 Only 52150 (Raise Dead - Pet) spell.
        UNK15                           = 0x00008000, // 15 Exorcism. Usable on players? 100% crit chance on undead and demons?
        CAN_RESTORE_SECONDARY_POWER     = 0x00010000, // 16 These spells can replenish a powertype, which is not the current powertype.
        UNK17                           = 0x00020000, // 17 Only 27965 (Suicide) spell.
        HAS_CHARGE_EFFECT               = 0x00040000, // 18 Only spells that have Charge among effects.
        ZONE_TELEPORT                   = 0x00080000, // 19 Teleports to specific zones.
        UNK20                           = 0x00100000, // 20 Blink, Divine Shield, Ice Block
        UNK21                           = 0x00200000, // 21 Not set
        UNK22                           = 0x00400000, // 22
        UNK23                           = 0x00800000, // 23 Motivate, Mutilate, Shattering Throw
        UNK24                           = 0x01000000, // 24 Motivate, Mutilate, Perform Speech, Shattering Throw
        UNK25                           = 0x02000000, // 25
        UNK26                           = 0x04000000, // 26
        UNK27                           = 0x08000000, // 27 Not set
        CONSOLIDATED_RAID_BUFF          = 0x10000000, // 28 May be collapsed in raid buff frame (clientside attribute)
        UNK29                           = 0x20000000, // 29 only 69028, 71237
        UNK30                           = 0x40000000, // 30 Burning Determination, Divine Sacrifice, Earth Shield, Prayer of Mending
        //CLIENT_INDICATOR                = 0x80000000
    }

    public class SpellTemplate
    {
        public SpellTemplate()
        {
            Attributes = new uint[8];
            Totem = new int[2];
            Reagent = new int[8];
            ReagentCount = new uint[8];
            Effect = new int[3];
            EffectDieSides = new int[3];
            EffectBasePoints = new int[3];
            EffectPointsPerLevel = new float[3];
            EffectMechanic = new uint[3];
            EffectTargetA = new int[3];
            EffectTargetB = new int[3];
            EffectRadius = new int[3];
            EffectApplyAura = new int[3];
            EffectAmplitude = new uint[3];
            EffectMultipleValue = new float[3];
            EffectChainTargets = new uint[3];
            EffectItemType = new uint[3];
            EffectMisc = new int[3];
            EffectMiscB = new int[3];
            EffectTriggerSpell = new uint[3];
            EffectPointsPerComboPoint = new float[3];
            EffectSpellMaskA = new uint[3];
            EffectSpellMaskB = new uint[3];
            EffectSpellMaskC = new uint[3];
            EffectDamageMultiplier = new float[3];
            EffectBonusMultiplier = new float[3];
            TotemCategory = new int[2];
            Stance = new uint[2];
            StanceNot = new uint[2];
            Visual = new uint[2];
        }

        public uint ID { get; set; }
        public uint Category { get; set; }
        public int Dispel { get; set; }
        public int Mechanic { get; set; }
        public uint[] Attributes { get; set; }
        public uint[] Stance { get; set; }
        public uint[] StanceNot { get; set; }
        public uint Targets { get; set; }
        public uint TargetCreatureType { get; set; }
        public uint RequiredSpellFocus { get; set; }
        public bool RequireFacingTarget { get; set; }
        public int CasterAuraState { get; set; }
        public int TargetAuraState { get; set; }
        public int ExcludeCasterAuraState { get; set; }
        public int ExcludeTargetAuraState { get; set; }
        public uint CasterAuraSpell { get; set; }
        public uint TargetAuraSpell { get; set; }
        public uint ExcludeCasterAuraSpell { get; set; }
        public uint ExcludeTargetAuraSpell { get; set; }
        public int CastingTime { get; set; }
        public uint Cooldown { get; set; }
        public uint CategoryCooldown { get; set; }
        public uint InterruptFlags { get; set; }
        public uint AuraInterruptFlags { get; set; }
        public uint ChannelInterruptFlags { get; set; }
        public uint Proc { get; set; }
        public uint ProcChance { get; set; }
        public uint ProcCharges { get; set; }
        public uint MaxLevel { get; set; }
        public uint BaseLevel { get; set; }
        public uint Level { get; set; }
        public int Duration { get; set; }
        public int PowerType { get; set; }
        public uint PowerCost { get; set; }
        public uint PowerCostPerLevel { get; set; }
        public uint PowerCostPerSecond { get; set; }
        public uint PowerCostPerSecondPerLevel { get; set; }
        public int Range { get; set; }
        public float Speed { get; set; }
        public uint ModalNextSpell { get; set; }
        public uint StackAmount { get; set; }
        public int[] Totem { get; set; }
        public int[] Reagent { get; set; }
        public uint[] ReagentCount { get; set; }
        public int EquippedItemClass { get; set; }
        public int EquippedItemSubClassMask { get; set; }
        public int EquippedItemInventoryTypeMask { get; set; }
        public int[] Effect { get; set; }
        public int[] EffectDieSides { get; set; }
        public float[] EffectPointsPerLevel { get; set; }
        public int[] EffectBasePoints { get; set; }
        public uint[] EffectMechanic { get; set; }
        public int[] EffectTargetA { get; set; }
        public int[] EffectTargetB { get; set; }
        public int[] EffectRadius { get; set; }
        public int[] EffectApplyAura { get; set; }
        public uint[] EffectAmplitude { get; set; }
        public float[] EffectMultipleValue { get; set; }
        public uint[] EffectChainTargets { get; set; }
        public uint[] EffectItemType { get; set; }
        public int[] EffectMisc { get; set; }
        public int[] EffectMiscB { get; set; }
        public uint[] EffectTriggerSpell { get; set; }
        public float[] EffectPointsPerComboPoint { get; set; }
        public uint[] EffectSpellMaskA { get; set; }
        public uint[] EffectSpellMaskB { get; set; }
        public uint[] EffectSpellMaskC { get; set; }
        public uint[] Visual { get; set; }
        public uint Icon { get; set; }
        public uint ActiveIcon { get; set; }
        public uint Priority { get; set; }
        public string Name { get; set; }
        public uint NameFlags { get; set; }
        public string Rank { get; set; }
        public uint RankFlags { get; set; }
        public string Description { get; set; }
        public uint DescriptionFlags { get; set; }
        public string ToolTip { get; set; }
        public uint ToolTipFlags { get; set; }
        public uint PowerCostPercent { get; set; }
        public uint GlobalCategory { get; set; }
        public uint GlobalCooldown { get; set; }
        public uint MaxTargetLevel { get; set; }
        public int Family { get; set; }
        public uint FamilyMaskA { get; set; }
        public uint FamilyMaskB { get; set; }
        public uint FamilyMaskC { get; set; }
        public uint MaxAffectTargets { get; set; }
        public int DamageClass { get; set; }
        public uint PreventionType { get; set; }
        public uint StanceBarOrder { get; set; }
        public float[] EffectDamageMultiplier { get; set; }
        public uint MinFaction { get; set; }
        public uint MinReputation { get; set; }
        public uint RequiredAuraVision { get; set; }
        public int[] TotemCategory { get; set; }
        public int AreaGroup { get; set; }
        public uint SchoolMask { get; set; }
        public uint RuneCost { get; set; }
        public uint Missile { get; set; }
        public uint PowerDisplay { get; set; }
        public float[] EffectBonusMultiplier { get; set; }
        public uint DescriptionVariable { get; set; }
        public uint Difficulty { get; set; }
    }

    public class SkillLineAbility
    {
        public int ID { get; set; }
        public int Skill { get; set; }
        public int Spell { get; set; }
        public int Race { get; set; }
        public int Class { get; set; }
        public int RequiredSkillValue { get; set; }
        public int SupercededBySpell { get; set; }
        public int AccquiredMethod { get; set; }
        public int SkillLineRankHigh { get; set; }
        public int SkillLineRankLow { get; set; }
    }

    public class SkillLine
    {
        public int ID { get; set; }
        public int Category { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Icon { get; set; }
        public string Verb { get; set; }
        public int CanLink { get; set; }
    }
}
