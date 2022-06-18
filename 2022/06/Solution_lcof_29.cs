namespace LeetCodeNote
{
     /// <summary>
    /// no: 029
    /// title: 排序的循环链表
    /// problems: https://leetcode.cn/problems/4ueAj6/
    /// date: 20220618
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution_lcof_29
    {
        public class Node {
            public int val;
            public Node next;

            public Node() {}

            public Node(int _val) {
                val = _val;
                next = null;
            }

            public Node(int _val, Node _next) {
                val = _val;
                next = _next;
            }
        }

        // 参考解答
        // 没有想清楚怎么处理[3, 3, 3]
        public static Node Insert(Node head, int insertVal) {
            var node = new Node(insertVal);
            if(head == null){
                node.next = node;
                return node;
            }

            if(head.next == head){
                head.next = node;
                node.next = head;
                return head;
            }

            var cur = head;
            var next = cur.next;
            while(next != head){
                if(insertVal >= cur.val && insertVal <= next.val){
                   break;
                } 
                
                if(cur.val > next.val){
                    if(insertVal > cur.val  || insertVal < next.val)
                        break;
                }

                cur = next;
                next = next.next;
            }

            cur.next = node;
            node.next = next;
            
            return head;
        }
    }
}