namespace FighterDynamicProgramming.Models.Ships
{
	public class AirCraftCruiser : AircraftCarrier
	{
		public override bool Attackable => true;

		public AirCraftCruiser() : base(null)
		{

		}

		public AirCraftCruiser(AircraftCarrier source) : base(source)
		{
		}

		public override object Clone()
		{
			return new AirCraftCruiser(this); // コピーコンストラクタを使ってコピーを作成
		}
	}
}
