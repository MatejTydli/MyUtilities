using System.Collections.Generic;
using System.Linq;

namespace Utils.Console
{
	public static class ConsoleUtils
	{
		public static void WriteCollection<T>(this IEnumerable<T> collection)
		{
			foreach (T item in collection)
			{
				if (collection.Last().Equals(item)) System.Console.Write(item);
				else System.Console.Write(item + ", ");
			}
		}

		public static void WriteLinesCollection<T>(this IEnumerable<T> collection)
		{
			foreach (T item in collection) System.Console.WriteLine(item);
		}
	}
}