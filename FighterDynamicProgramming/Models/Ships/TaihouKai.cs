using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Ships
{
	public class TaihouKai : AircraftCarrier
	{
		public override string Name => "大鳳改";

		override public int Slot1Num { get { return 30; } }
		override public int Slot2Num { get { return 24; } }
		override public int Slot3Num { get { return 24; } }
		override public int Slot4Num { get { return 8; } }

		public TaihouKai() : base(null)
		{

		}

		public TaihouKai(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new TaihouKai(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
