using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterDynamicProgramming.Models
{
    public class Ro44SeaplaneFighter : SeaplaneFighter
    {
		public override int AA { get { return 2; } }

		public override string Name => "Ro.44水上戦闘機";
	}
}
