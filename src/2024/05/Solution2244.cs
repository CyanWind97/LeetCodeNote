using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2244
/// title: 完成所有任务需要的最少轮数
/// problems: https://leetcode.cn/problems/minimum-rounds-to-complete-all-tasks
/// date: 20240514
/// </summary>

public static class Solution2244
{
    public static int MinimumRounds(int[] tasks) {
        var count = new Dictionary<int, int>();
        foreach (int task in tasks) {
            count.TryAdd(task, 0);
            count[task]++;
        }

        int result = 0;
        foreach (int v in count.Values) {
            if (v == 1) 
                return -1;
            
            if (v % 3 == 0) 
                result += v / 3;
            else
                result += 1 + v / 3;
        }
        
        return result;
    }
}
