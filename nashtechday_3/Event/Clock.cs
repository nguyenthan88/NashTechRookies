public class Clock
{
    public int second;
    public delegate void ClockTickHandler(object clock, TimeEventArgs timeEvent);
    public event ClockTickHandler? clockTickEvent;
    protected void OnTick(object clock, TimeEventArgs timeEvent)
    {
        if (clockTickEvent != null)
        {
            clockTickEvent(clock, timeEvent);
        }
    }
    public void Run()
    {
        while (!Console.KeyAvailable)
        {
            Thread.Sleep(1000);
            DateTime now = DateTime.Now;

            if (now.Second != second)
            {
                TimeEventArgs timeEventArgs = new TimeEventArgs(now.Hour, now.Minute, now.Second);
                OnTick(this, timeEventArgs);
            }
        }
    }
}