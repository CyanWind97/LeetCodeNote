using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 144
/// title: 二叉树的前序遍历
/// problems: https://leetcode.cn/problems/binary-tree-preorder-traversal/description/?envType=daily-question&envId=2024-02-11
/// date: 20240211
/// </summary>
public static class Solution144
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

    public static IList<int> PreorderTraversal(TreeNode root) {
        var result = new List<int>();
        if (root is null)
            return result;
        
        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0) {
            var node = stack.Pop();
            result.Add(node.val);
            if (node.right is not null)
                stack.Push(node.right);

            if (node.left is not null)
                stack.Push(node.left);
        }

        return result;
    }
}
