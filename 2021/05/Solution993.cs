namespace LeetCodeNote
{
    /// <summary>
    /// no: 872
    /// title:  叶子相似的树
    /// problems: https://leetcode-cn.com/problems/leaf-similar-trees/
    /// date: 20210510
    /// </summary>
    public static class Solution993
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

        public static bool IsCousins(TreeNode root, int x, int y) {
            TreeNode xParent = null;
            TreeNode yParent = null;

            int xDepth = 0;
            int yDepth = 0;
            
            bool xFound = false;
            bool yFound = false;


            void DFS(TreeNode node, int depth, TreeNode parent) {
                if (node == null) {
                    return;
                }

                if (node.val == x) {
                    xParent = parent;
                    xDepth = depth;
                    xFound = true;
                } else if (node.val == y) {
                    yParent = parent;
                    yDepth = depth;
                    yFound = true;
                }

                // 如果两个节点都找到了，就可以提前退出遍历
                // 即使不提前退出，对最坏情况下的时间复杂度也不会有影响
                if (xFound && yFound) {
                    return;
                }

                DFS(node.left, depth + 1, node);

                if (xFound && yFound) {
                    return;
                }

                DFS(node.right, depth + 1, node);
            }

            DFS(root, 0, null);

            return xDepth == yDepth && xParent != yParent;
        }
    }
}