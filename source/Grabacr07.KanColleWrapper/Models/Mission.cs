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

        private string _title;
        public string Title => this._title;

        private string _detail;
        public string Detail => this._detail;

		public Mission(kcsapi_mission mission)
			: base(mission)
		{
            this.UpdateTranslatedValues();

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current) { (sender, args) => this.UpdateTranslatedValues() });
        }

        private void UpdateTranslatedValues()
        {
            this._title = Translation.MissionTranslationHelper.TranslateTitle(this.Id, this.RawData.api_name);
            this._detail = Translation.MissionTranslationHelper.TranslateDetail(this.Id, this.RawData.api_details);

            this.RaisePropertyChanged(nameof(this.Title));
            this.RaisePropertyChanged(nameof(this.Detail));
        }
	}
}
