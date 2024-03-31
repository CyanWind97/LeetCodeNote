using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2469
    /// title:  温度转换
    /// problems: https://leetcode.cn/problems/convert-the-temperature/
    /// date: 20230321
    /// </summary>
    public static class Solution2469
    {
        public static double[] ConvertTemperature(double celsius) {
            return new double[]{celsius + 273.15, celsius * 1.80 + 32.00};
        }
    }
}