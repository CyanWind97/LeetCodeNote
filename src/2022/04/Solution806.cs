namespace LeetCodeNote
{
    /// <summary>
    /// no: 806
    /// title: 写字符串需要的行数
    /// problems: https://leetcode-cn.com/problems/number-of-lines-to-write-string/
    /// date: 20220412
    /// </summary>
    public static class Solution806
    {
        public static int[] NumberOfLines(int[] widths, string s) {
            int rowCount = 1;
            int curLength = 0;

            foreach(var c in s){
                var length = widths[c - 'a'];
                if(curLength + length > 100){
                    rowCount++;
                    curLength = 0;
                }

                curLength += length;
            }

            return new int[2]{rowCount, curLength};
        }
    }
}