using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models.Raw;
using Livet.EventListeners;
using Grabacr07.KanColleWrapper.Globalization;

namespace Grabacr07.KanColleWrapper.Models
{
	public class MapInfo : RawDataWrapper<kcsapi_mst_mapinfo>, IIdentifiable
	{
		public int Id { get; }

		public string Name { get; private set; }

		public int MapAreaId { get;}

		public MapArea MapArea { get; internal set; }

		public int IdInEachMapArea { get;}

		public int Level { get; }

		public string OperationName { get; private set; }

		public string OperationSummary { get; private set; }

		public int RequiredDefeatCount { get; }

		public MasterTable<MapCell> MapCells { get; }

		public MapInfo(kcsapi_mst_mapinfo mapinfo, MasterTable<MapCell> mapCells)
			: base(mapinfo)
		{
			this.Id = mapinfo.api_id;
			this.MapAreaId = mapinfo.api_maparea_id;
			this.IdInEachMapArea = mapinfo.api_no;
			this.Level = mapinfo.api_level;
			this.RequiredDefeatCount = mapinfo.api_required_defeat_count ?? 1;

            this.UpdateTranslatedValues();

			this.MapCells = new MasterTable<MapCell>(mapCells.Values.Where(x => x.MapInfoId == mapinfo.api_id));
			foreach (var cell in this.MapCells.Values)
				cell.MapInfo = this;

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current){ (sender, args) => this.UpdateTranslatedValues() });
        }

        private void UpdateTranslatedValues()
        {
            this.Name = Translation.MapTranslationHelper.TranslateMapName(this.Id, this.RawData.api_name);
            this.OperationName = Translation.MapTranslationHelper.TranslateMapOperationName(this.Id, this.RawData.api_opetext);
            this.OperationSummary = Translation.MapTranslationHelper.TranslateMapOperationInfo(this.Id, this.RawData.api_infotext);

            this.RaisePropertyChanged(nameof(this.Name));
            this.RaisePropertyChanged(nameof(this.OperationName));
            this.RaisePropertyChanged(nameof(this.OperationSummary));
        }

        public override string ToString()
		{
			return $"ID = {this.Id}, Name = {this.Name}";
		}

		#region static members

		public static MapInfo Dummy { get; } = new MapInfo(new kcsapi_mst_mapinfo
		{
		    api_id = 0,
		    api_name = "？？？",
		    api_maparea_id = 0,
		    api_no = 0,
		    api_level = 0,
		}, new MasterTable<MapCell>())
	    {
		    MapArea = MapArea.Dummy,
	    };

	    #endregion
	}
}
