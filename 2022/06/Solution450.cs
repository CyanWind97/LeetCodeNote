namespace LeetCodeNote
{
    /// <summary>
    /// no: 450
    /// title: 删除二叉搜索树中的节点
    /// problems: https://leetcode-cn.com/problems/delete-node-in-a-bst/
    /// date: 20220602
    /// </summary>
    public static class Solution450
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

        // 参考解答
        // 三种情况
        // 1. 叶子节点，直接删除
        // 2. 拥有右节点，用后继节点替代，删除后继节点
        // 3. 拥有左节点，用前驱节点替代，删除前驱节点
        // Successor 代表的是中序遍历序列的下一个节点。即比当前节点大的最小节点，简称后继节点
        // Predecessor 代表的是中序遍历序列的前一个节点。即比当前节点小的最大节点，简称前驱节点
        public static TreeNode DeleteNode(TreeNode root, int key) {
            if(root == null)
                return null;
            
            if(key > root.val)
                root.right = DeleteNode(root.right, key);
            else if(key < root.val)
                root.left = DeleteNode(root.left, key);
            else
            {
                int Successor(TreeNode node)
                {
                    node = node.right;
                    while(node.left != null)
                        node = node.left;
                    
                    return node.val;
                }

                int Predecessor(TreeNode node)
                {
                    node = node.left;
                    while(node.right != null)
                        node = node.right;
                    
                    return node.val;
                }

                if(root.left == null && root.right == null)
                    root = null;
                else if (root.right != null)
                {
                    root.val = Successor(root);
                    root.right = DeleteNode(root.right, root.val);
                }
                else
                {
                    root.val = Predecessor(root);
                    root.left = DeleteNode(root.left, root.val);
                }

            }

            return root;
        }
    }
}