using FighterDynamicProgramming.Models;
using FighterDynamicProgramming.Models.Ships;
using Livet;
using Livet.EventListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		private Calculator calculator;

		public MainWindowViewModel()
		{
			calculator = new Calculator();

			CompositeDisposable.Add(new PropertyChangedEventListener(calculator)
			{
				{nameof(Calculator.AircraftCarrierListList), (sender, e) => Update() },
			});
		}

		#region Ship1
		private ShipViewModel _Ship1;
		public ShipViewModel Ship1
		{
			get
			{
				return _Ship1;
			}
			set
			{
				_Ship1 = value;
				calculator.Ship1 = _Ship1.CA.GetType();
			}
		}
		#endregion

		#region Ship2
		private ShipViewModel _Ship2;
		public ShipViewModel Ship2
		{
			get
			{
				return _Ship2;
			}
			set
			{
				_Ship2 = value;
				calculator.Ship2 = _Ship2.CA.GetType();
			}
		}
		#endregion

		#region Ship3
		private ShipViewModel _Ship3;
		public ShipViewModel Ship3
		{
			get
			{
				return _Ship3;
			}
			set
			{
				_Ship3 = value;
				calculator.Ship3 = _Ship3.CA.GetType();
			}
		}
		#endregion

		#region Ship4
		private ShipViewModel _Ship4;
		public ShipViewModel Ship4
		{
			get
			{
				return _Ship4;
			}
			set
			{
				_Ship4 = value;
				calculator.Ship4 = _Ship4.CA.GetType();
			}
		}
		#endregion

		#region Ship5
		private ShipViewModel _Ship5;
		public ShipViewModel Ship5
		{
			get
			{
				return _Ship5;
			}
			set
			{
				_Ship5 = value;
				calculator.Ship5 = _Ship5.CA.GetType();
			}
		}
		#endregion

		#region Ship6
		private ShipViewModel _Ship6;
		public ShipViewModel Ship6
		{
			get
			{
				return _Ship6;
			}
			set
			{
				_Ship6 = value;
				calculator.Ship6 = _Ship6.CA.GetType();
			}
		}
		#endregion

		private List<AircraftCarrierListViewModel> _AircraftCarrierListList;

		public List<AircraftCarrierListViewModel> AircraftCarrierListList => _AircraftCarrierListList;

		public void Update()
		{
			_AircraftCarrierListList = new List<AircraftCarrierListViewModel>();
			foreach (var list in calculator.AircraftCarrierListList)
			{
				_AircraftCarrierListList.Add(new AircraftCarrierListViewModel(list.Text));
			}

			RaisePropertyChanged(nameof(AircraftCarrierListList));
		}

		public List<ShipViewModel> ShipSelect => new List<ShipViewModel>()
		{
			new ShipViewModel(new AircraftCarrier(null)),
			new ShipViewModel(new AkagiKai()),
			new ShipViewModel(new KagaKai()),
			new ShipViewModel(new HiryuKai2()),
			new ShipViewModel(new ShokakuKai2()),
			new ShipViewModel(new ZuikakuKai2()),
			new ShipViewModel(new TaihouKai()),
		};
	}
}
