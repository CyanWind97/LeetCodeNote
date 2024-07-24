using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2844
/// title: 生成特殊数字的最少操作
/// problems: https://leetcode.cn/problems/minimum-operations-to-make-a-special-number
/// date: 20240725
/// </summary>
public static class Solution2844
{
    public static int MinimumOperations(string num) {
        int length = num.Length;
        var span = num.AsSpan();
        bool find0 = false;
        bool find5 = false;

        for(int i = 1; i <= length; i++){
            if (span[^i] is '0'){
                if (find0)
                    return i - 2;

                find0 = true;
            }else if (span[^i] is '5'){
                if (find0)
                    return i - 2;

                find5 = true;
            }else if (span[^i] is '2' or '7'){
                if (find5)
                    return i - 2;
            }
        }

        return find0 ? length - 1 : length;
    }

}
