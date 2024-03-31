using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 114
    /// title: 外星文字典
    /// problems: https://leetcode-cn.com/problems/er-jin-zhi-zhong-1de-ge-shu-lcof/
    /// date: 20220531
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution_lcof_114
    {
        // 参考解答 拓扑排序
        // 想到了拓扑排序 没想清楚怎么构建图
        public static string AlienOrder(string[] words) {
            const int VISITING = 1, VISITED = 2;
            var edges = new Dictionary<char, IList<char>>();
            var states = new Dictionary<char, int>();
            var valid = true;
            
            int length = words.Length;


            #region Init
            foreach(var word in words){
                foreach(char c in word){
                    if(!edges.ContainsKey(c))
                        edges.Add(c, new List<char>());
                }
            }

            void AddEdge(string before, string after){
                int l1 = before.Length;
                int l2 = after.Length;
                int l = Math.Min(l1, l2);
                int index = 0;
                while(index < l){
                    var c1 = before[index];
                    var c2 = after[index];
                    if(c1 != c2){
                        edges[c1].Add(c2);
                        break;
                    }
                    index++;
                }

                if(index == l && l1 > l2)
                    valid = false;
            }

            for(int i = 1; i < length && valid; i++){
                AddEdge(words[i - 1], words[i]);
            }
            #endregion
            
            var order = new char[edges.Count];
            var index = edges.Count - 1;
            
            void DFS(char u){
                states.Add(u, VISITING);
                foreach(var v in edges[u]){
                    if(!states.ContainsKey(v)){
                        DFS(v);
                        if(!valid)
                            return;
                    }else if(states[v] == VISITING){
                        valid = false;
                        return;
                    }
                }
                
                states[u] = VISITED;
                order[index] = u;
                index--;
            }

            foreach(var u in edges.Keys){
                if(!states.ContainsKey(u))
                    DFS(u);
            }

            if(!valid)
                return "";
            
            return new string(order);
        }
    }
}