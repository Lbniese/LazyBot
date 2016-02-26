namespace LazyLib.Wow
{
    using LazyLib.Helpers;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using LazyLib.Wow;
    using LazyLib;

    public class DBC<T> : IEnumerable<T>, IEnumerable where T: struct
    {
        private readonly WoWClientDB m_dbInfo;
        private readonly DBCFile m_fileHdr;
        private readonly bool m_cacheEnabled;
        private Dictionary<int, T> m_cache;

        public DBC(IntPtr dbcBase, bool enableCache = true)
        {
            m_dbInfo = Memory.ReadRelative<WoWClientDB>(new uint[] { (uint)dbcBase });
            m_fileHdr = Memory.Read<DBCFile>(m_dbInfo.Data);
            

            if (enableCache)
            {
                m_cache = new Dictionary<int, T>();

                for (int i = MinIndex; i <= MaxIndex; ++i)
                    if (ContainsKey(i))
                        m_cache[i] = this[i];
            }

            m_cacheEnabled = enableCache;
        }

        private int CountBitsSet(int a1)
        {
            return ((0x1010101 * (((((a1 - ((a1 >> 1) & 0x55555555)) & 0x33333333) + (((a1 - ((a1 >> 1) & 0x55555555)) >> 2) & 0x33333333)) + ((((a1 - ((a1 >> 1) & 0x55555555)) & 0x33333333) + (((a1 - ((a1 >> 1) & 0x55555555)) >> 2) & 0x33333333)) >> 4)) & 0xf0f0f0f)) >> 0x18);
        }

        private int GetArrayEntryBySizeType(IntPtr arrayPtr, int index)
        {
            if (this.m_dbInfo.RowEntrySize == 2)
            {
                return Memory.Read<short>(new uint[] { (uint) (((ulong) ((int) arrayPtr)) + (ulong)(2 * index)) });
            }
            return Memory.Read<int>(new uint[] { (uint) (((ulong) ((int) arrayPtr)) + (ulong)(4 * index)) });
        }
        
        public IntPtr GetRowPtr(int index)
        {

            if ((index < this.MinIndex) || (index > this.MaxIndex))
            {
                return IntPtr.Zero;
            }
            int num = index - this.MinIndex;

            int num2 = Memory.Read<int>(new uint[] { ((uint) this.m_dbInfo.Unk1) + (uint)(4 * ((int) num >> 5)) });

            int num3 = num & ((int) 0x1fL);

            if (((((int) 1) << num3) & num2) == 0)
            {
                return IntPtr.Zero;
            }
            int arrayEntryBySizeType = (this.CountBitsSet(num2 << (0x1f - num3)) + this.GetArrayEntryBySizeType(this.m_dbInfo.Unk3, num >> 5)) - 1;

            if (this.m_dbInfo.Unk2 == 0)
            {
                arrayEntryBySizeType = this.GetArrayEntryBySizeType(this.m_dbInfo.Rows, arrayEntryBySizeType);
            }
            return (IntPtr) (((ulong) ((int) this.m_dbInfo.FirstRow)) + (ulong)(this.m_fileHdr.RecordSize * arrayEntryBySizeType));
        }

        public bool HasRow(int index)
        {
            return (this.GetRowPtr(index) != IntPtr.Zero);
        }

        public T this[int index]
        {
            get
            {
                IntPtr[] addresses = new IntPtr[] { this.GetRowPtr(index) };
                return Memory.Read<T>(addresses);
            }
        }

        public int MaxIndex
        {
            get
            {
                return this.m_dbInfo.MaxIndex;
            }
        }

        public int MinIndex
        {
            get
            {
                return this.m_dbInfo.MinIndex;
            }
        }

        public int NumRows
        {
            get
            {
                return this.m_dbInfo.NumRows;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (m_cacheEnabled)
            {
                var e = m_cache.GetEnumerator();

                while (e.MoveNext())
                    yield return e.Current.Value;
            }
            else
            {
                for (int i = 0; i < NumRows; ++i)
                yield return Memory.Read<T>(new IntPtr(m_dbInfo.FirstRow.ToInt64() + (i * m_fileHdr.RecordSize)));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool ContainsKey(int key)
        {
            return m_cacheEnabled ? m_cache.ContainsKey(key) : GetRowPtr(key) != IntPtr.Zero;
        }

        public IEnumerable<int> Keys
        {
            get
            {
                if (m_cacheEnabled)
                {
                    var e = m_cache.GetEnumerator();

                    while (e.MoveNext())
                        yield return e.Current.Key;
                }
                else
                {
                    for (int i = MinIndex; i <= MaxIndex; ++i)
                    {
                        if (ContainsKey(i))
                            yield return i;
                    }
                }
            }
        }

        /*
        [CompilerGenerated]
        private sealed class <GetEnumerator>d__0 : IEnumerator<T>, IEnumerator, IDisposable
        {
            private int <>1__state;
            private T <>2__current;
            public DBC<T> <>4__this;
            public uint <i>5__1;

            [DebuggerHidden]
            public <GetEnumerator>d__0(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }

            private bool MoveNext()
            {
                switch (this.<>1__state)
                {
                    case 0:
                        this.<>1__state = -1;
                        this.<i>5__1 = 0;
                        break;

                    case 1:
                        this.<>1__state = -1;
                        this.<i>5__1++;
                        break;

                    default:
                        goto Label_00A6;
                }
                if (this.<i>5__1 < this.<>4__this.NumRows)
                {
                    this.<>2__current = Memory.Read<T>(new uint[] { (uint) (((ulong) ((int) this.<>4__this.m_dbInfo.FirstRow)) + ((int) (this.<i>5__1 * this.<>4__this.m_fileHdr.RecordSize))) });
                    this.<>1__state = 1;
                    return true;
                }
            Label_00A6:
                return false;
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose()
            {
            }

            T IEnumerator<T>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }
         }
         */
    }
}

