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

        public Ship Ship { get; }

        public ShipInfoViewModel(Ship ship)
        {
            this.Ship = ship;

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => {
                    this.RaisePropertyChanged(nameof(this.Name));
                    this.RaisePropertyChanged(nameof(this.ShipTypeName));
                    }
            });
        }
    }
}
