using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 335
    /// title: 路径交叉
    /// problems: https://leetcode-cn.com/problems/self-crossing/
    /// date: 20211029
    /// </summary>
    public static class Solution335
    {
        // 参考解答 归纳法
        public static bool IsSelfCrossing(int[] distance) {
            int n = distance.Length;
            for (int i = 3; i < n; ++i) {
                // 第 1 类路径交叉的情况
                if (distance[i] >= distance[i - 2] && distance[i - 1] <= distance[i - 3])
                    return true;
                

                // 第 2 类路径交叉的情况
                if (i == 4 && (distance[3] == distance[1] && distance[4] >= distance[2] - distance[0])) 
                    return true;
                

                // 第 3 类路径交叉的情况
                if (i >= 5 
                    && (distance[i - 3] - distance[i - 5] <= distance[i - 1]
                    && distance[i - 1] <= distance[i - 3]
                    && distance[i] >= distance[i - 2] - distance[i - 4]
                    && distance[i - 2] > distance[i - 4]))
                    return true;
                
            }
            return false;
        }


    }
}