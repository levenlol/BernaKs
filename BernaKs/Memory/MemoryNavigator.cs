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
            BuildDataAsInt();
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

        public List<IntPtr> GetAddressOfValue(int value)
        {
            List<IntPtr> ptrsList = new List<IntPtr>();

            foreach(IntPtr p in m_MemoryDictionary_int.Keys)
            {
                foreach(int v in m_MemoryDictionary_int[p])
                {
                    if(v == value)
                    {
                        ptrsList.Add(new IntPtr(p.ToInt64())); // #note just working on x64 for now.
                    }
                }
            }

            return ptrsList;
        }
    }
}
