namespace LeetCodeNote
{
    /// <summary>
    /// no: 1588
    /// title:  所有奇数长度子数组的和
    /// problems: https://leetcode-cn.com/problems/sum-of-all-odd-length-subarrays/
    /// date: 20210829
    /// </summary>
    public static class Solution1588
    {
        public static int SumOddLengthSubarrays(int[] arr) {
            int length = arr.Length;
            int n = (length - 1) / 2;
            int sum = 0;
            for(int i = 0; i < length; i++){
                int leftCount = i, rightCount = length - i - 1;
                int leftOdd = (leftCount + 1) / 2;
                int rightOdd = (rightCount + 1) / 2;
                int leftEven = leftCount / 2 + 1;
                int rightEven = rightCount / 2 + 1;
                sum += arr[i] * (leftOdd * rightOdd + leftEven * rightEven);
            }
            
            return sum;
        }
    }
}