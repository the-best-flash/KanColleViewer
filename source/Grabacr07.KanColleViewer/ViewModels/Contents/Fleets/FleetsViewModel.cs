﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper;
using Livet.EventListeners;
using Livet.Messaging;
using MetroTrilithon.Mvvm;

namespace Grabacr07.KanColleViewer.ViewModels.Contents.Fleets
{
	public class FleetsViewModel : TabItemViewModel
	{
		#region Fleets 変更通知プロパティ

		private FleetViewModel[] _Fleets;

		public FleetViewModel[] Fleets
		{
			get { return this._Fleets; }
			set
			{
				if (this._Fleets != value)
				{
					this._Fleets = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region SelectedFleet 変更通知プロパティ

		private FleetViewModel _SelectedFleet;

		/// <summary>
		/// 現在選択されている艦隊を取得または設定します。
		/// </summary>
		public FleetViewModel SelectedFleet
		{
			get { return this._SelectedFleet; }
			set
			{
				if (this._SelectedFleet != value)
				{
					if (this._SelectedFleet != null) this.SelectedFleet.IsSelected = false;
					if (value != null) value.IsSelected = true;
					this._SelectedFleet = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public FleetsViewModel()
		{
			KanColleClient.Current.Homeport.Organization
				.Subscribe(nameof(Organization.Fleets), this.UpdateFleets)
				.AddTo(this);

            this.UpdateTranslatedValues();
		}

		public void ShowFleetWindow()
		{
			var fleetwd = new FleetWindowViewModel();
			var message = new TransitionMessage(fleetwd, TransitionMode.Normal, "Show/FleetWindow");
			this.Messenger.Raise(message);
		}

		private void UpdateFleets()
		{
			this.Fleets = KanColleClient.Current.Homeport.Organization.Fleets.Select(kvp => new FleetViewModel(kvp.Value)).ToArray();
			this.SelectedFleet = this.Fleets.FirstOrDefault();
		}

        protected override void UpdateTranslatedValues()
        {
            this.Name = Properties.Resources.Fleets;
            this.RaisePropertyChanged(nameof(this.Name));
        }
    }
}
