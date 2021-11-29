using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 786
    /// title:  第 K 个最小的素数分数
    /// problems: https://leetcode-cn.com/problems/k-th-smallest-prime-fraction/
    /// date: 20211129
    /// </summary>
    public static class Solution786
    {
        public static int[] KthSmallestPrimeFraction(int[] arr, int k) {
            int length = arr.Length;

            IEnumerable<(int M, int D)> GetInfos(int index)
            {
                for(int i = index + 1; i < length; i++){
                    yield return (arr[index], arr[i]);
                }
            }

            var result = Enumerable.Range(0, length - 1)
                                   .SelectMany(GetInfos)
                                   .OrderBy(x => (double)x.M / (double)x.D)
                                   .Skip(k - 1)
                                   .First();
            
            return new int[] { result.M, result.D};
        }


        /// <summary>
        /// 参考解答 二分法 + 双指针
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] KthSmallestPrimeFraction_1(int[] arr, int k) {
            int n = arr.Length;
            double left = 0.0, right = 1.0;
            while (true) {
                double mid = (left + right) / 2;
                int i = -1, count = 0;
                // 记录最大的分数
                int x = 0, y = 1;
                
                for (int j = 1; j < n; ++j) {
                    while ((double) arr[i + 1] / arr[j] < mid) {
                        ++i;
                        if (arr[i] * y > arr[j] * x) {
                            x = arr[i];
                            y = arr[j];
                        }
                    }
                    count += i + 1;
                }

                if (count == k)
                    return new int[]{x, y};
                if (count < k)
                    left = mid;
                else
                    right = mid;
            }
        }
    }
}