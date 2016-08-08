using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
	public class Reppuu : Fighter
	{
		public override int AA { get { return 10; }  }

		public override string Name => "烈風";
	}
}
