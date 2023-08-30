using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public interface IAttribute
	{
		string Name { get; }

		int? Value { get; set; }

		bool IsSet { get; }

		Dictionary<ERace, int> MinValue { get; }

		Dictionary<ERace, int> MaxValue { get; }

		void CalculateValue(Character character, List<int> diceRolls);
	}
}
