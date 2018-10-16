using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write
{
    class Word
    {
        public Word left;
        public Word right;
        public string value;
        public int CompareValue()
        {
            return value.Length;
        }
        public Word()
        {
            
        }
        public Word(string value)
        {
            this.value = value;
        }
    }
}
