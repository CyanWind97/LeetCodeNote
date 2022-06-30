using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 241
    /// title: 为运算表达式设计优先级
    /// problems: https://leetcode.cn/problems/different-ways-to-add-parentheses/
    /// date: 202200701
    /// </summary>
    public static class Solution241
    {
        // 参考解答 dp
        public static IList<int> DiffWaysToCompute(string expression) {
            const int ADDITION = -1;
            const int SUBTRACTION = -2;
            const int MULTIPLICATION = -3;

            var ops = new List<int>();
            for(int i = 0; i < expression.Length;){
                if(!char.IsDigit(expression[i])){
                    if(expression[i] == '+')
                        ops.Add(ADDITION);
                    else if (expression[i] == '-')
                        ops.Add(SUBTRACTION);
                    else
                        ops.Add(MULTIPLICATION);
                    i++;
                }else{
                    int t = 0;
                    while(i < expression.Length && char.IsDigit(expression[i])){
                        t = t * 10 + expression[i] - '0';
                        i++;
                    }
                    ops.Add(t);
                }
            }

            var dp = new IList<int>[ops.Count, ops.Count];
            for(int i = 0; i < ops.Count; i++){
                for(int j = 0; j < ops.Count; j++){
                    dp[i, j] = new List<int>();
                }

                if(i % 2 == 0)
                    dp[i, i].Add(ops[i]);
            }

            for(int i = 3; i <= ops.Count; i++){
                for(int j = 0; j + i <= ops.Count; j += 2){
                    int l = j;
                    int r = j + i - 1;
                    for(int k = j + 1; k < r; k += 2){
                        var left = dp[l, k - 1];
                        var right = dp[k + 1, r];

                        foreach(var num1 in left){
                            foreach(var num2 in right){
                                if(ops[k] == ADDITION)
                                    dp[l, r].Add(num1 + num2);
                                else if(ops[k] == SUBTRACTION)
                                    dp[l, r].Add(num1 - num2);
                                else if(ops[k] == MULTIPLICATION)
                                    dp[l, r].Add(num1 * num2);
                            }
                        }
                    }
                }
            }

            return dp[0, ops.Count - 1];
        }
    }
}