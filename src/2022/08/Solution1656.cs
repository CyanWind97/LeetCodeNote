using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1656
    /// title:  设计有序流
    /// problems: https://leetcode.cn/problems/design-an-ordered-stream/
    /// date: 20220816
    /// </summary>

    public static class Solution1656
    {
        public class OrderedStream {
            private int _ptr;
            private string[] _streams;


            public OrderedStream(int n) {
                _streams = new string[n];
                _ptr = 0;
            }
            
            public IList<string> Insert(int idKey, string value) {
                _streams[idKey - 1] = value;
                if(idKey - 1 != _ptr)
                    return new string[]{};
                
                IEnumerable<string> GetOrders(){
                    while(_ptr < _streams.Length && _streams[_ptr] != null){
                        yield return _streams[_ptr];
                        _ptr++;
                    }
                }

                return GetOrders().ToArray();
            }
        }
    }
}