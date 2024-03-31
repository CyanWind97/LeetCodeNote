using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 17.09.
    /// title: 17.09. 第 k 个数
    /// problems: https://leetcode.cn/problems/get-kth-magic-number-lcci/
    /// date: 20220928
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_17_09
    {
        public static int GetKthMagicNumber(int k) {
            var nums = new int[k];
            nums[0] = 1;

            var indexs = new int[3] { 1, 2, 3 };
            var candidates = new int[3] { 3, 5, 7};

            for(int i = 1; i < k; i++){
                nums[i] = candidates.Min();
                for(int j = 0; j < 3; j++){
                    if(nums[i] != candidates[j]) 
                        continue;
                    
                    candidates[j] = nums[j + 1] * nums[indexs[j]];
                    indexs[j]++;
                }
            }

            return nums[k - 1];
        }
    }
}