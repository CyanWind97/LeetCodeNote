namespace LeetCodeNote
{
    /// <summary>
    /// no: 537
    /// title: 复数乘法
    /// problems: https://leetcode-cn.com/problems/complex-number-multiplication/
    /// date: 20220225
    /// </summary>
    public static class Solution537
    {
        public static string ComplexNumberMultiply(string num1, string num2) {
            var p1 = num1.Split('+');
            var p2 = num2.Split('+');

            var r1 = int.Parse(p1[0]);
            var i1 = int.Parse(p1[1].TrimEnd('i'));
            var r2 = int.Parse(p2[0]);
            var i2 = int.Parse(p2[1].TrimEnd('i'));

            return $"{r1 * r2 - i1 * i2}+{r1 * i2 + i1 * r2}i";
        }
    }
}