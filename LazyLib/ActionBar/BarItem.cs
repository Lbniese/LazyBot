// Type: LazyLib.ActionBar.BarItem
// Assembly: LazyLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A92FE1A9-C28E-4E6F-9BAC-5C48387A25CC
// Assembly location: E:\VeryOldLazyBots\Lazy Evolution\LazyLib.dll

using LazyLib.Helpers;
using System.Reflection;

namespace LazyLib.ActionBar
{
    [Obfuscation(ApplyToMembers = true, Feature = "renaming")]
    public class BarItem
    {
        private readonly KeyWrapper _wrap;

        public int ItemId { get; private set; }

        public int Bar { get; set; }

        public int Key { get; set; }

        public BarItem(int id, int bar, int key)
        {
            this.ItemId = id;
            this.Bar = bar;
            this.Key = key;
            this._wrap = new KeyWrapper("Unkown item", "none", bar.ToString(), key.ToString());
        }

        public void SendItem()
        {
            this._wrap.SendKey();
        }
    }
}
