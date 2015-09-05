using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;
using MetroTrilithon.Mvvm;
using Livet.EventListeners;
using Grabacr07.KanColleViewer.Models;

namespace Grabacr07.KanColleViewer.ViewModels.Settings
{
	public class PluginSettingsWindowViewModel : WindowViewModel
	{
		private readonly ISettings settings;

		public object Content => this.settings.View;

		public PluginSettingsWindowViewModel(ISettings settings, string title)
		{
			this.Title = string.Format(Properties.Resources.PlugingSettings_TitleFormat, title);
			this.settings = settings;

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) =>
                {
                    this.Title = string.Format(Properties.Resources.PlugingSettings_TitleFormat, title);
                }
            });
        }
	}
}
