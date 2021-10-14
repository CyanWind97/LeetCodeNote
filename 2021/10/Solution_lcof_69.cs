namespace LeetCodeNote
{
    /// <summary>
    /// no: 69
    /// title: 山峰数组的顶部
    /// problems: https://leetcode-cn.com/problems/B1IidL/
    /// date: 20211014
    /// type: 剑指Offer lcof
    /// </summary>
    public class Solution_lcof_69
    {
        public static int PeakIndexInMountainArray(int[] arr) {
            int length = arr.Length;
            int max = 0;

            for(int i = 1; i < length; i++){
                if(arr[i] > arr[max])
                    max = i;
            }

            return max;
        }

        // 二分法
        public static int PeakIndexInMountainArray_1(int[] arr) {
            int length = arr.Length;
            int left = 0;
            int right = length - 1;

            while(left < right){
                int mid = left + (right - left) / 2;
                bool flagLeft = mid == 0 || arr[mid] > arr[mid - 1];
                bool flagRight =  mid ==  length - 1 || arr[mid] > arr[mid + 1];
                
                if (flagLeft && flagRight)
                    return mid;
                else if(!flagLeft)
                    right = mid - 1;
                else 
                    left = mid + 1;
            }

            
            return left;
        }
    }
}