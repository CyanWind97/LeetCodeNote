using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 330
    /// title: 按要求补齐数组
    /// problems: https://leetcode-cn.com/problems/patching-array/
    /// date: 20201229
    /// </summary>
    public static class Solution330
    {
        public static int MinPatches(int[] nums, int n) {
            int length = nums.Length;
            int count = 0;
            int cur = 1;
            int sum = 0;
            
            for(int i = 0; i < length && nums[i] <= n && sum < n; i++)
            {
                if(cur < sum)
                    cur = sum + 1;

                while(sum < nums[i] - 1 && cur < nums[i]){
                    sum += cur;
                    cur *= 2;
                    count++;
                }
                if(cur == nums[i]){
                    cur *= 2;
                }

                sum += nums[i];
            }

            if(length != 0 && cur < sum){
                cur = sum + 1;
            }
            
            while(sum < n - sum){
                sum += cur;
                cur *= 2;
                count++;
            }
            
            if(sum < n)
                count++;
            
            return count;
        }
    }
}