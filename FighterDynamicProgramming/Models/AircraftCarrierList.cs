using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public class AircraftCarrierList : List<AircraftCarrier>
	{
		public int AirSuperiorityPotential => this.Sum(x => x.AirSuperiorityPotential);

		public bool Attackable => this.All(x => x.Attackable);

		public override string ToString()
		{
			return string.Join(",", this.Select(x => x.ToString()));
		}

		public override bool Equals(object obj)
		{
			//objがnullか、型が違うときは、等価でない
			if (obj == null || this.GetType() != obj.GetType())
			{
				return false;
			}

			var other = (AircraftCarrierList)obj;

			if(Count != other.Count)
			{
				return false;
			}

			for (int i = 0; i < other.Count; i++)
			{
				if(!this[i].Equals(other[i]))
				{
					return false;
				}
			}

			return true;
		}

		public override int GetHashCode()
		{
			if(!this.Any())
			{
				return 0;
			}

			int? code = null;

			for (int i = 0; i < Count; i++)
			{
				if(code == null)
				{
					code = this[i].GetHashCode();
				}
				else
				{
					code ^= this[i].GetHashCode();
				}
			}

			return code.Value;
		}
	}
}
