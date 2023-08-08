using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1281
    /// title: 整数的各位积和之差
    /// problems: https://leetcode.cn/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
    /// date: 20230809
    /// </summary>
    public class Solution1281
    {
        public static int SubtractProductAndSum(int n) {
            int sum = 0;
            int product = 1;
            while(n > 0){
                int num = n % 10;
                sum += num;
                product *= num;
                n /= 10;
            }

            return product - sum;
        }
    }
}