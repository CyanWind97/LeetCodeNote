namespace LeetCodeNote
{
    /// <summary>
    /// no: 278
    /// title: 第一个错误的版本
    /// problems: https://leetcode-cn.com/problems/first-bad-version/
    /// date: 20210613
    /// </summary>
    public static class Solution278
    {
        public static int FirstBadVersion(int n) {
            int start = 1;
            int end = n;
            while(start < end){
                int mid = start + (end - start) / 2;
                
                if(IsBadVersion(mid))
                    end = mid;
                else
                    start = mid + 1;
            }

            return start;
        }

        public static bool IsBadVersion(int version) => true;
    }
}