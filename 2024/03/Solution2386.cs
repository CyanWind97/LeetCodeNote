using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2386
/// title: 受限条件下可到达节点的数目
/// problems: https://leetcode.cn/problems/reachable-nodes-with-restrictions/description/?envType=daily-question&envId=2024-03-02
/// date: 20240302
/// </summary> 
public static class Solution2386
{
    public static int ReachableNodes(int n, int[][] edges, int[] restricted) {
        var result = 0;
        var graph = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var visited = new bool[n];
        foreach (var edge in edges){
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        foreach (var node in restricted){
            visited[node] = true;
        }

        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Count > 0){
            var current = queue.Dequeue();
            if (visited[current])
                continue;
            
            visited[current] = true;
            result++;
            foreach (var neighbor in graph[current].Where(neighbor => !visited[neighbor])){
                queue.Enqueue(neighbor);
            }
        }

        return result;
    }
}
