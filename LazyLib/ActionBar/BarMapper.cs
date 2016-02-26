// Type: LazyLib.ActionBar.BarMapper
// Assembly: LazyLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A92FE1A9-C28E-4E6F-9BAC-5C48387A25CC
// Assembly location: E:\VeryOldLazyBots\Lazy Evolution\LazyLib.dll

using LazyLib;
using LazyLib.Helpers;
using LazyLib.Wow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace LazyLib.ActionBar
{
    [Obfuscation(ApplyToMembers = true, Feature = "renaming")]
    [Obfuscation(ApplyToMembers = true, Feature = "renaming")]
    public class BarMapper
    {
        private static readonly List<WowKey> LoadedKeys = new List<WowKey>();
        private static readonly List<BarItem> BarItems = new List<BarItem>();
        private static readonly IDictionary<string, BarSpell> Spells = (IDictionary<string, BarSpell>)new Dictionary<string, BarSpell>();
        private static readonly Dictionary<int, string> SpellsUsed = new Dictionary<int, string>();
        private static Dictionary<int, string> _spellDatabase;

        public static int SpellsLoaded
        {
            get
            {
                return BarMapper.Spells.Count;
            }
        }

        static BarMapper()
        {
        }

        public static void ResetBar()
        {
            Logging.Write(LogType.Info, "Reset bar to first", new object[0]);
            KeyLowHelper.PostMessage(Memory.WindowHandle, 256U, (IntPtr)16L, (IntPtr)0);
            KeyLowHelper.PostMessage(Memory.WindowHandle, 256U, (IntPtr)49L, (IntPtr)0);
            KeyLowHelper.PostMessage(Memory.WindowHandle, 257U, (IntPtr)16L, (IntPtr)0);
            KeyLowHelper.PostMessage(Memory.WindowHandle, 257U, (IntPtr)49L, (IntPtr)0);
            Thread.Sleep(500);
        }

        public static void ResetBar1()
        {
            Logging.Debug("AddKey Reset Bars");
            KeyHelper.AddKey("ResetBars", "None", "1", "Indifferent");
            Logging.Debug("SendKey Reset Bars");
            KeyHelper.SendKey("ResetBars");
        }
        public static string GetNameFromSpell(int spellId)
        {
            BarMapper.Load();
            try
            {
                if (BarMapper._spellDatabase.ContainsKey(spellId))
                    return BarMapper._spellDatabase[spellId];
                else
                    return string.Empty;
            }
            catch (Exception)
            {
                Logging.Write("Error find name of spell: " + (object)spellId, new object[0]);
                return string.Empty;
            }
        }

        private static void Load()
        {
            if (_spellDatabase == null)
            {
                try
                {
                    _spellDatabase = new Dictionary<int, string>();
                    string[] spellsSplit = Resource.Spells.Split('\n');
                    foreach (string s in spellsSplit)
                    {
                        if (s.Contains("="))
                        {
                            int id = Convert.ToInt32(s.Split('=')[0]);
                            string name = s.Split('=')[1].Replace("\n", "").Replace("\r", "");
                            if (!_spellDatabase.ContainsKey(id))
                                _spellDatabase.Add(id, name);
                        }
                    }
                    Logging.Debug("[Mapper] We loaded " + _spellDatabase.Count + " spells");
                }
                catch (Exception e)
                {
                    Logging.Write(LogType.Error, "[Mapper] Spells could not be loaded, LazyBot is fubar :( " + e);
                }
            }
        }

        public static void MapBars()
        {
            ResetBar();
            //ResetBar1();
            LoadedKeys.Clear();
            BarItems.Clear();
            Spells.Clear();
            const int barSize = 0x60;
            int maxSlots = 60;
            switch (ObjectManager.MyPlayer.UnitClass)
            {
                case Constants.UnitClass.UnitClass_Warrior:
                    maxSlots = 0x60;
                    break;
                case Constants.UnitClass.UnitClass_Rogue:
                    maxSlots = 0x48;
                    break;
                case Constants.UnitClass.UnitClass_Priest:
                    maxSlots = 0x48;
                    break;
                case Constants.UnitClass.UnitClass_Monk:
                    maxSlots = 0x54;
                    break;
                case Constants.UnitClass.UnitClass_Druid:
                    maxSlots = 0x60;
                    break;
            }
            Int32 currentSlot = 1;
            Int32 currentBar = 1;
            for (uint i = 0; i < maxSlots; i++)
            {
                if (currentSlot > 12)
                {
                    currentBar++;
                    currentSlot = 1;
                }
                var actionId = Memory.ReadRelative<UInt32>((uint)Pointers.ActionBar.ActionBarFirstSlot + (8 * i) + barSize);

                if (actionId != 0)
                {
                    LoadedKeys.Add(new WowKey(actionId, currentBar, currentSlot));
                }
                currentSlot++;
            }
            var bonusBar = Memory.ReadRelative<Int32>((uint)Pointers.ActionBar.ActionBarBonus);
            if (bonusBar == 0)
            {
                for (uint i = 0; i < 12; i++)
                {
                    var actionId = Memory.ReadRelative<UInt32>((uint)Pointers.ActionBar.ActionBarFirstSlot + (8 * i));
                    if (actionId != 0)
                    {
                        LoadedKeys.Add(new WowKey(actionId, 0, (int)i + 1));
                    }
                    currentSlot++;
                }
            }
            else
            {
                for (uint i = 0; i < 12; i++)
                {
                    var actionId = Memory.ReadRelative<UInt32>((uint)Pointers.ActionBar.ActionBarFirstSlot + (8 * i) + (uint)barSize * 6 + (((uint)bonusBar - 1) * barSize));
                    if (actionId != 0)
                    {
                        LoadedKeys.Add(new WowKey(actionId, 0, (int)i + 1));
                    }
                    currentSlot++;
                }
            }
            //Load all spells 
            Load();
            LoadedKeys.Reverse(); //Reverse the list to get bar 1 first
            //Now lets find names and assign the correct once)
            foreach (WowKey wowKey in LoadedKeys)
            {
                string name = String.Empty;
                //First udjust the bar and the 0 key
                if (wowKey.Bar > 5)
                {
                    wowKey.Bar = 0;
                }
                wowKey.Bar = wowKey.Bar + 1;
                if (wowKey.Key == 10)
                    wowKey.Key = 0;
                if (wowKey.Key > 10)
                    continue;
                //Now lets sort by spells and items
                if (wowKey.Type.Equals(KeyType.Spell))
                {
                    name = GetNameFromSpell(wowKey.SpellId);
                    if (name != String.Empty)
                    {
                        if (!Spells.ContainsKey(name))
                        {
                            Logging.Debug("Found key: " + name + " : " + wowKey.Bar + " : " + wowKey.Key);
                            Spells.Add(name, new BarSpell(wowKey.SpellId, wowKey.Bar, wowKey.Key, name));
                        }
                        else
                        {
                            Logging.Debug("Key: " + name + " : " + wowKey.Bar + " : " + wowKey.Key + " is a duplicate");
                        }
                    }
                }
                if (wowKey.Type.Equals(KeyType.Item))
                {
                    BarItems.Add(new BarItem(wowKey.ItemId, wowKey.Bar, wowKey.Key));
                    Logging.Debug(string.Format("Found item: {0} : {1} : {2}", ItemHelper.GetNameById((uint)wowKey.ItemId), wowKey.Bar, wowKey.Key));
                }
            }
            LoadedKeys.Clear();
            GC.Collect();
        }


        public static bool HasSpellById(int spellId)
        {
            return Enumerable.Any<KeyValuePair<string, BarSpell>>((IEnumerable<KeyValuePair<string, BarSpell>>)BarMapper.Spells, (Func<KeyValuePair<string, BarSpell>, bool>)(spell => spell.Value.SpellId.Equals(spellId)));
        }

        public static bool HasSpellByName(string spellName)
        {
            return Enumerable.FirstOrDefault<BarSpell>(Enumerable.Select<KeyValuePair<string, BarSpell>, BarSpell>(Enumerable.Where<KeyValuePair<string, BarSpell>>((IEnumerable<KeyValuePair<string, BarSpell>>)BarMapper.Spells, (Func<KeyValuePair<string, BarSpell>, bool>)(barSpell => barSpell.Key == spellName)), (Func<KeyValuePair<string, BarSpell>, BarSpell>)(barSpell => barSpell.Value))) != null;
        }

        public static bool HasItemById(int itemId)
        {
            return Enumerable.Any<BarItem>((IEnumerable<BarItem>)BarMapper.BarItems, (Func<BarItem, bool>)(a => a.ItemId.Equals(itemId)));
        }

        public static BarSpell GetSpellById(int spellId)
        {
            return Enumerable.FirstOrDefault<BarSpell>(Enumerable.Select<KeyValuePair<string, BarSpell>, BarSpell>(Enumerable.Where<KeyValuePair<string, BarSpell>>((IEnumerable<KeyValuePair<string, BarSpell>>)BarMapper.Spells, (Func<KeyValuePair<string, BarSpell>, bool>)(spell => spell.Value.SpellId.Equals(spellId))), (Func<KeyValuePair<string, BarSpell>, BarSpell>)(spell => spell.Value)));
        }

        public static BarSpell GetSpellByName(String spellName)
        {
            return (from barSpell in Spells where barSpell.Key == spellName select barSpell.Value).FirstOrDefault() ?? new BarSpell(0, 0, 0, "Unknown Spell");
        }

        public static BarItem GetItemById(int itemId)
        {
            return Enumerable.FirstOrDefault<BarItem>((IEnumerable<BarItem>)BarMapper.BarItems, (Func<BarItem, bool>)(barItem => barItem.ItemId.Equals(itemId)));
        }

        public static bool IsSpellReadyByName(string name)
        {
            if (Enumerable.FirstOrDefault<BarSpell>(Enumerable.Select<KeyValuePair<string, BarSpell>, BarSpell>(Enumerable.Where<KeyValuePair<string, BarSpell>>((IEnumerable<KeyValuePair<string, BarSpell>>)BarMapper.Spells, (Func<KeyValuePair<string, BarSpell>, bool>)(barSpell => barSpell.Key == name)), (Func<KeyValuePair<string, BarSpell>, BarSpell>)(barSpell => barSpell.Value))) != null)
                return BarMapper.IsSpellReady(BarMapper.GetSpellByName(name).SpellId);
            else
                return false;
        }

        public static bool IsSpellReadyById(int id)
        {
            return BarMapper.IsSpellReady(id);
        }

        public static void CastSpell(string spellName)
        {
            BarSpell Spell = Enumerable.FirstOrDefault<BarSpell>(Enumerable.Select<KeyValuePair<string, BarSpell>, BarSpell>(Enumerable.Where<KeyValuePair<string, BarSpell>>((IEnumerable<KeyValuePair<string, BarSpell>>)BarMapper.Spells, (Func<KeyValuePair<string, BarSpell>, bool>)(barSpell => barSpell.Key == spellName)), (Func<KeyValuePair<string, BarSpell>, BarSpell>)(barSpell => barSpell.Value)));
            if (Spell == null)
                return;
            Logging.Write("[Mapper]Casting " + spellName, new object[0]);
            Spell.CastSpell();
        }

        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);


        private static bool IsSpellReady(int spellidToCheck)
        {
            long frequency;
            long perfCount;
            QueryPerformanceFrequency(out frequency);
            QueryPerformanceCounter(out perfCount);
            //Current time in ms
            long currentTime = (perfCount * 1000) / frequency;
            //Get first list object
            var currentListObject = Memory.ReadRelative<uint>((uint)Pointers.SpellCooldown.CooldPown + 0x8);
            while ((currentListObject != 0) && ((currentListObject & 1) == 0))
            {
                var spellId = Memory.Read<uint>(currentListObject + 0x8);

                if (spellId == spellidToCheck)
                {
                    //Start time of the spell cooldown in ms        
                    var startTime = Memory.Read<uint>(currentListObject + 0x10);
                    //Cooldown of spells with gcd
                    var cooldown1 = Memory.Read<int>(currentListObject + 0x14);
                    //Cooldown of spells without gcd
                    var cooldown2 = Memory.Read<int>(currentListObject + 0x20);
                    int cooldownLength = Math.Max(cooldown1, cooldown2);
                    if ((startTime + cooldownLength) > currentTime)
                    {
                        return false;
                    }
                }
                currentListObject = Memory.Read<uint>(currentListObject + 4);
            }
            return true;
        }

        public static bool HasBuff(PUnit check, string name)
        {
            List<int> idsFromName = BarMapper.GetIdsFromName(name);
            return ObjectManager.Initialized && check.HasBuff(idsFromName);
        }

        public static bool DoesBuffExist(string name)
        {
            return BarMapper.GetIdsFromName(name).Count != 0;
        }

        public static int GetIdByName(string spellName)
        {
            List<int> idsFromName = BarMapper.GetIdsFromName(spellName);
            if (idsFromName.Count != 0)
                return idsFromName[0];
            else
                return 0;
        }

        public static int GetIdFromName(string name)
        {
            List<int> idsFromName = BarMapper.GetIdsFromName(name);
            if (idsFromName.Count != 0)
                return idsFromName[0];
            else
                return 0;
        }

        public static List<int> GetIdsFromName(string name)
        {
            Load();
            try
            {
                if (SpellsUsed.ContainsValue(name))
                {
                    return SpellsUsed.Where(spell => spell.Value == name).Select(spell => spell.Key).ToList();
                }
                List<int> idsFromName = _spellDatabase.Where(spell => spell.Value == name).Select(spell => spell.Key).ToList();
                foreach (var i in idsFromName)
                {
                    SpellsUsed.Add(i, name);
                }
                return idsFromName;
            }
            catch (Exception)
            {
                return new List<int> { 0 };
            }
        }
    }
}
