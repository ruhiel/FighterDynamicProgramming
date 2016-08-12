using FighterDynamicProgramming.Models.Ships;
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

		public string Text => string.Join(",", this.Select(x => x.ToString()));

		public int AttackableNum() => this.Sum(x => x.Slots.Count(y => y != null && y.Attackable));

		public bool CheckLimit(Dictionary<Type, int> limits)
		{
			var list = this.SelectMany(x => x.Slots);

			foreach (var limit in limits)
			{
				if (list.Count(x => x?.GetType() == limit.Key) > limit.Value)
				{
					return false;
				}
			}

			return true;
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
