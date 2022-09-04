using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 652
    /// title: 寻找重复的子树
    /// problems: https://leetcode.cn/problems/find-duplicate-subtrees/
    /// date: 20220905
    /// </summary>
    public static class Solution652
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

        public static IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
            var result = new List<TreeNode>();
            var count = new Dictionary<string, int>();
            
            IEnumerable<int> LRD(TreeNode node){
                var list = new List<int>();
                if(node == null){
                    list.Add(-201);
                    return list;
                }
                
                list.AddRange(LRD(node.left));  
                list.AddRange(LRD(node.right));
                list.Add(node.val);
                
                var key = string.Join(",", list);
                if(!count.ContainsKey(key)){
                    count.Add(key, 1);
                }else if(count[key] == 1){
                    count[key]++;
                    result.Add(node);
                }

                return list;
            }

            if(root.left != null)
                LRD(root.left);
            
            if(root.right != null)
                LRD(root.right);

            return result;
        }

        // 参考解答
        // 使用三元组进行唯一表示
        public static IList<TreeNode> FindDuplicateSubtrees_1(TreeNode root) {
            var result = new HashSet<TreeNode>();
            int index = 0;
            var seen = new Dictionary<string, (TreeNode Node, int Index)>();
            
            int DFS(TreeNode node){
                if(node == null)
                    return -201;

                (int D, int L, int  R) tree = (node.val, DFS(node.left), DFS(node.right));
                var key = tree.ToString();
                if(seen.ContainsKey(key)){
                    (TreeNode dNode, int dIndex) = seen[key];
                    result.Add(dNode);

                    return dIndex;
                }else{
                    seen.Add(key, (node, ++index));
                    return index;
                }
            }

            DFS(root);

            return result.ToList();
        }
    }
}