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
    public class DisplayFunctionViewModel<T> : DisplayViewModel<T>
    {
        public Func<string> DisplayFunction { get; set; }

        public DisplayFunctionViewModel(T value, Func<string> displayFunc, INotifyPropertyChanged notificationObject)
        {
            this.Value = value;
            this.DisplayFunction = displayFunc;
            this.Display = this.InvokeDisplayFunction();

            this.CompositeDisposable.Add(new PropertyChangedEventListener(notificationObject)
            {
                (sender, args) =>
                {
                    if(this.DisplayFunction != null)
                    {
                        this.Display = this.InvokeDisplayFunction();
                    }
                }
            });
        }

        private string InvokeDisplayFunction()
        {
            return (this.DisplayFunction != null ? this.DisplayFunction.Invoke() : string.Empty);
        }
    }
}
