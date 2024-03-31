using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2208
    /// title:  将数组和减半的最少操作次数
    /// problems: https://leetcode.cn/problems/minimum-operations-to-halve-array-sum/
    /// date: 20230725
    /// </summary>
    public static class Solution2208
    {
        public static int HalveArray(int[] nums) {
            var queue = new PriorityQueue<double, double>();
            long sum = 0;
            foreach(var num in nums){
                queue.Enqueue(num, -num);
                sum += num;
            }

            int count = 0;
            double half = sum / 2.0;
            while(half > 0){
                var num = queue.Dequeue() / 2.0;
                half -= num;
                count++;

                queue.Enqueue(num, -num);
            }

            return count;
        }
    }
}