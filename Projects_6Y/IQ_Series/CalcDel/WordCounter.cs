using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalcDel
{
    public static class WordCounter
    {
        public static int Counter(string Sentence, string word)
        {
            return Regex.Matches(Regex.Escape(Sentence), word).Count;
        }

        public static int UsingLINQ(string Sentence, string word)
        {
            string[] splitdata = Sentence.Split(' ');
            var results = from p in splitdata
                          where p.Contains(word)
                          select p;

            return results.Count();

        }
    }
}
