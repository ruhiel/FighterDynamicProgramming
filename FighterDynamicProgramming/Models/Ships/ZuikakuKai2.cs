using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Ships
{
	public class ZuikakuKai2 : AircraftCarrier
	{
		public override string Name => "瑞鶴改二";

		override public int Slot1Num { get { return 28; } }
		override public int Slot2Num { get { return 26; } }
		override public int Slot3Num { get { return 26; } }
		override public int Slot4Num { get { return 13; } }

		public ZuikakuKai2() : base(null)
		{

		}

		public ZuikakuKai2(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new ZuikakuKai2(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
