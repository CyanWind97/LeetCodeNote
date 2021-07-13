namespace LeetCodeNote
{
    /// <summary>
    /// no: 275
    /// title: H 指数 II
    /// problems: https://leetcode-cn.com/problems/h-index-ii/
    /// date: 20210712
    /// </summary>
    public static class Solution275
    {
        public static int HIndex(int[] citations) {
            int length = citations.Length;
            int left = 0;
            int right = length - 1;
            if(citations[right] == 0)
                return 0;

            while(left < right){
                int mid = left + (right - left) / 2;
                if(citations[mid] >= length - mid)
                    right = mid;
                else 
                    left = mid + 1;
            }

            return length - right;
        }
    }
}