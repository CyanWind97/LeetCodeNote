using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1707
    /// title:  与数组中元素的最大异或值
    /// problems: https://leetcode-cn.com/problems/maximum-xor-with-an-element-from-array/
    /// date: 20210523
    /// </summary>
    public static class Solution1707
    {
        // 参考解答 在线查询 + 字典树
        public static int[] MaximizeXor(int[] nums, int[][] queries) {
            Trie trie = new Trie();
            foreach (int val in nums) {
                trie.Insert(val);
            }
            int numQ = queries.Length;
            int[] ans = new int[numQ];
            for (int i = 0; i < numQ; ++i) {
                ans[i] = trie.GetMaxXorWithLimit(queries[i][0], queries[i][1]);
            }
            return ans;
        }

    
        class Trie {
            const int L = 30;
            Trie[] children = new Trie[2];
            int min = int.MaxValue;

            public void Insert(int val) {
                Trie node = this;
                node.min = Math.Min(node.min, val);
                for (int i = L - 1; i >= 0; --i) {
                    int bit = (val >> i) & 1;
                    if (node.children[bit] == null) {
                        node.children[bit] = new Trie();
                    }
                    node = node.children[bit];
                    node.min = Math.Min(node.min, val);
                }
            }

            public int GetMaxXorWithLimit(int val, int limit) {
                Trie node = this;
                if (node.min > limit) {
                    return -1;
                }
                int ans = 0;
                for (int i = L - 1; i >= 0; --i) {
                    int bit = (val >> i) & 1;
                    if (node.children[bit ^ 1] != null && node.children[bit ^ 1].min <= limit) {
                        ans |= 1 << i;
                        bit ^= 1;
                    }
                    node = node.children[bit];
                }
                return ans;
            }
        }
    }
}