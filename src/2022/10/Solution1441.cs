using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1441
    /// title: 用栈操作构建数组
    /// problems: https://leetcode.cn/problems/build-an-array-with-stack-operations/
    /// date: 20221015
    /// </summary>
    public static class Solution1441
    {
        public static IList<string> BuildArray(int[] target, int n) {
            var result = new List<string>();
            int prev = 0;
            foreach (int number in target) {
                for (int i = 0; i < number - prev - 1; i++) {
                    result.Add("Push");
                    result.Add("Pop");
                }
                
                result.Add("Push");
                prev = number;
            }

            return result;
        }
    }
}