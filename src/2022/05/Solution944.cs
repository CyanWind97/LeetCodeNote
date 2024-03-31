namespace LeetCodeNote
{
    /// <summary>
    /// no: 944
    /// title: 删列造序
    /// problems: https://leetcode.cn/problems/delete-columns-to-make-sorted/
    /// date: 20220512
    /// </summary>
    public static class Solution944
    {
        public static int MinDeletionSize(string[] strs) {
            int m = strs.Length;
            int n = strs[0].Length;
            int count = 0;
            for(int j = 0; j < n; j++){
                for(int i = 0; i < m - 1; i++){
                    if(strs[i + 1][j] - strs[i][j] < 0){
                        count++;
                        break;
                    }
                }
            }

            return  count;
        }
    }
}