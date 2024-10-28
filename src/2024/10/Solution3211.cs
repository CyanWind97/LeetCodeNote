using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3211
/// title: 生成不含相邻零的二进制字符串
/// problems: https://leetcode.cn/problems/generate-binary-strings-without-adjacent-zeros
/// date: 20241029
/// </summary>
public static class Solution3211
{
    public static IList<string> ValidStrings(int n) {
        var result = new List<string>();
        var current = new char[n];

        void GenerateValidStrings(int index){
            if (index == n) {
                result.Add(new string(current));
                return;
            }

            if (index == 0 || current[index - 1] == '1') {
                current[index] = '0';
                GenerateValidStrings(index + 1);
            }

            current[index] = '1';
            GenerateValidStrings(index + 1);
        }

        GenerateValidStrings(0);
        return result;
    }
}
