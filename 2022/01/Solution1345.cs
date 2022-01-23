using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1345
    /// title: 跳跃游戏 IV
    /// problems: https://leetcode-cn.com/problems/jump-game-iv/
    /// date: 20220121
    /// </summary>
    public static class Solution1345
    {
        public static int MinJumps(int[] arr) {
            var dic = new Dictionary<int, IList<int>>();
            for (int i = 0; i < arr.Length; i++) {
                if (!dic.ContainsKey(arr[i])) 
                    dic.Add(arr[i], new List<int>());
                
                dic[arr[i]].Add(i);
            }

            var visted = new HashSet<int>();
            var queue = new Queue<(int Index, int Step)>();
            queue.Enqueue((0, 0));
            visted.Add(0);
            while (queue.Count > 0) {
                var cur = queue.Dequeue();
                if (cur.Index == arr.Length - 1) 
                    return cur.Step;
                
                int value = arr[cur.Index];
                cur.Step++;

                if (dic.ContainsKey(value)) {
                    foreach (int i in dic[value]) {
                        if (visted.Add(i))
                            queue.Enqueue((i, cur.Step));
                    }

                    dic.Remove(value);
                }

                if (cur.Index + 1 < arr.Length && visted.Add(cur.Index + 1)) 
                    queue.Enqueue((cur.Index + 1, cur.Step));
                
                if (cur.Index - 1 >= 0 && visted.Add(cur.Index - 1)) 
                    queue.Enqueue((cur.Index - 1, cur.Step));
                
            }
            
            return 0;
        }
    }
}