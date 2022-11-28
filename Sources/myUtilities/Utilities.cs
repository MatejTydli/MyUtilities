using System;
using System.Collections.Generic;
using System.Linq;

namespace myUtilities
{
	public static class Utilities
	{
		public static bool FindIndexOfItem<T>(this IEnumerable<T> collection, T itemToFind, out int index)
		{
			if (collection.Contains(itemToFind))
			{
				int i = -1;
				foreach (T item in collection)
				{
					i++;
					if (item.Equals(itemToFind))
					{
						index = i;
						return true;
					}
				}
			}

			index = -1;
			return false;
		}

		public static T Shift<T>(ref T[] array)
		{
			if (array.Length == 0 || array == null)
			{
				throw new Exception("array can not be shifted");
			}

			T item = array[0];

			if (array.Length == 1)
			{
				array = new T[] { };
				return item;
			}

			T[] shiftedArray = new T[array.Length - 1];
			for (int i = 1; i < array.Length; i++)
			{
				shiftedArray[i - 1] = array[i];
			}
			array = shiftedArray;

			return item;
		}

		public static void WriteCollection<T>(this IEnumerable<T> collection)
		{
			foreach (T item in collection)
			{
				if (collection.Last().Equals(item))
				{
					Console.Write(item);
				}
				else
				{
					Console.Write(item + ", ");
				}
			}
		}

		public static void WriteLinesCollection<T>(this IEnumerable<T> collection)
		{
			foreach (T item in collection)
			{
				Console.WriteLine(item);
			}
		}
	}
}
