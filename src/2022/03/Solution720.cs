namespace LeetCodeNote
{
    /// <summary>
    /// no: 720
    /// title: 词典中最长的单词
    /// problems: https://leetcode-cn.com/problems/longest-word-in-dictionary/
    /// date: 20220317
    /// </summary>
    public static class Solution720
    {
        

        public static string LongestWord(string[] words) {
            Trie trie = new Trie();
            foreach (string word in words) {
                trie.Insert(word);
            }
            string longest = "";
            foreach (string word in words) {
                if (trie.Search(word)) {
                    if (word.Length > longest.Length || (word.Length == longest.Length && word.CompareTo(longest) < 0)) {
                        longest = word;
                    }
                }
            }
            return longest;
        }

        class Trie {
            public Trie[] Children { get; set; }
            public bool IsEnd { get; set; }

            public Trie() {
                Children = new Trie[26];
                IsEnd = false;
            }
            
            public void Insert(string word) {
                Trie node = this;
                for (int i = 0; i < word.Length; i++) {
                    char ch = word[i];
                    int index = ch - 'a';
                    if (node.Children[index] == null) {
                        node.Children[index] = new Trie();
                    }
                    node = node.Children[index];
                }
                node.IsEnd = true;
            }
            
            public bool Search(string word) {
                Trie node = this;
                for (int i = 0; i < word.Length; i++) {
                    char ch = word[i];
                    int index = ch - 'a';
                    if (node.Children[index] == null || !node.Children[index].IsEnd) {
                        return false;
                    }
                    node = node.Children[index];
                }
                return node != null && node.IsEnd;
            }
        }

    }
}