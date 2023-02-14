using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1129
    /// title: 颜色交替的最短路径
    /// problems: https://leetcode.cn/problems/shortest-path-with-alternating-colors/
    /// date: 20230202
    /// </summary>
    public static class Solution1129
    {
        // 参考解答
        // 广度优先
        public static int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) {
            var next = new List<int>[n, 2];
            for(int i = 0; i < n; i++){
                next[i, 0] = new List<int>();
                next[i, 1] = new List<int>();
            }

            foreach(var edge in redEdges){
                next[edge[0], 0].Add(edge[1]);
            }

            foreach(var edge in blueEdges){
                next[edge[0], 1].Add(edge[1]);
            }

            var dist = new int[n, 2];
            for(int i = 0; i < n; i++){
                dist[i, 0] = dist[i, 1] = int.MaxValue;
            }

            var queue = new Queue<(int Node, int Color)>();
            dist[0, 0] = 0;
            dist[0, 1] = 0;

            queue.Enqueue((0, 0));
            queue.Enqueue((0, 1));
            while(queue.Count > 0){
                (int x, int t) = queue.Dequeue();
                foreach(var y in next[x, 1 - t]){
                    if(dist[y, 1 - t] != int.MaxValue)
                        continue;
                    
                    dist[y, 1 - t] = dist[x, t] + 1;
                    queue.Enqueue((y, 1 - t));
                }
            }

            var result = new int[n];
            for(int i = 0; i < n; i++){
                result[i] = Math.Min(dist[i, 0], dist[i, 1]);
                if(result[i] == int.MaxValue)
                    result[i] = -1;
            }

            return result;
        }
    }
}