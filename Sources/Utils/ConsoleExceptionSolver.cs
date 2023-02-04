using System;

namespace Utils
{
	public static class ConsoleExceptionSolver
	{
		public delegate void DelegConsoleProgram();
		private static bool nextWhile;
		private static string wantNextWhile;
		private static string wantClearConsole;

		public static void ConsoleExceptionSolverCZ(DelegConsoleProgram delegConsoleProgram)
		{
			nextWhile = false;
			wantNextWhile = "ne";
			wantClearConsole = "ano";

			do
			{
				try
				{
					delegConsoleProgram();
				}
				catch (Exception e)
				{
					Console.WriteLine("\nDoslo k neocekavane vyjimce a spadnuti programu, muze byt zpusobeno spatne zadanym vstupem.");
					Console.WriteLine("Chybova hlazka (nekdy v anglictine): " + e.Message);
				}
				finally
				{
					finallyCZ();
				}
			} while (nextWhile);
		}

		private static void finallyCZ()
		{
			try
			{
				Console.Write("\nChcete provest dalsi vypocet? (ano/ne): ");
				wantNextWhile = Console.ReadLine().ToLower();

				if (wantNextWhile == "ano" || wantNextWhile == "a")
				{
					nextWhile = true;
					Console.Write("Chcete vymazat vsechen text na konzoli? (ano/ne): ");
					wantClearConsole = Console.ReadLine().ToLower();

					if (wantClearConsole == "ano" || wantClearConsole == "a") Console.Clear();
					else if (wantClearConsole == "ne" || wantClearConsole == "n") Console.WriteLine();
					else throw new Exception("Spatne zadany vztup.");
				}
				else if (wantNextWhile == "ne" || wantNextWhile == "n") nextWhile = false;
				else throw new Exception("Spatne zadany vztup.");
			}
			catch (Exception e)
			{
				Console.WriteLine("\nDoslo k neocekavane vyjimce a spadnuti programu, muze byt zpusobeno spatne zadanym vstupem.");
				Console.WriteLine("Chybova hlazka (nekdy v anglictine): " + e.Message);
				finallyCZ();
			}
		}

		public static void ConsoleExceptionSolverEN(DelegConsoleProgram delegConsoleProgram)
		{
			nextWhile = false;
			wantNextWhile = "no";
			wantClearConsole = "yes";

			do
			{
				try
				{
					delegConsoleProgram();
				}
				catch (Exception e)
				{
					Console.WriteLine("\nAn unexpected exception occurred and the program crashed, which may have been caused by an incorrectly entered input.");
					Console.WriteLine("Exception message: " + e.Message);
				}
				finally
				{
					finallyEN();
				}
			} while (nextWhile);
		}

		private static void finallyEN()
		{
			try
			{
				Console.Write("\nWant another calculation? (yes/no): ");
				wantNextWhile = Console.ReadLine().ToLower();

				if (wantNextWhile == "yes" || wantNextWhile == "y")
				{
					nextWhile = true;
					Console.Write("Want clear the console? (yes/no): ");
					wantClearConsole = Console.ReadLine().ToLower();

					if (wantClearConsole == "yes" || wantClearConsole == "y") Console.Clear();
					else if (wantClearConsole == "n" || wantClearConsole == "no") Console.WriteLine();
					else throw new Exception("incorrectly entered input.");
				}
				else if (wantNextWhile == "n" || wantNextWhile == "no") nextWhile = false;
				else throw new Exception("Incorrectly entered input");
			}
			catch (Exception e)
			{
				Console.WriteLine("\nAn unexpected exception occurred and the program crashed, which may have been caused by an incorrectly entered input.");
				Console.WriteLine("Exception message: " + e.Message);
				finallyCZ();
			}
		}
	}
}