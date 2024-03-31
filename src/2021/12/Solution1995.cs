using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1995
    /// title:  统计特殊四元组
    /// problems: https://leetcode-cn.com/problems/count-special-quadruplets/
    /// date: 20211229
    /// </summary>
    public static class Solution1995
    {
        public static int CountQuadruplets(int[] nums) {
            var dic = new Dictionary<int, int>();
            int legnth = nums.Length;
            int result = 0;

            for(int b = legnth - 3;  b >= 1; b--){
                for(int d = b + 2; d < legnth; d++){
                    int diff = nums[d] - nums[b + 1];
                    if(dic.ContainsKey(diff))
                        dic[diff]++;
                    else
                        dic.Add(diff, 1);
                }

                for(int a = 0; a < b; a++){
                    int sum = nums[a] + nums[b];
                    if(dic.TryGetValue(sum, out int count))
                        result += count;
                }
            }
            
            return result;
        }
    }
}