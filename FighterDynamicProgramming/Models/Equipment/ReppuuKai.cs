using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models.Equipment
{
	public class ReppuuKai : Fighter
	{
		public override int AA { get { return 12; } }

		public override string Name => "烈風改";
	}
}
