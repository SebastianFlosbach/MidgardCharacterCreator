using MidgardCharacterCreatorPresentation.UserControls;
using MidgardCharacterCreatorPresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MidgardCharacterCreatorPresentation
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new MainWindowViewModel();
		}

		private void diceRollList_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("Object"))
			{
				e.Effects = DragDropEffects.Move;
			}
		}

		private void diceRollList_Drop(object sender, DragEventArgs e)
		{
			base.OnDrop(e);

			if (e.Handled)
				return;

			ItemsControl _target = (ItemsControl)sender;
			DiceRollDragContainer _element = (DiceRollDragContainer)e.Data.GetData("Object");

			if (_element == null)
				return;

			((ObservableCollection<int>)_target.ItemsSource).Add((int)_element.AttributeValue);
			_element.AttributeValue = null;

			// Set the value to return to the DoDragDrop call
			e.Effects = DragDropEffects.Move;
		}
	}
}
