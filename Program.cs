using Sharprompt;

public class Program
{
    public static void Main(string[] args)
    {
        Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelKeyPressHandler);

        while (true)
        {
            int days = Prompt.Input<int>("Days ago?");
            var ts = TimeSpan.FromDays(days);
            var thatDate = DateTime.Today - ts;
            var output = thatDate.ToString("d");

            Console.WriteLine(output);
        }
    }

    protected static void CancelKeyPressHandler(object sender, ConsoleCancelEventArgs args)
    {
        Console.WriteLine("\nBye!");
        args.Cancel = true;
        Environment.Exit(0);
    }
}
