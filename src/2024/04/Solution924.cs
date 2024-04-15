using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 924
/// title: 尽量减少恶意软件的传播
/// problems: https://leetcode.cn/problems/minimize-malware-spread
/// date: 20240416
/// </summary>
public static class Solution924
{   
    // 参考解答
    public static int MinMalwareSpread(int[][] graph, int[] initial) {
        int n = graph.Length;
        var colors = new int[n];
        var colorSize = new List<int>();
        int color = 0;
        colorSize.Add(0);
        for(int i = 0; i < n; i++){
            if(colors[i] != 0)
                continue;

            color++;
            int size = 1;
            var queue = new Queue<int>();
            queue.Enqueue(i);
            colors[i] = color;

            while(queue.Count > 0){
                int u = queue.Dequeue();
                colors[u] = color;
                for(int v = 0; v < n; v++){
                    if(colors[v] == 0 && graph[u][v] == 1){
                        size++;
                        queue.Enqueue(v);
                        colors[v] = color;
                    }
                }
            }
            
            colorSize.Add(size);
        }
        
        var colorInits = new int[colorSize.Count];
        foreach(var init in initial){
            colorInits[colors[init]]++;
        }

        var result = n + 1;
        var totalRemoved = 0;
        foreach(var u in initial){
            int removed = (colorInits[colors[u]] == 1) 
                        ? colorSize[colors[u]] 
                        : 0;
            if(removed > totalRemoved || (removed == totalRemoved && u < result)){
                result = u;
                totalRemoved = removed;
            }
        }

        return result;
    }
}
