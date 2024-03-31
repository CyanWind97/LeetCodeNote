using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 802
    /// title: 最终安全状态
    /// problems: https://leetcode-cn.com/problems/find-eventual-safe-states/
    /// date: 20210805
    /// </summary>
    public static class Solution802
    {
        public static IList<int> EventualSafeNodes(int[][] graph) {
            var result = new List<int>();
            int length = graph.Length;
            bool[] vistited = new bool[length];
            bool[] safe =  new bool[length];
            
            void IsSafe(int state)
            {
                vistited[state] = true;
                bool isSafe = true;
                foreach(var next in graph[state]){
                    if(!vistited[next])
                        IsSafe(next);
                        
                    isSafe = isSafe && safe[next];
                    if(!isSafe)
                        break;
                }

                if(isSafe)
                    result.Add(state);
                
                safe[state] = isSafe;
            }

            for(int i = 0; i < length; i++){
                if(!vistited[i])
                    IsSafe(i);
            }

            result.Sort();

            return result;
        }


        // 参考解答 深度优先 + 三色标记
        public static IList<int> EventualSafeNodes_1(int[][] graph) {
            int n = graph.Length;
            int[] color = new int[n];
            IList<int> ans = new List<int>();

            bool Safe(int x) {
                if (color[x] > 0)
                    return color[x] == 2;
                
                color[x] = 1;
                foreach (int y in graph[x]) {
                    if (!Safe(y))
                        return false;
                }
                color[x] = 2;
                return true;
            }

            for (int i = 0; i < n; ++i) {
                if (Safe(i))
                    ans.Add(i);
            }
            return ans;
        }

        // 参考解答 拓扑排序
        public static IList<int> EventualSafeNodes_2(int[][] graph) {
            int n = graph.Length;
            List<List<int>> rg = graph.Select(x => new List<int>())
                                      .ToList();

            int[] inDeg = new int[n];
            for (int x = 0; x < n; ++x) {
                foreach (int y in graph[x]) {
                    rg[y].Add(x);
                }
                inDeg[x] = graph[x].Length;
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; ++i) {
                if (inDeg[i] == 0) {
                    queue.Enqueue(i);
                }
            }
            while (queue.Count > 0) {
                int y = queue.Dequeue();
                foreach (int x in rg[y]) {
                    if (--inDeg[x] == 0) {
                        queue.Enqueue(x);
                    }
                }
            }

            IList<int> ans = new List<int>();
            for (int i = 0; i < n; ++i) {
                if (inDeg[i] == 0) {
                    ans.Add(i);
                }
            }
            return ans;
        }

    }
}