using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Strength : Attribute
	{
		public Strength()
		{
			Name = "Strength";

			MinValue.Add(ERace.Dwarf, 61);

			MaxValue.Add(ERace.Elf, 90);
			MaxValue.Add(ERace.Gnome, 60);
			MaxValue.Add(ERace.Halfling, 80);
		}

		public override void CalculateValue(Character character, List<int> diceRolls)
		{


			if (MinValue.TryGetValue(character.Race, out int min))
				if (m_Value < min)
					m_Value = MinValue[character.Race];

			if (MaxValue.TryGetValue(character.Race, out int max))
				if (m_Value > max)
					m_Value = max;
		}
	}
}
