using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1825
    /// title: 求出 MK 平均值
    /// problems: https://leetcode.cn/problems/finding-mk-average/
    /// date: 20230118
    /// </summary>
    public static class Solution1825
    {
        // 参考解答
        // 维护三个有序队列
        public class MKAverage {
            
            private int _m;

            private int _k;

            private Queue<int> _queue;

            private SortedDictionary<int, int> _s1;
            private SortedDictionary<int, int> _s2;
            private SortedDictionary<int, int> _s3;

            private int _size1;
            private int _size2;
            private int _size3;

            private int _sum;

            public MKAverage(int m, int k) {
                _m = m;
                _k = k;
                _queue = new(m);
                _s1 = new();
                _s2 = new();
                _s3 = new();
                _size1= 0;
                _size2 = 0;
                _size3 = 0;
                _sum = 0;
            }
            
            private bool Remove(SortedDictionary<int, int> s, int x){
                if(!s.ContainsKey(x))
                    return false;
                
                if(s[x] == 1)
                    s.Remove(x);
                else
                    s[x]--;
                
                return true;
            }

            private void Add(SortedDictionary<int, int> s, int x){
                s[x] = s.GetValueOrDefault(x) + 1;
            }

            private int Swap(SortedDictionary<int, int> s1, SortedDictionary<int, int> s2){
                int last = s1.Last().Key;
                int first = s2.First().Key;
                
                if(last <= first)
                    return 0;
                
                Remove(s1, last);
                Add(s1, first);
                Remove(s2, first);
                Add(s2, last);

                return last - first;
            }   

            public void AddElement(int num) {
                _queue.Enqueue(num);
                Add(_s2, num);
                _sum += num;
                _size2++;

                if(_queue.Count < _m)
                    return;
                
                if(_queue.Count == _m){
                    while(_size1 < _k){
                        int first = _s2.First().Key;
                        Add(_s1, first);
                        _size1++;
                        Remove(_s2, first);
                        _sum -= first;
                        _size2--;
                    }

                    while(_size3 < _k){
                        int last = _s2.Last().Key;
                        Add(_s3, last);
                        _size3++;
                        Remove(_s2, last);
                        _sum -= last;
                        _size2--;
                    }

                    return;
                }


                int x = _queue.Dequeue();

                if(Remove(_s1, x)){
                    _size1--;
                }else if(Remove(_s3, x)){
                    _size3--;
                }else{
                    Remove(_s2, x);
                    _size2--;
                    _sum -= x;
                }
                
                if(_size2 > _m - 2 * _k){
                    if(_size1 < _k){
                        int first = _s2.First().Key;
                        Add(_s1, first);
                        _size1++;
                        Remove(_s2, first);
                        _sum -= first;
                    }else{
                        int last = _s2.Last().Key;
                        Add(_s3, last);
                        _size3++;
                        Remove(_s2, last);
                        _sum -= last;
                    } 
                    
                    _size2--;     
                }
                
                _sum += Swap(_s1, _s2);
                _sum -= Swap(_s2, _s3);
            }
            
            public int CalculateMKAverage() {
                if(_queue.Count < _m)
                    return -1;

                return _sum / (_m - 2 * _k);
            }
        }
    }
}