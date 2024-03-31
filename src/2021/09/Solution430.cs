namespace LeetCodeNote
{
    /// <summary>
    /// no: 430
    /// title: 扁平化多级双向链表
    /// problems: https://leetcode-cn.com/problems/flatten-a-multilevel-doubly-linked-list/
    /// date: 20210924
    /// </summary>
    public static class Solution430
    {
        public class Node {
            public int val;
            public Node prev;
            public Node next;
            public Node child;
        }


        public static Node Flatten(Node head) {
            if (head == null)
                return head;

            Node FlattenNode(Node node) {
                var cur = node;

                while(cur.next != null || cur.child != null){
                    if(cur.child != null){
                        var next = cur.next;
                        cur.next = cur.child;
                        cur.child.prev = cur;
                        var last = FlattenNode(cur.child);
                        cur.child = null;

                        if (next != null){
                            next.prev = last;
                            last.next = next;
                        }

                        cur = last.prev;
                    }

                    cur = cur.next;
                }

                return cur;
            }

            FlattenNode(head);

            return head;
        }
    }
}