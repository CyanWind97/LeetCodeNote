using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 138
    /// title: 复制带随机指针的链表
    /// problems: https://leetcode-cn.com/problems/copy-list-with-random-pointer/
    /// date: 20210722
    /// </summary>

    public static class Solution138
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
            var dic = new Dictionary<Node, Node>();

            Node Copy(Node node){
                if(node == null)
                    return null;
                
                if(!dic.ContainsKey(node)){
                    var newNode = new Node(node.val);
                    newNode.next = Copy(node.next);
                    newNode.random = Copy(node.random);
                }

                return dic[node];
            }

            return Copy(head);
        }

        // 参考解答 迭代 + 节点拆分
        public static Node CopyRandomList_1(Node head) {
            if(head == null)
                return null;
            
            for(var node = head; node != null; node = node.next.next){
                var newNode = new Node(node.val);
                newNode.next = node.next;
                node.next = newNode;
            }

            for(var node = head; node != null; node = node.next.next){
                var newNode = node.next;
                newNode.random =  node.random?.next;
            }

            var newHead = head.next;
            for(var node = head; node != null; node = node.next){
                var newNode = node.next;
                node.next = node.next.next;
                newNode.next = node.next?.next;
            }

            return newHead;
        }

    }
}