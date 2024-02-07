using Coding.Exercise;
using System;
using System.Text;

// Sentence sentence = new Sentence("hello world");
// sentence[1].Capitalize = true;
// Console.WriteLine(sentence); // writes "hello WORLD"

namespace Coding.Exercise
{
    public class Sentence
    {
        private string[] _words;
        private WordToken[] _wordTokens;

        public Sentence(string plainText)
        {
            _words = plainText.Split(' ');
            _wordTokens = new WordToken[_words.Length];

            for (int i = 0; i < _wordTokens.Length; i++)
            {
                _wordTokens[i] = new WordToken() { Capitalize = false };
            }
        }

        public WordToken this[int index]
        {
            get
            {
                return _wordTokens[index];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _words.Length; i++)
            {
                string word = _words[i];
                if (_wordTokens[i].Capitalize)
                {
                    sb.Append(word.ToUpper());
                }
                else
                {
                    sb.Append(word);
                }
                sb.Append(' ');
            }
            return sb.ToString().Trim();
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}