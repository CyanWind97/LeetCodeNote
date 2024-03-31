using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1093
    /// title: 大样本统计
    /// problems: https://leetcode.cn/problems/statistics-from-a-large-sample/
    /// date: 20230527
    /// </summary>
    public static class Solution1093
    {
        public static double[] SampleStats(int[] count) {
            int n = count.Length;
            int total = count.Sum();
            double mean = 0.0;
            double median = 0.0;
            int minnum = 256;
            int maxnum = 0;
            int mode = 0;

            int left = (total + 1) / 2;
            int right = (total + 2) / 2;
            int cnt = 0;
            int maxfreq = 0;
            long sum = 0;
            for (int i = 0; i < n; i++) {
                sum += (long) count[i] * i;
                if (count[i] > maxfreq) {
                    maxfreq = count[i];
                    mode = i;
                }
                if (count[i] > 0) {
                    if (minnum == 256) {
                        minnum = i;
                    }
                    maxnum = i;
                }
                if (cnt < right && cnt + count[i] >= right) {
                    median += i;
                }
                if (cnt < left && cnt + count[i] >= left) {
                    median += i;
                }
                cnt += count[i];
            }
            mean = (double) sum / total;
            median = median / 2.0;
            
            return new double[]{minnum, maxnum, mean, median, mode};
        }
    }
}