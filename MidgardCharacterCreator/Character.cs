using MidgardCharacterCreator.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardCharacterCreator
{
	public class Character
	{
		public string Name { get; set; }

		public string PlayerName { get; set; }

		public ERace Race { get; set; }

		public EAdventurer Adventurer { get; set; }

		public EGender Gender { get; set; }

		private readonly Life m_Life = new Life();
		public IAttribute Life { get => m_Life; }
		public int CurrentLife { get; set; }

		private readonly Endurance m_Endurance = new Endurance();
		public IAttribute Endurance { get => m_Endurance; }
		public int CurrentEndurance { get; set; }

		public int Range { get; set; }

		public int DamageBonus { get; set; }
		public int DefenderBonus { get; set; }
		public int MagicBonus { get; set; }
		public int Resitance { get; set; }

		#region Base Abilities

		private readonly Strength m_Strength = new Strength();
		public IAttribute Strength { get => m_Strength; }

		/// <summary>
		/// Geschicklichkeit
		/// </summary>
		private readonly Dexterity m_Dexterity = new Dexterity();
		public IAttribute Dexterity { get => m_Dexterity; }

		/// <summary>
		/// Gewandheit
		/// </summary>
		private readonly Agility m_Agility = new Agility();
		public IAttribute Agility { get => m_Agility; }

		private readonly Constitution m_Constitution = new Constitution();
		public IAttribute Constitution { get => m_Constitution; }

		private readonly Intelligence m_Intelligence = new Intelligence();
		public IAttribute Intelligence { get => m_Intelligence; }

		private readonly MagicSkill m_MagicSkill = new MagicSkill();
		public IAttribute MagicSkill { get => m_MagicSkill; }

		#endregion

		private readonly Charisma m_Charisma = new Charisma();
		public IAttribute Charisma { get => m_Charisma; }

		private readonly Willpower m_Willpower = new Willpower();
		public IAttribute Willpower { get => m_Willpower; }

		private readonly Appeareance m_Appeareance = new Appeareance();
		public IAttribute Appearance { get => m_Appeareance; }
	}
}
