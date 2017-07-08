namespace CloudCherry.Views
{
    public partial class TopRankingPage
    {
        public TopRankingPage()
        {
            InitializeComponent();
            ListView.ItemSelected += (s,e) => { ListView.SelectedItem = null; };
        }
    }
}
