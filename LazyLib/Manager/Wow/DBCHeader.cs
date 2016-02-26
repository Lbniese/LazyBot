

namespace LazyLib.Wow
{
    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Sequential)]
    struct DBCFile
    {
        public uint Magic;
        public int RecordsCount;
        public int FieldsCount;
        public int RecordSize;
        public int StringTableSize;
    }
}