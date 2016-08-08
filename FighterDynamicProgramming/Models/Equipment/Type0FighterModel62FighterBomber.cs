using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Equipment
{
	public class Type0FighterModel62FighterBomber : CarrierBasedAircraft
	{
		public override int AA { get { return 4; } }

		public override string Name => "零式艦戦62型(爆戦)";
	}
}
