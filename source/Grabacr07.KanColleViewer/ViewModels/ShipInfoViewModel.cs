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
    public class ShipInfoViewModel : ViewModel
    {
        public string Name
        {
            get
            {
                return ShipTranslationHelper.TranslateShipName(this.Ship.Info.Name);
            }
        }

        public string ShipTypeName
        {
            get
            {
                return ShipTranslationHelper.TranslateShipName(this.Ship.Info.ShipType.Name);
            }
        }

        private ShipSlotViewModel[] _slots;
        public ShipSlotViewModel[] Slots
        {
            get
            {
                return this._slots;
            }
        }

        ShipSlotViewModel _exSlot;
        public ShipSlotViewModel ExSlot
        {
            get
            {
                return this._exSlot;
            }
        }

        private ShipSlotViewModel[] _equippedItems;
        public ShipSlotViewModel[] EquippedItems
        {
            get
            {
                return this._equippedItems;
            }
        }

        public Ship Ship { get; }

        public ShipInfoViewModel(Ship ship)
        {
            this.Ship = ship;
            this._slots = this.Ship.Slots.Select(x => new ShipSlotViewModel(x)).ToArray();
            this._equippedItems = this.Ship.EquippedItems.Select(x => new ShipSlotViewModel(x)).ToArray();
            this._exSlot = new ShipSlotViewModel(this.Ship.ExSlot);

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => {
                    this.RaisePropertyChanged(nameof(this.Name));
                    this.RaisePropertyChanged(nameof(this.ShipTypeName));
                    }
            });

            this.CompositeDisposable.Add(new PropertyChangedEventListener(this.Ship)
            {
                (sender, args) => {
                        this._slots = this.Ship.Slots.Select(x => new ShipSlotViewModel(x)).ToArray();
                        this.RaisePropertyChanged(nameof(this.Slots));

                        this._exSlot = new ShipSlotViewModel(this.Ship.ExSlot);
                        this.RaisePropertyChanged(nameof(this.ExSlot));

                        this._equippedItems = this.Ship.EquippedItems.Select(x => new ShipSlotViewModel(x)).ToArray();
                        this.RaisePropertyChanged(nameof(this.EquippedItems));
                    }
            });
        }
    }
}
