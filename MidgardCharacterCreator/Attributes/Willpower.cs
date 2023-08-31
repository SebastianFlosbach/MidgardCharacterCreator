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
			int constitution;
			int intelligence;

			constitution = character.Constitution.IsSet
				? (int)character.Constitution.Value
                : throw new ArgumentException($"Missing value for attribute {character.Constitution.Name} in character to calculate {Name}.");

			intelligence = character.Intelligence.IsSet
				? (int)character.Intelligence.Value
                : throw new ArgumentException($"Missing value for attribute {character.Intelligence.Name} in character to calculate {Name}.");

			// W% + 2x(Ko/10 + In/10) - 20
			m_Value = Dice.RollW100() + (2 * (constitution / 10 + intelligence / 10)) - 20;

			if (MinValue.TryGetValue(character.Race, out int min))
				if (m_Value < min)
					m_Value = MinValue[character.Race];

			if (MaxValue.TryGetValue(character.Race, out int max))
				if (m_Value > max)
					m_Value = max;
		}
	}
}
