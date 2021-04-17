using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 220
    /// title: 存在重复元素 III
    /// problems: https://leetcode-cn.com/problems/contains-duplicate-iii/
    /// date: 20210417
    /// </summary>
    public static class Solution220
    {
        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
            int length = nums.Length;
            SortedSet<long> set  = new SortedSet<long>();
            for(int i = 0; i < length; i++){
                if(set.GetViewBetween((long)nums[i] - (long)t, (long)nums[i] + (long)t).Count() > 0)
                    return true;
                
                set.Add(nums[i]);
                if(set.Count > k){
                    set.Remove(nums[i - k]);
                }
            }

            return false;
        }
    }
}