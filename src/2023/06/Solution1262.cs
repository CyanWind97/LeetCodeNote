using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1262
    /// title: 可被三整除的最大和
    /// problems: https://leetcode.cn/problems/greatest-sum-divisible-by-three/
    /// date: 20230619
    /// </summary>
    public static class Solution1262
    {
        public static int MaxSumDivThree(int[] nums) {
            const int Max = 1_000_000;
            var sum = 0;
            var totalRemainder = 0;
            var mins1 = new int[2]{Max, Max};
            var mins2 = new int[2]{Max, Max};

            void CalcMin(int num, int[] mins){
                if (num < mins[0]){
                    mins[1] = mins[0];
                    mins[0] = num;
                }else if(num < mins[1]){
                    mins[1] = num;
                }
            }

            foreach(var num in nums){
                sum += num;
                var remainder = num % 3;
                totalRemainder = (totalRemainder + remainder) % 3;
                
                if (remainder == 1)
                    CalcMin(num, mins1);
                
                if (remainder == 2)
                    CalcMin(num, mins2);
            }

            if (totalRemainder == 1){
                sum -=  Math.Min(mins1[0], mins2[0] + mins2[1]);
            }else if(totalRemainder == 2){
                sum -= Math.Min(mins2[0], mins1[0] + mins1[1]);
            }

            return sum;
        }
    }
}