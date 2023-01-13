using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1819
    /// title: 序列中不同最大公约数的数目
    /// problems: https://leetcode.cn/problems/number-of-different-subsequences-gcds/
    /// date: 20230114
    /// </summary>
    public static class Solution1819
    {   
        // 参考解答
        // 枚举
        public static int CountDifferentSubsequenceGCDs(int[] nums) {
            int maxVal = nums.Max();
            var occured = new bool[maxVal + 1];
            foreach(var num in nums){
                occured[num] = true;
            }

            int GCD(int num1, int num2) {
                while (num2 != 0) {
                    int temp = num1;
                    num1 = num2;
                    num2 = temp % num2;
                }
                return num1;
            }


            int result = 0;
            for(int i = 1; i <= maxVal; i++){
                int subGcd = 0;
                for(int j = i; j <= maxVal; j+=i){
                    if(!occured[j])
                        continue;

                    subGcd = subGcd == 0 ? j : GCD(subGcd, j);

                    if(subGcd == i){
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }
}