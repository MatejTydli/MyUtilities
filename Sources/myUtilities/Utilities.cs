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

		public static T Shift<T>(ref IEnumerable<T> collection)
		{
			T firstItem = collection.First();
			collection = collection.Skip(1);
			return firstItem;
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
