using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2,1};
            int k = 2;
            var head = new Solution86.ListNode(nums[0]);
            var node = head;
            foreach(var x in nums.Skip(1)){
                node.next = new Solution86.ListNode(x);
                node = node.next;
            }

            var result = Solution86.Partition_1(head, 2);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
