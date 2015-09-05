using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;

namespace Grabacr07.KanColleViewer.ViewModels.Dev
{
	public class DebugTabViewModel : TabItemViewModel
	{
        public DebugTabViewModel()
        {
            this.UpdateTranslatedValues();
        }

        protected override void UpdateTranslatedValues()
        {
            this.Name = Properties.Resources.Debug;
            this.RaisePropertyChanged(nameof(this.Name));
        }
    }
}
