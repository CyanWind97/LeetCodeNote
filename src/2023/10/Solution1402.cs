using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1402
    /// title: 做菜顺序
    /// problems: https://leetcode.cn/problems/reducing-dishes/?envType=daily-question&envId=2023-10-22
    /// date: 20231022
    /// </summary>
    public static class Solution1402
    {
        // 参考解答
        public static int MaxSatisfaction(int[] satisfaction) {
            Array.Sort(satisfaction, (a, b) => b - a);
            int sum = 0;
            int result = 0;

            foreach(var num in satisfaction){
                if (sum + num > 0){
                    sum += num;
                    result += sum;
                }else{
                    break;
                }
            }

            return result;
        }
    }
}