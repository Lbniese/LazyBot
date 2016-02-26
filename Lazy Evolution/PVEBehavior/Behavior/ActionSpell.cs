using LazyLib.ActionBar;
using LazyLib.Helpers;
using System.Xml;

namespace LazyEvo.PVEBehavior.Behavior
{
    internal class ActionSpell : Action
    {
        private bool Exist;
        private string _name;
        private BarSpell _spell;
        private bool chek;

        public override bool DoesKeyExist
        {
            get
            {
                if (!this.chek)
                {
                    this.chek = true;
                    this.Exist = BarMapper.HasSpellByName(this._name);
                }
                return this.Exist;
            }
        }

        public override string Name
        {
            get
            {
                return this._name;
            }
        }

        public override bool IsReady
        {
            get
            {
                return BarMapper.IsSpellReadyByName(this._name);
            }
        }

        public ActionSpell()
        {
        }

        public ActionSpell(string name)
        {
            this._name = name;
        }

        public override void Execute(int globalcooldown)
        {
            if (!this.DoesKeyExist)
                return;
            if (!KeyHelper.HasKey(this._name))
                this._spell = (BarSpell)null;
            if (this._spell == null)
            {
                this._spell = BarMapper.GetSpellByName(this._name);
                this._spell.SetCooldown(globalcooldown);
                KeyHelper.AddKey(this._name, "", this._spell.Bar.ToString(), this._spell.Key.ToString());
            }
            this._spell.CastSpell();
        }

        public override string GetXml()
        {
            return "<Type>ActionSpell</Type>" + "<Name>" + this._name + "</Name>";
        }

        public override void Load(XmlNode node)
        {
            foreach (XmlNode xmlNode in node)
            {
                if (xmlNode.Name.Equals("Name"))
                    this._name = xmlNode.InnerText;
            }
        }
    }
}
/*
#region

using System.Xml;
using LazyLib.ActionBar;
using LazyLib.Helpers;

#endregion

namespace LazyEvo.PVEBehavior.Behavior
{
    internal class ActionSpell : Action
    {
        private bool Exist;
        private string _name;
        private BarSpell _spell;
        private bool chek;

        public ActionSpell()
        {
        }

        public ActionSpell(string name)
        {
            _name = name;
        }

        public override bool DoesKeyExist
        {
            get
            {
                if (!chek)
                {
                    chek = true;
                    Exist = BarMapper.HasSpellByName(_name);
                }
                return Exist;
            }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override bool IsReady
        {
            get { return BarMapper.IsSpellReadyByName(_name); }
        }

        public override void Execute(int globalcooldown)
        {
            if (DoesKeyExist)
            {
                if (!KeyHelper.HasKey(_name))
                    _spell = null;
                //Load the spell and set the global cooldown
                if (_spell == null)
                {
                    _spell = BarMapper.GetSpellByName(_name);
                    _spell.SetCooldown(globalcooldown);
                    KeyHelper.AddKey(_name, "", _spell.Bar.ToString(), _spell.Key.ToString());
                }

                _spell.CastSpell();
            }
        }

        public override string GetXml()
        {
            string xml = "<Type>ActionSpell</Type>";
            xml += "<Name>" + _name + "</Name>";
            return xml;
        }

        public override void Load(XmlNode node)
        {
            foreach (XmlNode xmlNode in node)
            {
                if (xmlNode.Name.Equals("Name"))
                {
                    _name = xmlNode.InnerText;
                }
            }
        }
    }
}
*/