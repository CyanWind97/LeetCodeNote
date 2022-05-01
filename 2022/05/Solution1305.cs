using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1305
    /// title: 两棵二叉搜索树中的所有元素
    /// problems: https://leetcode-cn.com/problems/all-elements-in-two-binary-search-trees/
    /// date: 20220501
    /// </summary>

    public static class Solution1305
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

        public static IList<int> GetAllElements(TreeNode root1, TreeNode root2) {
            void GetValues(TreeNode node, List<int> list){
                if(node == null)
                    return;

                GetValues(node.left, list);
                list.Add(node.val);
                GetValues(node.right, list);
            }

            var list1 = new List<int>();
            var list2 = new List<int>();
            GetValues(root1, list1);
            GetValues(root2, list2);
            var len1 = list1.Count;
            var len2 = list2.Count;

            var result = new List<int>(len1 + len2);
            int i1 = 0;
            int i2 = 0;

            while(true){
                if(i1 == len1){
                    while(i2 < len2){
                        result.Add(list2[i2++]);
                    }
                    break;
                } 

                if(i2 == len2){
                    while(i1 < len1){
                        result.Add(list1[i1++]);
                    }
                    break;
                }

                result.Add(list1[i1] < list2[i2] ? list1[i1++] : list2[i2++]);
            }

            return result;
        }
    }
}