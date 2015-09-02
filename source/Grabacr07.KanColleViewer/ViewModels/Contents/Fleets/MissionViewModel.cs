using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Grabacr07.KanColleViewer.Models;
using Livet;
using Livet.EventListeners;

namespace Grabacr07.KanColleViewer.ViewModels.Contents.Fleets
{
    public class MissionViewModel : ViewModel
    {
        private Mission _mission;

        public int Id => this._mission.Id;

        public string Title => MissionTranslationHelper.TranslateTitle(this._mission.Id, this._mission.Title);

        public string Detail => MissionTranslationHelper.TranslateDetail(this._mission.Id, this._mission.Detail);

        public MissionViewModel(Mission mission)
        {
            this._mission = mission;

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => {
                    this.RaisePropertyChanged(nameof(this.Title));
                    this.RaisePropertyChanged(nameof(this.Detail));
                    }
            });
        }
    }
}
