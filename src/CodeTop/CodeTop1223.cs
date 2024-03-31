using System;
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 1223
    /// title:  删除子文件夹
    /// problems: https://leetcode.cn/problems/remove-sub-folders-from-the-filesystem/
    /// date: 20220519
    /// priority: 0089
    /// time: 00:25:44.87
    /// </summary>
    public static class CodeTop1223
    {
        public static IList<string> RemoveSubfolders(string[] folder) {
            Array.Sort(folder);

            var keyMap = new Dictionary<string, int>();
            var result = new List<string>();
            int index = 0;
            
            IEnumerable<int> GetKeys(string s){
                foreach(var key in s.Split("/")){
                    if(!keyMap.ContainsKey(key))
                        keyMap.Add(key, index++);
                    
                    yield return keyMap[key];
                }
            }

            var trie = new Trie();

            foreach(var f in folder){
                if(trie.TryAdd(GetKeys(f)))
                    result.Add(f);
            }

            return result;
        }

        public class Trie
        {
            public Dictionary<int, Trie> Children;

            public bool HasValue;

            public Trie()
            {
                Children = new Dictionary<int, Trie>();
            }

            public bool TryAdd(IEnumerable<int> keys){
                var cur = this;
                
                foreach(var key in keys){
                    if(cur.HasValue)
                        return false;
                    
                    if(!cur.Children.ContainsKey(key))
                        cur.Children.Add(key, new Trie());
                    
                    cur = cur.Children[key];
                }

                if(cur.HasValue)
                    return false;
                
                cur.HasValue = true;
                return true;
            }
        }
    }
}