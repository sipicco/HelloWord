namespace HelloWord.WordSearch
{
    internal class WordScore
    {
        public WordScore(int totScore, int lengthScore, int casingScore, int orderScore)
        {
            TotScore = totScore;
            LengthScore = lengthScore;
            CasingScore = casingScore;
            OrderScore = orderScore;
        }

        public int TotScore { get; set; }
        public int LengthScore { get; set; }
        public int CasingScore { get; set; }
        public int OrderScore { get; set; }
    }
}