namespace Pract6;
using System.Timers;

public partial class Seconds : ContentPage
{
    int second;
    bool timerRun = false;
    IDispatcherTimer _timer;
    TimeSpan _remainingTime;

    public Seconds()
    {
        InitializeComponent();
    }
    private async void OnStartClicked(object sender, EventArgs e)
    {
        OnStartClicked1.IsEnabled = false;
        OnStartClicked1.IsVisible = false;
        OnStopClicked1.IsEnabled = true;
        OnStopClicked1.IsVisible = true;
        OnResetClicked1.IsEnabled = false;
        OnPitStopClicked1.IsEnabled = true;
        timerRun=true;
        while (timerRun)
        {
            second += 1;
            TimeSpan time = TimeSpan.FromMilliseconds(second);
            TimerLabel.Text = time.ToString(@"hh\:mm\:ss\:fff");
            await Task.Delay(1);
        }
    }

    private void OnStopClicked(object sender, EventArgs e)
    {
        OnStartClicked1.IsVisible = true;
        OnStartClicked1.IsEnabled = true;
        OnResetClicked1.IsEnabled = true;
        OnPitStopClicked1.IsEnabled = false;
        OnStopClicked1.IsEnabled = false;
        OnStopClicked1.IsVisible = false;
        timerRun=false;
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        OnResetClicked1.IsEnabled = true;
        OnPitStopClicked1.IsEnabled = false;
        OnStopClicked1.IsEnabled = false;
        OnStopClicked1.IsVisible = true;
        TimerLabel.Text = "00:00:00"; PitStop.Text = "";
        second = 0;
    }


    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        _remainingTime = _remainingTime.Add(TimeSpan.FromMilliseconds(10));
        MainThread.BeginInvokeOnMainThread(() =>
        {
            TimerLabel.Text = _remainingTime.ToString(@"hh\:mm\:ss");
        });
    }

    private void OnPitStopClicked(object sender, EventArgs e)
    {
        Label l1 = new Label();
        TimeSpan time = TimeSpan.FromMilliseconds(second);
        l1.Text = time.ToString(@"hh\:mm\:ss\:fff");
        PitStop.Text += l1.Text + "\n";
    }
}