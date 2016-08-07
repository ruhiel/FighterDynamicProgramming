using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public class AircraftCarrier : ICloneable
	{
		virtual public string Name { get; }

		virtual public int Slot1Num { get; }
		virtual public int Slot2Num { get; }
		virtual public int Slot3Num { get; }
		virtual public int Slot4Num { get; }

		public CarrierBasedAircraft Slot1 { get; set; }
		public CarrierBasedAircraft Slot2 { get; set; }
		public CarrierBasedAircraft Slot3 { get; set; }
		public CarrierBasedAircraft Slot4 { get; set; }
		
		// コピーコンストラクタ
		public AircraftCarrier(AircraftCarrier source)
		{
			this.Slot1 = source?.Slot1;
			this.Slot2 = source?.Slot2;
			this.Slot3 = source?.Slot3;
			this.Slot4 = source?.Slot4;
		}

		public List<CarrierBasedAircraft> Slots => new List<CarrierBasedAircraft>() { Slot1, Slot2, Slot3, Slot4 };

		public bool UniqEquipment(int count)
		{
			var list = new[] { Slot1, Slot2, Slot3, Slot4 }.Where(x => x != null);
			foreach (var groups in list.GroupBy(x => x.GetType()))
			{
				if(groups.Count() > count)
				{
					return false;
				}
			}

			return true;
		}

		public virtual bool Attackable
		{
			get
			{
				var list = new[] { Slot1, Slot2, Slot3, Slot4 };

				return list.Any(x => x is TorpedoBomber);
			}
			
		}

		public virtual object Clone()
		{
			return new AircraftCarrier(this); // コピーコンストラクタを使ってコピーを作成
		}

		public int AirSuperiorityPotential
		{
			get
			{

				var slots = new[] { Slot1Num, Slot2Num, Slot3Num, Slot4Num };
				var fighters = new[] { Slot1, Slot2, Slot3, Slot4 };

				return (int)slots.Zip(fighters, (first, second) => Tuple.Create(first, second))
					.Select(x => (x.Item2 == null ? 0.0 : x.Item2.Bonus + x.Item2.AA * Math.Sqrt(x.Item1))).Sum();
			}
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2} {3} {4}", Name, CarrierBasedAircraftToString(Slot1), CarrierBasedAircraftToString(Slot2), CarrierBasedAircraftToString(Slot3), CarrierBasedAircraftToString(Slot4));
		}

		private string CarrierBasedAircraftToString(CarrierBasedAircraft f)
		{
			return f == null ? "なし" : f.Name;
		}

		public override bool Equals(object obj)
		{
			//objがnullか、型が違うときは、等価でない
			if (obj == null || this.GetType() != obj.GetType())
			{
				return false;
			}

			var other = (AircraftCarrier)obj;

			return FighterEquals(Slot1, other.Slot1) && FighterEquals(Slot2, other.Slot2) && FighterEquals(Slot3, other.Slot3) && FighterEquals(Slot4, other.Slot4);
		}

		public override int GetHashCode()
		{
			return GetCarrierBasedAircraftCode(Slot1) ^ GetCarrierBasedAircraftCode(Slot2) ^ GetCarrierBasedAircraftCode(Slot3) ^ GetCarrierBasedAircraftCode(Slot4);
		}

		private int GetCarrierBasedAircraftCode(CarrierBasedAircraft f) => f == null ? 0 : f.GetHashCode();

		private bool FighterEquals(CarrierBasedAircraft src, CarrierBasedAircraft dest) => src == null ? dest == null : src.Equals(dest);
	}
}
