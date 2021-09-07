namespace LeetCodeNote
{
    /// <summary>
    /// no: 1221
    /// title: 分割平衡字符串
    /// problems: https://leetcode-cn.com/problems/split-a-string-in-balanced-strings/
    /// date: 20210907
    /// </summary>
    public static class Solution1221
    {
        public static int BalancedStringSplit(string s) {
            int length = s.Length;
            int count = 0;
            
            int left = 0;
            int right = 0;
            for(int i = 0; i < length; i++){
                if(s[i] == 'L')
                    left++;
                else
                    right++;
                
                if(left == right)
                    count++;
            }

            return count;
        }
    }
}