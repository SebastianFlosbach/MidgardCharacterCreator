using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Endurance : Attribute
	{
		public Endurance()
		{
			Name = "Endurance";
		}

		public override void CalculateValue(Character character, List<int> diceRolls)
		{
			if (diceRolls.Count() < 1)
				throw new ArgumentException($"Invalid number of dice rolls provided for attribute {Name}. {diceRolls.Count()} were provided, 1 needed.");

			int constitution;
			int strength;

			if (character.Constitution.IsSet)
				constitution = (int)character.Constitution.Value;
			else
				throw new ArgumentException($"Missing value for attribute {character.Constitution.Name} in character to calculate {Name}.");

			if (character.Strength.IsSet)
				strength = (int)character.Strength.Value;
			else
				throw new ArgumentException($"Missing value for attribute {character.Strength.Name} in character to calculate {Name}.");

			// 1W3 + 1 + Ko/10 + St/20
			m_Value = diceRolls[0] + 1 + constitution / 10 + strength / 20;

			switch (character.Adventurer)
			{
				case EAdventurer.Assassin:
					m_Value += 1;
					break;
				case EAdventurer.Barbarian:
					m_Value += 2;
					break;
				case EAdventurer.Venturer:
					m_Value += 1;
					break;
				case EAdventurer.Trader:
					m_Value += 1;
					break;
				case EAdventurer.Warrior:
					m_Value += 2;
					break;
				case EAdventurer.Thief:
					m_Value += 1;
					break;
				case EAdventurer.Ranger:
					m_Value += 2;
					break;
				case EAdventurer.Schaman:
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
