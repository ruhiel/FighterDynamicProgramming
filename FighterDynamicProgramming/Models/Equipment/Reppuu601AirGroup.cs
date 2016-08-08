using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Equipment
{
	public class Reppuu601AirGroup : Fighter
	{
		public override int AA { get { return 11; } }

		public override string Name => "烈風(六〇一空)";
	}
}
