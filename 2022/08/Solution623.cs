namespace LeetCodeNote
{
    /// <summary>
    /// no: 623
    /// title:  在二叉树中增加一行
    /// problems: https://leetcode.cn/problems/add-one-row-to-tree/
    /// date: 20220803
    /// </summary>
    public static class Solution623
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

        public static TreeNode AddOneRow(TreeNode root, int val, int depth) {
            if(depth == 1)
                return new TreeNode(val, root);
                
            
            void DFS(TreeNode node, int level){
                if(level != depth - 1){
                    if(node.left != null)
                        DFS(node.left, level + 1);
                    
                    if(node.right != null)
                        DFS(node.right, level + 1);

                }else{
                    node.left = node.left != null 
                                ? new TreeNode(val, node.left)
                                : new TreeNode(val);
                    

                    node.right = node.right != null 
                                ? new TreeNode(val, null, node.right)
                                : new TreeNode(val);
                }
            }

            DFS(root, 1);

            return root;
        }
    }
}