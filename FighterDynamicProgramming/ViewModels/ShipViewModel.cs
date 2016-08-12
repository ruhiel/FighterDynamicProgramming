using FighterDynamicProgramming.Models;
using FighterDynamicProgramming.Models.Ships;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.ViewModels
{
	public class ShipViewModel : ViewModel
	{
		public AircraftCarrier CA { get; set; }
		public ShipViewModel(AircraftCarrier ca)
		{
			CA = ca;
		}
	}
}
