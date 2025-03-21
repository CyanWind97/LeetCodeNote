using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2643
/// title:  一最多的行
/// problems: https://leetcode.cn/problems/row-with-maximum-ones
/// date: 20250322
/// </summary>
public static class Solution2643
{
    public static int[] RowAndMaximumOnes(int[][] mat) {
        int maxOnes = -1;
        int maxRow = -1;
        
        for (int i = 0; i < mat.Length; i++) {
            int onesCount = 0;
            for (int j = 0; j < mat[i].Length; j++) {
                if (mat[i][j] == 1) {
                    onesCount++;
                }
            }
            
            if (onesCount > maxOnes) {
                maxOnes = onesCount;
                maxRow = i;
            }
        }
        
        return [maxRow, maxOnes];
    }
}
