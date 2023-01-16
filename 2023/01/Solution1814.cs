using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1814
    /// title: 统计一个数组中好对子的数目
    /// problems: https://leetcode.cn/problems/count-nice-pairs-in-an-array/
    /// date: 20230117
    /// </summary>
    public static class Solution1814
    {
        // 参考解答
        // 转化为 nums[i] - rev(nums[i]) == nums[j] - rev(nums[j])
        public static int CountNicePairs(int[] nums) {
            const int MOD = 1000000007;
            int result =  0;

            var count = new Dictionary<int, int>();
            foreach(var i in nums){
                int temp = i;
                int j = 0;
                while(temp > 0){
                    j = j * 10 + temp % 10;
                    temp /= 10;
                }

                count.TryAdd(i - j, 0);
                result = (result + count[i - j]) % MOD;
                count[i - j]++;
            }
            
            return result;
        }
    }
}