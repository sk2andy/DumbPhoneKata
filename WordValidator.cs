using System.Collections.Generic;
using System.Linq;

namespace CodingKata
{
    public static class WordValidator
    {
        private static readonly Dictionary<int, char[]> Rows = new Dictionary<int, char[]>
        {
            {1, new[] {'a', 'b', 'c', 'd', 'e', 'f', '1', '2', '3'}},
            {2, new[] {'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', '4', '5', '6'}},
            {3, new[] {'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '7', '8', '9'}},
            {4, new[] {'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', '*', '0', '#', ' '}},
        };

        private static readonly Dictionary<int, char[]> Cols = new Dictionary<int, char[]>
        {
            {1, new[] {'1', '4', '7', '*', 'g', 'h', 'i', 'p', 'q', 'r', 's'}},
            {2, new[] {'a', 'b', 'c', 'j', 'k', 'l', 't', 'u', 'v', '0', ' ', '2', '5', '8'}},
            {3, new[] {'d', 'e', 'f', 'm', 'n', 'o', 'w', 'x', 'y', 'z', '3', '6', '9', '#'}},
        };


        public static bool Validate(string word)
        {
            word = word.ToLower();

            for (var i = 0; i < word.Length - 1; i++)
            {
                if (!IsOnSameCol(word[i], word[i + 1]) && !IsOnSameRow(word[i], word[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsOnSameRow(char letterA, char letterB) => HasSameKeyInDict(letterA, letterB, Rows);
        private static bool IsOnSameCol(char letterA, char letterB) => HasSameKeyInDict(letterA, letterB, Cols);

        private static bool HasSameKeyInDict(char letterA, char letterB, Dictionary<int, char[]> dict)
        {
            return dict.FirstOrDefault(x => x.Value.Contains(letterA)).Key ==
                   dict.FirstOrDefault(x => x.Value.Contains(letterB)).Key;
        }
    }
}