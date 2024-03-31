using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 395
    /// title: 至少有K个重复字符的最长子串
    /// problems: https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/
    /// date: 20210227
    /// </summary>
    public static class Solution395
    {
        // 参考解答 滑动窗口
        public static int LongestSubstring(string s, int k) {
            int length = s.Length;
            int result = 0;
            int max = s.GroupBy(x => x).Where(x => x.Count() >= k).Count();

            for(int t = 1; t <= max; t++){
                int left = 0;
                int right = 0;
                int[] count = new int[26];
                int total = 0;
                int less = 0;
                
                while(right < length){
                    char cur = s[right];
                    count[cur - 'a']++;

                    if(count[cur - 'a'] == 1){
                        total++;
                        less++;
                    }
                    if(count[cur - 'a'] == k){
                        less--;
                    }

                    while(total > t){
                        char pre = s[left];
                        count[pre - 'a']--;
                        if(count[pre - 'a'] == k - 1){
                            less++;
                        }
                        if(count[pre - 'a'] == 0){
                            total--;
                            less--;
                        }
                        left++;
                    }
                    
                    right++;

                    if(less == 0)
                        result = Math.Max(result, right - left);
                }
            }

            return result;
        }

        // 参考解答 分治
        public static int LongestSubstring_1(string s, int k) {
            int length = s.Length;

            int dfs(int left, int right){
                int[] count = new int[26];
                for(int i = left; i <= right; i++){
                    count[s[i] - 'a']++;
                }

                char split = (char)0;
                for(int i = 0; i < 26; i++){
                    if(count[i] > 0 && count[i] < k){
                        split = (char)(i + 'a');
                        break;
                    }
                }

                if(split == (char)0){
                    return right - left + 1;
                }

                int end = left;
                int result = 0;
                while(end <= right){
                    while(end <= right && s[end] == split){
                        end++;
                    }
                    if(end > right)
                        break;
                    
                    int start = end;
                    while(end <= right && s[end] != split){
                        end++;
                    }
                    result = Math.Max(result, dfs(start, end - 1));
                }
                
                return result;
            }

            return dfs(0, length - 1);
        }

        
    }
}