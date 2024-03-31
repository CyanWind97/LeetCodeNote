using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2736
    /// title: 最大和查询
    /// problems: https://leetcode.cn/problems/maximum-sum-queries/description/?envType=daily-question&envId=2023-11-17
    /// date: 20231117
    /// </summary>
    public static class Solution2736
    {

        // 参考解答
        // 单调栈 + 二分
        public static int[] MaximumSumQueries(int[] nums1, int[] nums2, int[][] queries) {
             int length = nums1.Length;
            var searchs = nums1.Zip(nums2, (x, y) => (x, y, x + y))
                            .OrderByDescending(tmp => tmp.x)
                            .ToArray<(int First, int Second, int Sum)>();
            

            var sortedQueries = queries.Select((x, index) => (x[0], x[1], index))
                                    .OrderByDescending(x => x.Item1)
                                    .ToArray<(int X, int Y, int Index)>();

            var result = Enumerable.Repeat(-1, queries.Length).ToArray();
            var stack = new List<(int Second, int Sum)>();

            int j = 0;
            foreach(var query in sortedQueries){
                (int x, int y, int index) = query;
                while(j < length && searchs[j].First >= x){

                    while(stack.Count  > 0 && stack.Last().Sum <= searchs[j].Sum)
                        stack.RemoveAt(stack.Count - 1);
                    
                    if (stack.Count == 0 
                    || stack.Last().Second < searchs[j].Second)
                        stack.Add((searchs[j].Second, searchs[j].Sum));
                    
                    j++;
                }

                int k = stack.BinarySearch((y, 0), Comparer<(int Second, int Sum)>.Create((x, y) => x.Second.CompareTo(y.Second)));
                if(k < 0)
                    k = ~k;

                while(k < stack.Count && stack[k].Second < y)
                    k++;
                
                if(k < stack.Count)
                    result[index] = stack[k].Sum;
            }

            return result;
        }
    }
}