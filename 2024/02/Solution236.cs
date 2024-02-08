using System;

namespace LeetCodeNote;

/// <summary>
/// no: 236
/// title: 二叉树的最近公共祖先
/// problems: https://leetcode.cn/problems/lowest-common-ancestor-of-a-binary-tree/description/?envType=daily-question&envId=2024-02-09
/// date: 20240209
/// </summary>

public static class Solution236
{
    public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            TreeNode result = null;

            (bool IsPAcestor, bool IsQAcestor) LRD(TreeNode node){
                if(result != null)
                    return (false, false);

                var isP = node == p;
                var isQ = node == q;

                if(node.left != null){
                    (var isPC, var isQC) = LRD(node.left);
                    isP = isP || isPC;
                    isQ = isQ || isQC;
                }

                if(node.right != null){
                    (var isPC, var isQC) = LRD(node.right);
                    isP = isP || isPC;
                    isQ = isQ || isQC;
                }

                if(isP && isQ && result == null)
                    result = node;
                
                return (isP, isQ);
            }

            LRD(root);

            return result;
        }
}
