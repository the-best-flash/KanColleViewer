using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models.Raw;
using Livet.EventListeners;
using Grabacr07.KanColleWrapper.Globalization;

namespace Grabacr07.KanColleWrapper.Models
{
	public class SlotItem : RawDataWrapper<kcsapi_slotitem>, IIdentifiable
	{
		public int Id => this.RawData.api_id;

		public SlotItemInfo Info { get; private set; }

		public int Level => this.RawData.api_level;

		public string LevelText => this.Level >= 10 ? "★max" : this.Level >= 1 ? ("★+" + this.Level) : "";

        public string _nameWithLevel;
        public string NameWithLevel => this._nameWithLevel;

        public int Adept => this.RawData.api_alv;

        private string _adeptText;
        public string AdeptText => this._adeptText;

        internal SlotItem(kcsapi_slotitem rawData)
			: base(rawData)
		{
			this.Info = KanColleClient.Current.Master.SlotItems[this.RawData.api_slotitem_id] ?? SlotItemInfo.Dummy;
            this.UpdateTranslatedValues();

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current) { (sender, args) => { this.UpdateTranslatedValues(); } });
        }


		public void Remodel(int level, int masterId)
		{
			this.RawData.api_level = level;
			this.Info = KanColleClient.Current.Master.SlotItems[masterId] ?? SlotItemInfo.Dummy;

			this.RaisePropertyChanged(nameof(this.Info));
			this.RaisePropertyChanged(nameof(this.Level));

            this.UpdateTranslatedValues();
        }

        private void UpdateTranslatedValues()
        {
            this._adeptText = this.Adept >= 1 ? string.Format(" ({0} {1}) ", Translation.Equipment.Resources.Skilled, this.Adept) : "";
            this._nameWithLevel = $"{this.Info.Name}{(this.Level >= 1 ? (" " + this.LevelText) : "")}{(this.Adept >= 1 ? this.AdeptText : "")}";

            this.RaisePropertyChanged(nameof(this.AdeptText));
            this.RaisePropertyChanged(nameof(this.NameWithLevel));
        }

		public override string ToString()
		{
			return $"ID = {this.Id}, Name = \"{this.Info.Name}\", Level = {this.Level}, Adapt = {this.Adept}";
		}


		public static SlotItem Dummy { get; } = new SlotItem(new kcsapi_slotitem { api_slotitem_id = -1, });
	}
}
