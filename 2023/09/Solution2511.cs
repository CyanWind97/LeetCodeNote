using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2511
    /// title: 最多可以摧毁的敌人城堡数目
    /// problems: https://leetcode.cn/problems/maximum-enemy-forts-that-can-be-captured/?envType=daily-question&envId=2023-09-02
    /// date: 20230902
    /// </summary>
    public class Solution2511
    {
        public static int CaptureForts(int[] forts) {
            int length = forts.Length;
            int prev = -1;
            int result = 0;
            for(int i = 0; i < length; i++){
                if (forts[i] == 0)
                    continue;

                if (prev != -1 && forts[i] != forts[prev])
                    result = Math.Max(result, i - prev - 1);
                
                prev = i;
            }

            return result;
        }
    }
}