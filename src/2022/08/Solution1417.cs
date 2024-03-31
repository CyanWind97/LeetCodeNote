using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1417
    /// title:  重新格式化字符串
    /// problems: https://leetcode.cn/problems/reformat-the-string/
    /// date: 20220811
    /// </summary>
    public static class Solution1417
    {
        public static string Reformat(string s) {
            var letters = new List<char>();
            var nums = new List<char>();
            
            foreach(var c in s){
                if(char.IsNumber(c))
                    nums.Add(c);
                else
                    letters.Add(c);
            }

            if(Math.Abs(nums.Count - letters.Count) > 1)
                return "";
            
            var sb = new StringBuilder();
            int n = Math.Min(nums.Count, letters.Count);
            if(nums.Count > n)
                sb.Append(nums.Last());
            
            
            for(int i = 0; i < n; i++){
                sb.Append(letters[i]);
                sb.Append(nums[i]);
            }

            if(letters.Count > n)
                sb.Append(letters.Last());
            
            return sb.ToString();
        }
    }
}