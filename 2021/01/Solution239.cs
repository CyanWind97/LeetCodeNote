using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 239
    /// title: 滑动窗口最大值
    /// problems: https://leetcode-cn.com/problems/sliding-window-maximum/
    /// date: 20210102
    /// </summary>
    public static class Solution239
    {

        // 超时
        public static int[] MaxSlidingWindow(int[] nums, int k) {
            int length = nums.Length;
            int n =  length - k + 1;
            int[] result = new int[n];
            Array.Fill(result, int.MinValue);
            var sorted = nums.Select((val,index) => (index, val))
                            .OrderBy(x => -x.val)
                            .ToArray();
            int count = 0;
            foreach(var x in sorted){
                int start = x.index + 1 > k ? x.index - k + 1 : 0;
                int end = x.index + k - 1 < length ? x.index : n - 1;
                if(start > end)
                    start = end;
                while(start <= end && x.val <= result[start])
                    start++;
                while(end >= start && x.val <= result[end])
                    end--;
                if(start <= end){
                    Array.Fill(result, x.val, start, end - start + 1);
                    count += end - start + 1;
                }
                if(count >= n)
                    break;
            }

            return result;
        }


        // 官方解答： 单调队列
        public static int[] MaxSlidingWindow_1(int[] nums, int k) {
            int length = nums.Length;
            int n =  length - k + 1;
            int[] result = new int[n];
            int[] deque = new int[length];
            int left = 0, right = 0;
            for(int i = 0; i < k; i++){
                while(right > left && nums[i] >= nums[deque[right - 1]])
                    right--;
                
                deque[right++] = i;
            }
            result[0] = nums[deque[left]];
            for(int i = k; i < length; i++){
                while(right > left && nums[i] >= nums[deque[right - 1]])
                    right--;

                deque[right++] = i;
                while(left < right &&  deque[left] <= i - k)
                    left++;

                result[i - k + 1] = nums[deque[left]];
            }

            return result;
        }

        // 参考解答： 单调队列(双端队列) LinkedList
        public static int[] MaxSlidingWindow_2(int[] nums, int k) {
            int length = nums.Length;
            int n =  length - k + 1;
            int[] result = new int[n];
            LinkedList<int> list = new LinkedList<int>();
            for(int i = 0; i < k; i++){
                while(list.Count > 0 && nums[i] >= nums[list.Last.Value])
                    list.RemoveLast();
                
                list.AddLast(i);
            }
            result[0] = nums[list.First()];
            for(int i = k; i < length; i++){
                while(list.Count > 0 && nums[i] >= nums[list.Last.Value])
                    list.RemoveLast();

                list.AddLast(i);
                while(list.First.Value <= i - k)
                    list.RemoveFirst();

                result[i - k + 1] = nums[list.First.Value];
            }

            return result;
        }

    }
}