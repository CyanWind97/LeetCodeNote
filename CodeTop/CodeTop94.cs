using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 94
    /// title:  二叉树的中序遍历
    /// problems: https://leetcode.cn/problems/binary-tree-inorder-traversal/
    /// date: 20220509
    /// priority: 0025
    /// time: 00:03:49.67
    public class CodeTop94
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


        public static IList<int> InorderTraversal(TreeNode root) {
            var result = new List<int>();
            var node = root;
            var stack = new Stack<TreeNode>();

            while(stack.Count > 0 || node != null){
                while(node != null){
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();
                result.Add(node.val);

                node = node.right;
            }

            return result;
        }


        // 参考 颜色标记
        public static IList<int> InorderTraversal_1(TreeNode root){
            const int WHITE = 0;
            const int GRAY = 1;
            var stack = new Stack<(int Color, TreeNode Node)>();
            var result = new List<int>();

            stack.Push((WHITE, root));

            while(stack.Count > 0){
                (var color, var node) = stack.Pop();

                if(node is null)
                    continue;
                
                if(color == WHITE){
                    stack.Push((WHITE, node.right));
                    stack.Push((GRAY, node));
                    stack.Push((WHITE, node.left));
                }else{
                    result.Add(node.val);
                }
            }

            return result;
        }

        // 参考 Morris
        public static IList<int> InorderTraversal_2(TreeNode root){
            var result = new List<int>();
            TreeNode predecessor = null;
            
            while(root != null){
                if(root.left != null){
                    predecessor = root.left;
                    while(predecessor.right != null && predecessor != root){
                        predecessor = predecessor.right;
                    }

                    if(predecessor.right == null){
                        predecessor.right = root;
                        root = root.left;
                    }else{
                        result.Add(root.val);
                        predecessor.right = null;
                        root = root.right;
                    }
                }else{
                    result.Add(root.val);
                    root = root.right;
                }
            }

            return result;
        }
    }
}