using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 442
    /// title: 数组中重复的数据
    /// problems: https://leetcode-cn.com/problems/find-all-duplicates-in-an-array/
    /// date: 20220508
    /// </summary>    
    public static class Solution442
    {
        // 参考解答 原地哈希
        public static IList<int> FindDuplicates(int[] nums) {
            int n = nums.Length;

            for(int i = 0; i < n; i++){
                while(nums[i] != nums[nums[i] - 1]){
                    int j = nums[i] - 1;
                    (nums[i], nums[j]) = (nums[j], nums[i]);
                }
            }

            return Enumerable.Range(0, n)
                        .Where(i => nums[i] - 1 != i)
                        .Select(i=> nums[i])
                        .ToList();
        }
    }
}