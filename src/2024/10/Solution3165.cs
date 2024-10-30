using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3165
/// title: 不包含相邻元素的子序列的最大和
/// problems: https://leetcode.cn/problems/maximum-sum-of-subsequence-with-non-adjacent-elements
/// date: 20241031
/// </summary>
public static class Solution3165
{
    // 参考解答
    public static int MaximumSumSubsequence(int[] nums, int[][] queries) {
        const int MOD = 1000000007;
        int n = nums.Length;
        SegTree tree = new SegTree(n);
        tree.Init(nums);
        
        long ans = 0;
        foreach (var q in queries) {
            tree.Update(q[0], q[1]);
            ans = (ans + tree.Query()) % MOD;
        }
        
        return (int)ans;
    }

    public class SegNode {
        public long v00, v01, v10, v11;

        public SegNode() {
            v00 = v01 = v10 = v11 = 0;
        }

        public void Set(long v) {
            v00 = v01 = v10 = 0;
            v11 = Math.Max(v, 0);
        }

        public long Best() {
            return v11;
        }
    }

    public class SegTree {
        private int n;
        private SegNode[] tree;

        public SegTree(int n) {
            this.n = n;
            tree = new SegNode[n * 4 + 1];
            for (int i = 0; i < tree.Length; i++) {
                tree[i] = new SegNode();
            }
        }

        public void Init(int[] nums) {
            InternalInit(nums, 1, 1, n);
        }

        public void Update(int x, int v) {
            InternalUpdate(1, 1, n, x + 1, v);
        }

        public long Query() {
            return tree[1].Best();
        }

        private void InternalInit(int[] nums, int x, int l, int r) {
            if (l == r) {
                tree[x].Set(nums[l - 1]);
                return;
            }
            int mid = (l + r) / 2;
            InternalInit(nums, x * 2, l, mid);
            InternalInit(nums, x * 2 + 1, mid + 1, r);
            Pushup(x);
        }

        private void InternalUpdate(int x, int l, int r, int pos, int v) {
            if (l > pos || r < pos) {
                return;
            }
            if (l == r) {
                tree[x].Set(v);
                return;
            }
            int mid = (l + r) / 2;
            InternalUpdate(x * 2, l, mid, pos, v);
            InternalUpdate(x * 2 + 1, mid + 1, r, pos, v);
            Pushup(x);
        }

        private void Pushup(int x) {
            int l = x * 2, r = x * 2 + 1;
            tree[x].v00 = Math.Max(tree[l].v00 + tree[r].v10, tree[l].v01 + tree[r].v00);
            tree[x].v01 = Math.Max(tree[l].v00 + tree[r].v11, tree[l].v01 + tree[r].v01);
            tree[x].v10 = Math.Max(tree[l].v10 + tree[r].v10, tree[l].v11 + tree[r].v00);
            tree[x].v11 = Math.Max(tree[l].v10 + tree[r].v11, tree[l].v11 + tree[r].v01);
        }
    }
}
