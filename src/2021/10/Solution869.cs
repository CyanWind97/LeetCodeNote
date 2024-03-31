using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 869
    /// title: 重新排序得到 2 的幂
    /// problems: https://leetcode-cn.com/problems/reordered-power-of-2/
    /// date: 20211028
    /// </summary>
    public static class Solution869
    {
        public static bool ReorderedPowerOf2(int n) {
            List<int> GetNums(int num){
                var nums = new List<int>();

                while(num > 0){
                    nums.Add(num % 10);
                    num = num / 10;
                }

                nums.Sort();
                
                return nums;
            }

            var numsList = GetNums(n);
            int length = numsList.Count;
            int limit = (int)Math.Pow(10, length - 1);

            var twoPowers = new List<int>();
            var twoPower = 1;
            while(twoPower < limit){
                twoPower <<= 1;
            }

            while(twoPower < limit * 10){
                twoPowers.Add(twoPower);
                twoPower <<= 1;
            }

            if (twoPowers.Count == 0)
                return false;
            
            numsList.Sort();
            foreach(var num in twoPowers){
                var compareList = GetNums(num);
                
                if (numsList.SequenceEqual(compareList))
                    return true;
            }

            return false;
        }
    }
}