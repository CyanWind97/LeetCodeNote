using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 77
    /// title:  组合
    /// problems: https://leetcode.cn/problems/combinations/
    /// date: 20230517
    /// </summary>
    public static class Solution77
    {
        // 回溯 + 减枝
        public static IList<IList<int>> Combine(int n, int k){
            var result = new List<IList<int>>();
            var path = new int[k];
            void Backtrack(int start, int index){
                if(index + n - start + 1 < k)
                    return;

                if(index == k){
                    result.Add(path.ToArray());
                    return;
                }

                for(int i = start; i <= n; i++){
                    path[index] = i;
                    Backtrack(i + 1, index + 1);
                }
            }

            Backtrack(1, 0);

            return result;
        }

        // 参考解答
        // 非递归 字典序法
        public static IList<IList<int>> Combine_1(int n, int k){
            var temp = new List<int>();
            var result = new List<IList<int>>();
            
            // 初始化
            // 将 temp 中 [0, k - 1] 每个位置 i 设置为 i + 1，即 [0, k - 1] 存 [1, k]
            // 末尾加一位 n + 1 作为哨兵
            for(int i = 1; i <= k; i++){
                temp.Add(i);
            }

            temp.Add(n + 1);

            int j = 0;
            while(j < k){
                result.Add(temp.Take(k).ToArray());
                j = 0;
                // 寻找第一个 temp[j] + 1 != temp[j + 1] 的位置 t
                // 我们需要把 [0, t - 1] 区间内的每个位置重置成 [1, t]
                while(j < k && temp[j] + 1 == temp[j + 1]){
                    temp[j] = j + 1;
                    j++;
                }
                // j 是第一个 temp[j] + 1 != temp[j + 1] 的位置
                temp[j] += 1;
            }

            return result;
        }
    }
}