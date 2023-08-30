using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Logging
{
	public static class StaticLogger
	{
		private static ILogger m_Logger = new ConsoleLogger();

		public static void Log(string message) => m_Logger.Log(message);
	}
}
