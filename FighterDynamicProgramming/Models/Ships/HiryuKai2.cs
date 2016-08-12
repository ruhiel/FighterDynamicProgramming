using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Ships
{
	public class HiryuKai2 : AircraftCarrier
	{
		public override string Name => "飛龍改二";

		override public int Slot1Num { get { return 18; } }
		override public int Slot2Num { get { return 36; } }
		override public int Slot3Num { get { return 22; } }
		override public int Slot4Num { get { return 3; } }

		public HiryuKai2() : base(null)
		{

		}

		public HiryuKai2(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new HiryuKai2(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
