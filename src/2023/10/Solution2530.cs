using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2530
    /// title: 执行 K 次操作后的最大分数
    /// problems: https://leetcode.cn/problems/maximal-score-after-applying-k-operations/?envType=daily-question&envId=2023-10-18
    /// date: 20231018
    /// </summary>
    public static class Solution2530
    {
        public static long MaxKelements(int[] nums, int k) {
            var queue = new PriorityQueue<int, int>();
            foreach(var num in nums){
                queue.Enqueue(num, -num);
            }

            long result = 0;
            while(k-- > 0){
                var value = queue.Dequeue();
                result += value;
                var next = (int)Math.Ceiling(value / 3.0);
                queue.Enqueue(next, -next);
            }

            return result;
        }
    }
}