namespace LazyLib.Wow
{
    using LazyLib.Helpers;
    using System;
    using LazyLib;

    internal class Faction
    {
        private static LazyLib.Wow.Reaction CompareFactionHash(uint localBitHash, uint mobBitHash)
        {
            int mobHashCheck = Memory.Read<int>(new uint[] { mobBitHash + 4 });
            if (TestBits(localBitHash + (uint)Pointers.Reaction.FriendlyOffset1, mobBitHash + (uint)Pointers.Reaction.FriendlyOffset2))
            {
                return LazyLib.Wow.Reaction.Friendly;
            }
            if (HashCompare(40, localBitHash, mobHashCheck))
            {
                return LazyLib.Wow.Reaction.Friendly;
            }
            if (TestBits(localBitHash + (uint)Pointers.Reaction.HostileOffset1, mobBitHash + (uint)Pointers.Reaction.HostileOffset2))
            {
                return LazyLib.Wow.Reaction.Hostile;
            }
            if (HashCompare(0x18, localBitHash, mobHashCheck))
            {
                return LazyLib.Wow.Reaction.Hostile;
            }
            return LazyLib.Wow.Reaction.Neutral;
        }

        public static LazyLib.Wow.Reaction GetReaction(PUnit localObj, PUnit mobObj)
        {
            DBC<IntPtr> dbc = new DBC<IntPtr>((IntPtr)(uint)Pointers.Reaction.DBCPtrFactionTemplate);
            try
            {
                if ((localObj.Faction < 1) || (mobObj.Faction < 1))
                {
                    return LazyLib.Wow.Reaction.Missing;
                }
                IntPtr rowPtr = dbc.GetRowPtr((int) localObj.Faction);
                IntPtr ptr2 = dbc.GetRowPtr((int) mobObj.Faction);
                return CompareFactionHash((uint) ((int) rowPtr), (uint) ((int) ptr2));
            }
            catch (Exception)
            {
                return LazyLib.Wow.Reaction.Missing;
            }
        }

        private static bool HashCompare(int hashIndex, uint localBitHash, int mobHashCheck)
        {
            int num = Memory.Read<int>(new uint[] { (uint)(localBitHash + hashIndex) });
            for (uint i = 0; i < 4; i++)
            {
                if (num == mobHashCheck)
                {
                    return true;
                }
                hashIndex += 4;
                num = Memory.Read<int>(new uint[] { (uint)(localBitHash + hashIndex) });
                if (num == 0)
                {
                    break;
                }
            }
            return false;
        }

        private static bool TestBits(uint lBitAddr, uint rBitAddr)
        {
            uint num = Memory.Read<uint>(new uint[] { lBitAddr });
            uint num2 = Memory.Read<uint>(new uint[] { rBitAddr });
            return ((num & num2) != 0);
        }
    }
}

