using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 384
    /// title:  打乱数组
    /// problems: https://leetcode-cn.com/problems/shuffle-an-array/
    /// date: 20211122
    /// </summary>
    public static class Solution384
    {
        // 参考解答 洗牌算法
        public class Solution {
            private int[] _original;
            private int[] _nums;

            private int _length;

            public Solution(int[] nums) {
                _nums = nums;
                _length = nums.Length;
                _original = new int[_length];
                Array.Copy(nums, _original, _length);
            }
            
            public int[] Reset() {
                Array.Copy(_original, _nums, _length);

                return _nums;
            }
            
            public int[] Shuffle() {
                Random random = new Random();
                for (int i = 0; i < _length; ++i) {
                    int j = random.Next(i, _length);
                    (_nums[i], _nums[j]) = (_nums[j], _nums[i]);
                }

                return _nums;
            }
        }
    }
}