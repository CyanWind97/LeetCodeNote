using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 851
    /// title:  喧闹和富有
    /// problems: https://leetcode-cn.com/problems/loud-and-rich/
    /// date: 20211215
    /// </summary>
    public static class Solution851
    {
        public static int[] LoudAndRich(int[][] richer, int[] quiet) {
            int length = quiet.Length;
            int[] result = Enumerable.Range(0, length).ToArray();
            List<int>[] maps = result.Select(x => new List<int>())
                                     .ToArray();
            
            foreach(var rich in richer){
                var a = rich[0];
                var b = rich[1];

                maps[a].Add(b);

                var quietA = quiet[result[a]];
                var queue = new Queue<int>(maps[a]);
                
                while(queue.Count > 0){
                    int cur = queue.Dequeue();
                    int q = quiet[result[cur]];
                    if(q > quietA)
                        result[cur] = result[a];

                    foreach(var c in maps[cur]){
                        queue.Enqueue(c);
                    }
                }
            }

            return result;
        }
    }
}