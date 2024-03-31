using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2698
    /// title: 求一个整数的惩罚数
    /// problems: https://leetcode.cn/problems/find-the-punishment-number-of-an-integer/?envType=daily-question&envId=2023-10-25
    /// date: 20231025
    /// </summary>
    public static class Solution2698
    {
        // 参考解答
        public static int PunishmentNumber(int n) {
            bool DFS(string s, int pos, int tot, int target) {
                if (pos == s.Length) {
                    return tot == target;
                } 
                int sum = 0;
                for (int i = pos; i < s.Length; i++) {
                    sum = sum * 10 + s[i] - '0';
                    if (sum + tot > target) {
                        break;
                    }
                    if (DFS(s, i + 1, sum + tot, target)) {
                        return true;
                    }
                }
                return false;
            }

            int res = 0;
            for (int i = 1; i <= n; i++) {
                string s = (i * i).ToString();
                if (DFS(s, 0, 0, i)) {
                    res += i * i;
                }
            }

            return res;
        }
    }
}