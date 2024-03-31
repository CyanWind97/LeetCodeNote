using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 168
    /// title: Excel表列名称
    /// problems: https://leetcode-cn.com/problems/excel-sheet-column-title/
    /// date: 20210629
    /// </summary>
    public static class Solution168
    {
        public static string ConvertToTitle(int columnNumber) {
            List<char> list = new List<char>();
            while(columnNumber > 0){
                int n = columnNumber % 26;
                if(n == 0)
                    list.Add('Z');
                else
                    list.Add((char)('A' + n - 1));
                columnNumber = columnNumber / 26 - (n == 0 ? 1 : 0);
            }

            list.Reverse();
            return new string(list.ToArray());
        }
    }
}