using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 831
    /// title: 隐藏个人信息
    /// problems: https://leetcode.cn/problems/masking-personal-information/
    /// date: 20230401
    /// </summary>
    public static class Solution831
    {
        public static string MaskPII(string s) {
            var splits = s.Split("@");

            if(splits.Length > 1){
                // email
                var start = char.ToLower(splits[0].First());
                var end = char.ToLower(splits[0].Last());

                return $"{start}*****{end}@{splits[1].ToLower()}";
            }else{
                var digits = s.Where(c => char.IsDigit(c)).ToList();
                var builder = new StringBuilder();
                if(digits.Count > 10){
                    builder.Append('+');

                    for(int i = digits.Count; i > 10; i--){                
                        builder.Append("*");
                    }

                    builder.Append("-");
                }
                
                builder.Append($"***-***-");
                foreach(var c in digits.TakeLast(4)){
                    builder.Append(c);
                }

                return builder.ToString();
            }
        }
    }
}