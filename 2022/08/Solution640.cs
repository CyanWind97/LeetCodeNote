namespace LeetCodeNote
{
    /// <summary>
    /// no: 640
    /// title:  求解方程
    /// problems: https://leetcode.cn/problems/solve-the-equation/
    /// date: 20220810
    /// </summary>
    public static class Solution640
    {
        // 参考解答
        public static string SolveEquation(string equation) {
            int factor = 0, val = 0;
            int index = 0, n = equation.Length, sign1 = 1; // 等式左边默认系数为正
            while (index < n) {
                if (equation[index] == '=') {
                    sign1 = -1; // 等式右边默认系数为负
                    index++;
                    continue;
                }

                int sign2 = sign1, number = 0;
                bool valid = false; // 记录 number 是否有效
                if (equation[index] == '-' || equation[index] == '+') { // 去掉前面的符号
                    sign2 = (equation[index] == '-') ? -sign1 : sign1;
                    index++;
                }
                while (index < n && char.IsDigit(equation[index])) {
                    number = number * 10 + (equation[index] - '0');
                    index++;
                    valid = true;
                }

                if (index < n && equation[index] == 'x') { // 变量
                    factor += valid ? sign2 * number : sign2;
                    index++;
                } else { // 数值
                    val += sign2 * number;
                }
            }

            if (factor == 0) 
                return val == 0 ? "Infinite solutions" : "No solution";
            
            if (val % factor != 0) 
                return "No solution";
            
            return "x=" + (-val / factor);
        }
    }
}