using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1331
    /// title:  数组序号转换
    /// problems: https://leetcode.cn/problems/rank-transform-of-an-array/
    /// date: 20220728
    /// </summary>
    public static class Solution1331
    {
        public static int[] ArrayRankTransform(int[] arr) {
            int length = arr.Length;
            var result = new int[length];
            if(length == 0)
                return result;

            var sorted = arr.Select((value, index) => (value, index))
                            .OrderBy(p => p.value)
                            .ToArray<(int Value, int Index)>();
            int rank = 1;
            for(int i = 0; i < length - 1; i++){
                result[sorted[i].Index] = rank;
                if(sorted[i].Value != sorted[i + 1].Value)
                    rank++;
            }

            result[sorted[length - 1].Index] = rank;

            return result;
        }
    }
}