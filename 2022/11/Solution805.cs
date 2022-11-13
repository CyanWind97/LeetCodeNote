using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 805
    /// title: 数组的均值分割
    /// problems: https://leetcode.cn/problems/split-array-with-same-average/
    /// date: 20221114
    /// </summary> 
    public static class Solution805
    {
        // 参考解答
        // 折半搜索
        public static bool SplitArraySameAverage(int[] nums) {
            int n = nums.Length;
            if(n == 1)
                return false;
            
            int m = n / 2;
            int sum = nums.Sum();
            for(int i = 0; i < n; i++){
                nums[i] = nums[i] * n - sum;
            }
            
            var left = new HashSet<int>();
            for(int i = 1; i < (1 << m); i++){
                int tot = 0;
                for(int j  = 0; j < m; j++){
                    if((i & (1 << j)) != 0)
                        tot += nums[j];
                }

                if(tot == 0)
                    return true;

                left.Add(tot);
            }
            
            int rsum = nums.Skip(m).Sum();

            for(int i = 1; i < (1 << (n - m)); i++){
                int tot = 0;
                for(int j = m; j < n; j++){
                    if((i & (1 << (j - m))) != 0)
                        tot += nums[j];
                }

                if(tot == 0 || (rsum != tot && left.Contains(-tot)))
                    return true;
            }

            return false;
        }
    }
}