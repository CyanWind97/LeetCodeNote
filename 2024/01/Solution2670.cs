using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2670
    /// title: 找出不同元素数目差数组
    /// problems: https://leetcode.cn/problems/find-the-distinct-difference-array/description/?envType=daily-question&envId=2024-01-31
    /// date: 20240131
    /// </summary>
    public static class Solution2670
    {
        public static int[] DistinctDifferenceArray(int[] nums) {
            var count = new Dictionary<int, int>();
            int n = nums.Length;
            for(int i = 0; i < n; i++){
                if(!count.ContainsKey(nums[i]))
                    count[nums[i]] = 0;
                
                count[nums[i]]++;
            }

            var set = new HashSet<int>();

            var result = new int[n];
            for(int i = 0; i < n; i++){
                if(count[nums[i]] == 1)
                    count.Remove(nums[i]);
                else
                    count[nums[i]]--;
                
                set.Add(nums[i]);
                
                result[i] = set.Count - count.Count;
            }

            return result;
        }
    }
}