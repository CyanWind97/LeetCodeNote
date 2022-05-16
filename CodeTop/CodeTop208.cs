using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 208
    /// title:  实现 Trie (前缀树)
    /// problems: https://leetcode.cn/problems/implement-trie-prefix-tree/
    /// date: 20220516
    /// priority: 0066
    /// time: 00:15:08.75
    /// </summary>  
    public static class CodeTop208
    {
        public class Trie {
            
            public bool HasValue { get; set; }

            public Trie[] Children { get; set; }

            public Trie() {
                Children = new Trie[26];
            }
            
            public void Insert(string word) {
                var node = GetNode(word);

                node.HasValue = true;
            }
            
            public bool Search(string word) {
                return GetNode(word).HasValue;
            }
            
            private Trie GetNode(string key){
                var cur = this;
                foreach(var c in key){
                    var cIndex = c - 'a';
                    
                    if(cur.Children[cIndex] == null)
                        cur.Children[cIndex] = new Trie();
                    
                    cur = cur.Children[cIndex];
                }

                return cur;
            }

            public bool StartsWith(string prefix) {
                var node = GetNode(prefix);
                
                return node.AnyHasValue();
            }

            private bool AnyHasValue(){
                return HasValue 
                    ? true 
                    : Children.Any(child => child?.AnyHasValue() == true);
            }
        }
    }
}