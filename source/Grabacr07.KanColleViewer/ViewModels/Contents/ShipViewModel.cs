using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Livet;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
	public class ShipViewModel : ViewModel
	{
		public ShipInfoViewModel ShipInfo { get; }

        public Ship Ship
        {
            get
            {
                return this.ShipInfo.Ship;
            }
        }

		public ShipViewModel(Ship ship)
		{
			this.ShipInfo = new ShipInfoViewModel(ship);
		}
	}
}
