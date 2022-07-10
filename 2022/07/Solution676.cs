using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 676
    /// title: 实现一个魔法字典
    /// problems: https://leetcode.cn/problems/implement-magic-dictionary/
    /// date: 20220711
    /// </summary>
    public static  class Solution676
    {
        public class MagicDictionary {
            private Trie _trie;

            public MagicDictionary() {
                _trie = new();
            }
            
            public void BuildDict(string[] dictionary) {
                foreach(var word in dictionary){
                    var cur = _trie;
                    foreach(var c in word){
                        var index = c - 'a';
                        if(cur.Child[index] == null)
                            cur.Child[index] = new Trie();
                        
                        cur = cur.Child[index];
                    }

                    cur.HasValue = true;
                }
            }
            
            public bool Search(string searchWord) {
                return DFS(searchWord, _trie, 0, false);
            }

            private bool DFS(string searchWord, Trie node, int pos, bool modified){
                if(pos ==  searchWord.Length)
                    return modified && node.HasValue;
                
                var index = searchWord[pos] - 'a';
                if(node.Child[index] != null){
                    if(DFS(searchWord, node.Child[index], pos + 1, modified))
                        return true;
                }
                
                if(!modified){
                    if(Enumerable.Range(0, 26)
                                .Where(i => i != index && node.Child[i] != null)
                                .Any(i => DFS(searchWord, node.Child[i], pos + 1, true)))
                        return true;
                }

                return false;
            }
        }

        public class Trie {
            public bool HasValue { get; set; } = false;
            public Trie[] Child { get; set; } = new Trie[26];
        }
    }
}