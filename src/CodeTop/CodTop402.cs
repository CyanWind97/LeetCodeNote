using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 402
    /// title:  移掉 K 位数字
    /// problems: https://leetcode.cn/problems/remove-k-digits/
    /// date: 20220523
    /// priority: 0093
    /// time: 00:21:26.45
    /// </summary>
    public static class CodTop402
    {
        public static string RemoveKdigits(string num, int k) {
            int length = num.Length;
            if(k == length)
                return "0";

            var sb = new StringBuilder();
            sb.Append(num[0]);
            int index = 0;
            int remove = 0;
            int i = 1;
            for(; i < length && remove < k; i++){
                while(index >= 0 && remove < k && num[i] < sb[index]){
                    sb.Remove(index, 1);
                    index--;
                    remove++;
                }

                sb.Append(num[i]);
                index++;
            }

            for( ; i < length; i++){
                sb.Append(num[i]);
            }

            if(remove < k)
                sb.Remove(sb.Length - k + remove, k - remove);
            

            i = 0;
            while(i < sb.Length - 1  && sb[i] == '0'){
                i++;
            }

            return sb.ToString(i, sb.Length - i);
        }
    }
}