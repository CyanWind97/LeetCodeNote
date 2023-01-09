using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 753
    /// title: 破解保险箱
    /// problems: https://leetcode.cn/problems/cracking-the-safe/
    /// date: 20230110
    /// </summary>
    public static class Solution753
    {
        // 参考解答
        // 欧拉通路
        // Hierholzer算法
        public static string CrackSafe(int n, int k) {
            var seen = new HashSet<int>();
            var result = new StringBuilder();
            int highest = (int)Math.Pow(10, n - 1);

            void DFS(int node){
                for(int x = 0; x < k; ++x){
                    int nei = node * 10 + x;
                    if(seen.Contains(nei))
                       continue; 
                    
                    seen.Add(nei);
                    DFS(nei % highest);
                    result.Append(x);
                }
            }

            DFS(0);
            for(int i = 1; i < n; i++){
                result.Append('0');
            }

            return result.ToString();
        }   
    }
}