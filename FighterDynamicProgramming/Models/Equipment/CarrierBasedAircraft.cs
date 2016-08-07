using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public abstract class CarrierBasedAircraft
	{
		public virtual int AA { get; }
		public virtual string Name { get; }
		public virtual int Bonus { get; }
		public virtual bool Attackable { get; }
	}
}
