
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml;
using LazyLib.Wow;

#endregion

namespace LazyLib.Helpers
{
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public static class KeyHelper
    {
        internal static readonly IDictionary<string, KeyWrapper> KeysList = new Dictionary<string, KeyWrapper>();
        private static readonly Ticker Open = new Ticker(800);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern short GetKeyState(int virtualKeyCode);
        private const string KeyFile = "\\Settings\\Keys.xml";
        internal const string InteractWithMouseover = "InteractWithMouseOver";
        internal const string InteractTarget = "InteractTarget";
        internal const string TargetLastTarget = "TargetLastTarget";
        private static object _lock = new object();
        public static void LoadKeys()
        {
            lock (_lock)
            {
                if (!Directory.Exists(LazySettings.OurDirectory + @"\Settings"))
                {
                    Directory.CreateDirectory(LazySettings.OurDirectory + @"\Settings");
                }
                if (!File.Exists(LazySettings.OurDirectory + @"\Settings\Keys.xml"))
                {
                    SaveKeys();
                }
                AddKey("Eat", "None", LazySettings.KeysEatBar, LazySettings.KeysEatKey);
                AddKey("Drink", "None", LazySettings.KeysDrinkBar, LazySettings.KeysDrinkKey);
                AddKey("GMount", "None", LazySettings.KeysGroundMountBar, LazySettings.KeysGroundMountKey);
                AddKey("Q", "None", "Indifferent", LazySettings.KeysStafeLeftKeyText);
                AddKey("E", "None", "Indifferent", LazySettings.KeysStafeRightKeyText);
                AddKey("Attack1", "None", LazySettings.KeysAttack1Bar, LazySettings.KeysAttack1Key);
                AddKey("MacroForMail", "None", LazySettings.KeysMailMacroBar, LazySettings.KeysMailMacroKey);
                AddKey("InteractWithMouseOver", "None", "Indifferent", LazySettings.KeysInteractKeyText);
                AddKey("InteractTarget", "None", "Indifferent", LazySettings.KeysInteractTargetText);
                AddKey("TargetLastTarget", "None", "Indifferent", LazySettings.KeysTargetLastTargetText);
                AddKey("LFR", "None", "Indifferent", "I");
                XmlDocument document = new XmlDocument();
                try
                {
                    document.Load(LazySettings.OurDirectory + @"\Settings\Keys.xml");
                }
                catch (Exception exception)
                {
                    Logging.Write(LogType.Error, "Could not load keys: " + exception, new object[0]);
                    goto Label_02D5;
                }
                foreach (XmlNode node in document.GetElementsByTagName("KeyWrapper"))
                {
                    string innerText = string.Empty;
                    string shiftState = string.Empty;
                    string barState = string.Empty;
                    string character = string.Empty;
                    foreach (XmlNode node2 in node.ChildNodes)
                    {
                        string name = node2.Name;
                        if (name != null)
                        {
                            if (!(name == "name"))
                            {
                                if (name == "shiftstate")
                                {
                                    goto Label_0250;
                                }
                                if (name == "bar")
                                {
                                    goto Label_025B;
                                }
                                if (name == "key")
                                {
                                    goto Label_0266;
                                }
                            }
                            else
                            {
                                innerText = node2.InnerText;
                            }
                        }
                        continue;
                    Label_0250:
                        shiftState = node2.InnerText;
                        continue;
                    Label_025B:
                        barState = node2.InnerText;
                        continue;
                    Label_0266:
                        character = node2.InnerText;
                    }
                    if (!string.IsNullOrEmpty(innerText))
                    {
                        AddKey(innerText, shiftState, barState, character);
                    }
                }
            Label_02D5:;
            }
        }

        private static void SaveKeys()
        {
            Dictionary<string, KeyWrapper> dictionary = new Dictionary<string, KeyWrapper>();
            dictionary.Add("Up", new KeyWrapper("Up", "None", "Indifferent", "Up"));
            dictionary.Add("Down", new KeyWrapper("Down", "None", "Indifferent", "Down"));
            dictionary.Add("Right", new KeyWrapper("Down", "None", "Indifferent", "Right"));
            dictionary.Add("Left", new KeyWrapper("Down", "None", "Indifferent", "Left"));
            dictionary.Add("Space", new KeyWrapper("Space", "None", "Indifferent", "Space"));
            dictionary.Add("X", new KeyWrapper("X", "None", "Indifferent", "X"));
            dictionary.Add("PetAttack", new KeyWrapper("PetAttack", "Ctrl", "Indifferent", "1"));
            dictionary.Add("PetFollow", new KeyWrapper("PetFollow", "Ctrl", "Indifferent", "2"));
            dictionary.Add("F1", new KeyWrapper("F1", "None", "Indifferent", "F1"));
            dictionary.Add("TargetEnemy", new KeyWrapper("Tab", "None", "Indifferent", "Tab"));
            dictionary.Add("TargetFriend", new KeyWrapper("TargetFriend", "Ctrl", "Indifferent", "Tab"));
            dictionary.Add("ESC", new KeyWrapper("ESC", "None", "Indifferent", "Escape"));
            dictionary.Add("InventoryOpenAll", new KeyWrapper("InventoryOpenAll", "None", "Indifferent", "B"));
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<?xml version=\"1.0\"?>", new object[0]);
            builder.AppendFormat("<KeyList>", new object[0]);
            foreach (KeyValuePair<string, KeyWrapper> pair in dictionary)
            {
                builder.AppendFormat("<KeyWrapper>", new object[0]);
                builder.AppendFormat("<name>{0}</name>", pair.Key);
                builder.AppendFormat("<shiftstate>{0}</shiftstate>", pair.Value.Special);
                builder.AppendFormat("<bar>{0}</bar>", pair.Value.Bar);
                builder.AppendFormat("<key>{0}</key>", pair.Value.Key);
                builder.AppendFormat("</KeyWrapper>", new object[0]);
            }
            builder.AppendFormat("</KeyList>", new object[0]);
            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(builder.ToString());
                document.Save(LazySettings.OurDirectory + @"\Settings\Keys.xml");
            }
            catch (Exception exception)
            {
                Logging.Write("Could not save the keys: " + exception, new object[0]);
            }
        }

        public static void AddKey(string name, string shiftState, string barState, string character)
        {
            lock (_lock)
            {
                if (KeysList.ContainsKey(name))
                    KeysList.Remove(name);
                KeysList.Add(name, new KeyWrapper(name, shiftState, barState, character));
            }
        }

        /// <summary>
        ///   SendKey
        /// </summary>
        /// <param name = "name">
        ///   Key name to send
        /// </param>
        public static void SendKey(string name)
        {
            lock (_lock)
            {
                //LazyBot.Log.Debug("IsCasting spell: " + name);
                if (KeysList.ContainsKey(name))
                {
                    KeyWrapper key = KeysList[name];
                    key.SendKey();
                }
                else
                {
                    Logging.Write("Unknown key: " + name);
                }
            }
        }

        public static bool HasKey(string name)
        {
            return KeysList.ContainsKey(name);
        }

        /// <summary>
        ///   Press and hold a key
        /// </summary>
        /// <param name = "name">
        ///   Key name to press and hold
        /// </param>
        public static void PressKey(string name)
        {
            lock (_lock)
            {               
                if (KeysList.ContainsKey(name))
                {
                   // Logging.Debug("PressKey: " + name);
                    KeyWrapper key = KeysList[name];
                    //Logging.Write(key.Bar + " " + key.Key);
                    key.PressKey();
                }
                else
                {
                    Logging.Write("The key " + name + " could not be send");
                }
            }
        }

        /// <summary>
        ///   Release a held key.
        /// </summary>
        /// <param name = "name">
        ///   Key name to release
        /// </param>
        public static void ReleaseKey(string name)
        {
            lock (_lock)
            {
                if (KeysList.ContainsKey(name))
                {
                  //  Logging.Debug("ReleaseKey: " + name);
                    KeyWrapper key = KeysList[name];
                    key.ReleaseKey();
                }
                else
                {
                    Logging.Write("The key " + name + " could not be send");
                }
            }
        }

        public static void ChatboxSendText(string text)
        {
            if (IsChatboxOpened)
            {
                KeyLowHelper.PressKey(MicrosoftVirtualKeys.VK_LCONTROL);
                KeyLowHelper.PressKey(MicrosoftVirtualKeys.A);
                KeyLowHelper.ReleaseKey(MicrosoftVirtualKeys.A);
                KeyLowHelper.ReleaseKey(MicrosoftVirtualKeys.VK_LCONTROL);
                KeyLowHelper.PressKey(MicrosoftVirtualKeys.Delete);
                KeyLowHelper.ReleaseKey(MicrosoftVirtualKeys.Delete);
                Thread.Sleep(200);
            }
            else
            {
                KeyLowHelper.SendEnter();
                Open.Reset();
                while (!IsChatboxOpened && !Open.IsReady)
                {
                    Thread.Sleep(2);
                }
            }
            SendTextNow(text);
            Thread.Sleep(0x3e8);
            KeyLowHelper.SendEnter();
        }

        public static void SendEnter()
        {
            KeyLowHelper.SendEnter();
        }

        public static void SendTextNow(string text)
        {
            foreach (char ch in text)
            {
                KeyLowHelper.SendMessage(Memory.WindowHandle, 0x102, (IntPtr)ch, IntPtr.Zero);
            }
        }

        public static bool IsChatboxOpened
        {
            get
            {
                return (Memory.ReadRelative<uint>(new uint[] { 0xba033c }) == 1);
            }
        }
    }
}