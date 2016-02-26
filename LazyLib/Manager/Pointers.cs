
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
#region

using System.Reflection;

#endregion

namespace LazyLib.Wow
{
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class PublicPointers
    {
        #region Globals enum

        /// <summary>
        ///   [WoW] [6.1.0 19678] 
        /// </summary>
        public enum Globals
        {
            PlayerName = 0xF72CF8, 
        }

        #endregion

        #region InGame enum

        /// <summary>
        ///   [WoW] [6.1.0 19678] 
        /// </summary>
        public enum InGame
        {
            InGame = 0xE3191E,   
        }

        #endregion
    }

    internal class Pointers
    {
        #region ActionBar enum

        /// <summary>
        ///   [WoW] [6.1.0 19678] 
        /// </summary>
        public enum ActionBar
        {
            ActionBarFirstSlot = 0xEA1800,
            ActionBarBonus = 0xEA1A40, // TODO Check
        }

        #endregion

        #region AutoLoot enum

        /// <summary>
        ///    [WoW] [6.1.0 19678] 
        /// </summary>
        public enum AutoLoot
        {
            Offset = 0x34,
            Pointer = 0xE31ACC,   
        }

        #endregion

        #region CgUnitCGetCreatureRank enum

        /// <summary>
        ///  Reversed from CGUnit_C__GetCreatureRank 
        /// </summary>
        public enum CgUnitCGetCreatureRank
        {
            Offset1 = 0xC04,
            Offset2 = 0x2C,        
        }

        #endregion

        #region CgUnitCGetCreatureType enum

        /// <summary>
        ///   reversed from CGUnit_C__GetCreatureType 
        /// </summary>
        public enum CgUnitCGetCreatureType
        {
            Offset1 = 0xC04,
            Offset2 = 0x24,     
        }

        #endregion

        #region CgWorldFrameGetActiveCamera enum

        /// <summary>
        ///  reversed from CGWorldFrame__GetActiveCamera
        /// </summary>
        public enum CgWorldFrameGetActiveCamera
        {
            CameraX = 0x8,
            CameraY = 0xC,
            CameraZ = 0x10,
            CameraMatrix = 0x14,
            CameraPointer = 0xE32098,
            CameraOffset = 0x7610, 
        }

        #endregion

        #region SkinningFlags enum
        /// <summary>
        ///   Done
        /// </summary>
        public enum Skinning
        {
            SkinnableFlags1 = 0x0C04,
            SkinnableFlags2 = 0x5C
        }

        #endregion

        #region ClickToMove enum

        /// <summary>
        ///   5.4
        /// </summary>
        public enum ClickToMove
        {
            Offset = 0x34,
            Pointer = 0xE31AAC,
        }

        #endregion

        #region Nested type: AutoAttack

        /// <summary>
        ///  reversed from CGActionBar__IsCurrentAction 
        /// </summary>
        internal enum AutoAttack
        {
            AutoAttackFlag = 0xEE8,       //Old Method
            AutoAttackMask = 0xEEC,       //Old Method
            //Address seems to show the GUID of the Auto Attack target
            AutoAttackGUID = 0xED8,
            //Shows 0x06 when not wanding, 0x0C or 0x0E when wanding.
            Wanding = 0xEF8,       
        }

        #endregion

        #region Nested type: CastingInfo

        /// <summary>
        /// [WoW] [6.1.0 19678] 
        /// </summary>
        internal enum CastingInfo
        {
            IsCasting = 0xF40,
            ChanneledCasting = 0xF80, 
        }

        #endregion

        #region Nested type: Chat

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Chat : uint
        {
            ChatStart = 0xE8DC84,// not used currently 
            OffsetToNextMsg = 0x17E8, // used
            chatBufferPos = 0xE33908, // used

            msgFormatedChat = 0x65, // used 
            MsgSenderGuid = 0x00,
            MsgSenderName = 0x034,
            MsgFullMessage = 0x0065,
            MsgOnlyMessage = 0x0C1D,
            MsgChannelNum = 0x17D8,
            MsgTimeStamp = 0x17E4,
        }

        #endregion

        #region BlueChat
        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Messages
        {
            EventMessage = 0xE30D10 // Updated :)
        }

        #endregion

        #region Nested type: Container

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Container
        {
            EquippedBagGUID = 0xEA7F80
        }

        #endregion

        #region Nested type: Globals

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Globals
        {
            RedMessage = 0xE30D10,
            MouseOverGUID = 0xE31CE0,
            LootWindow = 0xEA2968,
            ChatboxIsOpen = 0xCBEB60,
            CursorType = 0xDF82F8,
            IsBobbing = 0x104,
            ArchFacing = 0x268,               //TODO           
            ArchFacingOffset2 = 0x148,        //TODO  
        }

        #endregion

        #region Nested type: Items

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Items : uint
        {
            Offset = 0xC696D8,
        }

        #endregion

        #region Nested type: KeyBinding

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum KeyBinding
        {
            NumKeyBindings = 0xE8F850,
            First = 0xC8,
            Next = 0xC0,
            Key = 0x18,
            Command = 0x2C, 
        }

        #endregion

        #region Nested type: ObjectManager

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum ObjectManager
        {
            CurMgrPointer = 0xF72CB8,
            CurMgrOffset = 0x62C,
            NextObject = 0x3C,
            FirstObject = 0xD8,
            LocalGUID = 0xF8,   
        }

        #endregion

