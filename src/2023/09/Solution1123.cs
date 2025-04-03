using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1123
    /// title: 最深叶节点的最近公共祖先
    /// problems: https://leetcode.cn/problems/lowest-common-ancestor-of-deepest-leaves/?envType=daily-question&envId=2023-09-06
    /// date: 20230906
    /// </summary>

    public static partial class Solution1123
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

        public static TreeNode LcaDeepestLeaves(TreeNode root) {
            var result = root;
            int maxDepth = 1;

            int GetDepth(TreeNode node, int curDepth){
                var leftDepth = node.left == null ? curDepth : GetDepth(node.left, curDepth + 1);
                var rightDepth = node.right == null ? curDepth : GetDepth(node.right, curDepth + 1);

                var depth = Math.Max(leftDepth, rightDepth);
                if (depth >= maxDepth){
                    if (leftDepth == rightDepth)
                        result = node;
                    
                    maxDepth = depth;
                }
                
                return depth;
            }

            GetDepth(root, 1);

            return result;
        }
    }
}