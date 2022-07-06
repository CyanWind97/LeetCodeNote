using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 736
    /// title: Lisp 语法解析
    /// problems: https://leetcode.cn/problems/parse-lisp-expression/
    /// date: 20220706
    /// </summary>
    public static class Solution736
    {
        // 参考解答 状态机
        public static int Evaluate(string expression) {
            var scope = new Dictionary<string, Stack<int>>();

            int CalculateToken(string token)
                => char.IsLower(token[0]) ? scope[token].Peek() : int.Parse(token);
            
            var vars = new Stack<Stack<string>>();
            int start = 0, n = expression.Length;
            var stack = new Stack<Expr>();
            var cur = new Expr(ExprStatus.VALUE);
            while (start < n) {
                if (expression[start] == ' ') {
                    start++; // 去掉空格
                    continue;
                }
                if (expression[start] == '(') {
                    start++; // 去掉左括号
                    stack.Push(cur);
                    cur = new Expr(ExprStatus.NONE);
                    continue;
                }
                var sb = new StringBuilder();
                if (expression[start] == ')') { // 本质上是把表达式转成一个 token
                    start++; // 去掉右括号
                    if (cur.status == ExprStatus.LET2) {
                        sb = new StringBuilder(cur.value.ToString());
                        foreach (string var in vars.Peek()) { // 清除作用域
                            scope[var].Pop();
                        }
                        vars.Pop();
                    } else if (cur.status == ExprStatus.ADD2) {
                        sb = new StringBuilder((cur.e1 + cur.e2).ToString());
                    } else {
                        sb = new StringBuilder((cur.e1 * cur.e2).ToString());
                    }
                    cur = stack.Pop(); // 获取上层状态
                } else {
                    while (start < n && expression[start] != ' ' && expression[start] != ')') {
                        sb.Append(expression[start]);
                        start++;
                    }
                }
                string token = sb.ToString();
                switch (cur.status) {
                case ExprStatus.VALUE:
                    cur.value = int.Parse(token);
                    cur.status = ExprStatus.DONE;
                    break;
                case ExprStatus.NONE:
                    if ("let".Equals(token)) {
                        cur.status = ExprStatus.LET;
                        vars.Push(new Stack<string>()); // 记录该层作用域的所有变量, 方便后续的清除
                    } else if ("add".Equals(token)) {
                        cur.status = ExprStatus.ADD;
                    } else if ("mult".Equals(token)) {
                        cur.status = ExprStatus.MULT;
                    }
                    break;
                case ExprStatus.LET:
                    if (expression[start] == ')') { // let 表达式的最后一个 expr 表达式
                        cur.value = CalculateToken(token);
                        cur.status = ExprStatus.LET2;
                    } else {
                        cur.var = token;
                        vars.Peek().Push(token); // 记录该层作用域的所有变量, 方便后续的清除
                        cur.status = ExprStatus.LET1;
                    }
                    break;
                case ExprStatus.LET1:
                    if (!scope.ContainsKey(cur.var)) {
                        scope.Add(cur.var, new Stack<int>());
                    }
                    scope[cur.var].Push(CalculateToken(token));
                    cur.status = ExprStatus.LET;
                    break;
                case ExprStatus.ADD:
                    cur.e1 = CalculateToken(token);
                    cur.status = ExprStatus.ADD1;
                    break;
                case ExprStatus.ADD1:
                    cur.e2 = CalculateToken(token);
                    cur.status = ExprStatus.ADD2;
                    break;
                case ExprStatus.MULT:
                    cur.e1 = CalculateToken(token);
                    cur.status = ExprStatus.MULT1;
                    break;
                case ExprStatus.MULT1:
                    cur.e2 = CalculateToken(token);
                    cur.status = ExprStatus.MULT2;
                    break;
                }
            }
            return cur.value;
        }

        public enum ExprStatus {
            VALUE,     // 初始状态
            NONE,      // 表达式类型未知
            LET,       // let 表达式
            LET1,      // let 表达式已经解析了 vi 变量
            LET2,      // let 表达式已经解析了最后一个表达式 expr
            ADD,       // add 表达式
            ADD1,      // add 表达式已经解析了 e1 表达式
            ADD2,      // add 表达式已经解析了 e2 表达式
            MULT,      // mult 表达式
            MULT1,     // mult 表达式已经解析了 e1 表达式
            MULT2,     // mult 表达式已经解析了 e2 表达式
            DONE       // 解析完成
        }

        public class Expr {
            public ExprStatus status;
            public string var; // let 的变量 vi
            public int value; // VALUE 状态的数值，或者 LET2 状态最后一个表达式的数值
            public int e1, e2; // add 或 mult 表达式的两个表达式 e1 和 e2 的数值

            public Expr(ExprStatus s) {
                status = s;
            }
        }
    }
}