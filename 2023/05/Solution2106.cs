using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    //<summary>
    /// no: 2106
    /// title:  摘水果
    /// problems: https://leetcode.cn/problems/maximum-fruits-harvested-after-at-most-k-steps/
    /// date: 20230504
    /// </summary>
    public static class Solution2106
    {
        // 参考解答
        // 滑动窗口
        public static  int MaxTotalFruits(int[][] fruits, int startPos, int k) {
            int left = 0;
            int right = 0;
            int n = fruits.Length;
            int sum = 0;
            int ans = 0;

            int Step() {
                if (fruits[right][0] <= startPos)
                    return startPos - fruits[left][0];
                else if (fruits[left][0] >= startPos) 
                    return fruits[right][0] - startPos;
                else
                    return Math.Min(Math.Abs(startPos - fruits[right][0]), 
                                    Math.Abs(startPos - fruits[left][0])) 
                        + fruits[right][0] - fruits[left][0];
                
            }

            // 每次固定住窗口右边界
            while (right < n) {
                sum += fruits[right][1];
                // 移动左边界
                while (left <= right && Step() > k) {
                    sum -= fruits[left][1];
                    left++;
                }
                ans = Math.Max(ans, sum);
                right++;
            }
            
            return ans;
        }

    }
}