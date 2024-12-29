using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1367
/// title: 二叉树中的链表
/// problems: https://leetcode.cn/problems/linked-list-in-binary-tree
/// date: 20241230
/// </summary>
public static class Solution1367
{
    public static bool IsSubPath(ListNode head, TreeNode root) {
        if (root is null)
            return false;

        bool IsMatch(TreeNode node, ListNode listNode) {
            if (listNode is null)
                return true;

            if (node is null)
                return false;

            if (node.val != listNode.val)
                return false;

            return IsMatch(node.left, listNode.next) 
                || IsMatch(node.right, listNode.next);
        }

        return IsMatch(root, head) 
            || IsSubPath(head, root.left) 
            || IsSubPath(head, root.right);
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
     
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
}
