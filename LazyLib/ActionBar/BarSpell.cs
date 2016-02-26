// Type: LazyLib.ActionBar.BarSpell
// Assembly: LazyLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A92FE1A9-C28E-4E6F-9BAC-5C48387A25CC
// Assembly location: E:\VeryOldLazyBots\Lazy Evolution\LazyLib.dll

using LazyLib.Helpers;
using LazyLib.Wow;
using System.Reflection;
using System.Threading;

namespace LazyLib.ActionBar
{
    [Obfuscation(ApplyToMembers = true, Feature = "renaming")]
    public class BarSpell
    {
        private Ticker _globalCooldown;

        public int SpellId { get; private set; }

        public int Bar { get; set; }

        public int Key { get; set; }

        public string Name { get; private set; }

        public int Cooldown { get; private set; }

        public bool DoesKeyExist
        {
            get
            {
                return BarMapper.HasSpellByName(this.Name);
            }
        }

        public bool IsReady
        {
            get
            {
                return BarMapper.IsSpellReadyById(this.SpellId);
            }
        }

        public BarSpell(int id, int bar, int key, string name)
        {
            this.SpellId = id;
            this.Bar = bar;
            this._globalCooldown = new Ticker(1600.0);
            this.Key = key;
            this.Name = name;
            KeyHelper.AddKey(name, "", this.Bar.ToString(), this.Key.ToString());
        }

        public void SetCooldown(int cooldown)
        {
            this._globalCooldown = new Ticker((double)cooldown);
            this.Cooldown = cooldown;
        }

        public void CastSpell()
        {
            KeyHelper.SendKey(this.Name);
            this._globalCooldown.Reset();
            while (ObjectManager.MyPlayer.IsCasting || !this._globalCooldown.IsReady)
                Thread.Sleep(10);
        }
    }
}
