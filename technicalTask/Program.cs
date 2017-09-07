using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace technicalTask
{
	class Program
	{
		static void Main(string[] args)
		{
			var separators = new char[]{ ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '@', '#', '%', '\'', '/',
						'$', '&', '*', ';', ':', '.', ',', '-', '_', '^', '(', ')', '[', ']', '{', '}', '/', '?', '\n', '\t', '\r' };
			var wordsStat = new Dictionary<string, int>();

			Console.WriteLine("Enter file path:");
			string curFile = Console.ReadLine();
			//string curFile = "D:\\TestFile.txt";
			if (!File.Exists(curFile))
			{
				Console.WriteLine();
				Console.WriteLine(string.Format("File '{0}' is absent in the specified directory", curFile));
				Console.ReadKey();
				return;
			}

			Console.WriteLine();
			Console.WriteLine("Your file exist in the specified directory");
			try
			{
				using (var streamReader = new StreamReader(curFile))
				{
					string inputLine;
					// To optimize the use of memory, we are reading file line by line
					while (!streamReader.EndOfStream)
					{
						inputLine = streamReader.ReadLine();
						var words = inputLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);

						foreach (string word in words)
						{
							if (wordsStat.ContainsKey(word))
							{
								wordsStat[word]++;
							}
							else
							{
								wordsStat[word] = 1;
							}
						}
					}
				}
				int num = 0;
				Console.WriteLine("#\tWord\t\tCount");
				foreach (var wordsNumber in wordsStat.OrderByDescending(ws => ws.Value))
				{
					Console.WriteLine(string.Format("{0}\t{1}\t\t{2}", num, wordsNumber.Key, wordsNumber.Value));
					num++;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("The programm failed with an error.");
				Console.WriteLine(ex.ToString());
			}

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}
	}
}
