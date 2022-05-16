using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 76
    /// title:  最小覆盖子串
    /// problems: https://leetcode.cn/problems/minimum-window-substring/
    /// date: 20220515
    /// priority: 0053
    /// time: 00:28:19.19
    /// </summary>
    public static class CodeTop76
    {
        public static string MinWindow(string s, string t) {
            int sLength = s.Length;
            int tLength = t.Length;

            if(tLength > sLength)
                return "";

            var tKeys = new Dictionary<char, int>();

            foreach(var c in t){
                if(!tKeys.ContainsKey(c))
                    tKeys.Add(c, 1);
                else
                    tKeys[c]++;
            }

            int left = 0;
            int right = 0;
            int minL = sLength + 1;
            int start = 0;

            int count = tLength;
            var sKeys = new Dictionary<char, int>(tKeys);

            while(right < sLength){
                while(right < sLength && count > 0){
                    var c = s[right];
                    if(sKeys.ContainsKey(c)){
                        if(sKeys[c] > 0)
                            count--;
                        
                        sKeys[c]--;
                    }

                    right++;
                }

                if(right == sLength && count > 0)
                    break;

                while(left < right && count == 0){
                    var c = s[left];
                    if(sKeys.ContainsKey(c)){
                        if(sKeys[c] == 0 )
                            count++;

                        sKeys[c]++;
                    }

                    left++;
                }

                if(count == 1){
                    int l = right - left + 1;
                    if(l < minL){
                        start = left - 1;
                        minL = l;
                    }
                }
            }

            return minL <= sLength ? s.Substring(start, minL) : "";
        }
    }
}