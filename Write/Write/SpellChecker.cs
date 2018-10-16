using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write
{
    class SpellChecker
    {
        public Dictionary dic;
        public string language;
        public SpellChecker(string language)
        {
            this.language = language;
            dic = new Dictionary();
            LoadToDic(language, dic);
        }
        public void LoadToDic(string language,Dictionary dic)
        {
            string loadfrom = Environment.CurrentDirectory + "\\" + language + ".dic";
            string[] words = File.ReadAllLines(loadfrom);
            for(int i = 0; i <words.Length; i++)
            {
                dic.Add(ProcessWord(words[i]));
            }
        }
        public string Correct(string value)
        {
            string output="|";
            string[] tocorrect = Split(value);
            for(int i = 0; i < tocorrect.Length; i++)
            {
                Word word = dic.Search(ProcessWord(tocorrect[i]));
                if(word==null && tocorrect[i]!="")
                {
                    output += ProcessWord( tocorrect[i] )+ ", on word "+ i.ToString() +", is not a valid word. Consider revising|";
                }
            }
            output += "Proffing Complete|";
            return output;
        }
        public string[] Split(string senetence)
        {
            if (!senetence.EndsWith(".") && !senetence.EndsWith("?") && senetence.EndsWith("!"))
            {
                senetence += " ";
            }
            List<string> words = new List<string>();
            string temp = "";
            for(int i = 0; i < senetence.Length; i++)
            {
                if (senetence[i] == '.' || senetence[i] == '!' || senetence[i] == ' ' || senetence[i] == '?' || senetence[i] == '"' || senetence[i] == ',')
                {
                    if (senetence[i - 1] == '.' || senetence[i - 1] == '!' || senetence[i - 1] == ' ' || senetence[i - 1] == '?' || senetence[i - 1] == '"' || senetence[i - 1] == ',')
                    {

                    }
                    else
                    {
                        words.Add(temp);
                        temp = "";
                    }
                }
                else
                {
                    temp += senetence[i];
                }
            }
            return words.ToArray();
        }
        public void Add(string add)
        {
            dic.Add(add);
        }
        public string ProcessWord(string inp)
        {
            string word = inp;
            word = Replace(word, " ", "");
            word = Replace(word, "\r\n", "");
            word = Replace(word, "\n", "");
            string killchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string repchars = "abcdefghijklmnopqrstuvwxyz";
            for(int i = 0; i < killchars.Length; i++)
            {
                word = Replace(word, killchars[i].ToString(), repchars[i].ToString());
            }
            return word;
        }
        private string Replace(string inp, string a, string b)
        {
            while(inp.Contains(a))
            {
                inp = inp.Replace(a, b);
            }
            return inp;
        }
    }
}
