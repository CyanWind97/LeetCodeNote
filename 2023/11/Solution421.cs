using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 421
    /// title: 数组中两个数的最大异或值
    /// problems: https://leetcode.cn/problems/maximum-xor-of-two-numbers-in-an-array/description/?envType=daily-question&envId=2023-11-04
    /// date: 20231104
    /// </summary>
    public static class Solution421
    {
        public static int FindMaximumXOR(int[] nums) {
            const int highBit = 30;

            int length = nums.Length;
            int x = 0;
            for(int k = highBit; k >= 0; k--){
                HashSet<int> set = new HashSet<int>();
                foreach(int num in nums){
                    set.Add(num >> k);
                }

                int next = x * 2 + 1;
                bool found = false;
                foreach(int num in nums){
                    if(set.Contains(next ^ (num >> k))) {
                        found = true;
                        break;
                    }
                }

                if(found)
                    x = next;
                else
                    x = next - 1;
            }

            return x;
        }
    }
}