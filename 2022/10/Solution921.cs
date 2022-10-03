namespace LeetCodeNote
{
    /// <summary>
    /// no: 921
    /// title: 使括号有效的最少添加
    /// problems: https://leetcode.cn/problems/minimum-add-to-make-parentheses-valid/
    /// date: 20221004
    /// </summary>
    public static class Solution921
    {
        public static int MinAddToMakeValid(string s) {
            int result = 0;
            int l = 0;

            foreach(var c in s){
                if(c == '(')
                    l++;
                else if(l == 0)
                    result++;
                else
                    l--;
            }

            return result + l;
        }
    }
}