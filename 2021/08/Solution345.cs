using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 345
    /// title: 反转字符串中的元音字母
    /// problems: https://leetcode-cn.com/problems/reverse-vowels-of-a-string/
    /// date: 20210819
    /// </summary>
    public static class Solution345
    {
        
        public static string ReverseVowels(string s) {
            string vowels = "aeiouAEIOU";
            char[] chars = s.ToCharArray();
            int left = 0;
            int right = chars.Length - 1;
            while(left < right){
                while(left < right && !vowels.Contains(chars[left]))
                    left++;

                while(left < right && !vowels.Contains(chars[right]))
                    right--; 

                if(left >= right)
                    break;
                
                (chars[left], chars[right]) = (chars[right], chars[left]);
                left++;
                right--;
            }

            return new string(chars);
        }
    }
}