using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2716
/// title:  图中的最长环
/// problems: https://leetcode.cn/problems/longest-cycle-in-a-graph
/// date: 20250329
/// </summary>
public static class Solution2360
{
    public static int LongestCycle(int[] edges) {
        int n = edges.Length;
        int maxCycleLength = -1;
        bool[] visited = new bool[n];
        
        for (int i = 0; i < n; i++) {
            if (visited[i]) continue;
            
            Dictionary<int, int> distance = new Dictionary<int, int>();
            int node = i;
            int steps = 0;
            
            // 继续遍历直到找到一个已访问的节点或者没有出边的节点
            while (node != -1 && !visited[node]) {
                visited[node] = true;
                distance[node] = steps;
                steps++;
                node = edges[node];
                
                // 如果遇到一个已经在当前路径中的节点，找到了一个环
                if (node != -1 && distance.ContainsKey(node)) {
                    maxCycleLength = Math.Max(maxCycleLength, steps - distance[node]);
                    break;
                }
            }
        }
        
        return maxCycleLength;
    }
}
