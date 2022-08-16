using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1302
    /// title: 层数最深叶子节点的和
    /// problems: https://leetcode.cn/problems/deepest-leaves-sum/
    /// date: 20220817
    /// </summary>
    public class Solution1302
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

        public static int DeepestLeavesSum(TreeNode root) {
            var sum = 0;

            var list = new List<TreeNode>();
            list.Add(root);

            while(list.Count > 0){
                sum = 0;
                var newList = new List<TreeNode>();
                foreach(var node in list){
                    sum += node.val;
                    if(node.left != null) 
                        newList.Add(node.left);
                    
                    if(node.right != null)
                        newList.Add(node.right);
                }

                list = newList;
            }

            return sum;
        }   
    }
}