        #region Nested type: Reaction

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Reaction : uint
        {
            FriendlyOffset2 = 0xC,
            HostileOffset2 = 0xC,
            FriendlyOffset1 = 010,
            HostileOffset1 = 0x14,
            DBCPtrFactionTemplate = 0xC8A34C,
        }

        #endregion

        #region Nested type: InCombat

        /// <summary>
        /// Reversed from Lua_UnitAffectingCombat
        /// v4 = v2 && (*(_DWORD *)(*(_DWORD *)(v2 + 284) + 316) >> 19) & 1;
        /// </summary>
        public enum InCombat
        {
            Mask = 19,
            Offset2 = 0x13C,
            Offset1 = 0x11C
        }

        #endregion

        #region Nested type: Runes

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Runes
        {
            RuneTypes = 0xE0A218,       //Good
            RunesOffset = 0xE0A27C,     //Good
        }

        #endregion

        #region Nested type: ShapeshiftForm

        /// <summary>
        ///  Reversed from CGUnit_C__GetShapeshiftFormId
        /// </summary>
        internal enum ShapeshiftForm
        {
            BaseAddressOffset1 = 0x11C,       // 5.4.7 (17930)
            BaseAddressOffset2 = 0x253,      // 5.4.7 (17930)
        }

        #endregion

        #region Nested type: SpellCooldown

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum SpellCooldown : uint
        {
            CooldPown = 0xD24C78,  
        }

        #endregion

        #region Nested type: PowerIndex
        internal enum PowerIndex
        {
            PowerIndexArrays = 0xDCC744,
            Multiplicator = 0x10
        }

        #endregion

        #region Nested type: Swimming

        /// <summary>
        ///   Reversed from Lua_IsSwimming
        /// </summary>
        internal enum Swimming
        {
            Pointer = 0x12C,
            Offset = 0x40,
            Mask = 0x100000,  
        }

        #endregion

        #region IsFlying enum

        /// <summary>
        ///  Reversed from Lua_IsFlying 
        /// </summary>
        public enum IsFlying
        {
            Pointer = 0x12C,
            Offset = 0x40,
            Mask = 0x1000000  
        }

        #endregion

        #region IsFalling enum

        /// <summary>
        ///  Reversed from Lua_IsFalling
        /// </summary>
        public enum IsFalling
        {
            Pointer = 0x12C,
            Offset = 0x40,
            Mask = 0x1000000
        }

        #endregion

        #region Nested type: UnitAuras

        /// <summary>
        ///   reversed from CGUnit_C__GetAura 
        /// </summary>
        internal enum UnitAuras : uint
        {
            AuraCount1 = 0x1548,
            AuraCount2 = 0x10C8,
            AuraTable1 = 0x10C8,
            AuraTable2 = 0x10CC,
            AuraSize = 0x48,
            AuraSpellId = 0x30,
            AuraStack = 0x35,
            TimeLeft = 0x3C,
            OwnerGUID = 0x20,  
        }

        #endregion

        #region Nested type: UnitName

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum UnitName : uint
        {
            ObjectName1 = 0x274,
            ObjectName2 = 0xB4,
            PlayerNameGUIDOffset = 0x010,
            PlayerNameStringOffset = 0x021,
            PlayerNameCachePointer = 0xD0E5BC,
            UnitName1 = 0xC04,
            UnitName2 = 0x7C,    
        }

        #endregion

        #region Nested type: UnitSpeed

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum UnitSpeed
        {
            Pointer1 = 0x12C,
            Pointer2 = 0x88,   
        }

        #endregion

        #region Nested type: WowObject

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum WowObject
        {
            X = 0xA90,
            Y = X + 0x4,
            Z = X + 0x8,
            RotationOffset = X + 0x10,
            GameObjectX = 0x0140,
            GameObjectY = GameObjectX + 0x4,
            GameObjectZ = GameObjectX + 0x8,
            GameObjectRotation = GameObjectX + 0x10,   
        }

        #endregion

        #region Nested type: Zone

        /// <summary>
        ///   5.4
        /// </summary>
        internal enum Zone : uint
        {
            ZoneText = 0xE31914,
            ZoneID = 0xE31968,
        }

        #endregion

        #region Nested type: UiFrame
        internal enum UiFrame
        {
            //var @base = Memory.ReadRelative<uint>((uint)Pointers.UiFrame.FrameBase);
            //var currentFrame = Memory.Read<uint>(@base + (uint)Pointers.UiFrame.FirstFrame);

            ScrWidth = 0xBFED88,
            ScrHeight = 0xBFED8C,
            FrameBase = 0xCB2254,
            CurrentFramePtr = 0xCB2254,    

            FirstFrame = 0x12F4,            //Good
            NextFrame = 0x12EC,             //Good
            RegionsFirst = 0x168,           //Good
            RegionsNext = 0x160,            //Good
            Visible = 0x64,                 //Good
            Visible1 = 0x1A,                //Good
            Visible2 = 1,                   //Good
            LabelText = 0xF8,               //Good
            Name = 0x1C,                    //Good

            ButtonEnabledPointer = 0x1F4,   //Assumed Good
            ButtonEnabledMask = 0xF,        //Assumed Good
            ButtonChecked = 0x230,          //Assumed Good
            EditBoxText = 0x210,            //Assumed Good
            FrameBottom = 0x68,             //Assumed Good
            FrameLeft = 0x6c,               //Assumed Good
            FrameTop = 0x70,                //Assumed Good
            FrameRight = 0x74,              //Assumed Good
            CurrentFrameOffset = 0x88,      //Assumed Good?   
        }
        #endregion
    }
}