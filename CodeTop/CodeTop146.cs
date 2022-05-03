using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 146
    /// title:  LRU 缓存
    /// problems: https://leetcode-cn.com/problems/lru-cache/
    /// date: 20220504
    /// priority: 0006
    /// time: 00:22:00
    /// </summary>
    public static class CodeTop146
    {
        public class LRUCache {
            private int _capacity;

            private int _size;

            private Dictionary<int, int> _lookup;

            private Queue<int> _queue;

            private Dictionary<int, int> _count;

            public LRUCache(int capacity) {
                _capacity = capacity;
                _size = 0;

                _lookup = new();
                _queue = new();
                _count = new();
            }
            
            public int Get(int key) {
                if(_lookup.TryGetValue(key, out int val))
                {
                    _count[key]++;
                    _queue.Enqueue(key);

                    return val;
                }
                else
                {
                    return -1;
                }
            }
            
            public void Put(int key, int value) {
                if(_lookup.ContainsKey(key))
                {
                    _lookup[key] = value;
                    _count[key]++;
                    _queue.Enqueue(key);

                    return;
                }
                
                if(_size == _capacity)
                {
                   while(_queue.Count > 0)
                   {
                       var oldKey = _queue.Dequeue();
                       if(_count[oldKey] == 1)
                       {
                           _lookup.Remove(oldKey);
                           _count.Remove(oldKey);
                            break;
                       }
                       else
                       {
                           _count[oldKey]--;
                       }
                   }

                   _size--;
                }
                
                 _lookup.Add(key, value);
                _count.Add(key, 1);
                _queue.Enqueue(key);
                _size++;
            }
        }

        // 参考解答 双向链表
        public class LRUCache_1 {
            class DLinkedNode {
                public int Key;
                public int Value;

                public DLinkedNode Prev;
                public DLinkedNode Next;

                public DLinkedNode()
                {

                }   

                public DLinkedNode(int key, int val)
                {
                    Key = key;
                    Value = val;
                }
            }

            private int _capacity;

            private int _size;

            private Dictionary<int, DLinkedNode> _lookup;

            private DLinkedNode _head;

            private DLinkedNode _tail;

            public LRUCache_1(int capacity) {
                _capacity = capacity;
                _size = 0;
                _lookup = new();
                _head = new DLinkedNode();
                _tail = new DLinkedNode();
                _head.Next = _tail;
                _tail.Prev = _head;
            }
            
            public int Get(int key) {
                if(_lookup.TryGetValue(key, out var node)){
                    MoveToHead(node);
                    return node.Value;
                }else{
                    return -1;
                }
            }
            
            public void Put(int key, int value) {
                if(_lookup.TryGetValue(key, out var node)){
                    node.Value = value;
                    MoveToHead(node);
                }else{
                    node = new DLinkedNode(key, value);
                    _lookup.Add(key, node);
                    AddToHead(node);
                    if(_size == _capacity){
                        var tail = RemoveTail();
                        _lookup.Remove(tail.Key);
                    }else{
                        _size++;
                    }
                }
            }

            private void AddToHead(DLinkedNode node){
                node.Prev = _head;
                node.Next = _head.Next;
                _head.Next.Prev = node;
                _head.Next = node;
            }

            private void RemoveNode(DLinkedNode node){
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }

            private void MoveToHead(DLinkedNode node){
                RemoveNode(node);
                AddToHead(node);
            }

            private DLinkedNode RemoveTail(){
                var result = _tail.Prev;
                RemoveNode(result);

                return result;
            }
        }
    }
}