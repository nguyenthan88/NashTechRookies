public class DisplayClock
{
    public void Subcribe(Clock clock)
    {
        clock.clockTickEvent += new Clock.ClockTickHandler(ShowClock);
    }
    public void ShowClock(object clock, TimeEventArgs timeEventArgs)
    {
        Console.WriteLine($"{timeEventArgs.hour} : {timeEventArgs.minute}: {timeEventArgs.second}");
    }
}