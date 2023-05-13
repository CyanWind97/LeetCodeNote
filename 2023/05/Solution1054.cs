using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1054
    /// title: 距离相等的条形码
    /// problems: https://leetcode.cn/problems/distant-barcodes/
    /// date: 20230514
    /// </summary>
    public static class Solution1054
    {
        public static int[] RearrangeBarcodes(int[] barcodes) {
            int length = barcodes.Length;
            if(length <= 2)
                return barcodes;
            
            int[] result = new int[length];
            var array = barcodes.GroupBy(x => x)
                        .OrderByDescending(g => g.Count())
                        .SelectMany(g => g)
                        .ToArray();
            
            int mid = (length + 1) / 2;
            for(int i = 0; i < length / 2; i++){
                result[i * 2] = array[i];
                result[i * 2 + 1] = array[i + mid];
            }

            if(length % 2 == 1)
                result[length - 1] = array[mid - 1];

            return result;
        }

        // 参考解答
        // 计数统计
        public static int[] RearrangeBarcodes_1(int[] barcodes) {
            int length = barcodes.Length;
            if (length < 2) 
                return barcodes;

            var counts = new Dictionary<int, int>();
            foreach (int b in barcodes) {
                counts.TryAdd(b, 0);
                counts[b]++;
            }

            int evenIndex = 0;
            int oddIndex = 1;
            int halfLength = length / 2;
            var res = new int[length];
            foreach (var pair in counts) {
                int x = pair.Key;
                int count = pair.Value;
                while (count > 0 && count <= halfLength && oddIndex < length) {
                    res[oddIndex] = x;
                    count--;
                    oddIndex += 2;
                }
                while (count > 0) {
                    res[evenIndex] = x;
                    count--;
                    evenIndex += 2;
                }
            }
            
            return res;
        }
    }
}