using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2843
/// title: 统计对称整数的数目
/// problems: https://leetcode.cn/problems/count-the-number-of-powerful-integers
/// date: 20250411
/// </summary>
public class Solution2843
{
    public static int CountSymmetricIntegers(int low, int high) {
        int count = 0;
        for (int a = low; a <= high; ++a) {
            if (a < 100 && a % 11 == 0) {
                count++;
            } else if (1000 <= a && a < 10000) {
                int left = a / 1000 + (a % 1000) / 100;
                int right = (a % 100) / 10 + a % 10;
                if (left == right) {
                    count++;
                }
            }
        }

        return count;
    }
}
