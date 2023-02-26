using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1144
    /// title: 递减元素使数组呈锯齿状
    /// problems: https://leetcode.cn/problems/decrease-elements-to-make-array-zigzag/
    /// date: 20230227
    /// </summary>
    public static class Solution1144
    {
        public static int MovesToMakeZigzag(int[] nums) {
            int Help(int pos) {
                int res = 0;
                for (int i = pos; i < nums.Length; i += 2) {
                    int diff = 0;
                    if (i - 1 >= 0)
                        diff = Math.Max(diff, nums[i] - nums[i - 1] + 1);
                    
                    if (i + 1 < nums.Length) 
                        diff = Math.Max(diff, nums[i] - nums[i + 1] + 1);
                    
                    res += diff;
                }

                return res;
            }

            return Math.Min(Help(0), Help(1));
        }
    }
}