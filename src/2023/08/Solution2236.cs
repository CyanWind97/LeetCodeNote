using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2236
    /// title: 判断根结点是否等于子结点之和
    /// problems: https://leetcode.cn/problems/root-equals-sum-of-children/
    /// date: 20230820
    /// </summary>
    public static class Solution2236
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

        public static bool CheckTree(TreeNode root) {
            return root.val == root.left.val + root.right.val;
        }
    }
}