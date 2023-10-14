using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 137
    /// title: 只出现一次的数字 II
    /// problems: https://leetcode-cn.com/problems/single-number-ii/
    /// date: 20210430
    /// </summary>
    public static partial class Solution137
    {
        public static int SingleNumber(int[] nums) {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(int num in nums){
                if(!dic.ContainsKey(num))
                    dic[num] = 0;
                
                dic[num]++;
            } 

            foreach(var pair in dic){
                if(pair.Value == 1)
                    return pair.Key;
            }

            return nums[0];
        }


        // 参考解答 数字电路
        public static int SingleNumber_1(int[] nums) {
            int a = 0;
            int b = 0;
            foreach(int num in nums){
                b = ~a & (b ^ num);
                a = ~b & (a ^ num);
            }

            return b;
        }
    }
}