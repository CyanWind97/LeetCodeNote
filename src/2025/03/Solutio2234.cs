using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeeCodeNote;

/// <summary>
/// no: 2234
/// title: 花园的最大总美丽值
/// problems: https://leetcode.cn/problems/maximum-total-beauty-of-the-gardens
/// date: 20250308
/// </summary>
public class Solutio2234
{
    // 参考解答
    // 枚举「完善」和「不完善」的分界线
    public static long MaximumBeauty(int[] flowers, long newFlowers, int target, int full, int partial) {   
        int n = flowers.Length;
        for (int i = 0; i < n; i++) {
            flowers[i] = Math.Min(flowers[i], target);
        }
        Array.Sort(flowers, (a, b) => b.CompareTo(a));
        long sum = flowers.Sum(x => (long)x);
        long ans = 0;
        if ((long)target * n - sum <= newFlowers) {
            ans = (long)full * n;
        }
        long pre = 0;
        int ptr = 0;
        for (int i = 0; i < n; i++) {
            if (i != 0) {
                pre += flowers[i - 1];
            }
            if (flowers[i] == target) {
                continue;
            }
            long rest = newFlowers - ((long)target * i - pre);
            if (rest < 0) {
                break;
            }
            while (!(ptr >= i && (long)flowers[ptr] * (n - ptr) - sum <= rest)) {
                sum -= flowers[ptr];
                ptr++;
            }
            rest -= (long)flowers[ptr] * (n - ptr) - sum;
            ans = Math.Max(ans, (long)full * i + (long)partial * Math.Min(flowers[ptr] + rest / (n - ptr), (long)target - 1));
        }

        return ans;
    }
}
