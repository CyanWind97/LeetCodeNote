using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 98
    /// title:  验证二叉搜索树
    /// problems: https://leetcode.cn/problems/validate-binary-search-tree/
    /// date: 20220509
    /// priority: 0024
    /// time: 00:06:43:01
    public static class CodeTop98
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


        public static bool IsValidBST(TreeNode root) {
            bool IsValid(TreeNode node, int min, int max){
                if(node.val <= min || node.val >= max)
                    return false;
                
                if(node.left != null){
                    if(node.val <= node.left.val)
                        return false;
                    
                    if(!IsValid(node.left, min, node.val))
                        return false;
                }

                if(node.right != null){
                    if(node.val >= node.right.val)
                        return false;

                    if(!IsValid(node.right, node.val, max))
                        return false;
                }

                return true;
            }

            return IsValid(root, int.MinValue, int.MaxValue);
        }

        // 参考解答 中序遍历
        public static bool IsValidBST_1(TreeNode root) {
            var stack = new Stack<TreeNode>();
            long inorder = (long)int.MinValue - 1;
            var node = root;

            while(stack.Count > 0 || node != null){
                while(node != null){
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();
                if(node.val <= inorder)
                    return false;
                
                inorder = node.val;
                node = node.right;
            }

            return true;
        }
    }
}