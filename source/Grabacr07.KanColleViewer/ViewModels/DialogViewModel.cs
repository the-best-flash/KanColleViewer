using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetroTrilithon.Mvvm;
using Livet.EventListeners;
using System.ComponentModel;

namespace Grabacr07.KanColleViewer.ViewModels
{
	public class DialogViewModel : WindowViewModel
	{
        private Func<string> _titleFunction;

		public DialogViewModel(INotifyPropertyChanged updateSource = null, Func<string> titleFunction = null)
		{
			this.DialogResult = false;

            this._titleFunction = titleFunction;
            
            if(this._titleFunction != null)
            {
                this.Title = this._titleFunction.Invoke();
            }

            if (updateSource != null && titleFunction != null)
            {
                this.CompositeDisposable.Add(new PropertyChangedEventListener(updateSource)
                {
                    (sender, args) =>
                    {
                        if(this._titleFunction != null)
                        {
                            this.Title = this._titleFunction.Invoke();
                        }
                    }
                });
            }
        }

		public void OK()
		{
			this.DialogResult = true;
			this.Close();
		}

		public void Cancel()
		{
			this.DialogResult = false;
			this.Close();
		}
	}
}
