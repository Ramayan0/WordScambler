using System;
using WordScambler.Data;

namespace WordScambler.workers
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchWord(scrambledWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambleWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedScrambleWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchWord(scrambledWord, word));
                        }
                    }
                }
            }
            return matchedWords;
        }
        private MatchedWord BuildMatchWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
