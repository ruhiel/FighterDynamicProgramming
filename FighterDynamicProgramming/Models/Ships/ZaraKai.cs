using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public class ZaraKai : AirCraftCruiser
	{
		public override string Name => "Zara改";

		override public int Slot1Num { get { return 2; } }
		override public int Slot2Num { get { return 2; } }
		override public int Slot3Num { get { return 2; } }
		override public int Slot4Num { get { return 2; } }

		public ZaraKai() : base(null)
		{

		}

		public ZaraKai(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new ZaraKai(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
