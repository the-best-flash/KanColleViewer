using Grabacr07.KanColleViewer.Models;
using Livet.EventListeners;
using MetroTrilithon.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabacr07.KanColleViewer.ViewModels
{
    public static class DisplayFunctionViewModel
    {
        public static DisplayFunctionViewModel<T> Create<T>(T value, Func<string> displayFunc, INotifyPropertyChanged notificationObject)
        {
            return new DisplayFunctionViewModel<T> (notificationObject) { Value = value, Display = (displayFunc != null? displayFunc.Invoke() : ""), DisplayFunction = displayFunc };
        }
    }

    public class DisplayFunctionViewModel<T> : DisplayViewModel<T>
    {
        public Func<string> DisplayFunction { get; set; }

        public DisplayFunctionViewModel(INotifyPropertyChanged notificationObject)
        {
            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) =>
                {
                    if(this.DisplayFunction != null)
                    {
                        this.Display = this.DisplayFunction.Invoke();
                    }
                }
            });
        }
    }
}
