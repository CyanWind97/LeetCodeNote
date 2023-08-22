using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1782
    /// title: 统计点对的数目
    /// problems: https://leetcode.cn/problems/count-pairs-of-nodes/
    /// date: 20230823
    /// </summary>
    public static class Solution1782
    {
        // 参考解答
        // 二分
        public static int[] CountPairs(int n, int[][] edges, int[] queries) {
            var degree = new int[n];
            var count = new Dictionary<int, int>();
            foreach(var edeg in edges) {
                (int x, int y) = (edeg[0] - 1, edeg[1] - 1);
                if(x > y) 
                    (x, y) = (y, x); 

                degree[x]++;
                degree[y]++;
                if (count.ContainsKey(x * n + y))
                    count[x * n + y]++;
                else
                    count.Add(x * n + y, 1);
            }

            var arr = degree.ToArray();
            var result = new int[queries.Length];
            Array.Sort(arr);

            for(int k = 0; k < queries.Length; k++){
                int bound = queries[k];
                int total = 0;
                for(int i = 0; i < n; i++){
                    int index = Array.BinarySearch(arr, i + 1, n - i - 1, bound - arr[i]);
                    if (index < 0)
                        index = ~index;
                    
                    while(index < n && arr[index] == bound - arr[i])
                        index++;
                    
                    total += n - index;
                }

                foreach(var pair in count){
                    int x = pair.Key / n;
                    int y = pair.Key % n;
                    if(degree[x] + degree[y] > bound && degree[x] + degree[y] - pair.Value <= bound)
                        total--;
                }

                result[k] = total;
            }

            return result;
        }
    }
}