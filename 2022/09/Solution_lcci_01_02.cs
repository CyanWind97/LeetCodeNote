using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 01.02
    /// title: 01.02. 判定是否互为字符重排
    /// problems: https://leetcode.cn/problems/missing-two-lcci/
    /// date: 20220927
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_01_02
    {
        public static bool CheckPermutation(string s1, string s2) {
            int l1 = s1.Length;
            int l2 = s2.Length;

            if(l1 != l2)
                return false;
            
            var count = new Dictionary<char, int>();
            foreach(var c in s1){
                if(!count.ContainsKey(c))
                    count[c] = 1;
                else
                    count[c]++;
            }

            foreach(var c in s2){
                if(!count.ContainsKey(c))
                    return false;
                
                if(count[c] == 0)
                    return false;
                
                count[c]--;
            }

            return true;
        }
    }
}