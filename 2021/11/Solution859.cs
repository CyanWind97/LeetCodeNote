using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 859
    /// title: 亲密字符串
    /// problems: https://leetcode-cn.com/problems/buddy-strings/
    /// date: 20211123
    /// </summary>
    public static class Solution859
    {
        public static bool BuddyStrings(string s, string goal) {
            int length = s.Length;
            if (goal.Length != length || length == 1)
                return false;
            
            int[] count = new int[26];
            int[] diff = new int[2];
            int index = 0;

            for(int i = 0; i < length; i++){
                if(s[i] == goal[i])
                    count[s[i] - 'a']++;
                else if (index > 1)
                    return false;
                else
                    diff[index++] = i;
            }

            if (index == 1)
                return false;
            
            if (index == 0)
                return count.Any(x => x >= 2);
            
            return s[diff[0]] == goal[diff[1]] && s[diff[1]] == goal[diff[0]];
        }
    }
}