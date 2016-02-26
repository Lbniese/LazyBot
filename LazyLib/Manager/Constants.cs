namespace LazyLib.Wow
{
    using System;
    using System.Reflection;

    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class Constants
    {
        public enum ChatType : byte
        {
            Addon = 0,
            Afk = 0x17,
            Battleground = 0x2c,
            BattlegroundLeader = 0x2d,
            BgEventAlliance = 0x24,
            BgEventHorde = 0x25,
            BgEventNeutral = 0x23,
            Channel = 0x11,
            ChannelJoin = 0x12,
            ChannelLeave = 0x13,
            ChannelList = 20,
            ChannelNotice = 0x15,
            ChannelNoticeUser = 0x16,
            CombatFactionChange = 0x26,
            Dnd = 0x18,
            Emote = 10,
            Filtered = 0x2b,
            Guild = 4,
            Ignored = 0x19,
            Loot = 0x1b,
            MonsterEmote = 0x10,
            MonsterParty = 13,
            MonsterSay = 12,
            MonsterWhisper = 15,
            MonsterYell = 14,
            Officer = 5,
            Party = 2,
            Raid = 3,
            RaidLeader = 0x27,
            RaidWarning = 40,
            RaidWarningWidescreen = 0x29,
            RealId = 0x35,
            Restricted = 0x2e,
            Say = 1,
            Skill = 0x1a,
            TextEmote = 11,
            Whisper = 7,
            WhisperInform = 9,
            WhisperMob = 8,
            Yell = 6
        }

        public enum Classification
        {
            Normal,
            Elite,
            RareElite,
            WorldBoss,
            Rare,
            trivial,
            minus
        }

        public enum CreatureType
        {
            Unknown,
            Beast,
            Dragon,
            Demon,
            Elemental,
            Giant,
            Undead,
            Humanoid,
            Critter,
            Mechanical,
            NotSpecified,
            Totem,
            NonCombatPet,
            GasCloud
        }

    /*public enum PowerType
    {
        Mana,
        Rage,
        Focus,
        Energy,
        Happiness,
        Runes,
        RunicPower,
        SoulShards,
        Eclipse,
        HolyPower,
        Alternate,
        DarkForce,
        LightForce,
        ShadowOrbs,
        BurningEmbers,
        DemonicFury,
        ArcaneCharges
    }
     */
        public enum PowerType
        {
            Mana,
            Rage,
            Focus,
            Energy,
            ComboPoint,
            Runes,
            RunicPower,
            SoulShards,
            Eclipse,
            HolyPower,
            Alternate,
            DarkForce,
            LightForce,
            ShadowOrbs,
            BurningEmbers,
            DemonicFury,
            ArcaneCharges
        }

        public enum KeyType : uint
        {
            GeneralMacro = 0x40,
            Item = 0x80,
            Spell = 0,
            ToonSpecificMacro = 0x41
        }

        public enum ObjectType : uint
        {
            AiGroup = 8,
            AreaTrigger = 9,
            Container = 2,
            Corpse = 7,
            DynamicObject = 6,
            GameObject = 5,
            Item = 1,
            Object = 0,
            Player = 4,
            Unit = 3
        }

        public enum ObjType : uint
        {
            OT_AREATRIGGER = 8,
            OT_CONTAINER = 2,
            OT_CORPSE = 7,
            OT_DYNOBJ = 6,
            OT_FORCEDWORD = 0xffffffff,
            OT_GAMEOBJ = 5,
            OT_ITEM = 1,
            OT_NONE = 0,
            OT_PLAYER = 4,
            OT_SCENEOBJECT = 9,
            OT_UNIT = 3
        }

        public enum PlayerFactions : uint
        {
            None = 0,
            Human = 1,
            Orc = 2,
            Dwarf = 3,
            NightElf = 4,
            Undead = 5,
            Tauren = 6,
            Gnome = 7,
            Troll = 8,
            Goblin = 9,
            BloodElf = 10,
            Draenei = 11,
            FelOrc = 12,
            Naga = 13,
            Broken = 14,
            Skeleton = 15,
            Vrykul = 16,
            Tuskarr = 17,
            ForestTroll = 18,
            Taunka = 19,
            NorthrendSkeleton = 20,
            IceTroll = 21,
            Worgen = 22,
            PandarenNeutral = 24,
            PandarenAlliance = 25,
            PandarenHorde = 26
        }

        public enum ShapeshiftForm
        {
            Ambient = 6,
            Aqua = 4,
            BattleStance = 0x11,
            Bear = 5,
            BerserkerStance = 0x13,
            Cat = 1,
            CreatureBear = 14,
            CreatureCat = 15,
            DefensiveStance = 0x12,
            DireBear = 8,
            EpicFlightForm = 0x1b,
            GhostWolf = 0x10,
            Ghoul = 7,
            Moonkin = 0x1f,
            Normal = 0,
            Shadow = 0x1c,
            Stealth = 30,
            Travel = 3,
            TreeOfLife = 2
        }

        public enum SkinnableType
        {
            None,
            Skining,
            Herb,
            Mining,
            Engineer
        }

        public enum UnitClass
        {
            UnitClass_Unknown = 0,
            UnitClass_Warrior = 1,
            UnitClass_Paladin = 2,
            UnitClass_Hunter = 3,
            UnitClass_Rogue = 4,
            UnitClass_Priest = 5,
            UnitClass_DeathKnight = 6,
            UnitClass_Shaman = 7,
            UnitClass_Mage = 8,
            UnitClass_Warlock = 9,
            UnitClass_Monk = 10,
            UnitClass_Druid = 11,
        }

        public enum UnitDynamicFlags
        {
            None = 0,
            Invisible = 1,
            Lootable = 2,
            TrackUnit = 4,
            Tapped = 8,
            TappedByMe = 16,
            SpecialInfo = 32,
            Dead = 64,
            ReferAFriendLinked = 128,
            IsTappedByAllThreatList = 256
        }

        public enum UnitFlags : uint
        {
            CanPerformAction_Mask1 = 0x60000,
            Combat = 0x80000,
            Confused = 0x400000,
            Dazed = 0x20000000,
            Disarmed = 0x200000,
            Fleeing = 0x800000,
            Influenced = 4,
            Looting = 0x400,
            Mounted = 0x8000000,
            None = 0,
            NotAttackable = 0x100,
            NotSelectable = 0x2000000,
            Pacified = 0x20000,
            PetInCombat = 0x800,
            PlayerControlled = 8,
            PlusMob = 0x40,
            Possessed = 0x1000000,
            Preparation = 0x20,
            PvPFlagged = 0x1000,
            Sheathe = 0x40000000,
            Silenced = 0x2000,
            Sitting = 1,
            Skinnable = 0x4000000,
            Stunned = 0x40000,
            TaxiFlight = 0x100000,
            Totem = 0x10
        }

        public enum UnitGender
        {
            UnitGender_Male,
            UnitGender_Female,
            UnitGender_Unknown
        }

        public enum UnitPower
        {
            UnitPower_Mana,
            UnitPower_Rage,
            UnitPower_Focus,
            UnitPower_Energy,
            UnitPower_ComboPoint,
            UnitPower_Runes,
            UnitPower_RunicPower,
            UnitPower_SoulShard,
            UnitPower_Eclipse,
            UnitPower_HolyPower,
            UnitPower_Alternate,
            UnitPower_DarkForce,
            UnitPower_LightForce,
            UnitPower_ShadowOrbs,
            UnitPower_BurningEmbers,
            UnitPower_DemonicFury,
            UnitPower_ArcaneCharges,
            UnitPower_Max
        }

        public enum UnitRace
        {
            UnitRace_BloodElf = 10,
            UnitRace_Broken = 14,
            UnitRace_Draenei = 11,
            UnitRace_Dwarf = 3,
            UnitRace_FelOrc = 12,
            UnitRace_Gnome = 7,
            UnitRace_Goblin = 9,
            UnitRace_Human = 1,
            UnitRace_Naga = 13,
            UnitRace_NightElf = 4,
            UnitRace_Orc = 2,
            UnitRace_Pandaren = 0x18,
            UnitRace_Skeleton = 15,
            UnitRace_Tauren = 6,
            UnitRace_Troll = 8,
            UnitRace_Undead = 5,
            UnitRace_Worgen = 0x16
        }
    }
}

