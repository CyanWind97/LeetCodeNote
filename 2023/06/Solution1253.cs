using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1253
    /// title: 重构 2 行二进制矩阵
    /// problems: https://leetcode.cn/problems/reconstruct-a-2-row-binary-matrix/
    /// date: 20230629
    /// </summary>

    public static class Solution1253
    {
        public static IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum) {
            int length = colsum.Length;
            var result = new int[2][];
            result[0] = new int[length];
            result[1] = new int[length];

            for(int i = 0; i < length; i++){
                if(colsum[i] == 2){
                    result[0][i] = 1;
                    result[1][i] = 1;
                    upper--;
                    lower--;
                }else if(colsum[i] == 1){
                    if(upper > lower){
                        result[0][i] = 1;
                        upper--;
                    }else if(lower > 0){
                        result[1][i] = 1;
                        lower--;
                    }else{
                        lower--;
                        break;
                    }
                }
            }

            return upper == 0 && lower == 0 ? result : Array.Empty<IList<int>>();
        }
    }
}