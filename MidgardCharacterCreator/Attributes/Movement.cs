using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public class Movement : Attribute
	{
		public override void CalculateValue(Character character, List<int> diceRolls)
		{
			switch (character.Race)
			{
				case ERace.Gnome:
					Value = Dice.RollDice(EDice.W3, 2).Sum() + 8;
					break;
				case ERace.Halfling:
					Value = Dice.RollDice(EDice.W3, 2).Sum() + 8;
					break;
				case ERace.Dwarf:
					Value = Dice.RollDice(EDice.W3, 3).Sum() + 12;
					break;
				default:
					Value = Dice.RollDice(EDice.W3, 4).Sum() + 16;
					break;
			}
		}
	}
}
