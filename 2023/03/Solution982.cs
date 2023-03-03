using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 982
    /// title: 按位与为零的三元组
    /// problems: https://leetcode.cn/problems/triples-with-bitwise-and-equal-to-zero/
    /// date: 20230304
    /// </summary>
    public static class Solution982
    {
        // 参考解答
        // 枚举 + 子集优化
        public static int CountTriplets(int[] nums) {
            var count = new int[1 << 16];
            foreach (int x in nums) {
                foreach (int y in nums) {
                    count[x & y]++;
                }
            }

            int result = 0;
            foreach (int x in nums) {
                int y = x ^ 0xffff;
                for (int sub = y; sub != 0; sub = (sub - 1) & y) {
                    result += count[sub];
                }

                result += count[0];
            }
            
            return result;
        }
    }
}