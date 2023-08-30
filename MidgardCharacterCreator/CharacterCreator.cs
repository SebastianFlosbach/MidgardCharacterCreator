using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator
{
	public class CharacterCreator
	{
		private static readonly int NEEDED_DICE_AMOUNT = 6;

		public Character Character { get; set; } = new Character();

		public List<int> AvailableDice { get; set; } = new List<int>();

		public CharacterCreator()
		{

		}

		public void RollDice()
		{
			List<int> diceRolls = Dice.RollDice(EDice.W100, NEEDED_DICE_AMOUNT + 3);

			diceRolls.Sort();

			AvailableDice = diceRolls;
		}
	}
}
