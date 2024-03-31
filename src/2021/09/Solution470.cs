using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 470
    /// title: 用 Rand7() 实现 Rand10()
    /// problems: https://leetcode-cn.com/problems/implement-rand10-using-rand7/
    /// date: 20210905
    /// </summary>
    public static class Solution470
    {
        public class SolBase{
            public int Rand7() => (new Random()).Next(1, 7);
        }

        public class Solution: SolBase {
            public int Rand10() {
                int row, col, idx;
                do {
                    row = Rand7();
                    col = Rand7();
                    idx = col + (row - 1) * 7;
                } while (idx > 40);
                return 1 + (idx - 1) % 10;
            }
        }
    }
}