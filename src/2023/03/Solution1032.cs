using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1632
    /// title: 字符流
    /// problems: https://leetcode.cn/problems/stream-of-characters/
    /// date: 20230324
    /// </summary>
    public static class Solution1032
    {
        // 参考解答
        // 字典树想得到
        // AC自动机的构建想不到
        public class StreamChecker {
            private TrieNode _root;
            private TrieNode _temp;

            public StreamChecker(string[] words) {
                _root = new TrieNode();
                foreach(var word in words){
                    var cur = _root;
                    foreach(var ch in word){
                        int index = ch - 'a';
                        if(cur[index] == null)
                            cur[index] = new TrieNode();
                        
                        cur = cur[index];
                    }

                    cur.IsEnd = true;
                }
                _root.Fail = _root;

                var queue = new Queue<TrieNode>();
                for(int i = 0; i < 26; i++){
                    if(_root[i] != null){
                        _root[i].Fail = _root;
                        queue.Enqueue(_root[i]);
                    }else{
                        _root[i] = _root;
                    }
                }

                while(queue.Count > 0){
                    var node = queue.Dequeue();
                    node.IsEnd = node.IsEnd || node.Fail.IsEnd;
                    for(int i = 0; i < 26; i++){
                        if(node[i] != null){
                            node[i].Fail = node.Fail[i];
                            queue.Enqueue(node[i]);
                        }else{
                            node[i] = node.Fail[i];
                        }
                    }
                }

                _temp = _root;
            }

            
            public bool Query(char letter) {
                _temp = _temp[letter - 'a'];
                return _temp.IsEnd;
            }
        }

        public class TrieNode {
            public TrieNode[] Children { get; set; }
            public bool IsEnd { get; set;}
            public TrieNode Fail { get; set; }

            public TrieNode() {
                Children = new TrieNode[26];
            }

            public TrieNode this[int index]
            {
                get => Children[index];
                set => Children[index] = value;
            } 
        }
    }
}