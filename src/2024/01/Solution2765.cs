using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2765
    /// title: 最长交替子数组
    /// problems: https://leetcode.cn/problems/longest-alternating-subarray/description/?envType=daily-question&envId=2024-01-23
    /// date: 20240123
    /// </summary>
    public static class Solution2765
    {
        public static int AlternatingSubarray(int[] nums) {
            int length = nums.Length;
            int result = -1;

            for(int i = 1; i < length; i++){
                int diff = nums[i] - nums[i - 1];
                if (diff != 1)
                    continue;

                int count = 2;

                for(int j = i + 1; j < length; j++){
                    if (nums[j] - nums[j - 1] == -diff){
                        count++;
                        diff = -diff;
                    }else{
                        i = j - 1;
                        break;
                    }
                } 

                result = Math.Max(result, count);  
            }

            return result;
        }
    }
}