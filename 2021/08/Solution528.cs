using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 528
    /// title: 按权重随机选择
    /// problems: https://leetcode-cn.com/problems/random-pick-with-weight/
    /// date: 20210830
    /// </summary>
    public static class Solution528
    {
        public class Solution {
            private int _sum;
            private int[] _w;

            private int _length;

            private Random _random;

            public Solution(int[] w) {
                _length = w.Length;
                _w = new int[_length];
                _w[0] = w[0];
                for(int i = 1; i < _length; i++){
                    _w[i] = w[i] + _w[i - 1];
                }

                _sum = _w[_length - 1];
                _random = new Random();
            }
            
            public int PickIndex() {
               
                int target = _random.Next(_sum) + 1;
                
                return BinarySearch(target);
            }

            private int BinarySearch(int target){
                int start = 0;
                int end = _length - 1;
                while(start <= end){
                    int mid = (start + end) / 2;
                    if(_w[mid] == target)
                        return mid;
                    else if(_w[mid] < target)
                        start = mid + 1;
                    else
                        end = mid - 1;
                }

                return start;
            }
        }
    }
}