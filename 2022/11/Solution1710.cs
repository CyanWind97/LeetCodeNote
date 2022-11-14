using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
        /// no: 1710
        /// title: 卡车上的最大单元数
        /// problems: https://leetcode.cn/problems/maximum-units-on-a-truck/
        /// date: 20221115
        /// </summary> 
    public static class Solution1710
    {
        public static int MaximumUnits(int[][] boxTypes, int truckSize) {
            Array.Sort(boxTypes, (a, b) => b[1] - a[1]);
            int result = 0;
            foreach(var boxType in boxTypes){
                int num = Math.Min(boxType[0], truckSize);
                int units = boxType[1];

                result += num * units;
                truckSize -= num;

                if(truckSize == 0)
                    break;
            }

            return result;
        }
    }
}