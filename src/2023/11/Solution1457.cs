using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1457
    /// title: 二叉树中的伪回文路径
    /// problems: https://leetcode.cn/problems/count-pairs-whose-sum-is-less-than-target/description/?envType=daily-question&envId=2023-11-24
    /// date: 20231125
    /// </summary>
    public static class Solution1457
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

        public static int PseudoPalindromicPaths (TreeNode root) {

            int[] count = new int[10];
            int result = 0;

            void DFS(TreeNode node){
                count[node.val]++;
                if(node.left == null && node.right == null){
                    int oddCount = count.Count(num => num % 2 == 1);
                    
                    if(oddCount <= 1)
                        result++;
                }else{
                    if(node.left != null)
                        DFS(node.left);
                    
                    if(node.right != null)
                        DFS(node.right);
                }

                count[node.val]--;
            }

            DFS(root);

            return result;
        }
    }
}