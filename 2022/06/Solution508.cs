using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 508
    /// title: 出现次数最多的子树元素和
    /// problems: https://leetcode.cn/problems/most-frequent-subtree-sum/
    /// date: 20220619
    /// </summary>

    public static class Solution508
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

        public static int[] FindFrequentTreeSum(TreeNode root) {
            int max = 0;
            var frequent = new Dictionary<int, int>();

            int CalcSum(TreeNode node){
                int sum = node.val;
                if(node.left != null)
                    sum += CalcSum(node.left);
                
                if(node.right != null)
                    sum += CalcSum(node.right);
                
                if(!frequent.ContainsKey(sum))
                    frequent.Add(sum, 1);
                else
                    frequent[sum]++;
                
                max = Math.Max(max, frequent[sum]);

                return sum;
            }

            CalcSum(root);

            return  frequent.Where(pair => pair.Value == max)
                            .Select(pair => pair.Key)
                            .ToArray();
        }
    }
}