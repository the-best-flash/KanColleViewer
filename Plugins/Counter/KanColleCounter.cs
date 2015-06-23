﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;

namespace Counter
{
	[Export(typeof(IPlugin))]
	[Export(typeof(ITool))]
	[Export(typeof(IRequestNotify))]
	[ExportMetadata("Id", "65BE3E80-8EC1-41BD-85E0-78AEFD45A757")]
	[ExportMetadata("Title", "KanColleCounter")]
	[ExportMetadata("Description", "シンプルな回数カウント機能を提供します。")]
	[ExportMetadata("Version", "1.0")]
	[ExportMetadata("Author", "@Grabacr07")]
	public class KanColleCounter : IPlugin, ITool, IRequestNotify, IDisposable
	{
		private readonly CounterViewModel viewmodel = new CounterViewModel
		{
			Counters = new ObservableCollection<CounterBase>
			{
				new SupplyCounter(KanColleClient.Current.Proxy),
				new ItemDestroyCounter(KanColleClient.Current.Proxy),
				new MissionCounter(KanColleClient.Current.Proxy),
			}
		};

		string ITool.Name
		{
			get { return "Counter"; }
		}

		object ITool.View
		{
			get { return new CounterView { DataContext = this.viewmodel, }; }
		}

		public event EventHandler<NotifyEventArgs> NotifyRequested;

		public void Initialize()
		{
			MessageBox.Show("KanColleCounter initialized.");
		}

		public void Dispose()
		{
			MessageBox.Show("KanColleCounter disposed.");
		}
	}
}
