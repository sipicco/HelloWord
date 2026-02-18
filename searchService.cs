


namespace HelloWord
{
    internal class searchService
    {
        internal List<string> foundWords = new();

        string myText = "public static bool RectangleContains(Rectangle rect, Vector2 point) " +
            "{return point.X >= rect.X && point.X <= rect.X + rect.Width && " +
            "point.Y >= rect.Y && point.Y <= rect.Y + rect.Height; }";

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

        internal Dictionary<string, WordScore> FindWord(string text, string searchWord)
        {
            Dictionary<string, WordScore> scoreDict = new();
            int i = 0;
            string currWord = "";

            while (i < text.Length) //&& scoreDict.Keys.Count < 3
            {
                if (!char.IsLetterOrDigit(text[i]))
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
                    currWord += text[i];
                    i++;
                }
            }
            return scoreDict.OrderByDescending(kvp => kvp.Value.TotScore).ToDictionary();
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
            return i; // 1 point for each letter in correct order
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
