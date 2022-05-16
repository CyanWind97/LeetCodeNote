using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 04.06
    /// title: 04.06. 后继者
    /// problems: https://leetcode.cn/problems/successor-lcci/
    /// date: 20220516
    /// type: 面试题 lcci
    /// </summary>
    public class Solution_lcci_04_06
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
            if(p.right != null){
                p = p.right;
                while(p.left != null){
                    p = p.left;
                }
                
                return p;
            }

            TreeNode predecessor = null;

            var stack = new Stack<TreeNode>();
            var node = root;

#if DEBUG
            while(stack.Count > 0 || node != null){
                while(node != null){
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();
                if(predecessor == p)
                    return node;
                
                predecessor = node;
                node = node.right;
            }
            
#else            
            
            #region  递归
            TreeNode successor = null;
            bool IsContains(TreeNode node){
                if(successor != null)
                    return false;

                if(node == null)
                    return false;
                
                if(node == p)
                    return true;
                
                if(IsContains(node.left)){
                    successor = node;
                    return false;
                }

                if(IsContains(node.right))
                    return true;
                
                return false;
            }
            IsContains(root);
            #endregion
#endif

            return null;
        }

        // 参考 给的是二叉搜索树
        public static TreeNode InorderSuccessor_1(TreeNode root, TreeNode p) {
            TreeNode successor = null;
            if(p.right != null){
                successor = p.right;
                while(successor.left != null){
                    successor = successor.left;
                }
                
                return successor;
            }

            var node = root;
            while(node != null){
                if(node.val > p.val){
                    successor = node;
                    node = node.left;
                }else{
                    node = node.right;
                }
            }

            return successor;
        }
    }
}