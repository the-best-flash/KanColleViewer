using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models.Raw;
using Livet.EventListeners;
using Grabacr07.KanColleWrapper.Globalization;

namespace Grabacr07.KanColleWrapper.Models
{
	[DebuggerDisplay("[{Id}] {Title} - {Detail}")]
	public class Mission : RawDataWrapper<kcsapi_mission>, IIdentifiable
	{
        public int Id => this.RawData.api_id;

        public string Title => Translation.QuestTranslationHelper.TranslateQuestTitle(this.RawData.api_name);

        public string Detail => Translation.QuestTranslationHelper.TranslateQuestDetail(this.RawData.api_name, this.RawData.api_details);

		public Mission(kcsapi_mission mission)
			: base(mission)
		{
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
