using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Willpower : Attribute
	{
		public Willpower()
		{
			Name = "Willpower";
		}

		public override void CalculateValue(Character character, List<int> diceRolls)
		{
			if (diceRolls.Count() < 1)
				throw new ArgumentException($"Invalid number of dice rolls provided for attribute {Name}. {diceRolls.Count()} were provided, 1 needed.");

			int constitution;
			int intelligence;

			if (character.Constitution.IsSet)
				constitution = (int)character.Constitution.Value;
			else
				throw new ArgumentException($"Missing value for attribute {character.Constitution.Name} in character to calculate {Name}.");

			if (character.Intelligence.IsSet)
				intelligence = (int)character.Intelligence.Value;
			else
				throw new ArgumentException($"Missing value for attribute {character.Intelligence.Name} in character to calculate {Name}.");

			// W% + 2x(Ko/10 + In/10) - 20
			m_Value = diceRolls[0] + 4 * (constitution / 10 + intelligence / 10) - 20;

			if (MinValue.TryGetValue(character.Race, out int min))
				if (m_Value < min)
					m_Value = MinValue[character.Race];

			if (MaxValue.TryGetValue(character.Race, out int max))
				if (m_Value > max)
					m_Value = max;
		}
	}
}
