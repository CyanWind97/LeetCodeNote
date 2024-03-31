using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2251
    /// title: 花期内花的数目
    /// problems: https://leetcode.cn/problems/number-of-flowers-in-full-bloom/?envType=daily-question&envId=Invalid%20Date
    /// date: 20230928
    /// </summary>
    public static class Solution2251
    {
        public static int[] FullBloomFlowers(int[][] flowers, int[] people) {
            Array.Sort(flowers, (a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
            int length = flowers.Length;
            var map = people.Select((p, index) => (p, index))
                            .OrderBy(x => x.p)
                            .ToArray();

            int[] result = new int[people.Length];

            var queue = new PriorityQueue<int, int>();
            int index = 0;
            for(int i = 0; i < people.Length; i++){
                (var p, var curr) = map[i];
                while(queue.Count > 0 && queue.Peek() < p)
                    queue.Dequeue();

                while(index < length && flowers[index][0] <= p){
                    var fall = flowers[index][1];
                    if (fall >= p)
                        queue.Enqueue(fall, fall);
                        
                    index++;
                }

                result[curr] = queue.Count;
            }

            return result;
        }
    }
}