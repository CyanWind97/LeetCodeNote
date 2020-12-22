using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[] arr = {3,9,20,null,null,15,7};
            Solution103.TreeNode root = new Solution103.TreeNode(3);
            Queue<Solution103.TreeNode> queue = new();
            queue.Enqueue(root);
            int index = 1;
            while(queue.Count > 0 && index < arr.Length) {
                Solution103.TreeNode node = queue.Dequeue();
                int? a1 = arr[index++];
                int? a2 = arr[index++];
                if(a1 is int x){
                    Solution103.TreeNode leftNode = new Solution103.TreeNode(x);
                    node.left = leftNode;
                    queue.Enqueue(leftNode);
                }

                if(a2 is int y) {
                    Solution103.TreeNode rightNode = new Solution103.TreeNode(y);
                    node.right = rightNode;
                    queue.Enqueue(rightNode);
                }
            }
 
            var result = Solution103.ZigzagLevelOrder(root);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
