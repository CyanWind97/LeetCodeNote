using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 239
    /// title:  滑动窗口最大值
    /// problems: https://leetcode.cn/problems/sliding-window-maximum/
    /// date: 20220514
    /// priority: 0050
    /// time: 00:17:48.33 timeout
    /// </summary>
    public static class CodeTop239
    {
        // 单调队列
        public static int[] MaxSlidingWindow(int[] nums, int k) {
            int length = nums.Length;
            var result = new int[length - k + 1];
            var deque = new int[length];
            int left = 0;
            int right = 0;
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
                while(left < right && deque[left] <= i - k)
                    left++;
                
                result[i - k + 1] = nums[deque[left]];
            }

            return result;
        }   
    }
}