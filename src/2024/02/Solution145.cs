using System;
using System.Collections.Generic;

namespace LeetCodeNote;

/// <summary>
/// no: 145
/// title: 二叉树的后序遍历
/// problems: https://leetcode.cn/problems/binary-tree-postorder-traversal/description/?envType=daily-question&envId=2024-02-12
/// date: 20240212
/// </summary>
public static class Solution145
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

    public static IList<int> PostorderTraversal(TreeNode root) {
        var result = new List<int>();
        if (root is null)
            return result;

        var stack = new Stack<TreeNode>();
        TreeNode prev = null;
        var curr = root;
        while (curr is not null || stack.Count > 0) {
            while(curr is not null){
                stack.Push(curr);
                curr = curr.left;
            }

            curr = stack.Pop();
            if (curr.right is null || curr.right == prev) {
                result.Add(curr.val);
                prev = curr;
                curr = null;
            } else {
                stack.Push(curr);
                curr = curr.right;
            }
        }

        return result;
    }
}
