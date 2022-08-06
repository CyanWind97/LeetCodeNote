using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 636
    /// title:  函数的独占时间
    /// problems: https://leetcode.cn/problems/exclusive-time-of-functions/
    /// date: 20220807
    /// </summary>
    public static class Solution636
    {
        public static int[] ExclusiveTime(int n, IList<string> logs) {
            var stack = new Stack<(int Id, int Time)>();
            var result = new int[n];

            foreach(var log in logs){
                var infos = log.Split(":");
                var id = int.Parse(infos[0]);
                var isStart = infos[1] == "start";
                var time = int.Parse(infos[2]);
                
                if(isStart){
                    if(stack.Count > 0){
                        var pre = stack.Peek();
                        result[pre.Id] += time - pre.Time;
                    }

                    stack.Push((id, time));
                }else{
                    result[id] += time - stack.Pop().Time + 1;
                    if(stack.Count > 0){
                        var pre = stack.Pop();
                        stack.Push((pre.Id, time + 1));
                    }
                }
            }

            return result;
        }
    }
}