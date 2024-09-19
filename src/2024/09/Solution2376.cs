using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2376
/// title: 统计特殊整数
/// problems: https://leetcode.cn/problems/count-special-integers
/// date: 20240920
/// </summary>
public static class Solution2376
{
    public static int CountSpecialNumbers(int n) {
        var memo = new Dictionary<int, int>();  
        var nStr = n.ToString();

        int Dp(int mask, bool prefixSmaller) {
            int count = int.PopCount(mask);
            if (count == nStr.Length)
                return 1;
            
            int key = mask * 2 + (prefixSmaller ? 1 : 0);
            if (!memo.ContainsKey(key)) {
                int res = 0;
                int lowerBound = mask == 0 ? 1 : 0;
                int upperBound = prefixSmaller ? 9 : nStr[count] - '0';
                for (int i = lowerBound; i <= upperBound; i++) {
                    if (((mask >> i) & 1) == 0) {
                        res += Dp(mask | (1 << i), prefixSmaller || i < upperBound);
                    }
                }

                memo[key] = res;
            }

            return memo[key];
        }

        int result = 0;
        int prod = 9;
        for (int i = 0; i < nStr.Length - 1; i++){
            result += prod;
            prod *= 9 - i;
        }

        result += Dp(0, false);

        return result;
    }
}
