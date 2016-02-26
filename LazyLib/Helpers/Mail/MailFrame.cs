namespace LazyLib.Helpers.Mail
{
    using LazyLib.Helpers;
    using System;
    using System.Threading;

    internal class MailFrame
    {
        public static void ClickInboxTab()
        {
            try
            {
                InterfaceHelper.GetFrameByName("MailFrameTab1").LeftClick();
            }
            catch
            {
            }
        }

        public static void ClickMailFrame()
        {
            try
            {
                InterfaceHelper.GetFrameByName("MailFrame").LeftClick();
            }
            catch
            {
            }
        }

        public static void ClickSend()
        {
            try
            {
                ClickMailFrame();
                Thread.Sleep(0x4b0);
                InterfaceHelper.GetFrameByName("SendMailMailButton").LeftClick();
            }
            catch
            {
            }
        }

        public static void ClickSendHooked()
        {
            try
            {
                InterfaceHelper.GetFrameByName("SendMailMailButton").LeftClickHooked();
            }
            catch
            {
            }
        }

        public static void ClickSendMailTab()
        {
            try
            {
                InterfaceHelper.GetFrameByName("MailFrameTab2").LeftClick();
            }
            catch
            {
            }
        }

        public static void ClickSendMailTabHooked()
        {
            try
            {
                InterfaceHelper.GetFrameByName("MailFrameTab2").LeftClickHooked();
            }
            catch
            {
            }
        }

        public static void Close()
        {
            try
            {
                while (Open)
                {
                    InterfaceHelper.GetFrameByName("InboxCloseButton").LeftClick();
                    Thread.Sleep(250);
                }
            }
            catch
            {
            }
        }

        public static void SetMailBody(string body)
        {
            Frame frameByName = InterfaceHelper.GetFrameByName("SendMailBodyEditBox");
            if (frameByName != null)
            {
                frameByName.SetEditBoxText(body);
            }
        }

        public static void SetMailModeCod()
        {
            try
            {
                InterfaceHelper.GetFrameByName("SendMailCODButton").LeftClick();
            }
            catch
            {
            }
        }

        public static void SetMailModeSendMoney()
        {
            try
            {
                InterfaceHelper.GetFrameByName("SendMailSendMoneyButton").LeftClick();
            }
            catch
            {
            }
        }

        public static void SetMailSubject(string subject)
        {
            Frame frameByName = InterfaceHelper.GetFrameByName("SendMailSubjectEditBox");
            if (frameByName != null)
            {
                frameByName.SetEditBoxText(subject);
            }
        }

        public static void SetReceiver(string receiver)
        {
            Frame frameByName = InterfaceHelper.GetFrameByName("SendMailNameEditBox");
            if (frameByName != null)
            {
                frameByName.SetEditBoxText(receiver);
            }
        }

        public static void SetReceiverHooked(string receiver)
        {
            Frame frameByName = InterfaceHelper.GetFrameByName("SendMailNameEditBox");
            if (frameByName != null)
            {
                frameByName.SetEditBoxTextHooked(receiver);
            }
        }

        public static bool CurrentTabIsInbox
        {
            get
            {
                try
                {
                    return InterfaceHelper.GetFrameByName("InboxPrevPageButton").IsVisible;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool CurrentTabIsSendMail
        {
            get
            {
                try
                {
                    return InterfaceHelper.GetFrameByName("SendMailAttachment1").IsVisible;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static string GetMailSubject
        {
            get
            {
                try
                {
                    return InterfaceHelper.GetFrameByName("SendMailSubjectEditBox").GetEditBoxText;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static string GetReciver
        {
            get
            {
                try
                {
                    return InterfaceHelper.GetFrameByName("SendMailNameEditBox").GetEditBoxText;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static bool Open
        {
            get
            {
                try
                {
                    return InterfaceHelper.GetFrameByName("MailFrame").IsVisible;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}

