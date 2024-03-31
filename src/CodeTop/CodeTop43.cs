using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 43
    /// title:  字符串相乘
    /// problems: https://leetcode.cn/problems/multiply-strings/
    /// date: 20220523
    /// priority: 0100
    /// time: 00:19:31.12
    /// </summary>
    public static class CodeTop43
    {
        public static string Multiply(string num1, string num2) {
            if(num1 == "0" || num2 == "0")
                return "0";

            int l1 = num1.Length;
            int l2 = num2.Length;
            int max = (l1 + 1) * (l2 + 1) - 2;

            var result = new int[max];

            for(int i = l2 - 1; i >= 0; i--){
                int cur = 0;
                int num = num2[i] - '0';
                int rCur = 0;
                int index = max - (l2 - i);
                for(int j = l1 - 1; j >= 0; j--, index--){
                    int multi = num * (num1[j] - '0') + cur;
                    cur = multi / 10;
                    
                    result[index] += multi % 10 + rCur;
                    rCur = result[index] / 10;
                    result[index] = result[index] % 10;
                }

                if(cur != 0)
                    rCur += cur;

                while(rCur != 0){
                    result[index] += rCur;
                    rCur = result[index] / 10;
                    result[index] = result[index] % 10;
                    index --;
                }
            }

            int skip = 0;
            while(skip < max - 1 && result[skip] == 0){
                skip++;
            } 

            return string.Join("", result.Skip(skip));
        }
    }
}