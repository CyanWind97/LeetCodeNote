using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 103
    /// title: 二叉树的锯齿形层序遍历
    /// problems: https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/
    /// date: 20201222
    /// </summary>
    public static partial class Solution103
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
            IList<IList<int>> result = new List<IList<int>>();
            if(null == root)
                return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            int count = 1, childCount = 0, index = 0;
            bool flag = true;
            queue.Enqueue(root);
            int[] arr = new int[count];
            while(count > 0) {
                TreeNode node = queue.Dequeue();
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
                        index = flag? 0 : count - 1;
                    }
                }
            }

            return result;
        }

        // 参考解答：栈
        public static IList<IList<int>> ZigzagLevelOrder_1(TreeNode root) {
            IList<IList<int>> res = new List<IList<int>>();
            Stack<TreeNode> stack1 = new Stack<TreeNode>(); // 每行数据从左到右读入
            Stack<TreeNode> stack2 = new Stack<TreeNode>(); // 每行数据从右到做读入
            if (root == null)
            {
                return res;
            }
            stack2.Push(root);
            while (stack1.Count != 0 || stack2.Count != 0)
            {
                var sub = new List<int>();
                TreeNode cur;
                if (stack1.Count != 0)
                {
                    while (stack1.Count != 0)
                    {
                        cur = stack1.Pop();
                        sub.Add(cur.val);
                        if (cur.right != null)
                        {
                            stack2.Push(cur.right);
                        }
                        if (cur.left != null)
                        {
                            stack2.Push(cur.left);
                        }
                    }
                    res.Add(sub);
                }
                else
                {
                    while (stack2.Count != 0)
                    {
                        cur = stack2.Pop();
                        sub.Add(cur.val);
                        if (cur.left != null)
                        {
                            stack1.Push(cur.left);
                        }
                        if (cur.right != null)
                        {
                            stack1.Push(cur.right);
                        }
                    }
                    res.Add(sub);
                }
            }

            return res;
        }
    }
}