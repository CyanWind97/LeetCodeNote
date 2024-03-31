using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 138
    /// title:  复制带随机指针的链表
    /// problems: https://leetcode.cn/problems/copy-list-with-random-pointer/
    /// date: 20220513
    /// priority: 0045
    /// time: 00:12:40.38
    /// </summary>
    public static class CodeTop138
    {
        public class Node {
            public int val;
            public Node next;
            public Node random;
            
            public Node(int _val) {
                val = _val;
                next = null;
                random = null;
            }
        }

        public static Node CopyRandomList(Node head) {
            var lookup = new Dictionary<Node, Node>();

            while(head != null){
                var newNode = new Node(head.val);
                newNode.next = head.next;
                newNode.random = head.random;
                lookup.Add(head, newNode);

                head = head.next;
            }

            var newHead = lookup.Values.FirstOrDefault();
            
            while(newHead != null){
                if(newHead.next != null)
                    newHead.next = lookup[newHead.next];
                
                if(newHead.random != null)
                    newHead.random = lookup[newHead.random];

                newHead = newHead.next;
            }

            return lookup.Values.FirstOrDefault();
        }
    }
}