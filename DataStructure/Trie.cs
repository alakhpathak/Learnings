using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class TrieNode
    {
        private const int ALPHABET_SIZE = 26;
        public TrieNode(char data)
        {
            Childrens = new TrieNode[ALPHABET_SIZE];
            IsEnd = false;
            Data = data;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                Childrens[i] = null;
        }
        public char Data { get; set; }
        public bool IsEnd { get; set; }
        public TrieNode[] Childrens { get; set; }
    }

    public class Trie
    {
        public TrieNode Root { get; set; }

        public Trie()
        {
            Root = new TrieNode(' ');
        }
        public void Insert(string data)
        {
            TrieNode p = Root;
            int index;
            for (int i = 0; i < data.Length; i++)
            {
                index = data[i] - 'a';
                if (p.Childrens[index] == null)
                {
                    p.Childrens[index] = new TrieNode(data[i]);
                }
                p = p.Childrens[index];
            }
            p.IsEnd = true;
        }

        public bool Search(string data)
        {
            TrieNode p = Root;
            int index;

            for (int i = 0; i < data.Length; i++)
            {
                index = data[i] - 'a';
                if (p.Childrens[index] == null)
                {
                    return false;
                }
                p = p.Childrens[index];
            }
            return (p != null && p.IsEnd);
        }
    }
}
