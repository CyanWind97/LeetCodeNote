using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 105
/// title: 从前序与中序遍历序列构造二叉树
/// problems: https://leetcode.cn/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
/// date: 20240220
/// </summary>  
public static partial class Solution105
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

        public static TreeNode BuildTree(int[] preorder, int[] inorder) {
            int length = preorder.Length;
            if(length == 0)
                return null;
            
            var root = new TreeNode(preorder[0]);
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            int inIndex = 0;
            
            for(int i = 1; i < length; i++){
                int preVal = preorder[i];
                var node = stack.Peek();
                if(node.val != inorder[inIndex]){
                    node.left = new TreeNode(preVal);
                    stack.Push(node.left);
                }else{
                    while(stack.Count > 0 && stack.Peek().val == inorder[inIndex]){
                        node = stack.Pop();
                        inIndex++;
                    }

                    node.right = new TreeNode(preVal);
                    stack.Push(node.right);
                }
            }
            
            return root;
        }
}
