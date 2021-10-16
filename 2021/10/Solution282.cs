using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 282
    /// title:  给表达式添加运算符
    /// problems: https://leetcode-cn.com/problems/expression-add-operators/
    /// date: 20211016
    /// </summary>
    public static class Solution282
    {
        // 参考解答 回溯
        public static  IList<string> AddOperators(string num, int target) {
            
            int length = num.Length;
            IList<string> ans = new List<string>();
            var expr = new StringBuilder();

            void Backtrack(int i, long res, long mul) {
                if (i == length) {
                    if (res == target) {
                        ans.Add(expr.ToString());
                    }
                    return;
                }

                int signIndex = expr.Length;
                if (i > 0) {
                    expr.Append(0); // 占位，下面填充符号
                }
                long val = 0;
                // 枚举截取的数字长度（取多少位），注意数字可以是单个 0 但不能有前导零
                for (int j = i; j < length && (j == i || num[i] != '0'); ++j) {
                    val = val * 10 + num[j] - '0';
                    expr.Append(num[j]);
                    if (i == 0) { // 表达式开头不能添加符号
                        Backtrack(j + 1, val, val);
                    } else { // 枚举符号
                        expr.Replace(expr[signIndex], '+', signIndex, 1);
                        Backtrack(j + 1, res + val, val);
                        expr.Replace(expr[signIndex], '-', signIndex, 1);
                        Backtrack(j + 1, res - val, -val);
                        expr.Replace(expr[signIndex], '*', signIndex, 1);
                        Backtrack(j + 1, res - mul + mul * val, mul * val);
                    }
                }
                expr.Length = signIndex;
            }

            Backtrack(0, 0, 0);

            return ans;
        }
    }
}