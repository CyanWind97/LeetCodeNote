using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3249
/// title: 统计好节点的数目
/// problems: https://leetcode.cn/problems/count-the-number-of-good-nodes
/// date: 20241114
/// </summary>
public static class Solution3249
{
    public static int CountGoodNodes(int[][] edges){
        int n = edges.Length + 1;
        var g = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach(var edge in edges){
            g[edge[0]].Add(edge[1]);
            g[edge[1]].Add(edge[0]);
        }

        int result = 0;
        
        int DFS(int node, int parent){
            bool valid = true;
            int size = 0;
            int subSize = 0;
            foreach(var child in g[node]){
                if(child == parent)
                    continue;
                
                int curr = DFS(child, node);
                if (subSize == 0)
                    subSize = curr;
                else if(curr != subSize)
                    valid = false;
                
                size += curr;
            }

            if (valid)
                result++;
            
            return size + 1;
        }

        DFS(0, -1);
        return result;
    }
}
