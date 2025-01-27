using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 119
    /// title: 杨辉三角 II
    /// problems: https://leetcode-cn.com/problems/pascals-triangle-ii/
    /// date: 20210212
    /// </summary>
    public static partial class Solution119
    {
        public static IList<int> GetRow(int rowIndex) {
            int[] result = new int[rowIndex + 1];
            long cur = 1;
            result[0] = (int)cur;
            result[rowIndex] = (int)cur;
            for(int i = 1; i <= rowIndex / 2; i++){
                cur = cur * (rowIndex - i + 1) / i;
                result[i] = (int)cur;
                result[rowIndex - i] = (int)cur;
            }

            return result;
        }
    }
}