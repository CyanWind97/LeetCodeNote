using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2488
    /// title: 统计中位数为 K 的子数组
    /// problems: https://leetcode.cn/problems/count-subarrays-with-median-k/
    /// date: 20230316
    /// </summary>
    public static class Solution2488
    {
        public static int CountSubarrays(int[] nums, int k) {
            int n = nums.Length;
            int index = Array.IndexOf(nums, k);
            int result = 1;
            var count = new Dictionary<int, int>();
            int sum = 0;

            count[0] = 1;
            for(int i = index - 1; i >= 0; i--){
                sum += Math.Sign(nums[i] - k);
                if(sum == 0 || (((index - i + 1) % 2 == 0) && sum == 1))
                    result++;
                
                if(!count.ContainsKey(sum))
                    count[sum] = 0;
                
                count[sum]++;
            }

            sum = 0;
            for(int i = index + 1; i < n; i++){
                sum += Math.Sign(nums[i] - k);
                if(count.ContainsKey(-sum))
                    result += count[-sum];
                
                if(count.ContainsKey(-sum + 1))
                    result += count[-sum + 1];
            }

            return result;
        }
    }
}