using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1491
    /// title: 并行课程 II
    /// problems: https://leetcode.cn/problems/parallel-courses-ii/
    /// date: 20230616
    /// </summary>
    public static class Solution1491
    {
        public static int MinNumberOfSemesters(int n, int[][] relations, int k) {
            var inDegrees = new int[n];
            var outDegrees = new int[n];
            var inGraphs = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            var outGraphs = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

            foreach(var relation in relations){
                (var x, var y) = (relation[0] - 1, relation[1] - 1);
                inDegrees[y]++;
                outDegrees[x]++;
                inGraphs[x].Add(y);
                outGraphs[y].Add(x);
            }
            
            int CalcCount(int[] degrees, IList<int>[] graphs){
                var weight = new int[n];
                var visted = new bool[n];
                int CalcWeight(int node){
                    if(visted[node])
                        return weight[node];
                    
                    visted[node] = true;
                    weight[node] = 1;
                    foreach(var next in graphs[node]){
                        weight[node] +=  2 * CalcWeight(next);
                    }

                    return weight[node];
                }

                int result = 0;
                var queue = new PriorityQueue<int, int>();
                for(int i = 0; i < n; i++){
                    if(degrees[i] == 0){
                        CalcWeight(i);
                        queue.Enqueue(i, -weight[i]);
                    }
                }

                while(queue.Count > 0){
                    int count = Math.Min(k, queue.Count);
                    var nodes = new List<int>();
                    for(int i = 0; i < count; i++){
                        nodes.Add(queue.Dequeue());
                    }

                    foreach(var node in nodes){
                        foreach(var next in graphs[node]){
                            degrees[next]--;
                            if(degrees[next] == 0)
                                queue.Enqueue(next, -weight[next]);
                        }
                    }

                    result++;
                }

                return result;
            }

            return Math.Min(CalcCount(inDegrees, inGraphs), CalcCount(outDegrees, outGraphs));
        }
        
    }
}