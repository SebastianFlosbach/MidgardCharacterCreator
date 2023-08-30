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

		private CharacterCreator m_CharacterCreator = new CharacterCreator();

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

		#endregion

		protected void OnPropertyChanged([CallerMemberName] string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
