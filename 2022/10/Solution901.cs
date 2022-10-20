using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 901
    /// title: 股票价格跨度
    /// problems: https://leetcode.cn/problems/online-stock-span/
    /// date: 20221021
    /// </summary>
    public static class Solution901
    {
        public class StockSpanner {

            private Stack<(int Index, int Val)> _stack;
            private int _index;

            public StockSpanner() {
                _stack = new();
                _stack.Push((-1, int.MaxValue));
                _index = -1;
            }   
            
            public int Next(int price) {
                _index++;
                while(price >= _stack.Peek().Val){
                    _stack.Pop();
                }

                int result = _index - _stack.Peek().Index;
                _stack.Push((_index, price));

                return result;
            }
        }
    }
}