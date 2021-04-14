namespace LeetCodeNote
{
    /// <summary>
    /// no: 208
    /// title: 实现 Trie (前缀树)
    /// problems: https://leetcode-cn.com/problems/implement-trie-prefix-tree/
    /// date: 20210414
    /// </summary>
    public static class Solution208
    {
        public class Trie {

            private Trie[] _children;

            private string _value;

            /** Initialize your data structure here. */
            public Trie() {
                _children = new Trie[26];
            }
            
            /** Inserts a word into the trie. */
            public void Insert(string word) {
                char[] chars = word.ToCharArray();
                Trie cur = this;
                foreach(var c in chars)
                {
                    int index = c - 'a';
                    if(cur._children[index] == null)
                        cur._children[index] = new Trie();

                    cur = cur._children[index];
                }

                cur._value = word;
            }
            
            /** Returns if the word is in the trie. */
            public bool Search(string word) {
                Trie trie = GetTrieNode(word);
                return trie != null && !string.IsNullOrEmpty(trie._value) ? true : false;
            }
            
            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix) {
                Trie trie = GetTrieNode(prefix);

                return  trie != null ? true : false;
            }

            private Trie GetTrieNode(string s)
            {
                char[] chars = s.ToCharArray();
                Trie cur = this;
                foreach(var c in chars)
                {
                    int index = c - 'a';
                    if(cur._children[index] == null)
                        return null;

                    cur = cur._children[index];
                }

                return cur;
            }
        }
    }
}