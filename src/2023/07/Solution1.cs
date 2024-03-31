using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1
    /// title: 两数之和
    /// problems: https://leetcode.cn/problems/two-sum/
    /// date: 20230701
    /// </summary>
    public static class Solution1
    {
        public static int[] TwoSum(int[] nums, int target) {
            int length = nums.Length;
            var map = new Dictionary<int, int>();
            for(int i = 0; i < length; i++){
                int num = nums[i];
                if(map.TryGetValue(target - num, out int index))
                    return new int[]{index, i};
                
                map[num] = i;
            }

            return Array.Empty<int>();
        }
    }
}