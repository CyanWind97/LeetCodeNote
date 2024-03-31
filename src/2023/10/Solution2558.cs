using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2558
    /// title: 从数量最多的堆取走礼物
    /// problems: https://leetcode.cn/problems/take-gifts-from-the-richest-pile/?envType=daily-question&envId=2023-10-28
    /// date: 20231028
    /// </summary>
    public static class Solution2558
    {
        public static long PickGifts(int[] gifts, int k) {
            var queue = new PriorityQueue<int, int>();
            foreach(var gift in gifts){
                queue.Enqueue(gift, -gift);
            }

            while(k > 0){
                var gift = queue.Dequeue();
                int next = (int)Math.Sqrt(gift);
                queue.Enqueue(next, -next);
                k--;
            }

            long result = 0;
            while(queue.Count > 0){
                result += queue.Dequeue();
            }

            return result;
        }
    }
}