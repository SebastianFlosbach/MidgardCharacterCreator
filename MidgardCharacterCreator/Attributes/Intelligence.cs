using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Intelligence : Attribute
	{
		public Intelligence()
		{
			Name = "Intelligence";

			MinValue.Add(ERace.Elf, 51);
		}

		public override void CalculateValue(Character character, List<int> diceRolls)
		{
			if (diceRolls.Count() < 1)
				throw new ArgumentException($"Invalid number of dice rolls provided for attribute {Name}. {diceRolls.Count()} were provided, 1 needed.");

			m_Value = diceRolls[0];

			if (MinValue.TryGetValue(character.Race, out int min))
				if (m_Value < min)
					m_Value = MinValue[character.Race];

			if (MaxValue.TryGetValue(character.Race, out int max))
				if (m_Value > max)
					m_Value = max;
		}
	}
}
