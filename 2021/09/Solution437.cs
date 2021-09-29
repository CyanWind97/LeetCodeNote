using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 437
    /// title: 路径总和 III
    /// problems: https://leetcode-cn.com/problems/path-sum-iii/
    /// date: 20210928
    /// </summary>
    public static class Solution437
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

        public static int PathSum(TreeNode root, int targetSum) {
            var prefix = new Dictionary<long, int>();

            int DFS(TreeNode root, long curr, int targetSum) {
                if (root == null)
                    return 0;

                int ret = 0;
                curr += root.val;

                prefix.TryGetValue(curr - targetSum, out ret);
                if (prefix.ContainsKey(curr)) {
                    ++prefix[curr];
                } else {
                    prefix.Add(curr, 1);
                }
                ret += DFS(root.left, curr, targetSum);
                ret += DFS(root.right, curr, targetSum);
                --prefix[curr];

                return ret;
            }


            prefix.Add(0, 1);
            
            return DFS(root, 0, targetSum);
        }

    }
}