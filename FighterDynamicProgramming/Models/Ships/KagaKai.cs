using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Ships
{
	public class KagaKai : AircraftCarrier
	{
		public override string Name => "加賀改";

		override public int Slot1Num { get { return 20; } }
		override public int Slot2Num { get { return 20; } }
		override public int Slot3Num { get { return 46; } }
		override public int Slot4Num { get { return 12; } }

		public KagaKai() : base(null)
		{

		}

		public KagaKai(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new KagaKai(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
