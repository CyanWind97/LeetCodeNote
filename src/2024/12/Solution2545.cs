using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2545
/// title: 根据第 K 场考试的分数排序
/// problems: https://leetcode.cn/problems/sort-the-students-by-their-kth-score
/// date: 20241221
/// </summary>
public static class Solution2545
{
    public static int[][] SortTheStudents(int[][] score, int k) {
        Array.Sort(score, (a, b) => b[k] - a[k]);
        return score;
    }
}
