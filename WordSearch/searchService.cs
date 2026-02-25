namespace HelloWord.WordSearch
{
    internal class searchService
    {
        // How to efficiently parse large text files ???
        // Multiple files (many) on a folder to search
        // How large?? -> nvm, just read all of them
        // How many?? -> nvm, just read all of them

        // Filter only files that actually contains code (.cs)
        // Filter by extension of the filename

        // 3 best matches -> scoring system?
        // search "RC"

        // -- Case + order + length -> exact match
        // RC

        // -- Case + order -> substring
        // RCSystem
        // ARC_RAIDERS

        // -- Case + length
        // CR

        // -- Case only
        // ReallyCoolStuff

        // -- Partial match
        // ReallyBadStuff

        private static string _sampleText = "RC Rc rc RCSystem ARC_RAIDERS CR ReallyCoolStuff really_cool_stuff ReallyBadStuff really_bad_stuff";
        private static string _sampleTextFilename = "SampleTextFile";


        internal Dictionary<string, WordScore> FindWord(string directoryPath, string searchWord, int resultsAmount)
        {

            var filesDict = new Dictionary<string, string>(); // <fileName, fileContentString>
            Dictionary<string, WordScore> scoreDict = new(); // <foundWord, score>

            PopulateFilesDict(directoryPath, filesDict);
            ProcessFilesDict(searchWord, filesDict, scoreDict);

            return scoreDict
                .OrderByDescending(kvp => kvp.Value.TotScore)
                .Take(resultsAmount)
                .ToDictionary();
        }

        private static void PopulateFilesDict(string directoryPath, Dictionary<string, string> fileDict)
        {
            if (directoryPath == "sample")
            {
                Console.WriteLine($"Using sample text: {_sampleText}");
                fileDict[_sampleTextFilename] = _sampleText;
            }
            else
            {
                foreach (string filePath in Directory.GetFiles(directoryPath))
                {
                    try
                    {
                        string fileName = Path.GetFileName(filePath);
                        string content = File.ReadAllText(filePath);

                        fileDict[fileName] = content;
                        Console.WriteLine($"Loaded: {fileName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading {Path.GetFileName(filePath)}: {ex.Message}");
                    }
                }
            }

            Console.WriteLine();
        }

        private void ProcessFilesDict(string searchWord, Dictionary<string, string> filesDict, Dictionary<string, WordScore> scoreDict)
        {
            foreach ((string fileName, string fileText) in filesDict)
            {
                if (!fileName.EndsWith(".cs") && fileName != _sampleTextFilename) { continue; } // only look at code files

                int i = 0;
                string currWord = "";

                while (i < fileText.Length)
                {
                    if (!char.IsLetterOrDigit(fileText[i]))
                    {
                        var score = ScoreWord(searchWord, currWord);
                        if (score.TotScore > 0)
                        {
                            scoreDict[currWord] = score;
                        }
                        i++;
                        currWord = "";
                    }
                    else
                    {
                        currWord += fileText[i];
                        i++;
                    }
                }
            }
        }

        private WordScore ScoreWord(string searchWord, string wordToScore)
        {
            // wordToScore contains none of the letters from searchWord -> return 0
            if (!searchWord.ToCharArray().Any(c => wordToScore.Contains(c, StringComparison.OrdinalIgnoreCase))) { return new WordScore(0, 0, 0, 0); }

            // length
            int lengthScore = searchWord.Length == wordToScore.Length
                ? 3
                : 0;

            // Case
            int casingScore = ScoreCasing(searchWord, wordToScore);

            // Order
            int orderScore = ScoreOrder(searchWord, wordToScore);

            int totScore = lengthScore + casingScore + orderScore;

            return new WordScore(totScore, lengthScore, casingScore, orderScore);
        }

        private int ScoreOrder(string searchWord, string wordToScore)
        {
            // sq
            // '
            // using
            //  '
            int i = 0;
            int j = 0;

            while (i < searchWord.Length && j < wordToScore.Length)
            {
                if (wordToScore[j] == searchWord[i])
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                }
            }
            return i == searchWord.Length
                ? i // 1 point for each letter in correct order
                : 0;
        }

        private int ScoreCasing(string searchWord, string wordToScore)
        {
            // ReallyCool ->    4 pts
            // Reallycool ->    3 pts
            // ReallyBad ->     2 pts
            // reallycool ->    2 pts
            // reallybad ->     1 pt

            int caseScore = 0;
            foreach (char c in searchWord)
            {
                if (!wordToScore.Contains(c, StringComparison.OrdinalIgnoreCase)) { continue; }

                if (wordToScore.Contains(c, StringComparison.Ordinal))
                {
                    caseScore += 2;
                }
                else
                {
                    // char is there, but with different case
                    caseScore += 1;
                }
            }
            return caseScore;
        }


    }
}
