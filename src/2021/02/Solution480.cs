using System.Collections.Generic;
using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 480
    /// title: 滑动窗口中位数
    /// problems: https://leetcode-cn.com/problems/sliding-window-median/
    /// date: 20210203
    /// </summary>
    public class Solution480
    {
       
        public static double[] MedianSlidingWindow(int[] nums, int k) {
            int length = nums.Length;
            double[] result = new double[length - k + 1];
            int[] deque = new int[length];
            var array = nums.Take(k).ToArray();
            Array.Sort(array);

            result[0] = array[(k - 1) / 2] / 2.0 + (long)array[k / 2] / 2.0;

            int BinarySearch(int start, int end, int val){
                while (start < end) {
                    int mid = start + (end - start) / 2;
                    int num = array[mid];
                    if (num < val) {
                        start = mid + 1;
                    } else {
                        end = mid;
                    }
                }
                return start;   
            }

            for(int i = k; i < length; i++){
                int old = nums[i - k];
                int val = nums[i];
                if(old > val){
                    int index = BinarySearch(0, k - 1, old);
                    while(index > 0 && val < array[index - 1]){
                        array[index] = array[index - 1];
                        index--;
                    }
                    array[index] = val;

                }else if(old < val){
                    int index = BinarySearch(0, k - 1, old);
                    while(index < k - 1 && val > array[index + 1]){
                        array[index] = array[index + 1];
                        index++;
                    }
                    array[index] = val;
                }
                result[i - k + 1] = array[(k - 1) / 2] / 2.0 + (long)array[k / 2] / 2.0;
            }

            return result;
        }

        // 参考解答
        public static double[] MedianSlidingWindow_1(int[] nums, int k) {

            List<double> ans = new List<double>();
            List<int> data = new List<int>();

            for (int i=0;i<nums.Length;i++)
            {
                // Enqueue - O(logk)
                int l=0, r=data.Count-1;
                while (l<=r)
                {
                    int mid=(l+r)/2;
                    if (nums[data[mid]]==nums[i])
                    {
                        l = mid;
                        break;
                    }
                    else if (nums[data[mid]]<nums[i])
                        r = mid-1;
                    else if (nums[data[mid]]>nums[i])
                        l = mid+1;
                }
                data.Insert(l, i);  // O(n)

                if (data.Count > k)
                {
                    data.Remove(i-k);   // O(n)
                }

                if (data.Count == k)
                {
                    int a = nums[data[k/2]];
                    int b = nums[data[(k-1)/2]];
                    double median = (double)a/2 + (double)b/2;
                    ans.Add(median);
                }
                    
            }
            return ans.ToArray();
        }
    
        
    }
}