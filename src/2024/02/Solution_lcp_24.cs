using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 24
    /// title: 数字游戏
    /// problems: https://leetcode.cn/problems/5TxKeK/description/?envType=daily-question&envId=2024-02-01
    /// date: 20240201
    /// type: lcp
    /// </summary>
    public class Solution_lcp_24
    {
        // 参考解答
        // 求中位数
        public static int[] NumsGame(int[] nums) {
            const int MOD = 1_000_000_007;

            int n = nums.Length;
            var result = new int[n];

            var lower = new PriorityQueue<int, int>();
            var upper = new PriorityQueue<int, int>();

            long lowerSum = 0;
            long upperSum = 0;

            for(int i = 0; i < n; i++){
                int x = nums[i] - i;

                if (lower.Count == 0 || lower.Peek() >= x){
                    lowerSum += x;
                    lower.Enqueue(x, -x);
                    if (lower.Count > upper.Count + 1){
                        var peek = lower.Dequeue();
                        upper.Enqueue(peek, peek);
                        lowerSum -= peek;
                        upperSum += peek;
                    }
                }else{
                    upperSum += x;
                    upper.Enqueue(x, x);
                    if (upper.Count > lower.Count){
                        var peek = upper.Dequeue();
                        lower.Enqueue(peek, -peek);
                        upperSum -= peek;
                        lowerSum += peek;
                    }
                }

                result[i] = (i + 1) % 2 == 0
                        ? (int)((upperSum - lowerSum) % MOD)
                        : (int)((upperSum - lowerSum + lower.Peek()) % MOD);
            }

            return result;
        }
    }
}