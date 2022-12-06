using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1775
    /// title:  通过最少操作次数使数组的和相等
    /// problems: https://leetcode.cn/problems/equal-sum-arrays-with-minimum-number-of-operations/
    /// date: 20221207
    /// </summary>
    public static class Solution1775
    {
        // 参考解答
        // 贪心 + 哈希
        public static int MinOperations(int[] nums1, int[] nums2) {
            int l1 = nums1.Length;
            int l2 = nums2.Length;
            if (6 * l1 < l2 || 6 * l2 < l1)
                return -1;
            
            var cnt1 = new int[7];
            var cnt2 = new int[7];
            
            int diff = 0;
            foreach (int i in nums1) {
                ++cnt1[i];
                diff += i;
            }

            foreach (int i in nums2) {
                ++cnt2[i];
                diff -= i;
            }

            if (diff == 0) 
                return 0;
            
            if(diff < 0){
                (cnt1, cnt2) = (cnt2, cnt1);
                diff = -diff;
            }

            var h = new int[7];
            for (int i = 1; i < 7; ++i) {
                h[6 - i] += cnt2[i];
                h[i - 1] += cnt1[i];
            }

            int result = 0;
            for (int i = 5; i > 0 && diff > 0; --i) {
                int t = Math.Min((diff + i - 1) / i, h[i]);
                result += t;
                diff -= t * i;
            }
                
            return result;
        }
    }
}