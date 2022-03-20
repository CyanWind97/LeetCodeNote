using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 432
    /// title: 全 O(1) 的数据结构
    /// problems: https://leetcode-cn.com/problems/all-oone-data-structure/
    /// date: 20220316
    /// </summary>
    public static class Solution432
    {
        // 参考解答 双向链表
        public class AllOne {
            
            class Node {
                public int Count { get; set; } = 1;
                public HashSet<string> Keys = new();
            }

            
            private LinkedList<Node> _list;

            private Dictionary<string, LinkedListNode<Node>> _lookup;

            public AllOne() {
                _list = new();
                _lookup = new();
            }
            
            public void Inc(string key) {
                if (_lookup.ContainsKey(key)){
                    var cur = _lookup[key];

                    if(cur.Next?.Value?.Count ==  cur.Value.Count + 1){
                        cur.Next.Value.Keys.Add(key);
                    }else{
                        var node = new Node()
                        {
                            Count = cur.Value.Count + 1,
                            Keys = new() {key},
                        };

                        _list.AddAfter(cur, node);
                    }

                    _lookup[key] = cur.Next;

                    cur.Value.Keys.Remove(key);
                    if(cur.Value.Keys.Count == 0)
                        _list.Remove(cur);
                }else{
                    if(_list.First?.Value?.Count != 1)
                        _list.AddFirst(new Node());

                    _list.First.Value.Keys.Add(key);
                    _lookup[key] = _list.First;
                }
                
            }
            
            public void Dec(string key) {
                var cur = _lookup[key];
                cur.Value.Keys.Remove(key);

                if(cur.Previous?.Value?.Count == cur.Value.Count - 1){
                    cur.Previous.Value.Keys.Add(key);
                }else if(cur.Value.Count > 1){
                    var node = new Node()
                    {
                        Count = cur.Value.Count - 1,
                        Keys = new() { key },
                    };
                    _list.AddBefore(cur, node);
                }

                if(cur.Previous == null)
                    _lookup.Remove(key);
                else
                    _lookup[key] = cur.Previous;
                
                if(cur.Value.Keys.Count == 0)
                    _list.Remove(cur);
            }
            
            public string GetMaxKey()
                => _list.Last?.Value?.Keys.FirstOrDefault() ?? "";
            
            public string GetMinKey() 
                =>  _list.First?.Value?.Keys.FirstOrDefault() ?? "";
        }

    }
}