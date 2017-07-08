using CloudCherry.Model;
using System.Collections.ObjectModel;
using CloudCherry.Service;
using System.Linq;
using Prism.Mvvm;
using Prism.Commands;

namespace CloudCherry.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Prism.Services;

    public class TopRankingPageViewModel : BindableBase
    {
        private ObservableCollection<Card> _listRanking = new ObservableCollection<Card>();

        private string _title;

        private IPageDialogService _pageDialogService;

        public ObservableCollection<Card> ListRanking
        { 
          get { return _listRanking; }
          set { SetProperty(ref _listRanking, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ScoreCheckCommand { get; set; }
        public DelegateCommand TimeCheckCommand { get; set; }

        public TopRankingPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            ScoreCheckCommand = new DelegateCommand(OrderByScore);
            TimeCheckCommand = new DelegateCommand(OrderByTime);
            Title = "Top Ranking";
            GetRankList();
        }

        private async void GetRankList()
        {
            try
            {
                var list = await new RestService().GetDataAsync<Card>();
                ListRanking = new ObservableCollection<Card>(list);
            }
            catch (Exception e)
            {
                await _pageDialogService.DisplayAlertAsync("Oops","No Internet Connection", "Ok");
            }
        }

        private void OrderByScore()
        {
                var list = _listRanking.OrderByDescending(x => x.Score);
                ListRanking = new ObservableCollection<Card>(list);         
        }

        private void OrderByTime()
        {
                var list = _listRanking.OrderByDescending(x => x.Time);
                ListRanking = new ObservableCollection<Card>(list);
        }
    }
}
