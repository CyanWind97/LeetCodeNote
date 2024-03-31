using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2293
    /// title: 极大极小游戏
    /// problems: https://leetcode.cn/problems/min-max-game/
    /// date: 20230115
    /// </summary>
    public static class Solution2293
    {
        public static int MinMaxGame(int[] nums) {
            int n = nums.Length;
            while(n != 1){
                int m = n / 2;
                for(int i = 0; i < m; i++){
                    nums[i] = Math.Min(nums[2 * i], nums[2 * i + 1]);
                    i++;
                    if(i == m)
                        continue;
                    
                    nums[i] = Math.Max(nums[2 * i], nums[2 * i + 1]);
                }
                n = m;
            }

            return nums[0];
        }
    }
}