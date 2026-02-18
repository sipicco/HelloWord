using HelloWord;

internal class Program
{
    private static void Main(string[] args)
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("What to search?");
            string searchWord = Console.ReadLine();

            Console.WriteLine("Where to search? 'sample' to use sample text instead.");
            string directoryPath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(directoryPath) || (!Directory.Exists(directoryPath) && directoryPath != "sample"))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            Console.WriteLine("How many results?");
            int resultsAmount;
            if (!int.TryParse(Console.ReadLine(), out resultsAmount))
            {
                Console.WriteLine("Invalid amount of results!");
                return;
            }
            //directoryPath = "C:\\z_Personal\\SipiccoRepos\\HelloWord\\SampleTextFiles"; // for quick testing

            var service = new searchService();

            var wordScoreDict = service.FindWord(directoryPath, searchWord, resultsAmount);

            Console.WriteLine("--- RESULTS ---");
            foreach (var (word, score) in wordScoreDict)
            {
                Console.WriteLine($"""
                '{word}' with Total score: {score.TotScore}
                --- Length score: {score.LengthScore}
                --- Casing score: {score.CasingScore}
                --- Order score: {score.OrderScore}
        
                """);
            }

            string searchAgain;
            do
            {
                Console.WriteLine("Search again? (Y/N)");
                searchAgain = Console.ReadLine()?.ToUpper() ?? "";
            }
            while (searchAgain != "Y" && searchAgain != "N");

            if (searchAgain == "N")
            {
                Console.WriteLine("Thanks for searching!");
                keepRunning = false;
            }
        }

    }
}