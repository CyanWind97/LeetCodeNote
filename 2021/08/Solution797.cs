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
            var stack = new Stack<int>();
            var length = graph.Length - 1;

            void dfs(int x){
                if(x == length){
                    var list = new List<int>(stack);
                    list.Reverse();
                    result.Add(list);
                    return;
                }

                foreach(var y in graph[x]){
                    stack.Push(y);
                    dfs(y);
                    stack.Pop();
                }
            }

            stack.Push(0);
            dfs(0);

            return result;
        }
    }
}