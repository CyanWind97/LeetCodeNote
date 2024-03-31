namespace LeetCodeNote.CodeTop
{
     /// <summary>
    /// no: 236
    /// title:  二叉树的最近公共祖先
    /// problems: https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/
    /// date: 20220502
    /// priority: 0003
    /// time: 00:28:17.70
    /// </summary>
    public static class CodeTop236
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            TreeNode result = null;

            (bool IsPAcestor, bool IsQAcestor) LRD(TreeNode node){
                if(result != null)
                    return (false, false);

                var isP = node == p;
                var isQ = node == q;

                if(node.left != null){
                    (var isPC, var isQC) = LRD(node.left);
                    isP = isP || isPC;
                    isQ = isQ || isQC;
                }

                if(node.right != null){
                    (var isPC, var isQC) = LRD(node.right);
                    isP = isP || isPC;
                    isQ = isQ || isQC;
                }

                if(isP && isQ && result == null)
                    result = node;
                
                return (isP, isQ);
            }

            LRD(root);

            return result;
        }
    }
}