using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Presentation.Core;
using Presentation.Services;

namespace Presentation.ViewModels
{
	public class ProductViewModel : ViewModel
	{
		private string? _title;
		private string? _description;
		private decimal _price;
		private string? _model;
		private uint _itemsAvailable;

		public string Title
		{
			get { return _title!; }
			set
			{
				if (_title != value)
				{
					_title = value;
					OnPropertyChange();
				}
			}
		}

		public string Description
		{
			get { return _description!; }
			set
			{
				if (_description != value)
				{
					_description = value;
					OnPropertyChange();
				}
			}
		}

		public decimal Price
		{
			get { return _price; }
			set
			{
				if (_price != value)
				{
					_price = value;
					OnPropertyChange();
				}
			}
		}

		public string Model
		{
			get { return _model ?? ""; }
			set
			{
				if (_model != value)
				{
					_model = value;
					OnPropertyChange();
				}
			}
		}

		public uint ItemsAvailable
		{
			get { return _itemsAvailable; }
			set
			{
				if (_itemsAvailable != value)
				{
					_itemsAvailable = value;
					OnPropertyChange();
				}
			}
		}
		private RelayCommand? _navigateToDetails;
		public RelayCommand? NavigateToDetails
		{
			get => _navigateToDetails;
			set
			{
				_navigateToDetails = value;
				OnPropertyChange();
			}
		}
	}
}
