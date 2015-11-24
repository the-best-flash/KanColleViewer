using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media;
using Codeplex.Data;
using Livet;
using Livet.EventListeners;

namespace Grabacr07.KanColleViewer.Models
{
	public class SallyArea : ViewModel
    {
		public int Area { get; private set; }

        private string _name;
		public string Name
        {
            get
            {
                string translatedName = Properties.Resources.ResourceManager.GetString(_name, Properties.Resources.Culture);

                if(string.IsNullOrEmpty(translatedName))
                {
                    translatedName = _name;
                }

                return translatedName;
            }

            private set
            {
                _name = value;
                this.RaisePropertyChanged();
            }
        }

        public string NonTranslatedName
        {
            get { return _name; }
        }

		public Color Color { get; private set; } = Colors.Transparent;

		private SallyArea()
        {
            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current) {
                (sender, args) =>
                {
                this.RaisePropertyChanged(nameof(this.Name));
                }
            });
        }

    public static SallyArea Default { get; } = new SallyArea();

		public static async Task<SallyArea[]> GetAsync()
		{
			using (var client = new HttpClient(Helper.GetProxyConfiguredHandler()))
			{
				try
				{
					var uri = new Uri(Properties.Settings.Default.SallyAreaSource);
					var response = await client.GetAsync(uri);
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						var json = DynamicJson.Parse(content);
						var result = ((object[])json)
							.Select(x => (dynamic)x)
							.Select(x =>
								new SallyArea
								{
									Area = (int)x.area,
									Name = (string)x.name,
									Color = Helper.StringToColor(x.color)
								})
							.ToArray();

						return result;
					}
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex);
					StatusService.Current.Notify("出撃海域の取得に失敗しました: " + ex);
				}
			}

			return new SallyArea[0];
		}
	}
}
