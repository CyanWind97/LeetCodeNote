using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 106
/// title: 从中序与后序遍历序列构造二叉树
/// problems: https://leetcode.cn/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/?envType=daily-question&envId=2024-02-21
/// date: 20240221
/// </summary> 
public static class Solution106
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

    public static TreeNode BuildTree(int[] inorder, int[] postorder) {
        int length = inorder.Length;
            if(length == 0)
                return null;
        
        var root = new TreeNode(postorder[^1]);
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        var inIndex = length - 1;

        for(int i = 1; i < length; i++){
            int postVal = postorder[^(i + 1)];
            var node = stack.Peek();
            if(node.val != inorder[inIndex]){
                node.right = new TreeNode(postVal);
                stack.Push(node.right);
            }else{
                while(stack.Count > 0 && stack.Peek().val == inorder[inIndex]){
                    node = stack.Pop();
                    inIndex--;
                }

                node.left = new TreeNode(postVal);
                stack.Push(node.left);
            }
        }

        return root;
    }
}
