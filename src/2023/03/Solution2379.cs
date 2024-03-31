using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2379
    /// title: 得到 K 个黑块的最少涂色次数
    /// problems: https://leetcode.cn/problems/minimum-recolors-to-get-k-consecutive-black-blocks/
    /// date: 20230309
    /// </summary>
    public static class Solution2379
    {
        public static int MinimumRecolors(string blocks, int k) {
            int length = blocks.Length;
            int recolor = blocks.Take(k).Count(block => block == 'W');
            int min = recolor;

            for(int i = k; i < length; i++){
                if(blocks[i] == blocks[i - k])
                    continue;
                
                if(blocks[i] == 'W'){
                    recolor++;
                }else{
                    recolor--;
                    min = Math.Min(recolor, min);
                }
            }

            return min;
        }
    }
}