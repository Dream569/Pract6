using System.Timers;

namespace Pract6;

public partial class Napomil : ContentPage
{
    IDispatcherTimer _timer;
    List<(DateTime date, TimeSpan Time, string Message)> _reminders = new List< (DateTime date, TimeSpan, string)>();
    bool _running;
    string _message;
    DateTime setDate;

    public Napomil()
    {
        InitializeComponent();
    }
    private void OnSetReminderClicked(object sender, EventArgs e)
    {
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _reminders.Add((ReminderDatePicker.Date, ReminderTimePicker.Time, ReminderMessageEntry.Text));

        setDate = ReminderDatePicker.Date + ReminderTimePicker.Time;
        _message = ReminderMessageEntry.Text + "\n" + setDate.ToString("dd MM yyyy HH mm");
        _timer.Tick += OnTimedEvent;
        _timer.Start();
    }

    private void OnTimedEvent(object sender, EventArgs e)
    {
        var currentSec = DateTime.Now.TimeOfDay.Seconds;
        var currentMinute = DateTime.Now.TimeOfDay.Minutes;
        var currentHours = DateTime.Now.TimeOfDay.Hours;
        var currentdate = DateTime.Now.Date;
        string dddd = "{" + currentHours.ToString() + ":" + currentMinute.ToString() + ":" + currentSec.ToString() + "}";
        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var reminder in _reminders.ToArray())
            {
                if (currentdate.ToString() == reminder.date.ToString())
                {
                    //if (currentSec.ToString(@"ss") == reminder.Time.ToString(@"ss") || currentMinute.ToString(@"mm") == reminder.Time.ToString(@"mm")
                    //|| currentHours.ToString(@"hh") == reminder.Time.ToString(@"hh"))
                    if (dddd == reminder.Time.ToString(@"hh\:mm\:ss"))
                    {
                        DisplayAlert("Напоминание", reminder.Message, "OK");
                        _reminders.Remove(reminder);
                        RemindersListView.ItemsSource = null;
                        RemindersListView.ItemsSource = _reminders;
                    }
                }
            }
        });

    }
}