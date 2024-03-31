namespace LeetCodeNote
{
    /// <summary>
    /// no: 852
    /// title: 山脉数组的峰顶索引
    /// problems: https://leetcode-cn.com/problems/peak-index-in-a-mountain-array/
    /// date: 20210615
    /// </summary>
    public static class Solution852
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
    }
}