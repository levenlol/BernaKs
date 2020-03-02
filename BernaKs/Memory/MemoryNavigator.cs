using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #todo just debug purpose for now.

namespace BernaKs.Memory
{
    class MemoryNavigator
    {
        private Dictionary<IntPtr, byte[]> m_MemoryDictionary;

        private Dictionary<IntPtr, int[]> m_MemoryDictionary_int;


        public MemoryNavigator(Dictionary<IntPtr, byte[]> memoryDictionary)
        {
            m_MemoryDictionary = memoryDictionary;
            //BuildDataAsInt();
        }

        public Dictionary<IntPtr, int[]> BuildDataAsInt()
        {
            if (m_MemoryDictionary_int == null)
            {
                m_MemoryDictionary_int = new Dictionary<IntPtr, int[]>();
            }

            int size = sizeof(int);

            foreach (IntPtr ptr in m_MemoryDictionary.Keys)
            {
                byte[] bytes = m_MemoryDictionary[ptr];
                int[] vals = new int[bytes.Length / size];

                for (int i = 0; i < vals.Length; i++)
                {
                    vals[i] = BitConverter.ToInt32(bytes, i * size);
                }

                m_MemoryDictionary_int.Add(ptr, vals);
            }

            return m_MemoryDictionary_int;
        }

        public List<IntPtr> GetAddressOfValue(byte[] data)
        {
            List<IntPtr> ptrsList = new List<IntPtr>();
            int size = data.Length;

            foreach(IntPtr p in m_MemoryDictionary.Keys)
            {
                int length = m_MemoryDictionary[p].Length;
                for (int i = 0; i < length / size; i++)
                {
                    byte[] currentChunk = new byte[size];
                    Array.Copy(m_MemoryDictionary[p], i * size, currentChunk, 0, size);

                    if (data.SequenceEqual(currentChunk))
                    {
                        ptrsList.Add(new IntPtr(p.ToInt64() + (long)i * size));
                    }
                }
            }

            return ptrsList;
        }
    }
}
