using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 334
    /// title: 递增的三元子序列
    /// problems: https://leetcode-cn.com/problems/increasing-triplet-subsequence/
    /// date: 20220112
    /// </summary>
    public  static class Solution334
    {
        public static bool IncreasingTriplet(int[] nums) {
            int length = nums.Length;

            int first = nums[0];
            int second = int.MaxValue;
            
            foreach(var num in nums.Skip(1)){
                if(num > second)
                    return true;
                else if(num > first)
                    second = num;
                else
                    first = num;
            }
            
            return false;
        }
    }
}