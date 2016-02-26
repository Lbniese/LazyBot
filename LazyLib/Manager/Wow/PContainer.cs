// Type: LazyLib.Wow.PContainer
// Assembly: LazyLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A92FE1A9-C28E-4E6F-9BAC-5C48387A25CC
// Assembly location: E:\VeryOldLazyBots\Lazy Evolution\LazyLib.dll

using System.Reflection;

namespace LazyLib.Wow
{
    [Obfuscation(ApplyToMembers = true, Feature = "renaming")]
    public class PContainer : PObject
    {
        public int Slots
        {
            get
            {
                return this.GetStorageField<int>(141);
            }
        }

        public PContainer(uint baseAddress)
            : base(baseAddress)
        {
        }

        public int _Slots(uint i)
        {
            return this.GetStorageField<int>(i);
        }
    }
}
