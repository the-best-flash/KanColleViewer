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
    public class ShipSlotViewModel : ViewModel
    {
        public ShipSlot ShipSlot { get; }

        public SlotItemViewModel Item { get; }

        public int Maximum
        {
            get
            {
                return ShipSlot.Maximum;
            }
        }

        public bool Equipped
        {
            get
            {
                return ShipSlot.Equipped;
            }
        }

        #region Current 変更通知プロパティ

        public int Current
        {
            get { return this.ShipSlot.Current; }
        }

        #endregion

        public ShipSlotViewModel(ShipSlot shipSlot)
        {
            this.ShipSlot = shipSlot;
            this.Item = new SlotItemViewModel(shipSlot.Item);

            this.CompositeDisposable.Add(new PropertyChangedEventListener(this.ShipSlot)
            {
                (sender, args) => {
                    this.RaisePropertyChanged(nameof(this.Current));
                }
            });
        }
    }
}
