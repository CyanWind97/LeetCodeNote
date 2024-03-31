using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1072
    /// title: 餐盘栈
    /// problems: https://leetcode.cn/problems/dinner-plate-stacks/
    /// date: 20230428
    /// </summary>
    public static class Solution1172
    {
        public class DinnerPlates {
            private int _capacity;

            private List<Stack<int>> _stacks;

            private SortedSet<int> _emptyIndex;

            private int _right = 0;


            public DinnerPlates(int capacity) {
                _capacity = capacity;
                _stacks = new List<Stack<int>>();
                _emptyIndex = new SortedSet<int>();
            }
            
            public void Push(int val) {
                if(_emptyIndex.Count == 0 || _emptyIndex.Min == _right){
                    _emptyIndex.Add(_right);
                    if(_right == _stacks.Count)
                        _stacks.Add(new Stack<int>(_capacity));

                    _right++;
                }
                
                var stack = _stacks[_emptyIndex.Min];
                stack.Push(val);
                if(stack.Count == _capacity)
                    _emptyIndex.Remove(_emptyIndex.Min);

            }
            
            public int Pop() {
                while(_right > 0 && _stacks[_right - 1].Count == 0){
                    _emptyIndex.Remove(_right - 1);
                    _right--;
                }
                
                if(_right == 0)
                    return -1;
                
                int result = _stacks[_right - 1].Pop();
                _emptyIndex.Add(_right - 1);

                return result;
            }
            
            public int PopAtStack(int index) {
                if(index >= _right || _stacks[index].Count == 0)
                    return -1;
                
                var result = _stacks[index].Pop();
                _emptyIndex.Add(index);

                return result;
            }
        }


        // 参考解答
        // 
        public class DinnerPlates_1 {
            private int _capacity;

            private List<int> _stack;

            private SortedSet<int> _emptyIndex;

            private List<int> _top;


            public DinnerPlates_1(int capacity) {
                _capacity = capacity;
                _stack = new List<int>();
                _emptyIndex = new SortedSet<int>();
                _top = new List<int>();
            }
            
            public void Push(int val) {
                 if (_emptyIndex.Count == 0) {
                    int pos = _stack.Count;
                    _stack.Add(val);
                    if (pos % _capacity == 0) 
                        _top.Add(0);
                    else {
                        _top[_top.Count - 1]++;
                    }
                } else {
                    int pos = _emptyIndex.Min;
                    _emptyIndex.Remove(pos);
                    _stack[pos] = val;
                    int index = pos / _capacity;
                    _top[index]++;
                }

            }
            
            public int Pop() {
                while(_stack.Count != 0 && _emptyIndex.Contains(_stack.Count - 1)) {
                    _stack.RemoveAt(_stack.Count - 1);
                    var pos1 = _emptyIndex.Max;
                    _emptyIndex.Remove(pos1);
                    if(pos1 % _capacity == 0)
                        _top.RemoveAt(_top.Count - 1);
                }
                
                if(_stack.Count == 0)
                    return -1;
                
                int pos = _stack.Count - 1;
                int val = _stack[pos];
                
                _stack.RemoveAt(pos);
                int index = _top.Count - 1;

                if (pos % _capacity == 0)
                    _top.RemoveAt(index);
                else
                    _top[index] = index - 1;

                return val;
            }
            
            public int PopAtStack(int index) {
                if(index >= _top.Count ||  _top[index] < 0)
                    return -1;
                
                int pos = index * _capacity + _top[index];
                var result = _stack[pos];
                _emptyIndex.Add(pos);
                _top[index]--;

                return result;
            }
        }
    }
}