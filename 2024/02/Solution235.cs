using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 235
/// title: 二叉搜索树的最近公共祖先
/// problems: https://leetcode.cn/problems/lowest-common-ancestor-of-a-binary-search-tree/description/?envType=daily-question&envId=2024-02-25
/// date: 20240225
/// </summary> 
public static class Solution235
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var curr = root;
        while(curr != null){
            if (p.val < curr.val && q.val < curr.val)
                curr = curr.left;
            else if (p.val > curr.val && q.val > curr.val)
                curr = curr.right;
            else
                return curr;
        }

        return null;
    }
}
