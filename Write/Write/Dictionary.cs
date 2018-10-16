using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write
{
    class Dictionary
    {
        public Word Head;
        
        public Dictionary()
        {
            Head = new Word();
        }
        
        public void Add(string value)
        {
            Word currentword = Head;
            Word previous = null;
            while(currentword!=null && currentword.value!=null)
            {
                if (value.Length >= currentword.value.Length)
                {
                    previous = currentword;
                    currentword = currentword.right;
                }
                else
                {
                    previous = currentword;
                    currentword = currentword.left;
                }
            }
            if (previous != null)
            {
                if (value.Length >= previous.value.Length)
                {
                    previous.right = new Word(value);
                }
                else
                {
                    previous.left = new Word(value);
                }
            }
            else
            {
                currentword.value = value;
            }
        }
        public Word Search(string key, Word currentword)
        {
            if(currentword == null)
            {
                return null;
            }
            if (key.Length>=currentword.value.Length)
            {
                var a = Search(key, currentword.right);
                if(a != null)
                {
                    return a;
                }
            }
            else
            {
                var a = Search(key, currentword.left);
                if(a != null)
                {
                    return a;
                }
            }
            if(key == currentword.value)
            {
                return currentword;
            }
            return null;
        }
        public Word Search(string key)
        {
            Word currentword = Head;
            while(currentword!=null&&currentword.value!=null)
            {
                if(currentword.value == key)
                {
                    return currentword;
                }
                if (key.Length >= currentword.value.Length)
                {
                    currentword = currentword.right;
                }
                else
                {
                    currentword = currentword.left;
                }
            }
            return null;
        }
    }
}
