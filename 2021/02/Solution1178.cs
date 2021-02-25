using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1178
    /// title: 猜字谜
    /// problems: https://leetcode-cn.com/problems/number-of-valid-words-for-each-puzzle/
    /// date: 20210226
    /// </summary>
    public static class Solution1178
    {
        // 参考解答 字典树
        public static IList<int> FindNumOfValidWords(string[] words, string[] puzzles) {
            int pLength = puzzles.Length;

            TrieNode root = new TrieNode();

            void Add(IEnumerable<char> chars){
                TrieNode cur = root;
                foreach(var c in chars){
                    int index = c - 'a';
                    if(cur.Children[index] == null)
                        cur.Children[index] = new TrieNode();
                    
                    cur = cur.Children[index];
                }
                cur.Freq++;
            }

            int Find(char[] chars, char required, TrieNode cur, int pos){
                if(cur == null)
                    return 0;
                
                if(pos == 7)
                    return cur.Freq;

                int result  = Find(chars, required, cur.Children[chars[pos] - 'a'], pos + 1);

                if(chars[pos] != required){
                    result += Find(chars, required, cur, pos + 1);
                }

                return result;
            }

            var list = new List<char[]>();
            foreach(var word in words)
            {
                var chars = word.Distinct();
                if(chars.Count() > 7)
                    continue;
                
                Add(chars.OrderBy(x => x));
            }

            
            List<int> result = new List<int>();
            foreach(var puzzle in puzzles){
                char[] chars = puzzle.ToCharArray();
                char required = chars[0];
                Array.Sort(chars);
                result.Add(Find(chars, required, root, 0));
            }

            return result;
        }

        public class TrieNode{
            public int Freq;
            public TrieNode[] Children;

            public TrieNode(){
                Freq = 0;
                Children = new TrieNode[26];
            }
        }
    }
}