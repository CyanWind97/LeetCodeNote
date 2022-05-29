using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1022
    /// title: 从根到叶的二进制数之和
    /// problems: https://leetcode.cn/problems/remove-outermost-parentheses/
    /// date: 20220530
    /// </summary>
    public static class Solution1022
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

        public static int SumRootToLeaf(TreeNode root) {
            
            int SumValue(TreeNode node, int preVal){
                int sum = 0;
                
                if(node == null)
                    return 0;
                
                preVal = preVal << 1 + node.val;
                if(node.left == null && node.right == null){
                    sum += preVal;
                }else{
                    sum += SumValue(node.left, preVal);
                    sum += SumValue(node.right, preVal);
                }

                return sum;
            }

            return SumValue(root, 0);
        }
    }
}