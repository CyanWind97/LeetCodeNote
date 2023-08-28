using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 823
    /// title: 带因子的二叉树
    /// problems: https://leetcode.cn/problems/binary-trees-with-factors/
    /// date: 20230829
    /// </summary>
    public static class Solution823
    {   
        public static int NumFactoredBinaryTrees(int[] arr) {
            int length = arr.Length;
            Array.Sort(arr);
            var dp = new long[length];
            Array.Fill(dp, 1);

            var dic = new Dictionary<int, int>();
            for(int i = 0; i < length; i++){
                dic.Add(arr[i], i);
            }

            long Mod = 1000000007;
            for(int i = 0; i < length; i++){
                for(int j = 0; j < i; j++){
                    if(arr[i] % arr[j] == 0){
                        int right = arr[i] / arr[j];
                        if(dic.ContainsKey(right)){
                            dp[i] = (dp[i] + dp[j] * dp[dic[right]]) % Mod;
                        }
                    }
                }
            }

            long result = 0;
            foreach(var num in dp){
                result = (result + num) % Mod;
            }

            return (int)result;
        }
    }
}