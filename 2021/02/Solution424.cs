using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 424
    /// title: 替换后的最长重复字符
    /// problems: https://leetcode-cn.com/problems/longest-repeating-character-replacement/
    /// date: 20210202
    /// </summary>
    public class Solution424
    {
        // 参考解答 滑动窗口
        public static int CharacterReplacement(string s, int k) {
            int length = s.Length;
            if(length < k)
                return  length;
            
            char[] chars = s.ToCharArray();
            int[] count = new int[26];
            int left = 0;
            int right = 0;
            int maxCount = 0;
            while(right < length){
                int index = chars[right] - 'A';
                count[index]++;
                maxCount = Math.Max(maxCount, count[index]);
                right++;

                if(right - left > maxCount + k){
                    count[chars[left] - 'A']--;
                    left++;
                }
            }

            return right - left;
        }
    }
}