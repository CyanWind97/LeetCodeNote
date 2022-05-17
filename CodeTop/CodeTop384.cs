using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 384
    /// title:  打乱数组
    /// problems: https://leetcode.cn/problems/shuffle-an-array/
    /// date: 20220517
    /// priority: 0075
    /// time: 00:25:58.06 timeout
    public static class CodeTop384
    {   
        // 洗牌算法
        public class Solution {
            private int[] _orgins;
            
            private int[] _nums;

            private int _length;

            public Solution(int[] nums) {
                _orgins = nums;
                _length = _orgins.Length;
                _nums = new int[_length];
                _orgins.CopyTo(_nums, 0);
            }
            
            public int[] Reset() {
                _orgins.CopyTo(_nums, 0);

                return _nums;
            }
            
            public int[] Shuffle() {
                var random = new Random();
                for(int i = 0; i < _length; i++){
                    var j = random.Next(i, _length);
                    (_nums[i], _nums[j]) = (_nums[j], _nums[i]);
                }

                return _nums;
            }
        }
    }
}