using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Grabacr07.KanColleViewer.Models;
using Livet.EventListeners;

namespace Grabacr07.KanColleViewer.ViewModels
{
    public class SlotItemViewModel : ViewModel
    {
        public SlotItem SlotItem { get; }

        public string Name
        {
            get
            {
                return ItemTranslationHelper.TranslateItemName(this.SlotItem.Info.Name);
            }
        }

        public string NameWithLevel
        {
            get
            {
                return $"{this.Name}{(this.SlotItem.Level >= 1 ? (" " + this.SlotItem.LevelText) : "")}{this.AdeptText}";
            }
        }

        public string AdeptText
        {
            get
            {
                return this.SlotItem.Adept >= 1 ? string.Format(" ({0} {1})", Properties.Resources.Skilled, this.SlotItem.Adept) : "";
            }
        }

        public int Id
        {
            get
            {
                return this.SlotItem.Id;
            }
        }

        public SlotItemInfo Info
        {
            get
            {
                return this.SlotItem.Info;
            }
        }

        public int Level
        {
            get
            {
                return this.SlotItem.Level;
            }
        }

        public string LevelText
        {
            get
            {
                return this.SlotItem.LevelText;
            }
        }

        public int Adept
        {
            get
            {
                return this.SlotItem.Adept;
            }
        }

        public SlotItemViewModel(SlotItem slotItem = null)
        {
            this.SlotItem = (slotItem != null ? slotItem : SlotItem.Dummy);

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => {
                    this.RaisePropertyChanged(nameof(this.NameWithLevel));
                    this.RaisePropertyChanged(nameof(this.AdeptText));
                    this.RaisePropertyChanged(nameof(this.Name));
                }
            });

            this.CompositeDisposable.Add(new PropertyChangedEventListener(this.SlotItem)
            {
                (sender, args) => {
                    this.RaisePropertyChanged(args.PropertyName);
                }
            });
        }
    }
}
