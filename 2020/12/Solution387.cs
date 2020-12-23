using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 387
    /// title: 字符串中的第一个唯一字符
    /// problems: https://leetcode-cn.com/problems/first-unique-character-in-a-string/
    /// date: 20201223
    /// </summary>
    public static class Solution387
    {
        
        public static int FirstUniqChar(string s) {
            int legnth = s.Length;
            if(legnth == 0)
                return -1;
            
            int[] count = new int[26];
            List<int> result = new List<int>();
            char[] chars = s.ToCharArray();
            for(int i = 0; i < legnth; i++){
                char c = chars[i];
                if(count[c - 'a'] == 0){
                    result.Add(i);
                }else if(count[c - 'a'] == 1){
                    int x = -1;
                    foreach(var item in result){
                        if(chars[item] == c){
                            x = item;
                            break;
                        }
                    }
                    result.Remove(x);
                }
                count[c - 'a']++;
            }

            return result.Count == 0 ? -1 : result[0];
        }

        //参考解答
        public static int FirstUniqChar_1(string s) {
            int[] count = new int[26];
            char[] chars = s.ToCharArray();
            int length = chars.Length;

            for(int i = 0; i <length; i++)
            {
                count[chars[i] - 'a']++;
            }


            for (int i = 0; i < length; i++)
            {
                if (count[chars[i] - 'a'] == 1) 
                    return i;
            }

            return -1;
        }
    }
}