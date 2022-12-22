using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2011
    /// title: 执行操作后的变量值
    /// problems: https://leetcode.cn/problems/final-value-of-variable-after-performing-operations/
    /// date: 20221223
    /// </summary>
    public static class Solution2011
    {
        public static int FinalValueAfterOperations(string[] operations) {
            var result = 0;
            foreach(var operation in operations){
                if(operation[1] == '+')
                    result++;
                else
                    result--;
            }

            return result;
        }
    }
}