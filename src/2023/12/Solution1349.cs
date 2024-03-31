using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 1349
    /// title: 参加考试的最大学生数
    /// problems: https://leetcode.cn/problems/maximum-students-taking-exam/description/?envType=daily-question&envId=2023-12-26
    /// date: 20231226
    /// </summary>
    public static class Solution1349
    {

        // 参考解答
        public static int MaxStudents(char[][] seats) {
            var memo = new Dictionary<int, int>();
            int m = seats.Length, n = seats[0].Length;

            int DP(int row, int status) {
                int n = seats[0].Length;
                int key = (row << n) + status;
                if (!memo.ContainsKey(key)) {
                    if (!IsSingleRowCompliant(status, row)) {
                        memo.Add(key, int.MinValue);
                        return int.MinValue;
                    }
                    int students = BitCount(status);
                    if (row == 0) {
                        memo.Add(key, students);
                        return students;
                    }
                    int mx = 0;
                    for (int upperRowStatus = 0; upperRowStatus < 1 << n; upperRowStatus++) {
                        if (IsCrossRowsCompliant(status, upperRowStatus)) {
                            mx = Math.Max(mx, DP(row - 1, upperRowStatus));
                        }
                    }
                    memo.Add(key, students + mx);
                }
                return memo[key];
            }

            
            bool IsSingleRowCompliant(int status, int row) {
                for (int j = 0; j < n; j++) {
                    if (((status >> j) & 1) == 1) {
                        if (seats[row][j] == '#') {
                            return false;
                        }
                        if (j > 0 && ((status >> (j - 1)) & 1) == 1) {
                            return false;
                        }
                    }
                }
                return true;
            }

            bool IsCrossRowsCompliant(int status, int upperRowStatus) {
                for (int j = 0; j < n; j++) {
                    if (((status >> j) & 1) == 1) {
                        if (j > 0 && ((upperRowStatus >> (j - 1)) & 1) == 1) {
                            return false;
                        }
                        if (j < n - 1 && ((upperRowStatus >> (j + 1)) & 1) == 1) {
                            return false;
                        }
                    }
                }
                return true;
            }

            int BitCount(int num) {
                uint bits = (uint) num;
                bits = bits - ((bits >> 1) & 0x55555555);
                bits = (bits & 0x33333333) + ((bits >> 2) & 0x33333333);
                bits = (bits + (bits >> 4)) & 0x0f0f0f0f;
                bits = (bits + (bits >> 8)) & 0x00ff00ff;
                bits = (bits + (bits >> 16)) & 0x0000ffff;
                return (int) bits;
            }

            

            int mx = 0;    
            for (int i = 0; i < 1 << n; i++) {
                mx = Math.Max(mx, DP(m - 1, i));
            }
            return mx;
        }
    }
}