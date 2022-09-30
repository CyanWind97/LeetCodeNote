using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1694
    /// title: 重新格式化电话号码
    /// problems: https://leetcode.cn/problems/reformat-phone-number/
    /// date: 20221001
    /// </summary>
    public static class Solution1694
    {
        public static string ReformatNumber(string number) {
            var sb = new StringBuilder();
            int count = 0;
            foreach(var c in number){
                if(!char.IsDigit(c))
                    continue;
                
                sb.Append(c);
                count++;
                if(count == 3){
                    sb.Append('-');
                    count = 0;
                }
            }

            int length = sb.Length;
            if(sb[length - 1] == '-')
                sb.Remove(length - 1, 1);
            else if(length > 2 && sb[length - 2] == '-')
                (sb[length - 2], sb[length - 3]) = (sb[length - 3], '-');
            
            return sb.ToString();
        }
    }
}