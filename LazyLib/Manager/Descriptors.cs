
﻿/*
This file is part of LazyBot - Copyright (C) 2011 Arutha

    LazyBot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LazyBot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LazyBot.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace LazyLib.Wow
{
    public static class Descriptors
    {
        public const uint Multiplicator = 4;
        public static readonly uint StartDescriptors = 4;

        public enum CGObjectData
        {
            Guid = 0x0,                     // Size: 0x4, Flags: 0x1
            Data = 0x4,                     // Size: 0x4, Flags: 0x1
            Type = 0x8,                     // Size: 0x1, Flags: 0x1
            EntryID = 0x9,                     // Size: 0x1, Flags: 0x80
            DynamicFlags = 0xA,                     // Size: 0x1, Flags: 0x280
            Scale = 0xB,                     // Size: 0x1, Flags: 0x1
            End = 0xC
        }

        public enum CGItemData
        {
            Owner = CGObjectData.End + 0x0,  // Size: 0x4, Flags: 0x1
            ContainedIn = CGObjectData.End + 0x4,  // Size: 0x4, Flags: 0x1
            Creator = CGObjectData.End + 0x8,  // Size: 0x4, Flags: 0x1
            GiftCreator = CGObjectData.End + 0xC,  // Size: 0x4, Flags: 0x1
            StackCount = CGObjectData.End + 0x10, // Size: 0x1, Flags: 0x4
            Expiration = CGObjectData.End + 0x11, // Size: 0x1, Flags: 0x4
            SpellCharges = CGObjectData.End + 0x12, // Size: 0x5, Flags: 0x4
            DynamicFlags = CGObjectData.End + 0x17, // Size: 0x1, Flags: 0x1
            Enchantment = CGObjectData.End + 0x18, // Size: 0x27, Flags: 0x1
            PropertySeed = CGObjectData.End + 0x3F, // Size: 0x1, Flags: 0x1
            RandomPropertiesID = CGObjectData.End + 0x40, // Size: 0x1, Flags: 0x1
            Durability = CGObjectData.End + 0x41, // Size: 0x1, Flags: 0x4
            MaxDurability = CGObjectData.End + 0x42, // Size: 0x1, Flags: 0x4
            CreatePlayedTime = CGObjectData.End + 0x43, // Size: 0x1, Flags: 0x1
            ModifiersMask = CGObjectData.End + 0x44, // Size: 0x1, Flags: 0x4
            Context = CGObjectData.End + 0x45, // Size: 0x1, Flags: 0x1
            End = CGObjectData.End + 0x46
        }

        public enum CGContainerData
        {
            Slots = CGItemData.End + 0x0,    // Size: 0x90, Flags: 0x1
            NumSlots = CGItemData.End + 0x90,   // Size: 0x1, Flags: 0x1
            End = CGItemData.End + 0x91
        }

        public enum CGUnitData
        {
            Charm = CGObjectData.End + 0x0,  // Size: 0x4, Flags: 0x1
            Summon = CGObjectData.End + 0x4,  // Size: 0x4, Flags: 0x1
            Critter = CGObjectData.End + 0x8,  // Size: 0x4, Flags: 0x2
            CharmedBy = CGObjectData.End + 0xC,  // Size: 0x4, Flags: 0x1
            SummonedBy = CGObjectData.End + 0x10, // Size: 0x4, Flags: 0x1
            CreatedBy = CGObjectData.End + 0x14, // Size: 0x4, Flags: 0x1
            DemonCreator = CGObjectData.End + 0x18, // Size: 0x4, Flags: 0x1
            Target = CGObjectData.End + 0x1C, // Size: 0x4, Flags: 0x1
            BattlePetCompanionGUID = CGObjectData.End + 0x20, // Size: 0x4, Flags: 0x1
            BattlePetDBID = CGObjectData.End + 0x24, // Size: 0x2, Flags: 0x1
            ChannelObject = CGObjectData.End + 0x26, // Size: 0x4, Flags: 0x201
            ChannelSpell = CGObjectData.End + 0x2A, // Size: 0x1, Flags: 0x201
            SummonedByHomeRealm = CGObjectData.End + 0x2B, // Size: 0x1, Flags: 0x1
            Sex = CGObjectData.End + 0x2C, // Size: 0x1, Flags: 0x1
            DisplayPower = CGObjectData.End + 0x2D, // Size: 0x1, Flags: 0x1
            OverrideDisplayPowerID = CGObjectData.End + 0x2E, // Size: 0x1, Flags: 0x1
            Health = CGObjectData.End + 0x2F, // Size: 0x1, Flags: 0x1
            Power = CGObjectData.End + 0x30, // Size: 0x6, Flags: 0x401
            MaxHealth = CGObjectData.End + 0x36, // Size: 0x1, Flags: 0x1
            MaxPower = CGObjectData.End + 0x37, // Size: 0x6, Flags: 0x1
            PowerRegenFlatModifier = CGObjectData.End + 0x3D, // Size: 0x6, Flags: 0x46
            PowerRegenInterruptedFlatModifier = CGObjectData.End + 0x43, // Size: 0x6, Flags: 0x46
            Level = CGObjectData.End + 0x49, // Size: 0x1, Flags: 0x1
            EffectiveLevel = CGObjectData.End + 0x4A, // Size: 0x1, Flags: 0x1
            FactionTemplate = CGObjectData.End + 0x4B, // Size: 0x1, Flags: 0x1
            VirtualItemID = CGObjectData.End + 0x4C, // Size: 0x3, Flags: 0x1
            Flags = CGObjectData.End + 0x4F, // Size: 0x1, Flags: 0x1
            Flags2 = CGObjectData.End + 0x50, // Size: 0x1, Flags: 0x1
            Flags3 = CGObjectData.End + 0x51, // Size: 0x1, Flags: 0x1
            AuraState = CGObjectData.End + 0x52, // Size: 0x1, Flags: 0x1
            AttackRoundBaseTime = CGObjectData.End + 0x53, // Size: 0x2, Flags: 0x1
            RangedAttackRoundBaseTime = CGObjectData.End + 0x55, // Size: 0x1, Flags: 0x2
            BoundingRadius = CGObjectData.End + 0x56, // Size: 0x1, Flags: 0x1
            CombatReach = CGObjectData.End + 0x57, // Size: 0x1, Flags: 0x1
            DisplayID = CGObjectData.End + 0x58, // Size: 0x1, Flags: 0x280
            NativeDisplayID = CGObjectData.End + 0x59, // Size: 0x1, Flags: 0x201
            MountDisplayID = CGObjectData.End + 0x5A, // Size: 0x1, Flags: 0x201
            MinDamage = CGObjectData.End + 0x5B, // Size: 0x1, Flags: 0x16
            MaxDamage = CGObjectData.End + 0x5C, // Size: 0x1, Flags: 0x16
            MinOffHandDamage = CGObjectData.End + 0x5D, // Size: 0x1, Flags: 0x16
            MaxOffHandDamage = CGObjectData.End + 0x5E, // Size: 0x1, Flags: 0x16
            AnimTier = CGObjectData.End + 0x5F, // Size: 0x1, Flags: 0x1
            PetNumber = CGObjectData.End + 0x60, // Size: 0x1, Flags: 0x1
            PetNameTimestamp = CGObjectData.End + 0x61, // Size: 0x1, Flags: 0x1
            PetExperience = CGObjectData.End + 0x62, // Size: 0x1, Flags: 0x4
            PetNextLevelExperience = CGObjectData.End + 0x63, // Size: 0x1, Flags: 0x4
            ModCastingSpeed = CGObjectData.End + 0x64, // Size: 0x1, Flags: 0x1
            ModSpellHaste = CGObjectData.End + 0x65, // Size: 0x1, Flags: 0x1
            ModHaste = CGObjectData.End + 0x66, // Size: 0x1, Flags: 0x1
            ModRangedHaste = CGObjectData.End + 0x67, // Size: 0x1, Flags: 0x1
            ModHasteRegen = CGObjectData.End + 0x68, // Size: 0x1, Flags: 0x1
            CreatedBySpell = CGObjectData.End + 0x69, // Size: 0x1, Flags: 0x1
            NpcFlags = CGObjectData.End + 0x6A, // Size: 0x2, Flags: 0x81
            EmoteState = CGObjectData.End + 0x6C, // Size: 0x1, Flags: 0x1
            Stats = CGObjectData.End + 0x6D, // Size: 0x5, Flags: 0x6
            StatPosBuff = CGObjectData.End + 0x72, // Size: 0x5, Flags: 0x6
            StatNegBuff = CGObjectData.End + 0x77, // Size: 0x5, Flags: 0x6
            Resistances = CGObjectData.End + 0x7C, // Size: 0x7, Flags: 0x16
            ResistanceBuffModsPositive = CGObjectData.End + 0x83, // Size: 0x7, Flags: 0x6
            ResistanceBuffModsNegative = CGObjectData.End + 0x8A, // Size: 0x7, Flags: 0x6
            ModBonusArmor = CGObjectData.End + 0x91, // Size: 0x1, Flags: 0x6
            BaseMana = CGObjectData.End + 0x92, // Size: 0x1, Flags: 0x1
            BaseHealth = CGObjectData.End + 0x93, // Size: 0x1, Flags: 0x6
            ShapeshiftForm = CGObjectData.End + 0x94, // Size: 0x1, Flags: 0x1
            AttackPower = CGObjectData.End + 0x95, // Size: 0x1, Flags: 0x6
            AttackPowerModPos = CGObjectData.End + 0x96, // Size: 0x1, Flags: 0x6
            AttackPowerModNeg = CGObjectData.End + 0x97, // Size: 0x1, Flags: 0x6
            AttackPowerMultiplier = CGObjectData.End + 0x98, // Size: 0x1, Flags: 0x6
            RangedAttackPower = CGObjectData.End + 0x99, // Size: 0x1, Flags: 0x6
            RangedAttackPowerModPos = CGObjectData.End + 0x9A, // Size: 0x1, Flags: 0x6
            RangedAttackPowerModNeg = CGObjectData.End + 0x9B, // Size: 0x1, Flags: 0x6
            RangedAttackPowerMultiplier = CGObjectData.End + 0x9C, // Size: 0x1, Flags: 0x6
            MinRangedDamage = CGObjectData.End + 0x9D, // Size: 0x1, Flags: 0x6
            MaxRangedDamage = CGObjectData.End + 0x9E, // Size: 0x1, Flags: 0x6
            PowerCostModifier = CGObjectData.End + 0x9F, // Size: 0x7, Flags: 0x6
            PowerCostMultiplier = CGObjectData.End + 0xA6, // Size: 0x7, Flags: 0x6
            MaxHealthModifier = CGObjectData.End + 0xAD, // Size: 0x1, Flags: 0x6
            HoverHeight = CGObjectData.End + 0xAE, // Size: 0x1, Flags: 0x1
            MinItemLevelCutoff = CGObjectData.End + 0xAF, // Size: 0x1, Flags: 0x1
            MinItemLevel = CGObjectData.End + 0xB0, // Size: 0x1, Flags: 0x1
            MaxItemLevel = CGObjectData.End + 0xB1, // Size: 0x1, Flags: 0x1
            WildBattlePetLevel = CGObjectData.End + 0xB2, // Size: 0x1, Flags: 0x1
            BattlePetCompanionNameTimestamp = CGObjectData.End + 0xB3, // Size: 0x1, Flags: 0x1
            InteractSpellID = CGObjectData.End + 0xB4, // Size: 0x1, Flags: 0x1
            StateSpellVisualID = CGObjectData.End + 0xB5, // Size: 0x1, Flags: 0x280
            StateAnimID = CGObjectData.End + 0xB6, // Size: 0x1, Flags: 0x280
            StateAnimKitID = CGObjectData.End + 0xB7, // Size: 0x1, Flags: 0x280
            StateWorldEffectID = CGObjectData.End + 0xB8, // Size: 0x4, Flags: 0x280
            ScaleDuration = CGObjectData.End + 0xBC, // Size: 0x1, Flags: 0x1
            LooksLikeMountID = CGObjectData.End + 0xBD, // Size: 0x1, Flags: 0x1
            LooksLikeCreatureID = CGObjectData.End + 0xBE, // Size: 0x1, Flags: 0x1
            LookAtControllerID = CGObjectData.End + 0xBF, // Size: 0x1, Flags: 0x1
            LookAtControllerTarget = CGObjectData.End + 0xC0, // Size: 0x4, Flags: 0x1
            End = CGObjectData.End + 0xC4
        }

        public enum CGPlayerData
        {
            DuelArbiter = CGUnitData.End + 0x0,    // Size: 0x4, Flags: 0x1
            WowAccount = CGUnitData.End + 0x4,    // Size: 0x4, Flags: 0x1
            LootTargetGUID = CGUnitData.End + 0x8,    // Size: 0x4, Flags: 0x1
            PlayerFlags = CGUnitData.End + 0xC,    // Size: 0x1, Flags: 0x1
            PlayerFlagsEx = CGUnitData.End + 0xD,    // Size: 0x1, Flags: 0x1
            GuildRankID = CGUnitData.End + 0xE,    // Size: 0x1, Flags: 0x1
            GuildDeleteDate = CGUnitData.End + 0xF,    // Size: 0x1, Flags: 0x1
            GuildLevel = CGUnitData.End + 0x10,   // Size: 0x1, Flags: 0x1
            HairColorID = CGUnitData.End + 0x11,   // Size: 0x1, Flags: 0x1
            RestState = CGUnitData.End + 0x12,   // Size: 0x1, Flags: 0x1
            ArenaFaction = CGUnitData.End + 0x13,   // Size: 0x1, Flags: 0x1
            DuelTeam = CGUnitData.End + 0x14,   // Size: 0x1, Flags: 0x1
            GuildTimeStamp = CGUnitData.End + 0x15,   // Size: 0x1, Flags: 0x1
            QuestLog = CGUnitData.End + 0x16,   // Size: 0x2EE, Flags: 0x20
            VisibleItems = CGUnitData.End + 0x304,  // Size: 0x39, Flags: 0x1
            PlayerTitle = CGUnitData.End + 0x33D,  // Size: 0x1, Flags: 0x1
            FakeInebriation = CGUnitData.End + 0x33E,  // Size: 0x1, Flags: 0x1
            VirtualPlayerRealm = CGUnitData.End + 0x33F,  // Size: 0x1, Flags: 0x1
            CurrentSpecID = CGUnitData.End + 0x340,  // Size: 0x1, Flags: 0x1
            TaxiMountAnimKitID = CGUnitData.End + 0x341,  // Size: 0x1, Flags: 0x1
            AvgItemLevelTotal = CGUnitData.End + 0x342,  // Size: 0x1, Flags: 0x1
            AvgItemLevelEquipped = CGUnitData.End + 0x343,  // Size: 0x1, Flags: 0x1
            CurrentBattlePetBreedQuality = CGUnitData.End + 0x344,  // Size: 0x1, Flags: 0x1
            InvSlots = CGUnitData.End + 0x345,  // Size: 0x2E0, Flags: 0x2
            FarsightObject = CGUnitData.End + 0x625,  // Size: 0x4, Flags: 0x2
            KnownTitles = CGUnitData.End + 0x629,  // Size: 0xA, Flags: 0x2
            Coinage = CGUnitData.End + 0x633,  // Size: 0x2, Flags: 0x2
            XP = CGUnitData.End + 0x635,  // Size: 0x1, Flags: 0x2
            NextLevelXP = CGUnitData.End + 0x636,  // Size: 0x1, Flags: 0x2
            Skill = CGUnitData.End + 0x637,  // Size: 0x1C0, Flags: 0x2
            CharacterPoints = CGUnitData.End + 0x7F7,  // Size: 0x1, Flags: 0x2
            MaxTalentTiers = CGUnitData.End + 0x7F8,  // Size: 0x1, Flags: 0x2
            TrackCreatureMask = CGUnitData.End + 0x7F9,  // Size: 0x1, Flags: 0x2
            TrackResourceMask = CGUnitData.End + 0x7FA,  // Size: 0x1, Flags: 0x2
            MainhandExpertise = CGUnitData.End + 0x7FB,  // Size: 0x1, Flags: 0x2
            OffhandExpertise = CGUnitData.End + 0x7FC,  // Size: 0x1, Flags: 0x2
            RangedExpertise = CGUnitData.End + 0x7FD,  // Size: 0x1, Flags: 0x2
            CombatRatingExpertise = CGUnitData.End + 0x7FE,  // Size: 0x1, Flags: 0x2
            BlockPercentage = CGUnitData.End + 0x7FF,  // Size: 0x1, Flags: 0x2
            DodgePercentage = CGUnitData.End + 0x800,  // Size: 0x1, Flags: 0x2
            ParryPercentage = CGUnitData.End + 0x801,  // Size: 0x1, Flags: 0x2
            CritPercentage = CGUnitData.End + 0x802,  // Size: 0x1, Flags: 0x2
            RangedCritPercentage = CGUnitData.End + 0x803,  // Size: 0x1, Flags: 0x2
            OffhandCritPercentage = CGUnitData.End + 0x804,  // Size: 0x1, Flags: 0x2
            SpellCritPercentage = CGUnitData.End + 0x805,  // Size: 0x7, Flags: 0x2
            ShieldBlock = CGUnitData.End + 0x80C,  // Size: 0x1, Flags: 0x2
            ShieldBlockCritPercentage = CGUnitData.End + 0x80D,  // Size: 0x1, Flags: 0x2
            Mastery = CGUnitData.End + 0x80E,  // Size: 0x1, Flags: 0x2
            Amplify = CGUnitData.End + 0x80F,  // Size: 0x1, Flags: 0x2
            Multistrike = CGUnitData.End + 0x810,  // Size: 0x1, Flags: 0x2
            MultistrikeEffect = CGUnitData.End + 0x811,  // Size: 0x1, Flags: 0x2
            Readiness = CGUnitData.End + 0x812,  // Size: 0x1, Flags: 0x2
            Speed = CGUnitData.End + 0x813,  // Size: 0x1, Flags: 0x2
            Lifesteal = CGUnitData.End + 0x814,  // Size: 0x1, Flags: 0x2
            Avoidance = CGUnitData.End + 0x815,  // Size: 0x1, Flags: 0x2
            Sturdiness = CGUnitData.End + 0x816,  // Size: 0x1, Flags: 0x2
            Cleave = CGUnitData.End + 0x817,  // Size: 0x1, Flags: 0x2
            Versatility = CGUnitData.End + 0x818,  // Size: 0x1, Flags: 0x2
            VersatilityBonus = CGUnitData.End + 0x819,  // Size: 0x1, Flags: 0x2
            PvpPowerDamage = CGUnitData.End + 0x81A,  // Size: 0x1, Flags: 0x2
            PvpPowerHealing = CGUnitData.End + 0x81B,  // Size: 0x1, Flags: 0x2
            ExploredZones = CGUnitData.End + 0x81C,  // Size: 0xC8, Flags: 0x2
            RestStateBonusPool = CGUnitData.End + 0x8E4,  // Size: 0x1, Flags: 0x2
            ModDamageDonePos = CGUnitData.End + 0x8E5,  // Size: 0x7, Flags: 0x2
            ModDamageDoneNeg = CGUnitData.End + 0x8EC,  // Size: 0x7, Flags: 0x2
            ModDamageDonePercent = CGUnitData.End + 0x8F3,  // Size: 0x7, Flags: 0x2
            ModHealingDonePos = CGUnitData.End + 0x8FA,  // Size: 0x1, Flags: 0x2
            ModHealingPercent = CGUnitData.End + 0x8FB,  // Size: 0x1, Flags: 0x2
            ModHealingDonePercent = CGUnitData.End + 0x8FC,  // Size: 0x1, Flags: 0x2
            ModPeriodicHealingDonePercent = CGUnitData.End + 0x8FD,  // Size: 0x1, Flags: 0x2
            WeaponDmgMultipliers = CGUnitData.End + 0x8FE,  // Size: 0x3, Flags: 0x2
            WeaponAtkSpeedMultipliers = CGUnitData.End + 0x901,  // Size: 0x3, Flags: 0x2
            ModSpellPowerPercent = CGUnitData.End + 0x904,  // Size: 0x1, Flags: 0x2
            ModResiliencePercent = CGUnitData.End + 0x905,  // Size: 0x1, Flags: 0x2
            OverrideSpellPowerByAPPercent = CGUnitData.End + 0x906,  // Size: 0x1, Flags: 0x2
            OverrideAPBySpellPowerPercent = CGUnitData.End + 0x907,  // Size: 0x1, Flags: 0x2
            ModTargetResistance = CGUnitData.End + 0x908,  // Size: 0x1, Flags: 0x2
            ModTargetPhysicalResistance = CGUnitData.End + 0x909,  // Size: 0x1, Flags: 0x2
            LocalFlags = CGUnitData.End + 0x90A,  // Size: 0x1, Flags: 0x2
            LifetimeMaxRank = CGUnitData.End + 0x90B,  // Size: 0x1, Flags: 0x2
            SelfResSpell = CGUnitData.End + 0x90C,  // Size: 0x1, Flags: 0x2
            PvpMedals = CGUnitData.End + 0x90D,  // Size: 0x1, Flags: 0x2
            BuybackPrice = CGUnitData.End + 0x90E,  // Size: 0xC, Flags: 0x2
            BuybackTimestamp = CGUnitData.End + 0x91A,  // Size: 0xC, Flags: 0x2
            YesterdayHonorableKills = CGUnitData.End + 0x926,  // Size: 0x1, Flags: 0x2
            LifetimeHonorableKills = CGUnitData.End + 0x927,  // Size: 0x1, Flags: 0x2
            WatchedFactionIndex = CGUnitData.End + 0x928,  // Size: 0x1, Flags: 0x2
            CombatRatings = CGUnitData.End + 0x929,  // Size: 0x20, Flags: 0x2
            PvpInfo = CGUnitData.End + 0x949,  // Size: 0x24, Flags: 0x2
            MaxLevel = CGUnitData.End + 0x96D,  // Size: 0x1, Flags: 0x2
            RuneRegen = CGUnitData.End + 0x96E,  // Size: 0x4, Flags: 0x2
            NoReagentCostMask = CGUnitData.End + 0x972,  // Size: 0x4, Flags: 0x2
            GlyphSlots = CGUnitData.End + 0x976,  // Size: 0x6, Flags: 0x2
            Glyphs = CGUnitData.End + 0x97C,  // Size: 0x6, Flags: 0x2
            GlyphSlotsEnabled = CGUnitData.End + 0x982,  // Size: 0x1, Flags: 0x2
            PetSpellPower = CGUnitData.End + 0x983,  // Size: 0x1, Flags: 0x2
            Researching = CGUnitData.End + 0x984,  // Size: 0xA, Flags: 0x2
            ProfessionSkillLine = CGUnitData.End + 0x98E,  // Size: 0x2, Flags: 0x2
            UiHitModifier = CGUnitData.End + 0x990,  // Size: 0x1, Flags: 0x2
            UiSpellHitModifier = CGUnitData.End + 0x991,  // Size: 0x1, Flags: 0x2
            HomeRealmTimeOffset = CGUnitData.End + 0x992,  // Size: 0x1, Flags: 0x2
            ModPetHaste = CGUnitData.End + 0x993,  // Size: 0x1, Flags: 0x2
            SummonedBattlePetGUID = CGUnitData.End + 0x994,  // Size: 0x4, Flags: 0x2
            OverrideSpellsID = CGUnitData.End + 0x998,  // Size: 0x1, Flags: 0x402
            LfgBonusFactionID = CGUnitData.End + 0x999,  // Size: 0x1, Flags: 0x2
            LootSpecID = CGUnitData.End + 0x99A,  // Size: 0x1, Flags: 0x2
            OverrideZonePVPType = CGUnitData.End + 0x99B,  // Size: 0x1, Flags: 0x402
            ItemLevelDelta = CGUnitData.End + 0x99C,  // Size: 0x1, Flags: 0x2
            BagSlotFlags = CGUnitData.End + 0x99D,  // Size: 0x4, Flags: 0x2
            BankBagSlotFlags = CGUnitData.End + 0x9A1,  // Size: 0x7, Flags: 0x2
            InsertItemsLeftToRight = CGUnitData.End + 0x9A8,  // Size: 0x1, Flags: 0x2
            QuestCompleted = CGUnitData.End + 0x9A9,  // Size: 0x271, Flags: 0x2
            End = CGUnitData.End + 0xC1A
        }

        public enum CGGameObjectData
        {
            CreatedBy = CGObjectData.End + 0x0,  // Size: 0x4, Flags: 0x1
            DisplayID = CGObjectData.End + 0x4,  // Size: 0x1, Flags: 0x280
            Flags = CGObjectData.End + 0x5,  // Size: 0x1, Flags: 0x201
            ParentRotation = CGObjectData.End + 0x6,  // Size: 0x4, Flags: 0x1
            FactionTemplate = CGObjectData.End + 0xA,  // Size: 0x1, Flags: 0x1
            Level = CGObjectData.End + 0xB,  // Size: 0x1, Flags: 0x1
            PercentHealth = CGObjectData.End + 0xC,  // Size: 0x1, Flags: 0x201
            SpellVisualID = CGObjectData.End + 0xD,  // Size: 0x1, Flags: 0x201
            StateSpellVisualID = CGObjectData.End + 0xE,  // Size: 0x1, Flags: 0x280
            StateAnimID = CGObjectData.End + 0xF,  // Size: 0x1, Flags: 0x280
            StateAnimKitID = CGObjectData.End + 0x10, // Size: 0x1, Flags: 0x280
            StateWorldEffectID = CGObjectData.End + 0x11, // Size: 0x4, Flags: 0x280
            End = CGObjectData.End + 0x15
        }

        public enum CGDynamicObjectData
        {
            Caster = CGObjectData.End + 0x0,  // Size: 0x4, Flags: 0x1
            TypeAndVisualID = CGObjectData.End + 0x4,  // Size: 0x1, Flags: 0x80
            SpellID = CGObjectData.End + 0x5,  // Size: 0x1, Flags: 0x1
            Radius = CGObjectData.End + 0x6,  // Size: 0x1, Flags: 0x1
            CastTime = CGObjectData.End + 0x7,  // Size: 0x1, Flags: 0x1
            End = CGObjectData.End + 0x8
        }

        public enum CGCorpseData
        {
            Owner = CGObjectData.End + 0x0,  // Size: 0x4, Flags: 0x1
            PartyGUID = CGObjectData.End + 0x4,  // Size: 0x4, Flags: 0x1
            DisplayID = CGObjectData.End + 0x8,  // Size: 0x1, Flags: 0x1
            Items = CGObjectData.End + 0x9,  // Size: 0x13, Flags: 0x1
            SkinID = CGObjectData.End + 0x1C, // Size: 0x1, Flags: 0x1
            FacialHairStyleID = CGObjectData.End + 0x1D, // Size: 0x1, Flags: 0x1
            Flags = CGObjectData.End + 0x1E, // Size: 0x1, Flags: 0x1
            DynamicFlags = CGObjectData.End + 0x1F, // Size: 0x1, Flags: 0x80
            FactionTemplate = CGObjectData.End + 0x20, // Size: 0x1, Flags: 0x1
            End = CGObjectData.End + 0x21
        }

        public enum CGAreaTriggerData
        {
            Caster = CGObjectData.End + 0x0,  // Size: 0x4, Flags: 0x1
            Duration = CGObjectData.End + 0x4,  // Size: 0x1, Flags: 0x1
            SpellID = CGObjectData.End + 0x5,  // Size: 0x1, Flags: 0x1
            SpellVisualID = CGObjectData.End + 0x6,  // Size: 0x1, Flags: 0x80
            ExplicitScale = CGObjectData.End + 0x7,  // Size: 0x1, Flags: 0x201
            End = CGObjectData.End + 0x8
        }

        public enum CGSceneObjectData
        {
            ScriptPackageID = CGObjectData.End + 0x0,  // Size: 0x1, Flags: 0x1
            RndSeedVal = CGObjectData.End + 0x1,  // Size: 0x1, Flags: 0x1
            CreatedBy = CGObjectData.End + 0x2,  // Size: 0x4, Flags: 0x1
            SceneType = CGObjectData.End + 0x6,  // Size: 0x1, Flags: 0x1
            End = CGObjectData.End + 0x7
        }

        public enum CGConversationData
        {
            Dummy = CGObjectData.End + 0x0,  // Size: 0x1, Flags: 0x2
            End = CGObjectData.End + 0x1
        }
    }
}