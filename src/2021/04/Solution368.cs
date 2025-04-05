using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 368
    /// title: 最大整除子集
    /// problems: https://leetcode-cn.com/problems/largest-divisible-subset/
    /// date: 20210423
    /// </summary>
    public static partial class Solution368
    {
        // 参考解答 dp
        public static IList<int> LargestDivisibleSubset(int[] nums) {
            int length = nums.Length;
            Array.Sort(nums);
            
            int[] f = new int[length];
            int[] g = new int[length];
            
            int max = 1;
            int index = 0;
            Array.Fill(f, 1);
            for(int i = 0; i < length; i++){
                g[i] = i;
                for(int j = 0; j < i; j++){
                    if(nums[i] % nums[j] == 0){
                        if(f[j] + 1 > f[i]){
                            f[i] = f[j] + 1;
                            g[i] = j;
                        }
                    }
                }
                if(f[i] > max){
                    max = f[i];
                    index = i;
                }
            }

            IList<int> result = new List<int>();
            while(g[index] != index){
                result.Add(nums[index]);
                index = g[index];
            }
            result.Add(nums[index]);

            return result;
        }
    }
}