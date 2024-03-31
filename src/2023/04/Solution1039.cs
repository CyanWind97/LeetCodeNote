using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1039
    /// title: 多边形三角剖分的最低得分
    /// problems: https://leetcode.cn/problems/minimum-score-triangulation-of-polygon/
    /// date: 20230402
    /// </summary>
    public static class Solution1039
    {
        public static int MinScoreTriangulation(int[] values) {
            int n = values.Length;
            var map = new Dictionary<int, int>();

            int DP(int i, int j){
                if(i + 2 > j)
                    return 0;
                
                if(i + 2 == j)
                    return values[i] * values[i + 1] * values[j];
                
                int key = i * n + j;
                if(!map.ContainsKey(key)){
                    int minScore = int.MaxValue;
                    for(int k = i + 1; k < j; k++){
                        minScore = Math.Min(minScore, values[i] * values[k] * values[j] + DP(i, k) + DP(k, j));
                    }

                    map[key] = minScore;
                }

                return map[key];
            }

            return DP(0, n - 1);
        }
    }
}