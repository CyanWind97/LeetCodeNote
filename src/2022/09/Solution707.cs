using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 707
    /// title: 设计链表
    /// problems: https://leetcode.cn/problems/design-linked-list/
    /// date: 20220923
    /// </summary>
    public static class Solution707
    {
        public class ListNode {
            public int Val;
            public ListNode Next;

            public ListNode(int val)
                => Val = val;
        }

        public class MyLinkedList {
            private int _size;
            private ListNode _head;

            public MyLinkedList() {
                _size = 0;
                _head = new ListNode(0);
            }
            
            private bool IsValidIndex(int index)
                => index >= 0 && index < _size;

            public int Get(int index) {
                if(!IsValidIndex(index))
                    return -1;
                
                var cur = _head;
                for(int i = 0; i <= index; i++){
                    cur = cur.Next;
                }

                return cur.Val;
            }
            
            public void AddAtHead(int val) {
                AddAtIndex(0, val);
            }
            
            public void AddAtTail(int val) {
                AddAtIndex(_size, val);
            }
            
            public void AddAtIndex(int index, int val) {
                if(index > _size)
                    return;
                
                index = Math.Max(0, index);
                _size++;
                var prev = _head;
                for(int i = 0; i < index; i++){
                    prev = prev.Next;
                }

                var node = new ListNode(val);
                node.Next = prev.Next;
                prev.Next = node;
            }
            
            public void DeleteAtIndex(int index) {
                if(!IsValidIndex(index))
                    return;
                
                _size--;
                var prev = _head;
                for(int i = 0; i < index; i++){
                    prev = prev.Next;
                }

                prev.Next = prev.Next.Next;
            }
        }
    }
}