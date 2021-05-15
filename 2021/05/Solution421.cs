using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 421
    /// title: 数组中两个数的最大异或值
    /// problems: https://leetcode-cn.com/problems/maximum-xor-of-two-numbers-in-an-array/
    /// date: 20210516
    /// </summary>
    public class Solution421
    {
        // 参考解答 hashSet
        // x = ai ^ aj =>  aj = x ^ ai
        // 从最高位开始枚举能取到的值
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