using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.ViewModels.Contents.Fleets;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
	public class ExpeditionsViewModel : TabItemViewModel
	{
		public FleetsViewModel Fleets { get; }

		public ExpeditionsViewModel(FleetsViewModel fleets)
		{
			this.Fleets = fleets;

            this.UpdateTranslatedValues();
		}

        protected override void UpdateTranslatedValues()
        {
            this.Name = Properties.Resources.Expedition;
            this.RaisePropertyChanged(nameof(this.Name));
        }
    }
}
