using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 1884
/// title: 鸡蛋掉落-两枚鸡蛋
/// problems: https://leetcode.cn/problems/egg-drop-with-2-eggs-and-n-floors
/// date: 20241013
/// </summary>
public static class Solution1884
{
    public static int TwoEggDrop(int n) {
        return (int)Math.Ceiling((-1 + Math.Sqrt(1 + 8 * n)) / 2);
    }
}
