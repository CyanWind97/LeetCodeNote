using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2286
/// title: 以组为单位订音乐会的门票
/// problems: https://leetcode.cn/problems/booking-concert-tickets-in-groups
/// date: 20240928
/// </summary>
public static class Solution2286
{
    // 参考解答 线段树
    public class BookMyShow {
        private int n;
        private int m;
        private int[] minTree;
        private long[] sumTree;

        public BookMyShow(int n, int m) {
            this.n = n;
            this.m = m;
            this.minTree = new int[4 * n];
            this.sumTree = new long[4 * n];
        }
        
        private void Modify(int i, int l, int r, int index, int val) {
            if (l == r) {
                minTree[i] = val;
                sumTree[i] = val;
                return;
            }
            int mid = (l + r) / 2;
            if (index <= mid) {
                Modify(i * 2, l, mid, index, val);
            } else {
                Modify(i * 2 + 1, mid + 1, r, index, val);
            }
            minTree[i] = Math.Min(minTree[i * 2], minTree[i * 2 + 1]);
            sumTree[i] = sumTree[i * 2] + sumTree[i * 2 + 1];
        }

        private int QueryMinRow(int i, int l, int r, int val) {
            if (l == r) {
                if (minTree[i] > val) {
                    return n;
                }
                return l;
            }
            int mid = (l + r) / 2;
            if (minTree[i * 2] <= val) {
                return QueryMinRow(i * 2, l, mid, val);
            } else {
                return QueryMinRow(i * 2 + 1, mid + 1, r, val);
            }
        }

        private long QuerySum(int i, int l, int r, int l2, int r2) {
            if (r < l2 || l > r2) {
                return 0;
            }
            if (l >= l2 && r <= r2) {
                return sumTree[i];
            }
            int mid = (l + r) / 2;
            return QuerySum(i * 2, l, mid, l2, r2) + QuerySum(i * 2 + 1, mid + 1, r, l2, r2);
        }

        public int[] Gather(int k, int maxRow) {
            int i = QueryMinRow(1, 0, n - 1, m - k);
            if (i > maxRow) {
                return new int[0];
            }
            long used = QuerySum(1, 0, n - 1, i, i);
            Modify(1, 0, n - 1, i, (int)(used + k));
            return new int[] { i, (int)used };
        }

        public bool Scatter(int k, int maxRow) {
            long usedTotal = QuerySum(1, 0, n - 1, 0, maxRow);
            if ((maxRow + 1L) * m - usedTotal < k) {
                return false;
            }
            int i = QueryMinRow(1, 0, n - 1, m - 1);
            while (true) {
                long used = QuerySum(1, 0, n - 1, i, i);
                if (m - used >= k) {
                    Modify(1, 0, n - 1, i, (int)(used + k));
                    break;
                }
                k -= m - (int)used;
                Modify(1, 0, n - 1, i, m);
                i++;
            }
            return true;
        }
    }
}
