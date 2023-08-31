using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Charisma : Attribute
	{
		public Charisma()
		{
			Name = "Charisma";
		}

		public override void CalculateValue(Character character, List<int> diceRolls)
		{
			int intelligence;

			if (character.Intelligence.IsSet)
				intelligence = (int)character.Intelligence.Value;
			else
				throw new ArgumentException($"Missing value for attribute {character.Intelligence.Name} in character to calculate {Name}.");

			// W% + 2xIn/10 - 20
			m_Value = Dice.RollW100() + (4 * intelligence / 10) - 20;

			if (MinValue.TryGetValue(character.Race, out int min))
				if (m_Value < min)
					m_Value = MinValue[character.Race];

			if (MaxValue.TryGetValue(character.Race, out int max))
				if (m_Value > max)
					m_Value = max;
		}
	}
}
