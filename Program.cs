using CommandLine;
using Sharprompt;
using System.Runtime.InteropServices;

public class Program
{
    public static async Task Main(string[] args)
    {
        var parserResult = CommandLine.Parser.Default.ParseArguments<Options>(args);
        await parserResult.WithParsedAsync(RunOptions);
    }

    public static async Task RunOptions(Options opts)
    {
        if (opts.Days is null)
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
        else
        {
            var ts = TimeSpan.FromDays(opts.Days ?? 0);
            var thatDate = DateTime.Today - ts;
            var output = thatDate.ToString("d");

            Console.WriteLine(output);
            
        }
    }

    protected static void CancelKeyPressHandler(object? sender, ConsoleCancelEventArgs args)
    {
        Console.WriteLine("\nBye!");
        args.Cancel = true;
        Environment.Exit(0);
    }
}

public class Options
{
    [Option(shortName: 'd', longName: "days", HelpText = "Number of days to use")]
    public int? Days { get; set; }
}