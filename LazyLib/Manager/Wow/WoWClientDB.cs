namespace LazyLib.Wow
{
    using System;
    using System.Runtime.InteropServices;
#pragma warning disable 649
    [StructLayout(LayoutKind.Sequential)]
    struct WoWClientDB
    {
        public IntPtr VTable;

        public int NumRows;

        public int MaxIndex;

        public int MinIndex;

        public uint Unk4bytes;

        public IntPtr Data;

        public IntPtr FirstRow;

        public IntPtr Rows;

        public IntPtr Unk1;

        public uint Unk2;

        public IntPtr Unk3;

        public uint RowEntrySize;
    };
#pragma warning restore 649
}