using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stretch: Random scripture from a library
            var scriptureList = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), 
                    "For God so loved the world that he gave his only begotten Son"),
                new Scripture(new Reference("Proverbs", 3, 5, 6), 
                    "Trust in the Lord with all thine heart and lean not unto thine own understanding"),
                new Scripture(new Reference("2 Nephi", 2, 25), 
                    "Adam fell that men might be and men are that they might have joy")
            };

            Random rand = new Random();
            var scripture = scriptureList[rand.Next(scriptureList.Count)];

            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    return;

                scripture.HideRandomWords(3); // Hides 3 visible words each round
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\nAll words are now hidden");
            AnimateDots(3);
            Console.WriteLine("\nWell done!");
        }

        static void AnimateDots(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }

    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide() => _isHidden = true;

        public bool IsHidden() => _isHidden;

        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }

    class Reference
    {
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int _verseEnd;

        public Reference(string book, int chapter, int verseStart)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseStart;
        }

        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        public string GetDisplayText()
        {
            return _verseStart == _verseEnd
                ? $"{_book} {_chapter}:{_verseStart}"
                : $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
    }

    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        public void HideRandomWords(int count)
        {
            Random rand = new Random();
            var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            foreach (var word in visibleWords.OrderBy(_ => rand.Next()).Take(count))
                word.Hide();
        }

        public string GetDisplayText()
        {
            return _reference.GetDisplayText() + "\n" +
                   string.Join(" ", _words.Select(w => w.GetDisplayText()));
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}