using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 37
    /// title: 序列化二叉树
    /// problems: https://leetcode-cn.com/problems/xu-lie-hua-er-cha-shu-lcof/
    /// date: 20210630
    /// type: 剑指Offer lcof
    /// </summary>
    public class Solution_lcof_37
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class Codec {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root) {
                return rserialize(root, "");
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data) {
                string[] dataArray = data.Split(",");
                LinkedList<string> dataList = new LinkedList<string>(dataArray.ToList());
                return rdeserialize(dataList);
            }

            public string rserialize(TreeNode root, string str) {
                if (root == null) {
                    str += "None,";
                } else {
                    str += root.val.ToString() + ",";
                    str = rserialize(root.left, str);
                    str = rserialize(root.right, str);
                }
                return str;
            }

            public TreeNode rdeserialize(LinkedList<string> dataList) {
                if (dataList.First.Value.Equals("None")) {
                    dataList.RemoveFirst();
                    return null;
                }
        
                TreeNode root = new TreeNode(int.Parse(dataList.First.Value));
                dataList.RemoveFirst();
                root.left = rdeserialize(dataList);
                root.right = rdeserialize(dataList);
            
                return root;
            }

        }
    }
}