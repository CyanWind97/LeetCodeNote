namespace LeetCodeNote
{
    /// <summary>
    /// no: 796
    /// title: 旋转字符串
    /// problems: https://leetcode-cn.com/problems/rotate-string/
    /// date: 20220407
    /// </summary>
    public static class Solution796
    {
        // IndexOf效率高于Contains?
        public static bool RotateString(string s, string goal) {
            return s.Length == goal.Length && (s + s).IndexOf(goal) >= 0;
        }
    }
}