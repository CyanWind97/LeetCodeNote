using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 284
    /// title: 窥探迭代器
    /// problems: https://leetcode-cn.com/problems/peeking-iterator/
    /// date: 20211005
    /// </summary>
    public static class Solution284
    {
        class PeekingIterator {
            private IEnumerator<int> _iterator;
            private bool _hasNext;

            // iterators refers to the first element of the array.
            public PeekingIterator(IEnumerator<int> iterator) {
                // initialize any member here.
                _iterator = iterator;
                _hasNext = true;
            }
            
            // Returns the next element in the iteration without advancing the iterator.
            public int Peek() {
                return _iterator.Current;
            }
            
            // Returns the next element in the iteration and advances the iterator.
            public int Next() {
                int ret = _iterator.Current;
                _hasNext = _iterator.MoveNext();

                return ret;
            }
            
            // Returns false if the iterator is refering to the end of the array of true otherwise.
            public bool HasNext() {
                return _hasNext;
            }
        }
    }
}