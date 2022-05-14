using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 12
    /// title:  二叉树的下一个节点
    /// problems: https://www.nowcoder.com/questionTerminal/9023a0c988684a53960365b889ceaf5e
    /// date: 20220514
    /// type: 补充题 added
    /// priority: 0051
    /// time: 00:31:29.54 timeout
    /// </summary>

    public static class CodeTop_added_12
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

        public static TreeNode GetNext(TreeNode root, TreeNode target)
        {
            TreeNode pre = null;
            TreeNode node = root;
            var stack = new Stack<TreeNode>();
            
            while(stack.Count > 0 || node != null){
                while(node != null){
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();
                if(pre == target)                
                    return node;
                
                pre = node;
                node = node.right;
            }

            return null;
        }
    }
}