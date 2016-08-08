using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Equipment
{
	public class ShindenKai : Fighter
	{
		public override int AA { get { return 15; } }

		public override string Name => "震電改";
	}
}
