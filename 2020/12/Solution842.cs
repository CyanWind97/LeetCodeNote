using System.Collections.Generic;
using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 842
    /// problems: https://leetcode-cn.com/problems/split-array-into-fibonacci-sequence/
    /// date: 20201208
    /// </summary>
    public static class Solution842
    {
        // 官方解答：回溯法 + 减枝
    
        public static IList<int> SplitIntoFibonacci(string S) {
            IList<int> result = new List<int>();
            if(S.Length < 3)
                return result;

            for (int i = 1; i <= Math.Min(S.Length / 2, 10); i++) {
                if((i > 1 && S.Substring(S.Length - i, 1) == "0")
                || (i == 10 && (S.Substring(S.Length - i).CompareTo(int.MaxValue.ToString()) > 0)))
                    continue;
                
                for(int j = 1; j <= i; j++) {
                    if((j > 1 && S.Substring(S.Length - i - j, 1) == "0")
                    || (j == 10 && S.Substring(S.Length - i - j, j).CompareTo(int.MaxValue.ToString()) > 0))
                        continue;
                    result = GetFibonacci(S, i, j);
                    if(result.Count > 0){
                        return result;
                    }
                }
            }

            return result;
        }

        public static IList<int> GetFibonacci(String S, int i, int j) {
            List<int> list = new List<int>();
            int length = S.Length;

            int val1 = int.Parse(S.Substring(length - i));
            int val2 = int.Parse(S.Substring(length - i - j, j));
            int val3 = val1 - val2; 
            int remain = length - (i + j);
            
            if(remain > 0) {
                list.Add(val1);
                list.Add(val2);
            }

            while(remain > 0) {
                if(val3 < 0)
                    return new List<int>();
                
                string tmp = val3.ToString();
                int k = val3 == 0 ? 1: tmp.Length;
                if(remain < k || !tmp.Equals(S.Substring(remain - k, k)))
                    return new List<int>();
                
                list.Add(val3);
                remain -= k;
                val1 = val2;
                val2 = val3;
                val3 = val1 - val2;
            }

            list.Reverse();

            return list;
        }
    }
}