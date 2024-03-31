using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 974
    /// title:  和可被 K 整除的子数组
    /// problems: https://leetcode.cn/problems/subarray-sums-divisible-by-k/
    /// date: 20220523
    /// priority: 0097
    /// time: 00:13:55.46
    /// </summary>
    public static class CodeTop974
    {
        public static int SubarraysDivByK(int[] nums, int k) {
            int length = nums.Length;
            var lookup = new Dictionary<int, int>();

            int sum = 0;
            int result = 0;
            lookup.Add(0, 1);

            for(int i = 0; i < length; i++){
                sum += nums[i];

                var key = (sum % k + k) % k;

                if(lookup.ContainsKey(key))
                    lookup[key]++;
                else
                    lookup.Add(key, 1);

                result += lookup[key] - 1;
            }

            return result;
        }
    }
}