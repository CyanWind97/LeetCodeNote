using System.Text;
using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 179
    /// title: 最大数
    /// problems: https://leetcode-cn.com/problems/largest-number/
    /// date: 20210412
    /// </summary>
    public static class Solution179
    {
        public static string LargestNumber(int[] nums) {
            Array.Sort(nums, 
                (a,b) => 
                {
                    long aN = 10, bN = 10;
                    while(aN <= a){
                        aN *= 10;
                    }

                    while(bN <= b){
                        bN *= 10;
                    }

                    return (aN * b + a).CompareTo(bN * a + b);
                });

            if(nums[0] == 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            foreach(var num in nums)
            {
                sb.Append(num);
            }

            return  sb.ToString();
        }
    }
}