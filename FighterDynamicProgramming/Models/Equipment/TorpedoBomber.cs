using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public abstract class TorpedoBomber : CarrierBasedAircraft
	{
		public override int Bonus { get { return 3; } }
		public override bool Attackable => true;
	}
}
