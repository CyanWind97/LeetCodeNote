using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 987
    /// title: 二叉树的垂序遍历
    /// problems: https://leetcode-cn.com/problems/vertical-order-traversal-of-a-binary-tree/
    /// date: 20210731
    /// </summary>
    public static class Solution987
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

         public static IList<IList<int>> VerticalTraversal(TreeNode root) {
            var dic = new SortedDictionary<int, IList<int>>();
            var queue1 = new Queue<(TreeNode Node, int Col)>();
            var queue2 = new Queue<(TreeNode Node, int Col)>();

            void AddRow(Queue<(TreeNode Node, int Col)> curRow, Queue<(TreeNode Node, int Col)> nextRow){
                var curDic = new Dictionary<int, List<int>>();

                while(curRow.Count > 0){
                    var cur = curRow.Dequeue();
                    if(!curDic.ContainsKey(cur.Col))
                        curDic.Add(cur.Col, new List<int>());
                    
                    curDic[cur.Col].Add(cur.Node.val);

                    if(cur.Node.left != null)
                        nextRow.Enqueue((cur.Node.left, cur.Col - 1));
                    
                    if(cur.Node.right != null)
                        nextRow.Enqueue((cur.Node.right, cur.Col + 1));
                }
                
                foreach(var pair in curDic){
                    if(!dic.ContainsKey(pair.Key))
                        dic.Add(pair.Key, new List<int>());
                    
                    pair.Value.Sort();
                    ((List<int>)dic[pair.Key]).AddRange(pair.Value);
                }

                if(nextRow.Count > 0)
                    AddRow(nextRow, curRow);
            }

            queue1.Enqueue((root, 0));
            AddRow(queue1, queue2);

            return dic.Values.ToList();
        }
    }
}