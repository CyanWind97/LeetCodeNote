using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 376
    /// title: 摆动序列
    /// problems: https://leetcode-cn.com/problems/wiggle-subsequence/
    /// date: 20201212
    /// </summary>
    public static class Solution376
    {
        public static int WiggleMaxLength(int[] nums) {
            if(nums.Length <= 1)
                return nums.Length;

            int count = 1;
            bool asc = true;
            for(int i = 1; i < nums.Length; i++){
                int diff = nums[i] - nums[i-1];
                if(count == 1){
                    if(diff == 0)
                        continue;
                    asc = diff > 0 ? true : false;
                    count++;
                }else if(asc && diff < 0 || !asc && diff > 0) {
                    asc = !asc;
                    count++;
                }
            }
            

            return count;
        }

        // 官方解答 动态规划 峰谷
        public static int WiggleMaxLength_1(int[] nums) {
            if(nums.Length < 2)
                return nums.Length;

            int up = 1, down = 1;
            for(int i = 1; i < nums.Length; i++){
                if(nums[i] > nums[i-1])
                    up = down + 1;
                else if(nums[i] < nums[i-1])
                    down = up + 1;
            }
            

            return Math.Max(up, down);
        }

        public static int WiggleMaxLength_2(int[] nums) {
            if(nums.Length < 2)
                return nums.Length;
            
            int preDiff = nums[1] - nums[0];
            int count = preDiff == 0 ? 1 : 2;
            for(int i = 2; i < nums.Length; i++) {
                int diff = nums[i] - nums[i-1];
                if((diff > 0 && preDiff <= 0) || (diff < 0 && preDiff >= 0)) {
                    count++;
                    preDiff = diff;
                }
            }

            return count;
        }
    }
}