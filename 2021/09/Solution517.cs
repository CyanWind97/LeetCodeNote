using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 517
    /// title: 超级洗衣机
    /// problems: https://leetcode-cn.com/problems/super-washing-machines/
    /// date: 20210929
    /// </summary>
    public class Solution517
    {
        public static int FindMinMoves(int[] machines) {
            int length = machines.Length;
            int sum = machines.Sum();
            if (sum % length != 0)
                return -1;

            int avg = sum / length;
            int ans = 0, totol = 0;
            foreach (int num in machines) {
                int tmp = num - avg;
                totol += tmp;
                ans = Math.Max(ans, Math.Max(Math.Abs(totol), tmp));
            }

            return ans;
        }
    }
}