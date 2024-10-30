namespace Pract6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            tim();
        }
        async private void tim()
        {
            tpTime.Text = DateTime.Now.Hour.ToString()+":";
            tpTime.Text += DateTime.Now.Minute.ToString() + ":";
            tpTime.Text += DateTime.Now.Second.ToString();
            await Task.Delay(1000);tim();
        }
        private void dpDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime setdate;
            setdate = dpDate.Date;
            setdate = e.NewDate;
            setdate = e.OldDate;
            string message = setdate.ToString("dd MMMM yyyy");
            int day = setdate.Day;
            int year = setdate.Year;
            if (setdate <= DateTime.Now) ;
        }
    }

}
