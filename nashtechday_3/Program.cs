class ClockApplication
{
    public class Clock
    {
        public delegate void ClockApp();
        public event ClockApp OnChange = delegate { };
        public void ClockDisplay()
        {
            OnChange();
        }
    }
    static void Main(String[] args)
    {
        while (true)
        {
            Thread.Sleep(1000);
            Clock clock = new Clock();
            clock.OnChange += () => Console.WriteLine(DateTime.Now);
            clock.ClockDisplay();
        }
    }
}