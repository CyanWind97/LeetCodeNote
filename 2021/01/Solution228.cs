using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 228
    /// title: 汇总区间
    /// problems: https://leetcode-cn.com/problems/summary-ranges/
    /// date: 20210110
    /// </summary>
    public partial class Solution228
    {
        public static IList<string> SummaryRanges(int[] nums) {
            int length = nums.Length;
            if(length == 0)
                return new string[]{};
            
            List<string> result = new List<string>();

            int pre = 0;
            for(int i = 1; i < length; i++){
                if(nums[i] - nums[pre] != i - pre){
                    result.Add(i - 1 == pre ? $"{nums[pre]}" : $"{nums[pre]}->{nums[i - 1]}");
                    pre = i;
                }
            }

            result.Add(length - 1 == pre? $"{nums[pre]}" : $"{nums[pre]}->{nums[length - 1]}");

            return result;
        }
    }
}