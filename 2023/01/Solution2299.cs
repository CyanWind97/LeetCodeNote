using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2299
    /// title: 强密码检验器 II
    /// problems: https://leetcode.cn/problems/strong-password-checker-ii/
    /// date: 20230119
    /// </summary>
    public static class Solution2299
    {
        public static bool StrongPasswordCheckerII(string password) {
            if(password.Length < 8)
                return false;
            
            var speacials = "!@#$%^&*()-+".ToHashSet();
            // 0 小写 1 大写 2 数字 3 特殊
            var checkers = new bool[4];
            char prev = ' ';

            foreach(var c in password){
                if(c == prev)
                    return false;
                
                if(char.IsLower(c))
                    checkers[0] = true;
                else if(char.IsUpper(c))
                    checkers[1] = true;
                else if(char.IsDigit(c))
                    checkers[2] = true;
                else if(speacials.Contains(c))
                    checkers[3] = true;
                
                prev = c;
            }

            return checkers.All(checker => checker);
        }
    }
}