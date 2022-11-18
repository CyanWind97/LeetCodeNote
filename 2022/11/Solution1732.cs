using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1732
    /// title: 找到最高海拔
    /// problems: https://leetcode.cn/problems/find-the-highest-altitude/
    /// date: 20221119
    /// </summary>
    public static class Solution1732
    {
        public static int LargestAltitude(int[] gain) {
            int largest = 0;
            int altitutde = 0;
            foreach(var g in gain){
                altitutde += g;
                largest = Math.Max(largest, altitutde);
            }

            return largest;
        }
    }
}