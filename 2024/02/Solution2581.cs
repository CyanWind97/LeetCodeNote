using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2581
/// title: 统计可能的树根数目
/// problems: https://leetcode.cn/problems/count-number-of-possible-root-nodes/description/?envType=daily-question&envId=2024-02-29
/// date: 20240229
/// </summary> 
public static class Solution2581
{
    // 参考解答
    public static int RootCount(int[][] edges, int[][] guesses, int k) {
        int total = 0;
        int result = 0;
        var set = new HashSet<(int X, int Y)>();
        int n = edges.Length + 1;
        var g = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach(var edge in edges){
            g[edge[0]].Add(edge[1]);
            g[edge[1]].Add(edge[0]);
        }

        foreach(var guess in guesses){
            set.Add((guess[0], guess[1]));
        }

        var queue = new Queue<(int X, int Parent)>();
        queue.Enqueue((0, -1));
        while(queue.Count > 0){
            var (x, parent) = queue.Dequeue();
            foreach(var y in g[x].Where(y =>  y != parent)){
                total += set.Contains((x,y)) ? 1 : 0;
                queue.Enqueue((y, x));
            }
        }

        var reQueue = new Queue<(int X, int Parent, int Count)>();
        reQueue.Enqueue((0, -1, total));
        while(reQueue.Count > 0){
            var (x, parent, count) = reQueue.Dequeue();
            if (count >= k)
                result++;
            
            foreach(var y in g[x].Where(y => y != parent)){
                int next = count + (set.Contains((x,y)) ? -1 : 0) + (set.Contains((y,x)) ? 1: 0);
                reQueue.Enqueue((y, x, next));
            }
        }

        return result;
    }

    
    // 参考解答
    // stack overflow
    public static int RootCount_1(int[][] edges, int[][] guesses, int k) {
        int count = 0;
        int result = 0;
        var set = new HashSet<(int X, int Y)>();
        int n = edges.Length + 1;
        var g = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach(var edge in edges){
            g[edge[0]].Add(edge[1]);
            g[edge[1]].Add(edge[0]);
        }

        foreach(var guess in guesses){
            set.Add((guess[0], guess[1]));
        }

        void DFS(int x, int parent){
            foreach(var y in g[x]){
                if (y == parent)
                    continue;

                count += set.Contains((x,y)) ? 1 : 0;
                DFS(y, x);
            }
        }

        void ReDFS(int x, int parent, int count){
            if (count >= k)
                result++;
            
            foreach(var y in g[x]){
                if (y == parent)
                    continue;

                int next = count + (set.Contains((x,y)) ? -1 : 0) + (set.Contains((y,x)) ? 1: 0);
                ReDFS(y, x, next);
            }
        }

        DFS(0, -1);
        ReDFS(0, -1, count);

        return result;
    }
}
