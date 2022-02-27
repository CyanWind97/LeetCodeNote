namespace LeetCodeNote
{
    /// <summary>
    /// no: 917
    /// title: 仅仅反转字母
    /// problems: https://leetcode-cn.com/problems/reverse-only-letters/
    /// date: 20220223
    /// </summary>
    public static class Solution917
    {
        public static string ReverseOnlyLetters(string s) {
            var chars = s.ToCharArray();
            int left = 0;
            int right = chars.Length - 1;

            while(left < right){
                while(left < right && !char.IsLetter(chars[left])){
                    left++;
                }

                while(right > left && !char.IsLetter(chars[right])){
                    right--;
                }

                if(left < right){
                    (chars[left], chars[right]) = (chars[right], chars[left]);
                    left++;
                    right--;
                }
            }

            return new string(chars);
        }
    }
}