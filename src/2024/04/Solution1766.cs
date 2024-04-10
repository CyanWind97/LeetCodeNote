using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1766
/// title: 互质树
/// problems: https://leetcode.cn/problems/tree-of-coprimes
/// date: 20240411
/// </summary>
public static class Solution1766
{
    public static int[] GetCoprimes(int[] nums, int[][] edges) {
        int n = nums.Length;
        var graph =  Enumerable.Range(0, n)
                        .Select(_ => new List<int>())
                        .ToArray();
        
        foreach (int[] edge in edges) {
            (int u, int v) = (edge[0], edge[1]);
            graph[u].Add(v);
            graph[v].Add(u);
        }

        var visited = new bool[n];
        var result = new int[n];
        var ancestors = new int[n];
        
        int GCD(int a, int b) { 
            while (b != 0) {
                (a, b) = (b, a % b);
            }

            return a;
        }
        
        var queue = new Queue<(int Node, int Ancestor)>();
        queue.Enqueue((0, -1));
        visited[0] = true;

        while(queue.Count > 0){
            var (node, parent) = queue.Dequeue();
            // 压缩路径
            ancestors[node] = parent != -1 && nums[node] == nums[parent] 
                            ? ancestors[parent] 
                            : parent;
            
            var ancestor = parent;
            while(ancestor != -1 ){
                if (nums[node] == nums[ancestor]
                && nums[node] != 1){
                    ancestor = result[ancestor];
                    break;
                }

                if (GCD(nums[node], nums[ancestor]) == 1){
                    break;
                }

                ancestor = ancestors[ancestor];
            }

            result[node] = ancestor;

            foreach (int child in graph[node]) {
                if (visited[child])
                    continue;
                
                queue.Enqueue((child, node));
                visited[child] = true;
            }
        }

        return result;
    }

    // DFS
    public static int[] GetCoprimes_1(int[] nums, int[][] edges) {
        int n = nums.Length;
        var graph =  Enumerable.Range(0, n)
                        .Select(_ => new List<int>())
                        .ToArray();
        
        foreach (int[] edge in edges) {
            (int u, int v) = (edge[0], edge[1]);
            graph[u].Add(v);
            graph[v].Add(u);
        }

        var gcds = Enumerable.Range(0, 51)
                    .Select(_ => new List<int>())
                    .ToArray();
        var tmp = Enumerable.Range(0, 51)
                    .Select(_ => new Stack<int>())
                    .ToArray();
        var result = Enumerable.Repeat(-1, n).ToArray();
        var dep = Enumerable.Repeat(-1, n).ToArray(); 

        int GCD(int a, int b) {
            while (b != 0) {
                (a, b) = (b, a % b);
            }

            return a;
        }

        for (int i =  1; i <= 50; i++){
            for(int j = 1; j <= 50; j++){
                if (GCD(i, j) == 1){
                    gcds[i].Add(j);
                }
            }
        }

        void DFS(int node, int depth){
            dep[node] = depth;
            foreach(var val in gcds[nums[node]]){
                if (tmp[val].Count == 0)
                    continue;
                
                var last = tmp[val].Peek();
                if (result[node] == -1 || dep[last] > dep[result[node]])
                    result[node] = last;
            }

            tmp[nums[node]].Push(node);

            foreach (int child in graph[node]){
                if (dep[child] == -1)
                    DFS(child, depth + 1);
            }

            tmp[nums[node]].Pop();
        }

        DFS(0, 1);

        return result;
    }
}
