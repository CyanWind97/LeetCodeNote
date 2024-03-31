using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1769
    /// title:  移动所有球到每个盒子所需的最小操作数
    /// problems: https://leetcode.cn/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/
    /// date: 20221202
    /// </summary>
    public static class Solution1769
    {
        // 参考解答 
        // 模拟
        public static int[] MinOperations(string boxes) {
            int left = boxes[0] - '0';
            int right = 0;
            int operations = 0;
            int n = boxes.Length;
            for (int i = 1; i < n; i++) {
                if (boxes[i] == '1') {
                    right++;
                    operations += i;
                }
            }
            int[] res = new int[n];
            res[0] = operations;
            for (int i = 1; i < n; i++) {
                operations += left - right;
                if (boxes[i] == '1') {
                    left++;
                    right--;
                }
                res[i] = operations;
            }

            return res;
        }
    }
}