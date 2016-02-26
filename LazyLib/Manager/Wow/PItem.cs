
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

using LazyLib.Manager;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace LazyLib.Wow
{
    /// <summary>
    ///   Contains all information related to a WowItem.
    /// </summary>
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class PItem : PObject
    {
        public PItem(uint baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        ///   The item's remaining durability.
        /// </summary>
        public int Durability
        {
            get { return GetStorageField<int>((uint)Descriptors.CGItemData.Durability); }
        }

        public ulong Info
        {
            get { return GetStorageField<ulong>(4); }
        }

        /// <summary>
        ///   Returns Display ID
        /// </summary>
        /// <value>The display id.</value>
        public uint EntryId
        {
            get
            {
                try
                {
                    return GetStorageField<uint>((uint)Descriptors.CGObjectData.EntryID);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///   Returns durability as percentage
        /// </summary>
        public float GetDurabilityPercentage
        {
            get
            {
                try
                {
                    return ((Durability)/((float) MaximumDurability))*100;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public List<uint> TempEnchants
        {
            get
            {
                return new List<uint> { base.GetStorageField<uint>((uint)0x68), base.GetStorageField<uint>((uint)0x70) };
            }
        }

        /// <summary>
        ///   Gets the tempory enchants idøs.
        /// </summary>
        /// <value>The enchant id's</value>
        public List<uint> Enchants
        {
            get
            {
                return new List<uint> { 
                    base.GetStorageField<uint>((uint) 0x5c), base.GetStorageField<uint>((uint) 100), base.GetStorageField<uint>((uint) 0x68), base.GetStorageField<uint>((uint) 0x70), base.GetStorageField<uint>((uint) 0x74), base.GetStorageField<uint>((uint) 0x7c), base.GetStorageField<uint>((uint) 0x80), base.GetStorageField<uint>((uint) 0x88), base.GetStorageField<uint>((uint) 140), base.GetStorageField<uint>((uint) 0x94), base.GetStorageField<uint>((uint) 0x98), base.GetStorageField<uint>((uint) 160), base.GetStorageField<uint>((uint) 0xa4), base.GetStorageField<uint>((uint) 0xac), base.GetStorageField<uint>((uint) 0xb0), base.GetStorageField<uint>((uint) 0xb8), 
                    base.GetStorageField<uint>((uint) 0xbc), base.GetStorageField<uint>((uint) 0xc4), base.GetStorageField<uint>((uint) 200), base.GetStorageField<uint>((uint) 0xd0), base.GetStorageField<uint>((uint) 0xd4), base.GetStorageField<uint>((uint) 220), base.GetStorageField<uint>((uint) 0xe0), base.GetStorageField<uint>((uint) 0xe8)
                 };
            }
        }

        /// <summary>
        ///   Gets the contained.
        /// </summary>
        /// <value>The contained.</value>
        public UInt128 Contained
        {
            get { return GetStorageField<UInt128>((uint)Descriptors.CGItemData.ContainedIn); }
        }

        /// <summary>
        ///   The item's maximum durability.
        /// </summary>
        public int MaximumDurability
        {
            get { return GetStorageField<int>((uint)Descriptors.CGItemData.MaxDurability); }
        }

        /// <summary>
        ///   The amount of items stacked.
        /// </summary>
        public int StackCount
        {
            get { return GetStorageField<int>((uint)Descriptors.CGItemData.StackCount); }
        }

        /// <summary>
        ///   The amount of charges this item has.
        /// </summary>
        public int Charges
        {
            get { return GetStorageField<int>((uint)Descriptors.CGItemData.SpellCharges); }
        }

        /// <summary>
        ///   Does the item have charges?
        /// </summary>
        public bool HasCharges
        {
            get { return Charges > 0 ? true : false; }
        }
    }
}