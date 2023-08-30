using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator.Attributes
{
	public abstract class Attribute : IAttribute
	{
		public string Name { get; protected set; }

		protected int? m_Value;
		public int? Value
		{
			get => m_Value;
			set => m_Value = value;
		}
		public bool IsSet { get => m_Value != null; }

		public Dictionary<ERace, int> MinValue { get; protected set; } = new Dictionary<ERace, int>();

		public Dictionary<ERace, int> MaxValue { get; protected set; } = new Dictionary<ERace, int>();

		public abstract void CalculateValue(Character character, List<int> diceRolls);
	}
}
