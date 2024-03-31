using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 405
    /// title: 数字转换为十六进制数
    /// problems: https://leetcode-cn.com/problems/convert-a-number-to-hexadecimal/
    /// date: 20211002
    /// </summary>
    public static class Solution405
    {
        public static string ToHex(int num) {
            if (num == 0)
                return "0";
                
            char GetChar(int n)
                => (char)(n >= 10 ? 'a' + n - 10 : '0' + n);
            
            var sb = new StringBuilder();

            for (int i = 7; i >= 0; i--){
                int val = (num >> (4 * i)) & 0xf;
                if (sb.Length > 0 || val > 0)
                    sb.Append(GetChar(val));
            }

            return sb.ToString();
        }
    }
}