using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 103
    /// title:  二叉树的锯齿形层序遍历
    /// problems: https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/
    /// date: 20220505
    /// priority: 0010
    /// time: 00:15:57.07
    /// </summary>
    public static class CodeTop103
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

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root) {            
            var result = new List<IList<int>>();
            if(root == null)
                return result;

            var queue = new Queue<TreeNode>();
            int count = 1;
            int childCount = 0;
            int index = 0;
            bool flag = true;
            queue.Enqueue(root);
            int[] arr = new int[count];
            while(count> 0) {
                var node = queue.Dequeue();
                if(flag)
                    arr[index++] = node.val;
                else
                    arr[index--] = node.val;
                if(null != node.left){
                    queue.Enqueue(node.left);
                    childCount++;
                }
                
                if(null != node.right){
                    queue.Enqueue(node.right);
                    childCount++;
                }

                count--;

                if(count == 0){
                    result.Add(new List<int>(arr));
                    
                    flag = !flag;
                    count = childCount;
                    childCount = 0;
                    if(0 != count){
                        arr = new int[count];
                        index = flag ? 0 : count - 1;
                    }
                }
            }

            return result;
        }
    }
}