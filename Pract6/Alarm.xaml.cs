namespace Pract6;

public partial class Alarm : ContentPage
{
    TimeSpan time;
    IDispatcherTimer timer;
	public Alarm()
	{
		InitializeComponent();
	}

    public void Timer(object sender, EventArgs e)
    {
        DateTime nowday = DateTime.Now;
        TimeSpan nowtime = new TimeSpan(nowday.Hour, nowday.Minute, 0);

        if (time.CompareTo(nowtime) == 0)
        {
            if (swMonday.IsToggled == true && nowday.DayOfWeek == DayOfWeek.Monday 
                || swTuesday.IsToggled == true && nowday.DayOfWeek == DayOfWeek.Tuesday
                || swWednesday.IsToggled == true && nowday.DayOfWeek == DayOfWeek.Wednesday
                || swSaturday.IsToggled == true && nowday.DayOfWeek == DayOfWeek.Saturday
                || swFriday.IsToggled == true && nowday.DayOfWeek == DayOfWeek.Friday
                || Sunday.IsToggled == true && nowday.DayOfWeek == DayOfWeek.Sunday
                || swThursday.IsToggled == true && nowday.DayOfWeek == DayOfWeek.Thursday)
            {
                DisplayAlert("Внимание", "Просыпайся", "Дай поспать еще");
                timer.Stop();
            }
        }
    }
    private void OnSetAlarmClicked(object sender, EventArgs e)
    {
        //var alarmTime = AlarmTimePicker.Time;
        timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer;

        if (swOnOffTime.IsToggled == true)
        {
            time = AlarmTimePicker.Time;
            AlarmTimePicker.IsEnabled = false;
            timer.Start();
        }
        else
        {
            AlarmTimePicker.IsEnabled = true;
            timer.Stop();
        }
    }

    private void swOnOffTime_Toggled(object sender, ToggledEventArgs e)
    {

    }
}