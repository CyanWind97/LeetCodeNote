using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2415
    /// title: 反转二叉树的奇数层
    /// problems: https://leetcode.cn/problems/reverse-odd-levels-of-binary-tree/description/?envType=daily-question&envId=2023-12-15
    /// date: 20231215
    /// </summary>
    public static class Solution2415
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


        public static TreeNode ReverseOddLevels(TreeNode root) {
            if(root == null)
                return null;
            
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool isOdd = false;
            while(queue.Count > 0){
                int size = queue.Count;
                var list = new List<TreeNode>();
                for(int i = 0; i < size; i++){
                    var node = queue.Dequeue();
                    list.Add(node);

                    if(node.left != null)
                        queue.Enqueue(node.left);
                    
                    if(node.right != null)
                        queue.Enqueue(node.right);
                }

                if(isOdd){
                    for(int i = 0; i < list.Count / 2; i++){
                        (var leftNode, var rightNode) = (list[i], list[^(i + 1)]);
                        (leftNode.val, rightNode.val) = (rightNode.val, leftNode.val);
                    }
                }

                isOdd = !isOdd;
            }

            return root;
        }
    }
}