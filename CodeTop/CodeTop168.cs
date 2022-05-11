using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 168
    /// title:  Excel表列名称
    /// problems: https://leetcode.cn/problems/excel-sheet-column-title/
    /// date: 20220511
    /// priority: 0034
    /// time: 00:09:12.29
    /// </summary>
    public static class CodeTop168
    {
        public static string ConvertToTitle(int columnNumber) {
            var sb = new StringBuilder();
            while (columnNumber > 0) {
                int m = (columnNumber - 1) % 26 + 1;
                sb.Insert(0, (char)(m - 1 + 'A'));
                columnNumber = (columnNumber - m) / 26;
            }

            return sb.ToString();
        }
    }
}