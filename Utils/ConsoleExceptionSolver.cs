using System;

namespace Utils.Console
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
					System.Console.WriteLine("\nDoslo k neocekavane vyjimce a spadnuti programu, muze byt zpusobeno spatne zadanym vstupem.");
					System.Console.WriteLine("Chybova hlazka (nekdy v anglictine): " + e.Message);
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
				System.Console.Write("\nChcete provest dalsi vypocet? (ano/ne): ");
				wantNextWhile = System.Console.ReadLine().ToLower();

				if (wantNextWhile == "ano" || wantNextWhile == "a")
				{
					nextWhile = true;
					System.Console.Write("Chcete vymazat vsechen text na konzoli? (ano/ne): ");
					wantClearConsole = System.Console.ReadLine().ToLower();

					if (wantClearConsole == "ano" || wantClearConsole == "a") System.Console.Clear();
					else if (wantClearConsole == "ne" || wantClearConsole == "n") System.Console.WriteLine();
					else throw new Exception("Spatne zadany vztup.");
				}
				else if (wantNextWhile == "ne" || wantNextWhile == "n") nextWhile = false;
				else throw new Exception("Spatne zadany vztup.");
			}
			catch (Exception e)
			{
				System.Console.WriteLine("\nDoslo k neocekavane vyjimce a spadnuti programu, muze byt zpusobeno spatne zadanym vstupem.");
				System.Console.WriteLine("Chybova hlazka (nekdy v anglictine): " + e.Message);
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
					System.Console.WriteLine("\nAn unexpected exception occurred and the program crashed, which may have been caused by an incorrectly entered input.");
					System.Console.WriteLine("Exception message: " + e.Message);
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
				System.Console.Write("\nWant another calculation? (yes/no): ");
				wantNextWhile = System.Console.ReadLine().ToLower();

				if (wantNextWhile == "yes" || wantNextWhile == "y")
				{
					nextWhile = true;
					System.Console.Write("Want clear the console? (yes/no): ");
					wantClearConsole = System.Console.ReadLine().ToLower();

					if (wantClearConsole == "yes" || wantClearConsole == "y") System.Console.Clear();
					else if (wantClearConsole == "n" || wantClearConsole == "no") System.Console.WriteLine();
					else throw new Exception("incorrectly entered input.");
				}
				else if (wantNextWhile == "n" || wantNextWhile == "no") nextWhile = false;
				else throw new Exception("Incorrectly entered input");
			}
			catch (Exception e)
			{
				System.Console.WriteLine("\nAn unexpected exception occurred and the program crashed, which may have been caused by an incorrectly entered input.");
				System.Console.WriteLine("Exception message: " + e.Message);
				finallyCZ();
			}
		}
	}
}