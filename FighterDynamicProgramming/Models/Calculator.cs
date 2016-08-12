using FighterDynamicProgramming.Models.Equipment;
using FighterDynamicProgramming.Models.Ships;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public class Calculator : NotificationObject
	{
		/// <summary>
		/// 装備数制限
		/// </summary>
		private Dictionary<Type, int> _EquipLimit;

		/// <summary>
		/// 艦戦以外を積んでいいスロット最低数
		/// </summary>
		private int _MinimumLimit = 10;

		private List<AircraftCarrierList> _AircraftCarrierListList;

		public List<AircraftCarrierList> AircraftCarrierListList => _AircraftCarrierListList;

		public void Update()
		{
			_EquipLimit = new Dictionary<Type, int>();

			_EquipLimit.Add(typeof(ReppuuKai), 1);

			_EquipLimit.Add(typeof(Reppuu601AirGroup), 2);

			_EquipLimit.Add(typeof(Type0FighterModel62FighterBomber), 0);

			_EquipLimit.Add(typeof(ShindenKai), 0);

			var kanmusu = new[] { Ship1, Ship2, Ship3, Ship4, Ship5, Ship6 };

			var targetList = kanmusu.Where(x => x != null && !x.Equals(typeof(AircraftCarrier))).ToArray();

			var result = GetList(targetList);

			Console.WriteLine("パターン数:" + result.Count);

			var list = result.Where(x => x.CheckLimit(_EquipLimit) && x.Attackable && x.AirSuperiorityPotential >= 355);
			if(list.Any())
			{
				var min = list.Min(y => y.AirSuperiorityPotential);
				_AircraftCarrierListList = result.Where(x => x.CheckLimit(_EquipLimit) && x.Attackable && x.AirSuperiorityPotential == min).ToList();
			}
			else
			{
				_AircraftCarrierListList = new List<AircraftCarrierList>();
			}
			
			RaisePropertyChanged(nameof(AircraftCarrierListList));
		}

		private List<AircraftCarrierList> GetList(Type[] types)
		{
			if (types.Count() == 1)
			{
				return GetList1(types[0]);
			}
			else if (types.Count() == 2)
			{
				return GetList2(types[0], types[1]);
			}
			else if (types.Count() == 3)
			{
				return GetList3(types[0], types[1], types[2]);
			}
			else if (types.Count() == 4)
			{
				return GetList4(types[0], types[1], types[2], types[3]);
			}
			else if (types.Count() == 5)
			{
				return GetList5(types[0], types[1], types[2], types[3], types[4]);
			}
			else
			{
				return GetList6(types[0], types[1], types[2], types[3], types[4], types[5]);
			}
		}

		private List<AircraftCarrierList> GetList1(Type type1)
		{
			var list = new List<AircraftCarrierList>();

			foreach (var first in GetList(type1))
			{
				var temp = new AircraftCarrierList();
				temp.Add((AircraftCarrier)first.Clone());
				list.Add(temp);
			}
			return list;
		}

		private List<AircraftCarrierList> GetList2(Type type1, Type type2)
		{
			var list = new List<AircraftCarrierList>();

			foreach (var first in GetList(type1))
			{
				foreach (var second in GetList(type2))
				{
					var temp = new AircraftCarrierList();
					temp.Add((AircraftCarrier)first.Clone());
					temp.Add((AircraftCarrier)second.Clone());
					list.Add(temp);
				}
			}
			return list;
		}

		private List<AircraftCarrierList> GetList3(Type type1, Type type2, Type type3)
		{
			var list = new List<AircraftCarrierList>();

			foreach (var first in GetList(type1))
			{
				foreach (var second in GetList(type2))
				{
					foreach (var third in GetList(type3))
					{
						var temp = new AircraftCarrierList();
						temp.Add((AircraftCarrier)first.Clone());
						temp.Add((AircraftCarrier)second.Clone());
						temp.Add((AircraftCarrier)third.Clone());
						list.Add(temp);
					}
				}
			}
			return list;
		}

		private List<AircraftCarrierList> GetList4(Type type1, Type type2, Type type3, Type type4)
		{
			var list = new List<AircraftCarrierList>();

			foreach (var first in GetList(type1))
			{
				foreach (var second in GetList(type2))
				{
					foreach (var third in GetList(type3))
					{
						foreach (var forth in GetList(type4))
						{
							var temp = new AircraftCarrierList();
							temp.Add((AircraftCarrier)first.Clone());
							temp.Add((AircraftCarrier)second.Clone());
							temp.Add((AircraftCarrier)third.Clone());
							temp.Add((AircraftCarrier)forth.Clone());
							list.Add(temp);
						}

					}
				}
			}
			return list;
		}

		private List<AircraftCarrierList> GetList5(Type type1, Type type2, Type type3, Type type4, Type type5)
		{
			var list = new List<AircraftCarrierList>();

			foreach (var first in GetList(type1))
			{
				foreach (var second in GetList(type2))
				{
					foreach (var third in GetList(type3))
					{
						foreach (var forth in GetList(type4))
						{
							foreach (var fifth in GetList(type5))
							{
								var temp = new AircraftCarrierList();
								temp.Add((AircraftCarrier)first.Clone());
								temp.Add((AircraftCarrier)second.Clone());
								temp.Add((AircraftCarrier)third.Clone());
								temp.Add((AircraftCarrier)forth.Clone());
								temp.Add((AircraftCarrier)fifth.Clone());
								list.Add(temp);
							}
						}

					}
				}
			}
			return list;
		}

		private List<AircraftCarrierList> GetList6(Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
		{
			var list = new List<AircraftCarrierList>();

			foreach (var first in GetList(type1))
			{
				foreach (var second in GetList(type2))
				{
					foreach (var third in GetList(type3))
					{
						foreach (var forth in GetList(type4))
						{
							foreach (var fifth in GetList(type5))
							{
								foreach (var sixth in GetList(type6))
								{
									var temp = new AircraftCarrierList();
									temp.Add((AircraftCarrier)first.Clone());
									temp.Add((AircraftCarrier)second.Clone());
									temp.Add((AircraftCarrier)third.Clone());
									temp.Add((AircraftCarrier)forth.Clone());
									temp.Add((AircraftCarrier)fifth.Clone());
									temp.Add((AircraftCarrier)sixth.Clone());
									list.Add(temp);
								}
							}
						}
					}
				}
			}
			return list;
		}

		private IEnumerable<AircraftCarrier> GetList(Type type)
		{
			Type[] aircraft;
			if (type.IsSubclassOf(typeof(AirCraftCruiser)))
			{
				aircraft = new Type[] { null, typeof(Ro44SeaplaneFighter) };
			}
			else
			{
				aircraft = new Type[] { typeof(Type0FighterModel62FighterBomber), typeof(Type97TorpedoBomberTomonagaSquadron), typeof(Reppuu), typeof(ReppuuKai), typeof(Reppuu601AirGroup), typeof(ShindenKai) };
			}

			List<AircraftCarrier> carrierList = new List<AircraftCarrier>();

			foreach (var type1 in aircraft)
			{
				if (!type.IsSubclassOf(typeof(AirCraftCruiser)) && type1 != null && type1.IsSubclassOf(typeof(Fighter)))
				{
					// 空母の第一スロットに艦戦を積ませない
					continue;
				}

				foreach (var type2 in aircraft)
				{
					foreach (var type3 in aircraft)
					{
						foreach (var type4 in aircraft)
						{
							CarrierBasedAircraft f1 = type1 == null ? null : (CarrierBasedAircraft)Activator.CreateInstance(type1);
							CarrierBasedAircraft f2 = type2 == null ? null : (CarrierBasedAircraft)Activator.CreateInstance(type2);
							CarrierBasedAircraft f3 = type3 == null ? null : (CarrierBasedAircraft)Activator.CreateInstance(type3);
							CarrierBasedAircraft f4 = type4 == null ? null : (CarrierBasedAircraft)Activator.CreateInstance(type4);


							AircraftCarrier aircraftCarrier = (AircraftCarrier)Activator.CreateInstance(type);

							if (LimitCheck(f1, f2, f3, f4) && MinimumCheck(aircraftCarrier, f1, f2, f3, f4))
							{
								aircraftCarrier.Slot1 = f1;
								aircraftCarrier.Slot2 = f2;
								aircraftCarrier.Slot3 = f3;
								aircraftCarrier.Slot4 = f4;
								carrierList.Add(aircraftCarrier);
							}
						}
					}
				}
			}

			if (type.IsSubclassOf(typeof(AirCraftCruiser)))
			{
				// イタリア重巡に同じ装備を複数させない
				carrierList = carrierList.Where(x => x.UniqEquipment(1)).ToList();
			}

			foreach (var airSuperiorityPotential in carrierList.Select(x => x.AirSuperiorityPotential).Distinct())
			{
				yield return carrierList.Where(x => x.AirSuperiorityPotential == airSuperiorityPotential).First();
			}
		}

		private bool LimitCheck(CarrierBasedAircraft f1, CarrierBasedAircraft f2, CarrierBasedAircraft f3, CarrierBasedAircraft f4)
		{
			var list = new[] { f1, f2, f3, f4 };

			foreach (var limit in _EquipLimit)
			{
				if (list.Count(x => x?.GetType() == limit.Key) > limit.Value)
				{
					return false;
				}
			}

			return true;
		}

		private bool MinimumCheck(AircraftCarrier aircraftCarrier, CarrierBasedAircraft f1, CarrierBasedAircraft f2, CarrierBasedAircraft f3, CarrierBasedAircraft f4)
		{
			if (f1 != null && !f1.GetType().IsSubclassOf(typeof(Fighter)) && _MinimumLimit > aircraftCarrier.Slot1Num)
			{
				return false;
			}
			else if (f2 != null && !f2.GetType().IsSubclassOf(typeof(Fighter)) && _MinimumLimit > aircraftCarrier.Slot2Num)
			{
				return false;
			}
			else if (f3 != null && !f3.GetType().IsSubclassOf(typeof(Fighter)) && _MinimumLimit > aircraftCarrier.Slot3Num)
			{
				return false;
			}
			else if (f4 != null && !f4.GetType().IsSubclassOf(typeof(Fighter)) && _MinimumLimit > aircraftCarrier.Slot4Num)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		private Type _Ship1;
		public Type Ship1
		{
			get
			{
				return _Ship1;
			}
			set
			{
				_Ship1 = value;
				Update();
			}
		}

		private Type _Ship2;
		public Type Ship2
		{
			get
			{
				return _Ship2;
			}
			set
			{
				_Ship2 = value;
				Update();
			}
		}
		private Type _Ship3;
		public Type Ship3
		{
			get
			{
				return _Ship3;
			}
			set
			{
				_Ship3 = value;
				Update();
			}
		}
		private Type _Ship4;
		public Type Ship4
		{
			get
			{
				return _Ship4;
			}
			set
			{
				_Ship4 = value;
				Update();
			}
		}
		private Type _Ship5;
		public Type Ship5
		{
			get
			{
				return _Ship5;
			}
			set
			{
				_Ship5 = value;
				Update();
			}
		}
		private Type _Ship6;
		public Type Ship6
		{
			get
			{
				return _Ship6;
			}
			set
			{
				_Ship6 = value;
				Update();
			}
		}
	}
}
