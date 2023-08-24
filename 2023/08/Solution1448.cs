using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1448
    /// title: 统计二叉树中好节点的数目
    /// problems: https://leetcode.cn/problems/count-good-nodes-in-binary-tree/
    /// date: 20230825
    /// </summary>
    public static class Solution1448
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

        public static int GoodNodes(TreeNode root) {
            int result = 0;
            void DFS(TreeNode node, int max){
                if(node == null)
                    return;
                
                if(node.val >= max){
                    result++;
                    max = node.val;
                }

                DFS(node.left, max);
                DFS(node.right, max);
            }

            DFS(root, root.val);

            return result;
        }
    }
}