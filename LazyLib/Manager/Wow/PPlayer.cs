
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
using System.Threading;
using LazyLib.Helpers;
using LazyLib.Manager;
using System;

#endregion

namespace LazyLib.Wow
{
    /// <summary>
    ///   Representing a player
    /// </summary>
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class PPlayer : PUnit
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "PPlayer" /> class.
        /// </summary>
        /// <param name = "baseAddress">The base address.</param>
        public PPlayer(uint baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        ///   Returns Player race
        /// </summary>
        public string PlayerRace
        {
            get
            {
                long faction = Faction;
                if (faction.Equals((long)Constants.PlayerFactions.Human))
                    return "Human";
                if (faction.Equals((long)Constants.PlayerFactions.BloodElf))
                    return "Blood Elf";
                if (faction.Equals((long)Constants.PlayerFactions.Dwarf))
                    return "Dwarf";
                if (faction.Equals((long)Constants.PlayerFactions.Gnome))
                    return "Gnome";
                if (faction.Equals((long)Constants.PlayerFactions.NightElf))
                    return "Night Elf";
                if (faction.Equals((long)Constants.PlayerFactions.Orc))
                    return "Orc";
                if (faction.Equals((long)Constants.PlayerFactions.Tauren))
                    return "Tauren";
                if (faction.Equals((long)Constants.PlayerFactions.Troll))
                    return "Troll";
                if (faction.Equals((long)Constants.PlayerFactions.Undead))
                    return "Undead";
                if (faction.Equals((long)Constants.PlayerFactions.Draenei))
                    return "Draenei";
                if (faction.Equals((long)Constants.PlayerFactions.Worgen))
                    return "Worgen";
                if (faction.Equals((long)Constants.PlayerFactions.Goblin))
                    return "Goblin";
                if (faction.Equals((long)Constants.PlayerFactions.PandarenAlliance))
                    return "PandarenAlliance";
                if (faction.Equals((long)Constants.PlayerFactions.PandarenHorde))
                    return "PandarenHorde";
                if (faction.Equals((long)Constants.PlayerFactions.PandarenNeutral))
                    return "PandarenNeutral";
                return "Unknown";
            }
        }

        /// <summary>
        ///   Returns faction group (Alliance || Horde)
        /// </summary>
        public string PlayerFaction
        {
            get
            {
                switch (PlayerRace)
                {
                    case "Human":
                    case "Dwarf":
                    case "Gnome":
                    case "Night Elf":
                    case "Draenei":
                    case "Worgen":
                    case "PandarenAlliance":
                        return "Alliance";
                    case "Orc":
                    case "Undead":
                    case "Tauren":
                    case "Troll":
                    case "Blood Elf":
                    case "Goblin":
                    case "PandarenHorde":
                        return "Horde";
                    case "PandarenNeutral":
                        return "Neutral";
                }
                return "Unknown";
            }
        }

        public override string Name
        {
            get
            {
                try
                {
                 var index = Memory.ReadRelative<int>((uint)Pointers.UnitName.PlayerNameCachePointer);
                 while (index != 0x00)
                {
                var next = Memory.Read<int>((uint)(index + 0x0));
                var guid = Memory.Read<UInt128>((uint)(index + (uint)Pointers.UnitName.PlayerNameGUIDOffset));
                if (guid == GUID)
                {
                 string name = Memory.ReadUtf8((uint)(index + (uint)Pointers.UnitName.PlayerNameStringOffset), 40);
                 return name;
                }
             index = next;
                }

                }
                catch
               {
             return "Error Reading Name";
             }
             return "Error Reading Name";
           }
       }
    }
}