using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1962
    /// title: 移除石子使总数最小
    /// problems: https://leetcode.cn/problems/remove-stones-to-minimize-the-total/description/?envType=daily-question&envId=2023-12-23
    /// date: 20231223
    /// </summary>
    public static class Solution1962
    {
        public static int MinStoneSum(int[] piles, int k) {
            int result = 0;
            var pq = new PriorityQueue<int, int>();
            foreach(var pile in piles){
                result += pile;
                pq.Enqueue(pile, -pile);
            }

            while(k-- > 0){
                var pile = pq.Dequeue();
                var remove = pile / 2;
                pile -= remove;
                result -= remove;
                pq.Enqueue(pile, -pile);
            }

            return result;
        }
    }
}