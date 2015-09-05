using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Livet;
using Grabacr07.KanColleViewer.Models;
using Livet.EventListeners;
using Grabacr07.KanColleWrapper.Translation;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
	public class QuestViewModel : ViewModel
	{
		#region Type 変更通知プロパティ

		private QuestType _Type;

		public QuestType Type
		{
			get { return this._Type; }
			set
			{
				if (this._Type != value)
				{
					this._Type = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region Category 変更通知プロパティ

		private QuestCategory _Category;

		public QuestCategory Category
		{
			get { return this._Category; }
			set
			{
				if (this._Category != value)
				{
					this._Category = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region State 変更通知プロパティ

		private QuestState _State;

		public QuestState State
		{
			get { return this._State; }
			set
			{
				if (this._State != value)
				{
					this._State = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region Progress 変更通知プロパティ

		private QuestProgress _Progress;

		public QuestProgress Progress
		{
			get { return this._Progress; }
			set
			{
				if (this._Progress != value)
				{
					this._Progress = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region Title 変更通知プロパティ

		private string _Title;
        private string _translatedTitle;

		public string Title
		{
			get { return _translatedTitle; }
			set
			{
				if (this._Title != value)
				{
					this._Title = value;
                    this._translatedTitle = QuestTranslationHelper.TranslateQuestTitle(this._Title);
                    this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region Detail 変更通知プロパティ

		private string _Detail;
        private string _translatedDetail;

		public string Detail
		{
			get { return this._translatedDetail; }
			set
			{
				if (this._Detail != value)
				{
					this._Detail = value;
                    this._translatedDetail = QuestTranslationHelper.TranslateQuestDetail(this._Title, this._Detail);
                    this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region IsUntaken 変更通知プロパティ

		private bool _IsUntaken;

		public bool IsUntaken
		{
			get { return this._IsUntaken; }
			set
			{
				if (this._IsUntaken != value)
				{
					this._IsUntaken = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public QuestViewModel(Quest quest)
		{
			if (quest == null)
			{
				this.IsUntaken = true;
			}
			else
			{
				this.IsUntaken = false;
				this.Type = quest.Type;
				this.Category = quest.Category;
				this.State = quest.State;
				this.Progress = quest.Progress;
				this.Title = quest.Title;
				this.Detail = quest.Detail;
			}

            this.UpdateTranslatedValues();

            this.CompositeDisposable.Add(new PropertyChangedEventListener(ResourceService.Current)
            {
                (sender, args) => 
                {
                    this.UpdateTranslatedValues();
                    this.RaisePropertyChanged(nameof(this.Title));
                    this.RaisePropertyChanged(nameof(this.Detail));
                }
            });
        }

        private void UpdateTranslatedValues()
        {
            this._translatedTitle = QuestTranslationHelper.TranslateQuestTitle(this._Title);
            this._translatedDetail = QuestTranslationHelper.TranslateQuestDetail(this._Title, this._Detail);
        }
	}
}
