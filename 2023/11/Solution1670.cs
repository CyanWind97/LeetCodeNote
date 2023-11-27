using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1670
    /// title: 设计前中后队列
    /// problems: https://leetcode.cn/problems/design-front-middle-back-queue/?envType=daily-question&envId=2023-11-28
    /// date: 20231128
    /// </summary>
    public static class Solution1670
    {
        public class FrontMiddleBackQueue {
            
            LinkedList<int> _front;
            LinkedList<int> _back;

            public FrontMiddleBackQueue() {
                _front = new LinkedList<int>();
                _back = new LinkedList<int>();
            }
            
            public void PushFront(int val) {
                _front.AddFirst(val);
                if (_front.Count > _back.Count + 1){
                    _back.AddFirst(_front.Last.Value);
                    _front.RemoveLast();
                }
            }
            
            public void PushMiddle(int val) {
                if (_front.Count > _back.Count){
                    _back.AddFirst(_front.Last.Value);
                    _front.Last.Value = val;
                }else
                    _front.AddLast(val);
            }
            
            public void PushBack(int val) {
                _back.AddLast(val);
                if (_back.Count > _front.Count){
                    _front.AddLast(_back.First.Value);
                    _back.RemoveFirst();
                }
            }
            
            public int PopFront() {
                if (_front.Count == 0)
                    return -1;
                
                int result = _front.First.Value;
                _front.RemoveFirst();
                if (_back.Count > _front.Count){
                    _front.AddLast(_back.First.Value);
                    _back.RemoveFirst();
                }

                return result;
            }
            
            public int PopMiddle() {
                if (_front.Count == 0)
                    return -1;
                
                int result = _front.Last.Value;
                _front.RemoveLast();
                if (_back.Count > _front.Count){
                    _front.AddLast(_back.First.Value);
                    _back.RemoveFirst();
                }

                return result;
            }
            
            public int PopBack() {
                if (_back.Count == 0){
                    if (_front.Count == 0)
                        return -1;
                    
                    var value = _front.Last.Value;
                    _front.RemoveLast();
                    
                    return value;
                }
                
                int result = _back.Last.Value;
                _back.RemoveLast();
                if (_front.Count > _back.Count + 1){
                    _back.AddFirst(_front.Last.Value);
                    _front.RemoveLast();
                }

                return result;
            }
        }
    }
}