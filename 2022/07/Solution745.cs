using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 745
    /// title: 前缀和后缀搜索
    /// problems: https://leetcode.cn/problems/prefix-and-suffix-search/
    /// date: 20220714
    /// </summary>
    public static class Solution745
    {
        // 参考解答 
        // 字典树 + 组合key
        public class WordFilter {

            private Trie _trie;
            public WordFilter(string[] words) {
                _trie = new();
                for(int i = words.Length - 1; i >= 0; i--){
                    var word = words[i];
                    var cur = _trie;
                    (char, char) key;
                    int m = word.Length;
                    for(int j = 0; j < m; j++){
                        var tmp = cur;
                        for(int k = j; k < m; k++){
                            key = (word[k], '#');
                            if(!tmp.Children.ContainsKey(key))
                                tmp.Children.Add(key, new Trie());
                            
                            tmp = tmp.Children[key];
                            if(!tmp.Index.HasValue)
                                tmp.Index = i;
                        }
                        
                        tmp = cur;
                        for(int k = j; k < m; k++){
                            key = ('#', word[m - k - 1]);
                            if(!tmp.Children.ContainsKey(key))
                                tmp.Children.Add(key, new Trie());
                            
                            tmp = tmp.Children[key];
                            if(!tmp.Index.HasValue)
                                tmp.Index = i;
                        }

                        key = (word[j],word[m - j - 1]);
                        if(!cur.Children.ContainsKey(key))
                            cur.Children.Add(key, new Trie());
                        
                        cur = cur.Children[key];
                        if(!cur.Index.HasValue)
                            cur.Index = i;
                    }
                }
            }
            
            public int F(string pref, string suff) {
                var cur = _trie;
                int pLen = pref.Length;
                int sLen = suff.Length;
                int m = Math.Max(pLen, sLen);
                for(int i = 0; i < m; i++){
                    var pChar = i < pLen ? pref[i] : '#';
                    var sChar = i < sLen ? suff[sLen - 1 - i] : '#';
                    var key = (pChar, sChar);

                    if(!cur.Children.ContainsKey(key))
                        return -1;
                    
                    cur = cur.Children[key];
                }

                return cur.Index.Value;
            }
        }

        public class Trie {
            public Dictionary<(char Pref, char Suff), Trie> Children;
            public int? Index;

            public Trie() {
                Children = new();
            }
        }
    }
}