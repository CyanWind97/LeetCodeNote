using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 22
    /// title:  括号生成
    /// problems: https://leetcode-cn.com/problems/generate-parentheses/
    /// date: 20220506
    /// priority: 0014
    /// time: 00:34.11.34 tiemout
    public static class CodeTop22
    {
        public static IList<string> GenerateParenthesis(int n) {
            int BitCount(int i) {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                i = (i + (i >> 4)) & 0x0f0f0f0f;
                i = i + (i >> 8);
                i = i + (i >> 16);
                return i & 0x3f;
            }
            
            bool TryGetS(int num, out string s){
                s = string.Empty;

                int count = 0;
                var builder = new StringBuilder();
                for(int i = 0; i < 2 * n; i++){
                    if((num & 1) == 0){
                        builder.Insert(0, ')');
                        count++;
                    }else{
                        builder.Insert(0, '(');
                        count--;
                        if(count < 0)
                            return false;
                    }

                    num >>= 1;
                }

                s = builder.ToString();
                return true;
            }
            
            // 用二进制表示括号
            int max = 0xffff;
            max >>= 16 - n;
            int min = (1 << (2 * n - 1)) + max - 1;
            max <<= n;

            var result = new List<string>();

            for(int i = min; i <= max; i++){
                if(BitCount(i) != n
                || (i & 1) == 1
                || (i >> (2* n - 1) & 1) == 0)
                    continue;
                
                
                if(TryGetS(i, out var s))
                    result.Add(s);
            }

            return result;
        }


        // 回溯
        public static IList<string> GenerateParenthesis_1(int n) {
        
            HashSet<string> GetS(int size)
            {
                if(size == 1){
                    return new HashSet<string>(){"()"};
                }

                var set = new HashSet<string>();

                int subLength = 2 * (size - 1);
                foreach(var s in GetS(size - 1)){
                    for(int i = 0; i < subLength; i++){
                        set.Add(s.Substring(0, i + 1) + "()" + s.Substring(i + 1, subLength - i - 1));
                    }
                }

                return set;
            }

            return GetS(n).ToList();
        }
    }
}