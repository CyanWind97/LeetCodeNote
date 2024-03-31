using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 211
    /// title: 添加与搜索单词 - 数据结构设计
    /// problems: https://leetcode-cn.com/problems/design-add-and-search-words-data-structure/
    /// date: 20211019
    /// </summary>

    public static class Solution211
    {
        public class WordDictionary {
            public bool HasValue;

            public WordDictionary[] Children;

            public WordDictionary() {
                Children = new WordDictionary[26];
                HasValue = false;
            }
            
            public void AddWord(string word) {
                var cur = this;
                
                foreach(var c in word){
                    int index = c - 'a';
                    if(cur.Children[index] == null)
                        cur.Children[index] = new WordDictionary();
                    
                    cur = cur.Children[index];
                }

                cur.HasValue = true;
            }
            
            public bool Search(string word) {
                var chars = word.ToCharArray();
                int length = chars.Length;
            

                bool Search(WordDictionary dic, int index){
                    if(index == length)
                        return dic.HasValue;

                    var key = chars[index];

                    if (key == '.')
                        return dic.Children.Any(node => node != null && Search(node, index + 1));
                    
                    int keyIndex = key - 'a';
                    if (dic.Children[keyIndex] == null)
                        return false;
                
                    return Search(dic.Children[keyIndex], index + 1);
                }

                return Search(this, 0);
            }

        }
    }
}