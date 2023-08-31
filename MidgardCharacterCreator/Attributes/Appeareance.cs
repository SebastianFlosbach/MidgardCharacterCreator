using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Appeareance : Attribute
	{
		public Appeareance()
		{
			Name = "Appearance";

			MinValue.Add(ERace.Elf, 81);

			MaxValue.Add(ERace.Gnome, 80);
			MaxValue.Add(ERace.Dwarf, 80);
		}

		public override void CalculateValue(Character character, List<int> diceRolls)
		{
			m_Value = Dice.RollW100();

			if (MinValue.TryGetValue(character.Race, out int min))
				if (m_Value < min)
					m_Value = MinValue[character.Race];

			if (MaxValue.TryGetValue(character.Race, out int max))
				if (m_Value > max)
					m_Value = max;
		}

	}
}
