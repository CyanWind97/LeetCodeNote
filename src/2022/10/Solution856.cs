namespace LeetCodeNote
{
    /// <summary>
    /// no: 856
    /// title: 括号的分数
    /// problems: https://leetcode.cn/problems/score-of-parentheses/
    /// date: 20221009
    /// </summary>
    public static class Solution856
    {
        public static int ScoreOfParentheses(string s) {
            int length = s.Length;
            int index = 0;

            int CalcScore(){
                int score = 0;
                while(index < length && s[index] != ')'){
                    index++;
                    if(s[index] == ')')
                        score += 1;
                    else
                        score += 2 * CalcScore();

                    index++;
                }

                return score;
            }

            return CalcScore();
        }

        // 参考解答
        // 根据深度直接计算
        // 因为有分值的只有()
        public static int ScoreOfParentheses_1(string s) {
            int bal = 0, n = s.Length, res = 0;
            for (int i = 0; i < n; i++) {
                bal += (s[i] == '(' ? 1 : -1);
                if (s[i] == ')' && s[i - 1] == '(') {
                    res += 1 << bal;
                }
            }
            return res;
        }
    }
}