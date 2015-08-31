using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;  
using Grabacr07.KanColleViewer.Models;  
using Livet.EventListeners;
using Grabacr07.KanColleWrapper.Models;

namespace Grabacr07.KanColleViewer.ViewModels.Catalogs
{
    public class SlotItemInfoViewModel : ViewModel
    {
        public SlotItemInfo SlotItemInfo { get; }

        public string Name
        {
            get
            {
                return ItemTranslationHelper.TranslateItemName(SlotItemInfo.Name);
            }
        }

        public SlotItemInfoViewModel(SlotItemInfo slotItemInfo)
        {
            this.SlotItemInfo = slotItemInfo;

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => {
                    this.RaisePropertyChanged(nameof(this.Name));
                }
            });
        }
    }
}
