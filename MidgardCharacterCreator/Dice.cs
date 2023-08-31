using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator
{
	public enum EDice
	{
		W100,
		W6,
		W3
	}

	public static class Dice
	{
		private static readonly Random m_Random = new Random();

		public static List<int> RollDice(EDice diceType, int amount)
		{
			List<int> rolls = new List<int>();

			for (int i = 0; i < amount; i++)
			{
				switch (diceType)
				{
					case EDice.W100:
						rolls.Add(RollW100());
						break;
					case EDice.W6:
						break;
					case EDice.W3:
						rolls.Add(RollW3());
						break;
					default:
						break;
				}
			}

			return rolls;
		}

		public static int RollW100() => m_Random.Next(1, 101);
		public static int RollW3() => m_Random.Next(1, 4);
	}
}
