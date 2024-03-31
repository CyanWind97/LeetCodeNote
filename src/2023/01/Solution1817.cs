using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1817
    /// title: 查找用户活跃分钟数
    /// problems: https://leetcode.cn/problems/finding-the-users-active-minutes/i/
    /// date: 20230120
    /// </summary>
    public static class Solution1817
    {
        public static int[] FindingUsersActiveMinutes(int[][] logs, int k) {
            var infos = logs.GroupBy(log => log[0])
                        .Select(g => g.Select(g => g[1]).Distinct().Count());
            
            var result = new int[k];
            foreach(var info in infos){
                result[info - 1]++;
            }

            return result;
        }
    }
}