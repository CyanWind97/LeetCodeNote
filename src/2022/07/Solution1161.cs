using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1161
    /// title:  最大层内元素和
    /// problems: https://leetcode.cn/problems/maximum-level-sum-of-a-binary-tree/
    /// date: 20220731
    /// </summary>
    public static class Solution1161
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

        public static int MaxLevelSum(TreeNode root) {
            int maxSum = int.MinValue;
            int result = 1;
            
            var list = new List<TreeNode>();
            list.Add(root);
            for(int level = 1;list.Count > 0; level++){
                int sum = 0;
                var nextList = new List<TreeNode>();
                foreach(var node in list){
                    sum += node.val;
                    if(node.left != null)
                        nextList.Add(node.left);
                    
                    if(node.right != null)
                        nextList.Add(node.right);
                }
                
                if(sum > maxSum){
                    result = level;
                    maxSum = sum;
                }
                
                list = nextList;
            }

            return result;
        }
    }
}