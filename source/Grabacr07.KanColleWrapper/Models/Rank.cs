using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grabacr07.KanColleWrapper.Models
{
	public static class Rank
	{
		public static string GetName(int rank)
		{
			switch (rank)
			{
				case 1:
					return Properties.Resources.AdmiralRank_01;
				case 2:
					return Properties.Resources.AdmiralRank_02;
				case 3:
					return Properties.Resources.AdmiralRank_03;
				case 4:
					return Properties.Resources.AdmiralRank_04;
				case 5:
					return Properties.Resources.AdmiralRank_05;
				case 6:
					return Properties.Resources.AdmiralRank_06;
				case 7:
					return Properties.Resources.AdmiralRank_07;
				case 8:
					return Properties.Resources.AdmiralRank_08;
				case 9:
					return Properties.Resources.AdmiralRank_09;
				case 10:
				default:
					return Properties.Resources.AdmiralRank_10;
			}
		}
	}
}
