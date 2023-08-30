using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Life : Attribute
	{
		public Life()
		{
			Name = "Life";
		}

		public override void CalculateValue(Character character, List<int> diceRolls)
		{
			if (diceRolls.Count() < 1)
				throw new ArgumentException($"Invalid number of dice rolls provided for attribute {Name}. {diceRolls.Count()} were provided, 1 needed.");

			int constitution;

			if (character.Constitution.IsSet)
				constitution = (int)character.Constitution.Value;
			else
				throw new ArgumentException($"Missing value for attribute {character.Constitution.Name} in character to calculate {Name}.");

			// 1W3 + 7 + Ko/10
			m_Value = diceRolls[0] + 7 + constitution / 10;

			switch (character.Race)
			{
				case ERace.Gnome:
					m_Value -= 3;
					break;
				case ERace.Halfling:
					m_Value -= 2;
					break;
				case ERace.Dwarf:
					m_Value += 1;
					break;
				default:
					break;
			}

			if (MinValue.TryGetValue(character.Race, out int min))
				if (m_Value < min)
					m_Value = MinValue[character.Race];

			if (MaxValue.TryGetValue(character.Race, out int max))
				if (m_Value > max)
					m_Value = max;
		}
	}
}
