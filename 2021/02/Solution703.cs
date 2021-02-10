using System;
using System.Collections.Generic;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 708
    /// title: 数据流中的第 K 大元素
    /// problems: https://leetcode-cn.com/problems/kth-largest-element-in-a-stream/
    /// date: 20210211
    /// </summary>
    public static class Solution703
    {
        public class KthLargest {

            private int[] _nums;

            private int _k;
            
            public KthLargest(int k, int[] nums) {
                _k = k;
                _nums = new int[_k];
                int length = nums.Length;
                Array.Sort(nums, (a,b) => b - a);
                if(length < k){
                    Array.Copy(nums, _nums, length);
                    for(int i = length; i < k; i++){
                        _nums[i] = int.MinValue;
                    }
                }else
                    Array.Copy(nums, _nums, k);
                
            }
            
            public int Add(int val) {
                if(val > _nums[_k - 1]){
                    int i = _k - 1;
                    while(i > 0 && val > _nums[i - 1] ){
                        _nums[i] = _nums[i - 1];
                        i--;
                    }
                    _nums[i] = val;
                }

                return _nums[_k - 1];
            }

        }
    }
}