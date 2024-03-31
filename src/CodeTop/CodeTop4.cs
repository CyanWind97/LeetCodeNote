using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 4
    /// title:  寻找两个正序数组的中位数
    /// problems: https://leetcode-cn.com/problems/median-of-two-sorted-arrays/
    /// date: 20220506
    /// priority: 0013
    /// time: timeout
    public static class CodeTop4
    {
        // 参考解答 划分数组
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            int length1 = nums1.Length;
            int length2 = nums2.Length;

            if(length1 > length2)
                return FindMedianSortedArrays(nums2, nums1);
            
            int left = 0;
            int right = length1;
            int median1 = 0;
            int median2 = 0;
            
            while(left <= right){
                int i = (left + right) / 2;
                int j = (length1 + length2 + 1) / 2 - i;

                int numsi0 = (i == 0) ? int.MinValue : nums1[i - 1];
                int numsi1 = (i == length1) ? int.MaxValue : nums1[i];
                int numsj0 = (j == 0) ? int.MinValue : nums2[j - 1];
                int numsj1 = (j == length2) ? int.MaxValue : nums2[j];

                if(numsi0 <= numsj1){
                    median1 = Math.Max(numsi0, numsj0);
                    median2 = Math.Min(numsi1, numsj1);
                    left = i + 1;
                }else{
                    right = i - 1;
                }
            }

            return (length1 + length2) % 2 == 0 ? (median1 + median2) / 2.0 : median1;
        }

        // 二分查找
        public static double FindMedianSortedArrays_1(int[] nums1, int[] nums2) {
            int length1 = nums1.Length;
            int length2 = nums2.Length;

            int mid = (length1 + length2 ) / 2;
            int index1 = 0;
            int index2 = 0;
            int k = mid + 1;

            double GetKthElement(){
                while(true){
                    if(index1 == length1)
                        return nums2[index2 + k - 1];
                    
                    if(index2 == length2)
                        return nums1[index1 + k - 1];
                    
                    if(k == 1)
                        return Math.Min(nums1[index1], nums2[index2]);
                    
                    int half = k / 2;
                    int newIndex1 = Math.Min(index1 + half, length1) - 1;
                    int newIndex2 = Math.Min(index2 + half, length2) - 1;
                    
                    if(nums1[newIndex1] <= nums2[newIndex2]){
                        k -= (newIndex1 - index1 + 1);
                        index1 = newIndex1 + 1;
                    }else{
                        k -= (newIndex2 - index2 + 1);
                        index2 = newIndex2 + 1;
                    }
                }
            }

            var result = GetKthElement();
            
            if((length1 + length2) % 2 == 0){
                var num = 0;
                if(index1 == length1)
                    num = index2 + k - 2 < 0 || length1 > 0 && nums2[index2 + k - 2] < nums1[length1 - 1]
                         ? nums1[length1 - 1]
                         : nums2[index2 + k - 2];
                else if(index2 == length2)
                    num = index1 + k - 2 < 0 || length2 > 0 && nums1[index1 + k - 2] < nums2[length2 - 1]
                        ? nums2[length2 - 1]
                        : nums1[index1 + k - 2];
                else
                    num = index1 == 0 || index2 > 0 && nums1[index1 - 1] < nums2[index2 - 1]
                        ? nums2[index2 - 1]
                        : nums1[index1 - 1];

                result = (result +  num) / 2;
            }
            
            return result;
        }

    }
}