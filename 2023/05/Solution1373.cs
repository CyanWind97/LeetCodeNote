using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1373
    /// title: 二叉搜索子树的最大键值和
    /// problems: https://leetcode.cn/problems/maximum-sum-bst-in-binary-tree/
    /// date: 20230520
    /// </summary>
    public static class Solution1373
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

        public class Solution {
            public int MaxSumBST(TreeNode root) {
                int result = 0;
                (bool IsBst, int Sum, int Min, int Max) DFS(TreeNode node){
                    if(node == null)
                        return (true, 0, int.MaxValue, int.MinValue);
                    
                    (var left, var leftSum,  var leftMin,  var leftMax) = DFS(node.left);
                    (var right, var rightSum, var rightMin, var rightMax) = DFS(node.right);

                    // 本身是BST，需要计算值
                    if(left && right && node.val > leftMax && node.val < rightMin){
                        int sum = node.val + leftSum + rightSum;
                        result = Math.Max(result, sum);
                        return (true, sum, Math.Min(leftMin, node.val), Math.Max(rightMax, node.val));
                    }else{
                        return (false, 0, 0, 0);
                    }
                }

                DFS(root);

                return result;
            }
        }
    }
}