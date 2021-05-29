using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1074
    /// title: 元素和为目标值的子矩阵数量
    /// problems: https://leetcode-cn.com/problems/number-of-submatrices-that-sum-to-target/
    /// date: 20210529
    /// </summary>
    public static class Solution1074
    {
        // 参考解答
        public static int NumSubmatrixSumTarget(int[][] matrix, int target) {
            int ans = 0;
            int m = matrix.Length, n = matrix[0].Length;

            int SubarraySum(int[] nums) {
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                dictionary.Add(0, 1);
                int count = 0, pre = 0;
                foreach (int x in nums) {
                    pre += x;
                    if (dictionary.ContainsKey(pre - target)) {
                        count += dictionary[pre - target];
                    }
                    if (!dictionary.ContainsKey(pre)) {
                        dictionary.Add(pre, 1);
                    } else {
                        ++dictionary[pre];
                    }
                }
                return count;
            }

            for (int i = 0; i < m; ++i) { // 枚举上边界
            int[] sum = new int[n];
            for (int j = i; j < m; ++j) { // 枚举下边界
                    for (int c = 0; c < n; ++c) {
                        sum[c] += matrix[j][c]; // 更新每列的元素和
                    }
                    ans += SubarraySum(sum);
                }
            }

            return ans;
        }
    }
}