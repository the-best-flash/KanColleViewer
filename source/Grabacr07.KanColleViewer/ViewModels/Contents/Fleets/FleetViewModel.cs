﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Livet.EventListeners;
using Grabacr07.KanColleViewer.Controls.Globalization;

namespace Grabacr07.KanColleViewer.ViewModels.Contents.Fleets
{
	/// <summary>
	/// 単一の艦隊情報を提供します。
	/// </summary>
	public class FleetViewModel : ItemViewModel
	{
		public Fleet Source { get; }

		public int Id => this.Source.Id;

        private string _name;
		public string Name => this._name;

		/// <summary>
		/// 艦隊に所属している艦娘のコレクションを取得します。
		/// </summary>
		public ShipViewModel[] Ships
		{
			get { return this.Source.Ships.Select(x => new ShipViewModel(x)).ToArray(); }
		}

		public FleetStateViewModel State { get; }

		public ExpeditionViewModel Expedition { get; }

		public ViewModel QuickStateView
		{
			get
			{
				var situation = this.Source.State.Situation;
				if (situation == FleetSituation.Empty)
				{
					return NullViewModel.Instance;
				}
				if (situation.HasFlag(FleetSituation.Sortie))
				{
					return this.State.Sortie;
				}
				if (situation.HasFlag(FleetSituation.Expedition))
				{
					return this.Expedition;
				}

				return this.State.Homeport;
			}
		}


		public FleetViewModel(Fleet fleet)
		{
			this.Source = fleet;
            this._name = string.IsNullOrWhiteSpace(this.Source.Name) ? string.Format(Properties.Resources.FleetNameFormat, this.Source.Id) : this.Source.Name;

            this.CompositeDisposable.Add(new PropertyChangedEventListener(fleet)
			{
				(sender, args) => this.RaisePropertyChanged(args.PropertyName),
			});
			this.CompositeDisposable.Add(new PropertyChangedEventListener(fleet.State)
			{
				{ nameof(fleet.State.Situation), (sender, args) => this.RaisePropertyChanged(nameof(this.QuickStateView)) },
			});

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => 
                {
                    this._name = string.IsNullOrWhiteSpace(this.Source.Name) ? string.Format(Properties.Resources.FleetNameFormat, this.Source.Id) : this.Source.Name;
                    this.RaisePropertyChanged(nameof(this.Name));
                }
            });

            this.State = new FleetStateViewModel(fleet.State);
			this.CompositeDisposable.Add(this.State);

			this.Expedition = new ExpeditionViewModel(fleet.Expedition);
			this.CompositeDisposable.Add(this.Expedition);
		}
	}
}
