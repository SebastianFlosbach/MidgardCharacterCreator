using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using MidgardCharacterCreator;

namespace MidgardCharacterCreatorPresentation.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private RelayCommand m_RollDiceCommand;

		public ICommand RollDiceCommand
		{
			get
			{
				if(m_RollDiceCommand == null)
				{
					m_RollDiceCommand = new RelayCommand(() =>
					{
						m_CharacterCreator.RollDice();
						OnPropertyChanged("DiceRolls");
					});
				}
				return m_RollDiceCommand;
			}
		}

		private RelayCommand m_CalculateMovement;
		public ICommand CalculateMovement
		{
			get
			{
				if (m_CalculateMovement == null)
				{
					m_CalculateMovement = new RelayCommand(() =>
					{
						m_CharacterCreator.Character.Movement.CalculateValue(m_CharacterCreator.Character, null);
						OnPropertyChanged("MovementValue");
					});
				}
				return m_CalculateMovement;
			}
		}

		private RelayCommand m_CalculateAppereance;
		public ICommand CalculateAppereance
		{
			get
			{
				if (m_CalculateAppereance == null)
				{
					m_CalculateAppereance = new RelayCommand(() =>
					{
						m_CharacterCreator.Character.Appearance.CalculateValue(m_CharacterCreator.Character, null);
						OnPropertyChanged("AppereanceValue");
					});
				}
				return m_CalculateAppereance;
			}
		}

		private RelayCommand m_CalculateCharisma;
		public ICommand CalculateCharisma
		{
			get
			{
				if (m_CalculateCharisma == null)
				{
					m_CalculateCharisma = new RelayCommand(() =>
					{
						m_CharacterCreator.Character.Charisma.CalculateValue(m_CharacterCreator.Character, null);
						OnPropertyChanged("CharismaValue");
					});
				}
				return m_CalculateCharisma;
			}
		}

		private RelayCommand m_CalculateWillpower;
		public ICommand CalculateWillpower
		{
			get
			{
				if (m_CalculateWillpower == null)
				{
					m_CalculateWillpower = new RelayCommand(() =>
					{
						m_CharacterCreator.Character.Willpower.CalculateValue(m_CharacterCreator.Character, null);
						OnPropertyChanged("WillpowerValue");
					});
				}
				return m_CalculateWillpower;
			}
		}

		public bool CalculateMovementEnabled => true;
		public bool CalculateAppereanceEnabled => true;
		public bool CalculateCharismaEnabled => IntelligenceValue != null;
		public bool CalculateWillpowerEnabled => ConstitutionValue != null && IntelligenceValue != null;

		private CharacterCreator m_CharacterCreator = new CharacterCreator();


		public ObservableCollection<int> DiceRolls => new ObservableCollection<int>(m_CharacterCreator.AvailableDice);

		#region Attributes

		public int? StrengthValue
		{
			get => m_CharacterCreator.Character.Strength.Value;
			set
			{
				m_CharacterCreator.Character.Strength.Value = value;
				OnPropertyChanged();
			}
		}
		public int? AgilityValue
		{
			get => m_CharacterCreator.Character.Agility.Value;
			set
			{
				m_CharacterCreator.Character.Agility.Value = value;
				OnPropertyChanged();
			}
		}
		public int? AppereanceValue
		{
			get => m_CharacterCreator.Character.Appearance.Value;
			set
			{
				m_CharacterCreator.Character.Appearance.Value = value;
				OnPropertyChanged();
			}
		}
		public int? CharismaValue
		{
			get => m_CharacterCreator.Character.Charisma.Value;
			set
			{
				m_CharacterCreator.Character.Charisma.Value = value;
				OnPropertyChanged();
			}
		}
		public int? ConstitutionValue
		{
			get => m_CharacterCreator.Character.Constitution.Value;
			set
			{
				m_CharacterCreator.Character.Constitution.Value = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(CalculateWillpowerEnabled));
			}
		}
		public int? DexterityValue
		{
			get => m_CharacterCreator.Character.Dexterity.Value;
			set
			{
				m_CharacterCreator.Character.Dexterity.Value = value;
				OnPropertyChanged();
			}
		}
		public int? EnduranceValue
		{
			get => m_CharacterCreator.Character.Endurance.Value;
			set
			{
				m_CharacterCreator.Character.Endurance.Value = value;
				OnPropertyChanged();
			}
		}
		public int? IntelligenceValue
		{
			get => m_CharacterCreator.Character.Intelligence.Value;
			set
			{
				m_CharacterCreator.Character.Intelligence.Value = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(CalculateCharismaEnabled));
				OnPropertyChanged(nameof(CalculateWillpowerEnabled));
			}
		}
		public int? LifeValue
		{
			get => m_CharacterCreator.Character.Life.Value;
			set
			{
				m_CharacterCreator.Character.Life.Value = value;
				OnPropertyChanged();
			}
		}
		public int? MagicSkillValue
		{
			get => m_CharacterCreator.Character.MagicSkill.Value;
			set
			{
				m_CharacterCreator.Character.MagicSkill.Value = value;
				OnPropertyChanged();
			}
		}
		public int? WillpowerValue
		{
			get => m_CharacterCreator.Character.Willpower.Value;
			set
			{
				m_CharacterCreator.Character.Willpower.Value = value;
				OnPropertyChanged();
			}
		}
		public int? MovementValue
		{
			get => m_CharacterCreator.Character.Movement.Value;
			set
			{
				m_CharacterCreator.Character.Movement.Value = value;
				OnPropertyChanged();
			}
		}

		#endregion

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
