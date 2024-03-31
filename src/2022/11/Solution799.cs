using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 799
    /// title: 香槟塔
    /// problems: https://leetcode.cn/problems/champagne-tower/
    /// date: 20221120
    /// </summary>
    public static class Solution799
    {
        public static double ChampagneTower(int poured, int query_row, int query_glass) {
            var row =  new double[] {poured};
            for(int i = 1; i <= query_row; i++){
                var nextRow = new double[i + 1];
                for(int j = 0; j < i; j++){
                    if(row[j] > 1 ){
                        nextRow[j] += (row[j] - 1) / 2;
                        nextRow[j + 1] += (row[j] - 1) / 2;
                    }
                }
                row = nextRow;
            }

            return Math.Min(1, row[query_glass]);
        }
    }
}