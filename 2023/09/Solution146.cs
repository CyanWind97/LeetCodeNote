using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 146
    /// title: LRU 缓存
    /// problems: https://leetcode.cn/problems/lru-cache/?envType=daily-question&envId=2023-09-24
    /// date: 20230924
    /// </summary>
    public static class Solution146
    {
        public class LRUCache {
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

            public LRUCache(int capacity) {
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