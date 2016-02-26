/*
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
namespace LazyEvo.LGrindEngine.Activity
{
    using LazyEvo.LGrindEngine;
    using LazyEvo.LGrindEngine.Helpers;
    using LazyEvo.Public;
    using LazyLib;
    using LazyLib.Helpers;
    using LazyLib.Wow;
    using System;
    using System.Threading;

    internal class LootAndSkin
    {
        private static readonly Ticker TimeOut = new Ticker(3000.0);

        public static void DoLootAfterCombat(PUnit unit)
        {
            if (GrindingSettings.Loot && !LazyLib.Wow.ObjectManager.ShouldDefend)
            {
                Thread.Sleep(500);
                if (!LazyLib.Wow.ObjectManager.MyPlayer.Target.IsValid && unit.IsLootable)
                {
                    KeyHelper.SendKey("TargetLastTarget");
                }
                Thread.Sleep(500);
                if (LazyLib.Wow.ObjectManager.MyPlayer.Target.IsValid)
                {
                    DoWork(LazyLib.Wow.ObjectManager.MyPlayer.Target);
                }
            }
        }

        public static void DoWork(PUnit unit)
        {
            MoveHelper.ReleaseKeys();
            if (unit.IsLootable)
            {
                Logging.Write("Looting: " + unit.Name, new object[0]);
                if (unit.DistanceToSelf > 5.0)
                {
                    MoveHelper.MoveToLoc(unit.Location, 4.0, false, true);
                }
                if (LazyLib.Wow.ObjectManager.ShouldDefend)
                {
                    Logging.Write("Skipping loot, we got into combat", new object[0]);
                    return;
                }
                Thread.Sleep(200);
                if (LazyLib.Wow.ObjectManager.MyPlayer.HasLivePet)
                {
                    Thread.Sleep(700);
                }
                if (LazyLib.Wow.ObjectManager.MyPlayer.Target != unit)
                {
                    unit.Interact(false);
                }
                else
                {
                    KeyHelper.SendKey("InteractTarget");
                }
                if (LazyLib.Wow.ObjectManager.ShouldDefend)
                {
                    return;
                }
                TimeOut.Reset();
                while (!LazyLib.Wow.ObjectManager.MyPlayer.LootWinOpen && !TimeOut.IsReady)
                {
                    Thread.Sleep(100);
                }
                if (GrindingSettings.WaitForLoot)
                {
                    Latency.Sleep(500);
                }
                GrindingEngine.UpdateStats(1, 0, 0);
                if (!GrindingSettings.Skin)
                {
                    PBlackList.Blacklist(unit, 300, false);
                }
            }
            if ((unit.IsSkinnable && GrindingSettings.Skin) && (unit.GetSkinnableType() == Constants.SkinnableType.Skining))
            {
                Logging.Write("Skinning: " + unit.Name, new object[0]);
                if (unit.DistanceToSelf > 5.0)
                {
                    MoveHelper.MoveToLoc(unit.Location, 4.0, false, true);
                }
                KeyHelper.SendKey("TargetLastTarget");
                Thread.Sleep(0x3e8);
                if (!LazyLib.Wow.ObjectManager.MyPlayer.Target.IsValid)
                {
                    unit.Interact(false);
                }
                else
                {
                    KeyHelper.SendKey("InteractTarget");
                }
                TimeOut.Reset();
                while (!LazyLib.Wow.ObjectManager.MyPlayer.LootWinOpen && !TimeOut.IsReady)
                {
                    Thread.Sleep(100);
                }
                if (GrindingSettings.WaitForLoot)
                {
                    Latency.Sleep(500);
                }
                GrindingEngine.UpdateStats(1, 0, 0);
                PBlackList.Blacklist(unit, 300, false);
            }
        }
    }
}
