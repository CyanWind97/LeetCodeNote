using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 872
    /// title:  叶子相似的树
    /// problems: https://leetcode-cn.com/problems/leaf-similar-trees/
    /// date: 20210510
    /// </summary>
    public static class Solution872
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
    
        public static bool LeafSimilar(TreeNode root1, TreeNode root2) {
            List<int> GetList(TreeNode root){
                List<int> list = new List<int>();

                void GetNum(TreeNode node){
                    bool flag = false;
                    if(node.left != null)
                        GetNum(node.left);
                    else 
                        flag = true;

                    if(node.right != null)
                        GetNum(node.right);
                    else if(flag)
                        list.Add(node.val);
                }

                GetNum(root);

                return list;
            }

            List<int> list1 = GetList(root1);
            List<int> list2 = GetList(root2);

            if(list1.Count != list2.Count)
                return false;

            int length = list1.Count;
            for(int i = 0; i < length; i++){
                if(list1[i] != list2[i])
                    return false;
            }

            return true;
        }
    }
}