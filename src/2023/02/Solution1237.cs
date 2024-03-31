using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1237
    /// title: 找出给定方程的正整数解
    /// problems: https://leetcode.cn/problems/find-positive-integer-solution-for-a-given-equation/
    /// date: 20230218
    /// </summary>
    public static class Solution1237
    {
        public class CustomFunction {
            // Returns f(x, y) for any given positive integers x and y.
            // Note that f(x, y) is increasing with respect to both x and y.
            // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
            public int f(int x, int y) => 0;
        };

        public static IList<IList<int>> FindSolution(CustomFunction customfunction, int z) {
            var reuslt = new List<IList<int>>();

            for(int x = 1, y = 1000; x <= 1000 && y >= 1; x++){
                while(y >= 1 && customfunction.f(x, y) > z){
                    y--;
                }

                if(y >= 1 && customfunction.f(x, y) == z)
                    reuslt.Add(new int[]{x, y});
            }

            return reuslt;
        }
    }
}