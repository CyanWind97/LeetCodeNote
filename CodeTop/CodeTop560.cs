using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 560
    /// title:  和为 K 的子数组
    /// problems: https://leetcode-cn.com/problems/subarray-sum-equals-k/
    /// date: 20220508
    /// priority: 0021
    /// time: 00:22:32.02
    /// </summary>
    public class CodeTop560
    {
        // 前缀和 哈希
        // 优化 已经有序，只需要记录数量即可
        public static int SubarraySum(int[] nums, int k) 
        {
            int length = nums.Length;
            var sum = 0;
            var preSum = new Dictionary<int, int>();
            int count = 0;

            preSum.Add(0, 1);
            for(int i = 0; i < length; i++)
            {   
                sum += nums[i];
                if(preSum.ContainsKey(sum - k))
                    count += preSum[sum - k];
                

                if(!preSum.ContainsKey(sum))
                    preSum.Add(sum, 1);
                else
                    preSum[sum]++;
            }
            
            return count;
        }
    }
}