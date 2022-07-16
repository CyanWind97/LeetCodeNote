using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 565
    /// title:  数组嵌套
    /// problems: https://leetcode.cn/problems/array-nesting/
    /// date: 20220717
    /// </summary>

    public static class Solution565
    {
        public static int ArrayNesting(int[] nums) {
            int length = nums.Length;
            var visited = new bool[length];
            int max = 0;
            
            for(int i = 0; i < length; i++){
                if(visited[i])
                    continue;

                int count = 0;
                int cur = i;
                while(!visited[cur]){
                    count++;
                    visited[cur] = true;
                    cur = nums[cur];
                }

                max = Math.Max(count, max);
            }

            return max;
        }
    }
}