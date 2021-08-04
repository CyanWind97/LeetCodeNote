using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 611
    /// title: 有效三角形的个数
    /// problems: https://leetcode-cn.com/problems/valid-triangle-number/
    /// date: 20210804
    /// </summary>
    public static class Solution611
    {
        public static int TriangleNumber(int[] nums) {
            Array.Sort(nums);
            int length = nums.Length;
            int BinarySearch(int start, int end, int target){
                while(start <= end){
                    int mid = (start + end) / 2;
                    if(nums[mid] < target)
                        start = mid + 1;
                    else
                        end = mid - 1;
                }

                return start;
            }

            int count = 0;
            for(int i = 0; i < length - 2; i++){
                for(int j = i + 1; j < length - 1; j++){
                    int sum = nums[i] + nums[j];
                    count +=  BinarySearch(j + 1, length - 1, sum) - j - 1;
                }
            }

            return count;
        }
        
        // 参考解答 双指针
        public static int TriangleNumber_1(int[] nums) {
            int n = nums.Length;
            Array.Sort(nums);
            int ans = 0;
            for (int i = 0; i < n; ++i) {
                int k = i;
                for (int j = i + 1; j < n; ++j) {
                    while (k + 1 < n && nums[k + 1] < nums[i] + nums[j]) {
                        ++k;
                    }
                    ans += Math.Max(k - j, 0);
                }
            }
            return ans;
        }
    }
}