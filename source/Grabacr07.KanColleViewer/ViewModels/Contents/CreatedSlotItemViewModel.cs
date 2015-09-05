using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Grabacr07.KanColleViewer.Models;
using Livet.EventListeners;
using Grabacr07.KanColleWrapper.Translation;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
	public class CreatedSlotItemViewModel : ViewModel
	{
		#region Succeed 変更通知プロパティ

		private bool? _Succeed;

		public bool? Succeed
		{
			get { return this._Succeed; }
			set
			{
				if (this._Succeed != value)
				{
					this._Succeed = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region Name 変更通知プロパティ

		private string _Name;
        private string _translatedName;

		public string Name
		{
			get { return this._translatedName; }
			set
			{
				if (this._Name != value)
				{
					this._Name = value;
                    this._translatedName = ItemTranslationHelper.TranslateItemName(this._Name);
                    this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public CreatedSlotItemViewModel()
		{
			this.Succeed = null;
			this.Name = "-----";

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => {
                    this._translatedName = ItemTranslationHelper.TranslateItemName(this._Name);
                    this.RaisePropertyChanged(nameof(this.Name));
                }
            });

        }

        public void Update(CreatedSlotItem item)
		{
			this.Succeed = item.Succeed;
			this.Name = item.SlotItemInfo.Name;
		}
	}
}
