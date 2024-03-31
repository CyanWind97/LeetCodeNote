using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1224
    /// title:  最大相等频率
    /// problems: https://leetcode.cn/problems/maximum-equal-frequency/
    /// date: 20220818
    /// </summary>
    public static class Solution1224
    {
        // 参考解答
        public static int MaxEqualFreq(int[] nums) {
            var freq = new Dictionary<int,int>();
            var count = new Dictionary<int,int>();
            int result = 0;
            int maxFreq = 0;
            for(int i = 0; i < nums.Length; i++){
                if(!count.ContainsKey(nums[i]))
                    count.Add(nums[i], 0);
                
                if(count[nums[i]] > 0)
                    freq[count[nums[i]]]--;
                
                count[nums[i]]++;
                maxFreq = Math.Max(maxFreq, count[nums[i]]);
                if(!freq.ContainsKey(count[nums[i]]))
                    freq.Add(count[nums[i]], 0);
                
                freq[count[nums[i]]]++;
                var ok = maxFreq == 1
                        || freq[maxFreq] * maxFreq + freq[maxFreq - 1] * (maxFreq - 1) == i + 1 && freq[maxFreq] == 1 
                        || freq[maxFreq] * maxFreq + 1 == i + 1 && freq[1] == 1;
                
                if(ok)
                    result = Math.Max(result, i + 1);
            }

            return result;
        }
    }
}