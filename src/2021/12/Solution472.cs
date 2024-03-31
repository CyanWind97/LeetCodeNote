using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 472
    /// title: 连接词
    /// problems: https://leetcode-cn.com/problems/concatenated-words/
    /// date: 20211228
    /// </summary>
    public static class Solution472
    {
        /// 参考解答 + 深度优先搜索
        public static IList<string> FindAllConcatenatedWordsInADict(string[] words) {
            Trie trie = new Trie();
            IList<string> ans = new List<string>();

            bool DFS(string word, int start) {
                if (word.Length == start) 
                    return true;
                
                Trie node = trie;
                for (int i = start; i < word.Length; i++) {
                    char ch = word[i];
                    int index = ch - 'a';
                    node = node.children[index];
                    if (node == null)
                        return false;
                    
                    if (node.isEnd && DFS(word, i + 1)) 
                        return true;
                        
                }
                return false;
            }

            void Insert(string word) {
                Trie node = trie;
                for (int i = 0; i < word.Length; i++) {
                    char ch = word[i];
                    int index = ch - 'a';
                    if (node.children[index] == null) 
                        node.children[index] = new Trie();
                    
                    node = node.children[index];
                }
                node.isEnd = true;
            }

            Array.Sort(words, (a, b) => a.Length - b.Length);
            for (int i = 0; i < words.Length; i++) {
                string word = words[i];
                if (word.Length == 0) 
                    continue;
                
                if (DFS(word, 0)) 
                    ans.Add(word);
                else 
                    Insert(word);
            }
            return ans;
        }

        class Trie {
            public Trie[] children;
            public bool isEnd;

            public Trie() {
                children = new Trie[26];
                isEnd = false;
            }
        }

    }
}