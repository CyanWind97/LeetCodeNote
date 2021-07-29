using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1104
    /// title: 二叉树寻路
    /// problems: https://leetcode-cn.com/problems/path-in-zigzag-labelled-binary-tree/
    /// date: 20210729
    /// </summary>
    public static class Solution1104
    {
        public static IList<int> PathInZigZagTree(int label) {
            var result = new List<int>();
            int n = 0;
            while(label > 0){
                result.Add(label);
                label >>= 1;
                n++;
            }

            int x = n % 2 == 0 ? 1 : 2;
            for(int i = n - x; i > 0; i -= 2){
                result[i] = 3 * x - 1 - result[i];
                x *= 4;
            }

            result.Reverse();

            return result;
        }
    }
}