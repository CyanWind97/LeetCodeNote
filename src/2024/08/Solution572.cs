using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 572
/// title: 另一棵树的子树
/// problems: https://leetcode.cn/problems/subtree-of-another-tree
/// date: 20240804
/// </summary>
public static class Solution572
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static bool IsSubtree(TreeNode root, TreeNode subRoot) {
        void LRD(TreeNode node, IList<int?> list){
            if (node is null){
                list.Add(null);
                return;
            }

            LRD(node.left, list);
            LRD(node.right, list);
            list.Add(node.val);
        }

        var subLRD = new List<int?>();
        var rootLRD = new List<int?>();
        LRD(subRoot, subLRD);
        LRD(root, rootLRD);

        bool IsMatch(IList<int?> sequence, IList<int?> subSequence){
            int n = sequence.Count;
            int m = subSequence.Count;
             // 构建部分匹配表
            int[] lps = new int[m];
            for (int i = 1, len = 0; i < m;) {
                if (subSequence[i] == subSequence[len]) {
                    lps[i++] = ++len;
                } else if (len > 0) {
                    len = lps[len - 1];
                } else {
                    lps[i++] = 0;
                }
            }

            // 使用KMP算法进行匹配
            for (int i = 0, j = 0; i < n;) {
                if (subSequence[j] == sequence[i]) {
                    i++; j++;
                }
                if (j == m) return true;
                if (i < n && subSequence[j] != sequence[i]) {
                    j = (j > 0) ? lps[j - 1] : 0;
                    if (j == 0) i++; // 这个条件防止死循环
                }
            }
    

            return false;
        }

        return IsMatch(rootLRD, subLRD);
    }
  
}
