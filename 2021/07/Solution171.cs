namespace LeetCodeNote
{
    /// <summary>
    /// no: 171
    /// title: Excel表列序号
    /// problems: https://leetcode-cn.com/problems/excel-sheet-column-number/
    /// date: 20210730
    /// </summary>
    public static class Solution171
    {
        public static int TitleToNumber(string columnTitle) {
            int result = 0;
            foreach(var c in columnTitle){
                result = result * 26 + c - 'A' + 1;
            }

            return result;
        }
    }
}