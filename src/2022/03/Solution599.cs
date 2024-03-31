using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 599
    /// title: 两个列表的最小索引总和
    /// problems: https://leetcode-cn.com/problems/minimum-index-sum-of-two-lists/
    /// date: 20220314
    /// </summary>
    public static class Solution599
    {
        public static string[] FindRestaurant(string[] list1, string[] list2) {
            int len1 = list1.Length; 
            int len2 = list2.Length;
            if(len1 > len2){
                (list1, list2) = (list2, list1);
                (len1, len2) = (len2, len1);
            }

            var dic = new Dictionary<string, int>();
            for(int i = 0; i < len1; i++){
                dic.Add(list1[i], i);
            }

            var min = 2000;
            var result = new List<string>();

            for(int i = 0; i < Math.Min(min + 1, len2); i++){
                if(!dic.ContainsKey(list2[i]))
                    continue;
                
                int sum = dic[list2[i]] + i;
                if(sum > min)
                    continue;

                if(sum < min){
                    min = sum;
                    result.Clear();
                }
                
                result.Add(list2[i]);
            }

            return result.ToArray();
        }
    }
}