namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 8
    /// title:  字符串转换整数 (atoi)
    /// problems: https://leetcode-cn.com/problems/string-to-integer-atoi/
    /// date: 20220508
    /// priority: 0019
    /// time: 00:12:38.41
    public static class CodeTop8
    {
        public static int MyAtoi(string s) {
            int length = s.Length;
            int index = 0;
            int multi = 1;
            
            while(index < length && s[index] == ' '){
                index++;
            }

            if(index == length)
                return 0;
            
            long max = int.MaxValue;
            if(s[index] == '-'){
                multi = -1;
                max++;
                index++;
            }else if(s[index] == '+'){
                index++;
            }
            
            long result = 0;
            while(index < length && char.IsDigit(s[index])){
                var num = s[index] - '0';
                result = result * 10 + num;
                if(result > max)
                    return (int)(max * multi);

                index++;
            }

            return (int)(result * multi);
        }
    }
}