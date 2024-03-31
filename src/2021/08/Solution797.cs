using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 789
    /// title: 逃脱阻碍者
    /// problems: https://leetcode-cn.com/problems/escape-the-ghosts/
    /// date: 20210825
    /// </summary>
    public static class Solution797
    {
        public static IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
            var result = new List<IList<int>>();
            var stack = new LinkedList<int>();
            var length = graph.Length - 1;

            void dfs(int x){
                if(x == length){
                    result.Add(new List<int>(stack));
                    return;
                }

                foreach(var y in graph[x]){
                    stack.AddLast(y);
                    dfs(y);
                    stack.RemoveLast();
                }
            }

            stack.AddLast(0);
            dfs(0);

            return result;
        }
    }
}