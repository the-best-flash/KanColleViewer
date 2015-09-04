using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Livet;

namespace Grabacr07.KanColleWrapper.Globalization
{
    public class ResourceService : NotificationObject
    {
        // singleton
        public static ResourceService Current { get; } = new ResourceService();

        public CultureInfo Culture { get; private set; }

        /// <summary>
        /// サポートされているカルチャの名前。
        /// </summary>
        private readonly string[] supportedCultureNames =
        {
            "ja", // Resources.resx
			"en",
            "zh-CN",
            "ko-KR",
        };

        /// <summary>
        /// サポートされているカルチャを取得します。
        /// </summary>
        public IReadOnlyCollection<CultureInfo> SupportedCultures { get; }

        private ResourceService()
        {
            this.SupportedCultures = this.supportedCultureNames
                .Select(x =>
                {
                    try
                    {
                        return CultureInfo.GetCultureInfo(x);
                    }
                    catch (CultureNotFoundException)
                    {
                        return null;
                    }
                })
                .Where(x => x != null)
                .ToList();
        }

        /// <summary>
        /// 指定されたカルチャ名を使用して、リソースのカルチャを変更します。
        /// </summary>
        /// <param name="name">カルチャの名前。</param>
        public void ChangeCulture(string name, bool update = false)
        {
            this.Culture = this.SupportedCultures.SingleOrDefault(x => x.Name == name);

            Properties.Resources.Culture = this.Culture;
            Translation.Equipment.Resources.Culture = this.Culture;
            Translation.Quests.Resources.Culture = this.Culture;
            Translation.Ships.Resources.Culture = this.Culture;

            if (update)
            {
                this.RaisePropertyChanged(nameof(this.Culture));
            }
        }

        public void RaiseCultureChanged()
        {
            this.RaisePropertyChanged(nameof(this.Culture));
        }
    }
}
