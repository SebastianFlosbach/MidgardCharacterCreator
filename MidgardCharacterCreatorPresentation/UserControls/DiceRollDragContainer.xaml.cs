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

namespace MidgardCharacterCreatorPresentation.UserControls
{
	/// <summary>
	/// Interaction logic for DiceRollDragContainer.xaml
	/// </summary>
	public partial class DiceRollDragContainer : UserControl
	{
		public static readonly DependencyProperty AttributeValueProperty = DependencyProperty.Register("AttributeValue", typeof(int?), typeof(DiceRollDragContainer));

		public DiceRollDragContainer()
		{
			InitializeComponent();
		}

		public DiceRollDragContainer(DiceRollDragContainer other)
		{
			InitializeComponent();
			AttributeValue = other.AttributeValue;
		}

		public int? AttributeValue
		{
			get { return (int?)GetValue(AttributeValueProperty); }
			set { SetValue(AttributeValueProperty, value); }
		}

		protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			//call the base
			base.OnPreviewMouseLeftButtonDown(e);

			if (AttributeValue == null)
				return;

			// Package the data.
			DataObject data = new DataObject();
			data.SetData("int", this.DataContext);
			data.SetData("Object", this);

			// Initiate the drag-and-drop operation.
			DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
		}

		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);

			if (e.Data.GetDataPresent("Object"))
			{
				e.Effects = DragDropEffects.Move;
			}
		}

		protected override void OnDrop(DragEventArgs e)
		{
			base.OnDrop(e);

			// If an element in the panel has already handled the drop,
			// the panel should not also handle it.
			if (e.Handled)
				return;

			DiceRollDragContainer _element = (DiceRollDragContainer)e.Data.GetData("Object");

			if (_element == null)
				return;

			DependencyObject _source = VisualTreeHelper.GetParent(_element);
			while (_source != null && !(_source is ItemsControl))
			{
				_source = VisualTreeHelper.GetParent(_source);
			}

			int value = (int)_element.AttributeValue;

			if (_source == null)
			{
				_element.AttributeValue = this.AttributeValue;
			}
			else
			{
				var _sourceCollection = (ObservableCollection<int>)((ItemsControl)_source).ItemsSource;
				_sourceCollection.Remove(value);
				if (this.AttributeValue != null)
				{
					_sourceCollection.Add((int)this.AttributeValue);
				}
			}

			AttributeValue = value;

			// Set the value to return to the DoDragDrop call
			e.Effects = DragDropEffects.Move;
		}
	}
}
