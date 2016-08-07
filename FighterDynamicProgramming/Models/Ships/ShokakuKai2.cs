using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Ships
{
	public class ShokakuKai2 : AircraftCarrier
	{
		public override string Name => "翔鶴改二";

		override public int Slot1Num { get { return 27; } }
		override public int Slot2Num { get { return 27; } }
		override public int Slot3Num { get { return 27; } }
		override public int Slot4Num { get { return 12; } }

		public ShokakuKai2() : base(null)
		{

		}

		public ShokakuKai2(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new ShokakuKai2(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
