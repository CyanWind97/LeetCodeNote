namespace LeetCodeNote
{
    /// <summary>
    /// no: 567
    /// title: 字符串的排列
    /// problems: https://leetcode-cn.com/problems/permutation-in-string/
    /// date: 20210210
    /// </summary>
    public static class Solution567
    {
        public static bool CheckInclusion(string s1, string s2) {
            int length1 = s1.Length;
            int length2 = s2.Length;
            int[] count = new int[26];
            
            foreach(var c in s1){
                count[c - 'a']++;
            }

            char[] chars = s2.ToCharArray();
            int left = 0;
            int right = 0;
            while(right < length2){
                char c = chars[right];
                if(count[c - 'a'] > 0){
                    count[c - 'a']--;
                }else{
                    while(left < right && chars[left] != c){
                        count[chars[left++] - 'a']++;
                    }
                    left++;
                }
                right++;
                if(right - left == length1)
                    return true;
            }

            return false;
        }
    }
}