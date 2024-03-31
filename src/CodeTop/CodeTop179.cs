using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 179
    /// title:  最大数
    /// problems: https://leetcode.cn/problems/largest-number/
    /// date: 20220517
    /// priority: 0080
    /// time: 00:41:55.70 timeout
    /// </summary>
    public static class CodeTop179
    {

        public static string LargestNumber(int[] nums) {
            int Compare(int a, int b){
                long pa = 10;
                long pb = 10;
                while(pa <= a){
                    pa *= 10;
                }

                while(pb <= b){
                    pb *= 10;
                }

                return (int)(b * pa + a - a * pb - b);
            }
            

            var tmp = nums.OrderBy(x => x, Comparer<int>.Create(Compare)).ToList();
            if(tmp[0] == 0)
                return "0";

            return string.Join("", tmp);
        }
    }
}