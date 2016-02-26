namespace LazyLib.Helpers.Vendor
{
    using LazyLib;
    using LazyLib.Helpers;
    using LazyLib.Helpers.Mail;
    using LazyLib.Wow;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;

    [Obfuscation(Feature="renaming", ApplyToMembers=true)]
    public class VendorManager
    {
        private static readonly List<string> Sold = new List<string>();

        public static  event EventHandler SellFinished;

        public static void DoSell(PUnit vendor)
        {
            try
            {
                ProtectedList.Load();
                MailList.Load();
                MoveHelper.MoveToUnit(vendor, 3.0);
                vendor.Location.Face();
                int num = 1;
            Label_0027:
                vendor.Interact(false);
                Thread.Sleep(0x3e8);
                if (InterfaceHelper.GetFrameByName("GossipFrameCloseButton").IsVisible)
                {
                    if (InterfaceHelper.GetFrameByName("GossipTitleButton" + num).IsVisible)
                    {
                        Thread.Sleep(0x5dc);
                        InterfaceHelper.GetFrameByName("GossipTitleButton" + num).LeftClick();
                        Thread.Sleep(0x5dc);
                        if (InterfaceHelper.GetFrameByName("MerchantFrame").IsVisible || (num >= 6))
                        {
                            goto Label_00D2;
                        }
                        KeyHelper.SendKey("ESC");
                        num++;
                    }
                    else
                    {
                        KeyHelper.SendKey("ESC");
                        num++;
                    }
                    goto Label_0027;
                }
            Label_00D2:
                if (LazyLib.Wow.ObjectManager.MyPlayer.Target != vendor)
                {
                    vendor.Location.Face();
                    vendor.Interact(false);
                    Thread.Sleep(0x3e8);
                }
                MouseHelper.Hook();
                MailManager.OpenAllBags();
                if (LazySettings.ShouldVendor)
                {
                    Logging.Write("[Vendor]Going to sell items", new object[0]);
                    Sell();
                }
                if (LazySettings.ShouldRepair)
                {
                    Repair();
                }
            }
            finally
            {
                MailManager.CloseAllBags();
                MouseHelper.ReleaseMouse();
                if (SellFinished != null)
                {
                    SellFinished("VendorEngine", new EventArgs());
                }
            }
        }

        public static void DoSell(string unit_name)
        {
            try
            {
                ProtectedList.Load();
                MailList.Load();
                KeyHelper.ChatboxSendText("/target " + unit_name);
                Thread.Sleep(0xbb8);
                if (LazyLib.Wow.ObjectManager.MyPlayer.Target.Name != unit_name)
                {
                    Logging.Write("Could not target vendor: " + unit_name, new object[0]);
                }
                else
                {
                    KeyHelper.SendKey("InteractTarget");
                    MouseHelper.Hook();
                    MailManager.OpenAllBags();
                    if (LazySettings.ShouldVendor)
                    {
                        Logging.Write("[Vendor]Going to sell items", new object[0]);
                        Sell();
                    }
                    if (LazySettings.ShouldRepair)
                    {
                        Repair();
                    }
                }
            }
            finally
            {
                MailManager.CloseAllBags();
                MouseHelper.ReleaseMouse();
                if (SellFinished != null)
                {
                    SellFinished("VendorEngine", new EventArgs());
                }
            }
        }

        private static int GetSlotCount(int item)
        {
            try
            {
                if (item == 1)
                {
                    return 0x10;
                }
                if (item == 2)
                {
                    return Inventory.Bag1.Slots;
                }
                if (item == 3)
                {
                    return Inventory.Bag2.Slots;
                }
                if (item == 4)
                {
                    return Inventory.Bag3.Slots;
                }
                if (item == 5)
                {
                    return Inventory.Bag4.Slots;
                }
            }
            catch
            {
            }
            return 0;
        }

        private static void LoadWowHead()
        {
            foreach (PItem item in Inventory.GetItemsInBags)
            {
                if (ItemDatabase.GetItem(item.EntryId.ToString()) == null)
                {
                    Dictionary<string, string> wowHeadItem = WowHeadData.GetWowHeadItem((double) item.EntryId);
                    if (wowHeadItem != null)
                    {
                        string str = wowHeadItem["name"];
                        string str2 = wowHeadItem["quality"];
                        if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(str2))
                        {
                            ItemDatabase.PutItem(item.EntryId.ToString(), str, str2);
                        }
                    }
                }
            }
        }

        private static void Repair()
        {
            Frame frameByName = InterfaceHelper.GetFrameByName("MerchantRepairAllButton");
            if (frameByName != null)
            {
                frameByName.LeftClick();
            }
        }

        private static void Sell()
        {
            Sold.Clear();
            LoadWowHead();
            SellLoop();
        }

        private static void SellLoop()
        {
            int item = 1;
            int num2 = 1;
            while (item != 6)
            {
                if (InterfaceHelper.GetFrameByName("ContainerFrame" + item) != null)
                {
                    int slotCount = GetSlotCount(item);
                    Logging.Write("Found ContainerFrame with Slot count: " + slotCount, new object[0]);
                    while (num2 != (slotCount + 1))
                    {
                        Frame frameByName = InterfaceHelper.GetFrameByName(string.Concat(new object[] { "ContainerFrame", item, "Item", num2 }));
                        if (frameByName != null)
                        {
                            frameByName.HoverHooked();
                            Thread.Sleep(170);
                            try
                            {
                                Frame frame3 = InterfaceHelper.GetFrameByName("GameTooltip");
                                if (frame3 != null)
                                {
                                    Frame childObject = frame3.GetChildObject("GameTooltipTextLeft1");
                                    if ((childObject != null) && ShouldSell(childObject.GetText))
                                    {
                                        Logging.Write("Selling: " + childObject.GetText, new object[0]);
                                        Thread.Sleep(150);
                                        frameByName.RightClickHooked();
                                        Thread.Sleep(150);
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                Logging.Write("Exception when pasing gametooltip: " + exception, new object[0]);
                            }
                        }
                        num2++;
                    }
                    if (num2 == (slotCount + 1))
                    {
                        num2 = 1;
                        item++;
                    }
                }
                else
                {
                    item++;
                }
            }
        }

        private static bool ShouldSell(string sellName)
        {
            try
            {
                foreach (PItem item in Inventory.GetItemsInBags)
                {
                    try
                    {
                        string str3;
                        if (ItemDatabase.GetItem(item.EntryId.ToString()) == null)
                        {
                            continue;
                        }
                        string str = ItemDatabase.GetItem(item.EntryId.ToString())["item_name"].ToString();
                        string str2 = ItemDatabase.GetItem(item.EntryId.ToString())["item_quality"].ToString();
                        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str2))
                        {
                            goto Label_0185;
                        }
                        if ((((str != sellName) && (sellName.Replace(str, "").Length == sellName.Length)) || MailList.ShouldMail(str)) || (!ProtectedList.ShouldVendor(str) || ((str3 = str2) == null)))
                        {
                            continue;
                        }
                        if (!(str3 == "Poor"))
                        {
                            if (str3 == "Common")
                            {
                                goto Label_013D;
                            }
                            if (str3 == "UnCommon")
                            {
                                goto Label_014C;
                            }
                            if (str3 == "Низкий")
                            {
                                goto Label_015B;
                            }
                            if (str3 == "Обычный")
                            {
                                goto Label_016A;
                            }
                            if (str3 == "Необычный")
                            {
                                goto Label_0179;
                            }
                            continue;
                        }
                        if (!LazySettings.SellPoor)
                        {
                            continue;
                        }
                        return true;
                    Label_013D:
                        if (!LazySettings.SellCommon)
                        {
                            continue;
                        }
                        return true;
                    Label_014C:
                        if (!LazySettings.SellUncommon)
                        {
                            continue;
                        }
                        return true;
                    Label_015B:
                        if (!LazySettings.SellPoor)
                        {
                            continue;
                        }
                        return true;
                    Label_016A:
                        if (!LazySettings.SellCommon)
                        {
                            continue;
                        }
                        return true;
                    Label_0179:
                        if (!LazySettings.SellUncommon)
                        {
                            continue;
                        }
                        return true;
                    Label_0185:
                        Logging.Write(string.Format("[Vendor]Could not detect the name of: {0} is wowhead down?", item.EntryId), new object[0]);
                    }
                    catch (Exception exception)
                    {
                        Logging.Debug("Exception in ShouldSell (Loop): {0}", new object[] { exception });
                    }
                }
            }
            catch (Exception exception2)
            {
                Logging.Debug("Exception in ShouldSell: {0}", new object[] { exception2 });
            }
            return false;
        }
    }
}

