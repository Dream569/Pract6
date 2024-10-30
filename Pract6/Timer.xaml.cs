using System;
using System.Timers;
using Microsoft.Maui.LifecycleEvents;
namespace Pract6;

public partial class Timer : ContentPage
{
    IDispatcherTimer _timer;
    TimeSpan _remainingTime;

    public Timer()
	{
		InitializeComponent();     
    }

    private void Start(object sender, EventArgs e)
    {
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(1);
        _timer.Tick += OnTimedEvent;

        _remainingTime = TimerTimePicker.Time;
        _timer.Start();
    }

    private void Stop(object sender, EventArgs e)
    {
        _timer.Stop();
    }

    private void Reset(object sender, EventArgs e)
    {
        _timer.Stop();
        TimerLabel.Text = "00:00:00";
    }

    private void OnTimedEvent(object sender, EventArgs e)
    {
        if (_remainingTime.TotalSeconds > 0)
        {
            _remainingTime = _remainingTime.Add(TimeSpan.FromMilliseconds(-1));
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TimerLabel.Text = _remainingTime.ToString(@"hh\:mm\:ss\:fff");
            });
        }
        else
        {
            _timer.Stop();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TimerLabel.Text = "Время истекло!";
            });
        }
    }
}