
namespace HelloWord
{
    internal class searchService
    {
        internal List<string> foundWords = new();


        string myText = "public static bool RectangleContains(Rectangle rect, Vector2 point) " +
            "{return point.X >= rect.X && point.X <= rect.X + rect.Width && " +
            "point.Y >= rect.Y && point.Y <= rect.Y + rect.Height; }";

        // RC -> RectangleContains method
        // rc -> rect


        internal List<string> FindWord(string text, string searchWord)
        {
            // is searchWord capital?
            bool capitalSearch = text.ToCharArray().Any(c => !char.IsUpper(c));

            // capitalSearch -> recognize methods

            var parts = text.Split(" ");
            int i = 0;

            while (foundWords.Count < 3 && i < parts.Count())
            {
                var part = parts[i];

                if (capitalSearch && !IsMethod(part))
                {
                    i++;
                    continue;
                }
                if (searchWord.All(c => part.Contains(c)))
                {
                    var fullSignature = part;

                    // expand left
                    for (int j = 1; j < 20; j++)
                    {
                        fullSignature = $"{parts[i - j]} " + fullSignature;

                        var test = parts[i - j];

                        if (IsAccessModifier(parts[i - j]))
                        {
                            break;
                        }
                    }
                    // expand right
                    for (int j = 1; j < 20; j++)
                    {
                        fullSignature = fullSignature + $" {parts[i + j]}";

                        var test = parts[i + j];

                        if (parts[i + j].Contains(")"))
                        {
                            break;
                        }
                    }


                    foundWords.Add(fullSignature);
                }
                i++;
            }
            return foundWords;
        }

        private bool IsAccessModifier(string s)
        {
            return s == "public" || s == "private" || s == "internal";
        }

        private bool IsMethod(string text)
        {
            bool startsCapital = char.IsUpper(text[0]);
            bool hasParenthesis = text.Contains("(");
            return startsCapital && hasParenthesis;
        }
    }
}
