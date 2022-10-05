class Program
{
    static void IsPrimeNumber(int number)
    {
        bool Prime = true;
        Console.WriteLine("Prime Numbers between 0 to {0} : ", number);
        for (int a = 2; a <= number; a++)
        {
            for (int b = 2; b <= number; b++)
            {
                if (a != b && a % b == 0)
                {
                    Prime = false;
                    break;
                }
            }
            if (Prime)
            {
                Console.Write(($"{a,3}"));
            }
            Prime = true;
        }
    }
    static async Task TaskPrimeNumber()
    {
        await Task.Run(() =>
           {
               Console.Write("enter integer:");
               int number = Convert.ToInt32(Console.ReadLine());
               IsPrimeNumber(number);
           });
    }
    static async Task Main(string[] args)
    {
        await TaskPrimeNumber();
        Console.Write("\n");
        Console.WriteLine("-------------------");
        Console.ReadKey();
    }
}
