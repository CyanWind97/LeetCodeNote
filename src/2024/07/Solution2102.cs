using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2102
/// title: 引爆最多的炸弹
/// problems: https://leetcode.cn/problems/detonate-the-maximum-bombs
/// date: 20240722
/// </summary>
public static class Solution2102
{
    public static int MaximumDetonation(int[][] bombs) {
        int n = bombs.Length;
        var g = Enumerable.Range(0, n)
                    .Select(_ => new List<int>())
                    .ToArray();

        bool CanDetonate(int i, int j){
            long dx = bombs[i][0] - bombs[j][0];
            long dy = bombs[i][1] - bombs[j][1];
            long r = bombs[i][2];

            return dx * dx + dy * dy <= r * r;
        }

        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                if (i != j &&  CanDetonate(i, j))
                    g[i].Add(j);
            }
        }

        var result = 0;
        for(int i = 0; i < n; i++){
            var visited = new bool[n];
            var queue = new Queue<int>();
            queue.Enqueue(i);
            visited[i] = true;
            int count = 1;

            while(queue.Count > 0){
                var cur = queue.Dequeue();
                foreach(var next in g[cur]){
                    if(visited[next])
                        continue;
                    
                    visited[next] = true;
                    count++;
                    queue.Enqueue(next);
                }
            }

            result = Math.Max(result, count);
        }

        return result;
    }
}
