using System.Reflection;

namespace LazyLib.Wow
{
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class ConstantsNew
    {
        #region WoWSpecialization enum
        public enum WoWSpecialization
        {
            None = 0,
            MageArcane = 62,
            MageFire = 63,
            MageFrost = 64,
            PaladinHoly = 65,
            PaladinProtection = 66,
            PaladinRetribution = 70,
            WarriorArms = 71,
            WarriorFury = 72,
            WarriorProtection = 73,
            DruidBalance = 102,
            DruidFeral = 103,
            DruidGuardian = 104,
            DruidRestoration = 105,
            DeathknightBlood = 250,
            DeathknightFrost = 251,
            DeathknightUnholy = 252,
            HunterBeastMastery = 253,
            HunterMarksmanship = 254,
            HunterSurvival = 255,
            PriestDiscipline = 256,
            PriestHoly = 257,
            PriestShadow = 258,
            RogueAssassination = 259,
            RogueCombat = 260,
            RogueSubtlety = 261,
            ShamanElemental = 262,
            ShamanEnhancement = 263,
            ShamanRestoration = 264,
            WarlockAffliction = 265,
            WarlockDemonology = 266,
            WarlockDestruction = 267,
            MonkBrewmaster = 268,
            MonkWindwalker = 269,
            MonkMistweaver = 270
        }
        #endregion

        #region BattlegroundId enum
        public enum BattlegroundId
        {
            None = 0,
            AlteracValley = 1,
            WarsongGulch = 2,
            ArathiBasin = 3,
            EyeoftheStorm = 7,
            StrandoftheAncients = 9,
            IsleofConquest = 30,
            RandomBattleground = 32,
            TwinPeaks = 108,
            BattleforGilneas = 120,
            TempleofKotmogu = 699,
            SilvershardMines = 708,
            DeepwindGorge = 754
        }
        #endregion

        #region BattlegroundWinnerType enum
        public enum BattlegroundWinnerType
        {
            NONE,
            HORDE,
            ALLIANCE
        }
        #endregion 

        #region BGStatus enum
        private enum BGStatus
        {
            Unknown = -1,
            None = 0,
            Queued = 1,
            Waiting = 2,
            Active = 4
        }
        #endregion

        #region SkillRank enum
        public enum SkillRank
        {
            None = 0,
            Apprentice = 75,
            Journeyman = 150,
            Expert = 225,
            Artisan = 300,
            Master = 375,
            GrandMaster = 450,
            IllustriousGrandMaster = 525,
            ZenMaster = 600,
            DraenorMaster = 700
        }
        #endregion

        #region QuestGiverStatus enum
        public enum QuestGiverStatus
        {
            None,
            Unavailable,
            LowLevelAvailable,
            LowLevelTurnInRepeatable,
            LowLevelAvailableRepeatable,
            Incomplete,
            TurnInRepeatable,
            AvailableRepeatable,
            Available,
            TurnInInvisible,
            TurnIn
        }
        #endregion

        #region WoWBaseItemSlot enum
        public enum WoWBaseItemSlot
        {
            None = -1,
            Head = 0,
            Neck = 1,
            Shoulders = 2,
            Shirt = 3,
            Chest = 4,
            Waist = 5,
            Legs = 6,
            Feet = 7,
            Wrists = 8,
            Hands = 9,
            Finger = 10,
            Finger2 = 11,
            Trinket = 12,
            Trinket2 = 13,
            Cloak = 14,
            MainHand = 15,
            OffHand = 16,
            Ranged = 17,
            Tabard = 18,
            Bag1 = 19,
            Bag2 = 20,
            Bag3 = 21,
            Bag4 = 22,
            Max = 23
        }
        #endregion

        #region WoWEquipSlot enum
        public enum WoWEquipSlot
        {
            NonEquip,
            Head,
            Neck,
            Shoulders,
            Shirt,
            Chest,
            Waist,
            Legs,
            Feet,
            Wrists,
            Hands,
            Finger,
            Trinket,
            Weapon,
            Shield,
            Ranged,
            Cloak,
            TwoHandedWeapon,
            Bag,
            Tabard,
            Robe,
            WeaponMainHand,
            WeaponOffHand,
            Holdable,
            Ammo,
            Thrown,
            RangedRight,
            Quiver,
            Relic,
            Max
        }
        #endregion

        #region WowPlayerEquipSlot enum
        public enum WowPlayerEquipSlot
        {
            Head,
            Neck,
            Shoulders,
            Shirt,
            Chest,
            Waist,
            Legs,
            Feet,
            Wrists,
            Hands,
            Finger1,
            Finger2,
            Trinket1,
            Trinket2,
            Back,
            MainHand,
            OffHand,
            Ranged,
            Tabard
        }
        #endregion 

        #region GameObjectTypes enum
        public enum GameObjectTypes
        {
            Door,
            Button,
            QuestGiver,
            Chest,
            Binder,
            Generic,
            Trap,
            Chair,
            SpellFocus,
            Text,
            Goober,
            Transport,
            AreaDamage,
            Camera,
            MapObject,
            MOTransport,
            DuelFlag,
            FishingNode,
            SummoningRitual,
            Mailbox,
            DoNotUse1,
            GuardPost,
            SpellCaster,
            MeetingStone,
            FlagStand,
            FishingHole,
            FlagDrop,
            MiniGame,
            DoNotUse2,
            CapturePoint,
            AuraGenerator,
            DungeonDifficulty,
            BarberChair,
            DestructibleBuilding,
            GuildBank,
            TrapDoor
        }
        #endregion
    }
}

