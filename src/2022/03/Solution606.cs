using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 606
    /// title: 根据二叉树创建字符串
    /// problems: https://leetcode-cn.com/problems/construct-string-from-binary-tree/
    /// date: 20220319
    /// </summary>
    public static class Solution606
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

        public static string Tree2str(TreeNode root) {
            var sb = new StringBuilder();

            void DFS(TreeNode node){
                if(node == null)
                    return;

                sb.Append(node.val);

                if(node.left == null && node.right == null)
                    return;
                
                sb.Append('(');
                DFS(node.left);
                sb.Append(')');

                if(node.right == null)
                    return;

                sb.Append('(');
                DFS(node.right);
                sb.Append(')');
            }

            DFS(root);

            return sb.ToString();
        }
    }
}