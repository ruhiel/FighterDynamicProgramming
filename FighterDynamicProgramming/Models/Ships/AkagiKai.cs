using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public class AkagiKai : AircraftCarrier
	{
		public override string Name => "赤城改";

		override public int Slot1Num { get { return 20; } }
		override public int Slot2Num { get { return 20; } }
		override public int Slot3Num { get { return 32; } }
		override public int Slot4Num { get { return 10; } }

		public AkagiKai() : base(null)
		{

		}

		public AkagiKai(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new AkagiKai(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
