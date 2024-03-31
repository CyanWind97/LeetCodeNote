using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 105
    /// title:   从前序与中序遍历序列构造二叉树
    /// problems: https://leetcode.cn/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
    /// date: 20220516
    /// priority: 0062
    /// time: 00:19:37.91
    /// </summary>   
    public static class CodeTop105
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
            TreeNode Build(int preIndex, int inLeft, int inRight){
                int num = preorder[preIndex];
                int size = inRight - inLeft + 1;
                var node = new TreeNode(num);
                if(size == 1)
                    return node;
                
                int inIndex = inLeft;
                while(inIndex <= inRight && inorder[inIndex] != num){
                    inIndex++;
                }
                 
                node.left = inIndex == inLeft
                                ? null
                                : Build(preIndex + 1, inLeft, inIndex - 1);
                
                
                node.right = inIndex == inRight
                            ? null
                            : Build(preIndex + inIndex - inLeft + 1, inIndex + 1, inRight);

                return node;
            }

            
            return Build(0, 0, inorder.Length - 1);
        }

        // 迭代法
        public static TreeNode BuildTree_1(int[] preorder, int[] inorder) {
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
}