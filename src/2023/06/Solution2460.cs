using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2460
    /// title: 对数组执行操作
    /// problems: https://leetcode.cn/problems/apply-operations-to-an-array/
    /// date: 20230605
    /// </summary>

    public static class Solution2460
    {
        public static int[] ApplyOperations(int[] nums) {
            int length = nums.Length;
            int j = 0;
            for(int i = 0; i < length - 1; i++){
                if(nums[i] == 0)
                    continue;
                
                nums[j] = nums[i];
                if(nums[i] == nums[i + 1]) {
                    nums[j] *= 2;
                    nums[i + 1] = 0;
                }
                j++;
            }

            if (nums[length - 1] != 0)
                nums[j++] = nums[length - 1];


            Array.Fill(nums, 0, j, length - j);
            return nums;
        }
    }
}