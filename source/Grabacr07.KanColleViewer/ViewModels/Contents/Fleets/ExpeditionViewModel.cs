using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Livet.EventListeners;

namespace Grabacr07.KanColleViewer.ViewModels.Contents.Fleets
{
	public class ExpeditionViewModel : ViewModel
	{
		private readonly Expedition source;

		public MissionViewModel Mission { get; private set; }

		public bool IsInExecution => this.source.IsInExecution;

		public string ReturnTime => this.source.ReturnTime?.LocalDateTime.ToString("MM/dd HH:mm") ?? "--/-- --:--";

		public string Remaining => this.source.Remaining.HasValue
			? $"{(int)this.source.Remaining.Value.TotalHours:D2}:{this.source.Remaining.Value.ToString(@"mm\:ss")}"
			: "--:--:--";

		public ExpeditionViewModel(Expedition expedition)
		{
			this.source = expedition;
            this.Mission = new MissionViewModel(expedition.Mission);

			this.CompositeDisposable.Add(new PropertyChangedEventListener(expedition, 
                (sender, args) => 
                {
                    if(args.PropertyName == nameof(this.Mission))
                    {
                        this.Mission = new MissionViewModel(expedition.Mission);
                    }

                    this.RaisePropertyChanged(args.PropertyName);
                }
            ));
		}
	}
}
