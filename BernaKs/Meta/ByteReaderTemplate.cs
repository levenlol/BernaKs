
using System;
using System.Collections.Generic;

public static class BytesReader
{
	public static Dictionary<IntPtr, List<Int32>> GetAsInt32(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.Int32>> outdictionary = new Dictionary<IntPtr, List<System.Int32>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.Int32> l = new List<System.Int32>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                Int32 val = BitConverter.ToInt32(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<UInt32>> GetAsUInt32(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.UInt32>> outdictionary = new Dictionary<IntPtr, List<System.UInt32>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.UInt32> l = new List<System.UInt32>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                UInt32 val = BitConverter.ToUInt32(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<Int64>> GetAsInt64(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.Int64>> outdictionary = new Dictionary<IntPtr, List<System.Int64>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.Int64> l = new List<System.Int64>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                Int64 val = BitConverter.ToInt64(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<UInt64>> GetAsUInt64(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.UInt64>> outdictionary = new Dictionary<IntPtr, List<System.UInt64>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.UInt64> l = new List<System.UInt64>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                UInt64 val = BitConverter.ToUInt64(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<Int16>> GetAsInt16(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.Int16>> outdictionary = new Dictionary<IntPtr, List<System.Int16>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.Int16> l = new List<System.Int16>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                Int16 val = BitConverter.ToInt16(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<UInt16>> GetAsUInt16(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.UInt16>> outdictionary = new Dictionary<IntPtr, List<System.UInt16>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.UInt16> l = new List<System.UInt16>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                UInt16 val = BitConverter.ToUInt16(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<Single>> GetAsSingle(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.Single>> outdictionary = new Dictionary<IntPtr, List<System.Single>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.Single> l = new List<System.Single>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                Single val = BitConverter.ToSingle(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<Double>> GetAsDouble(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.Double>> outdictionary = new Dictionary<IntPtr, List<System.Double>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.Double> l = new List<System.Double>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                Double val = BitConverter.ToDouble(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<Boolean>> GetAsBoolean(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.Boolean>> outdictionary = new Dictionary<IntPtr, List<System.Boolean>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.Boolean> l = new List<System.Boolean>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                Boolean val = BitConverter.ToBoolean(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	public static Dictionary<IntPtr, List<String>> GetAsString(BMemory memory)
	{
		int dataSize = 4;
        Dictionary<IntPtr, byte[]> dictionary;

        bool bResult = memory.ReadMemory(out dictionary);

        Dictionary<IntPtr, List<System.String>> outdictionary = new Dictionary<IntPtr, List<System.String>>();

        foreach (IntPtr key in dictionary.Keys)
        {
            byte[] b = dictionary[key];
			List<System.String> l = new List<System.String>();

            for (int i = 0; i < b.Length; i += dataSize)
            {
                String val = BitConverter.ToString(b, i);
                l.Add(val);
            }

			outdictionary.Add(key, l);
         }

		 return outdictionary;
	}

	}

