using System.Collections.Generic;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 513
    /// title: 找树左下角的值
    /// problems: https://leetcode.cn/problems/find-bottom-left-tree-value/
    /// date: 20220622
    /// </summary>
    public static class Solution513
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

            public static int FindBottomLeftValue(TreeNode root) {
                int maxHeight = -1;
                int result = 0;

                void DFS(TreeNode node, int height){
                    if(node.left != null)
                        DFS(node.left, height + 1);

                    if(node.right != null)
                        DFS(node.right, height + 1);
                    
                    if(height > maxHeight){
                        maxHeight = height;
                        result = node.val;
                    }
                    
                }

                DFS(root, 0);

                return result;
            }

            // 参考解答 层序遍历 从右往左添加
            public static int FindBottomLeftValue_1(TreeNode root) {
                int result = 0;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while (queue.Count > 0) {
                    var node = queue.Dequeue();
                    if (node.right != null)
                        queue.Enqueue(node.right);
                    
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    
                    result = node.val;
                }

                return result;
            }
        }
    }
}