using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1625
    /// title: 执行操作后字典序最小的字符串
    /// problems: https://leetcode.cn/problems/lexicographically-smallest-string-after-applying-operations/
    /// date: 20230319
    /// </summary>
    public static class Solution1625
    {
        // 参考解答
        public static string FindLexSmallestString(string s, int a, int b) {
            int n = s.Length;
            string res = s;
            s = s + s;

            int GCD(int num1, int num2) {
                while (num2 != 0) {
                    int temp = num1;
                    num1 = num2;
                    num2 = temp % num2;
                }
                return num1;
            }


            int g = GCD(b, n);
            for (int i = 0; i < n; i += g) {
                for (int j = 0; j < 10; j++) {
                    int kLimit = b % 2 == 0 ? 0 : 9;
                    for (int k = 0; k <= kLimit; k++) {
                        char[] t = s.Substring(i, n).ToCharArray();
                        for (int p = 1; p < n; p += 2) {
                            t[p] = (char) ('0' + (t[p] - '0' + j * a) % 10);
                        }
                        for (int p = 0; p < n; p += 2) {
                            t[p] = (char) ('0' + (t[p] - '0' + k * a) % 10);
                        }
                        string tStr = new string(t);
                        if (tStr.CompareTo(res) < 0) {
                            res = tStr;
                        }
                    }
                }
            }

            return res;
        }
    }
}