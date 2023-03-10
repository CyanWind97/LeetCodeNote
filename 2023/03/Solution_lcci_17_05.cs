using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 17.05
    /// title: 字母与数字
    /// problems: https://leetcode.cn/problems/find-longest-subarray-lcci/
    /// date: 20230311
    /// type: 面试题 lcci
    /// </summary>
    public class Solution_lcci_17_05
    {
        public static string[] FindLongestSubarray(string[] array) {
            var indexs = new Dictionary<int, int>();
            indexs[0] = -1;
            int sum = 0;
            int maxLength = 0;
            int start = -1;
            int length = array.Length;

            for(int i = 0; i < length; i++){
                if(char.IsLetter(array[i][0]))
                    sum++;
                else
                    sum--;
                
                if(indexs.ContainsKey(sum)){
                    int first = indexs[sum];
                    if(i - first > maxLength){
                        maxLength = i - first;
                        start = first + 1;
                    }
                }else{
                    indexs[sum] = i;
                }
            }

            if(maxLength == 0)
                return new string[0];
            
            return array.Skip(start).Take(maxLength).ToArray();
        }
    }
}