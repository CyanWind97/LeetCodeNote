using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 253
    /// title: 两数之和 IV - 输入 BST
    /// problems: https://leetcode-cn.com/problems/two-sum-iv-input-is-a-bst/
    /// date: 20220321
    /// </summary>
    public static class Solution253
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

        public static bool FindTarget(TreeNode root, int k) {
            if(root == null)
                return false;

            bool Find(int val){
                var node = root;
                
                while(node != null){
                    if(node.val == val)
                        return true;
                    else if(node.val > val)
                        node = node.left;
                    else
                        node = node.right;
                }

                return false;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0){
                var cur = queue.Dequeue();
                int diff = k - cur.val;
                
                if(diff != cur.val && Find(diff))
                    return true;
                
                if(cur.left != null)
                    queue.Enqueue(cur.left);
                
                if(cur.right != null)
                    queue.Enqueue(cur.right);
            }

            return false;
        }

        public static bool FindTarget_1(TreeNode root, int k) {
            if(root == null)
                return false;

            var nums = new List<int>();

            void LDR(TreeNode node){
                
                if(node.left != null)
                    LDR(node.left);

                nums.Add(node.val);

                if(node.right != null)
                    LDR(node.right);
            }

            LDR(root);
            int left = 0;
            int right = nums.Count - 1;

            if(right == 0 || k < nums[0] + nums[1] || k > nums[right] + nums[right - 1])
                return false;
            
            while(left < right){
                var sum = nums[left] + nums[right];
                if(sum == k)
                    return true;
                else if(sum < k)
                    left++;
                else
                    right--;
            }

            return false;
        }
    }
}