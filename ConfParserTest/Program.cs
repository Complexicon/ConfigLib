using ConfLib;
using System;

namespace ConfParserTest {
	class Program {
		static void Main(string[] args) {

			Config c = new Config("test.txt");

			foreach(string key in c.cfgDict.Keys) {
				Console.WriteLine("Key: " + key);
				Console.WriteLine("String " + c.GetStr(key));
				Console.WriteLine("Int " + c.GetInt(key));
				Console.WriteLine("Bool " + c.GetBool(key));
				Console.WriteLine("Float " + c.GetFloat(key));
				Console.WriteLine("Double " + c.GetDouble(key));
				Console.WriteLine("");
			}

			Console.WriteLine(c.SaveConfig());

			Console.ReadLine();
		}
	}
}
