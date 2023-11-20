using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2216
    /// title:  美化数组的最少删除数
    /// problems: https://leetcode.cn/problems/minimum-deletions-to-make-array-beautiful/description/?envType=daily-question&envId=2023-11-21
    /// date: 20231121
    /// </summary>
    public static class Solution2216
    {
        public static int MinDeletion(int[] nums) {
            int length = nums.Length;
            int result = 0;
            var check = true;
            for(int i  = 0; i < length - 1; i++){
                if (nums[i] == nums[i + 1] && check)
                    result++;
                else
                    check = !check;
            }

            if ((length - result) % 2 != 0)
                result++;
            
            return result;
        }
    }
}