using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 93
    /// title:  复原 IP 地址
    /// problems: https://leetcode.cn/problems/restore-ip-addresses/
    /// date: 20220512
    /// priority: 0042
    /// time: 00:09:18.04
    public static class CodeTop93
    {
        public static IList<string> RestoreIpAddresses(string s) {
            var result = new List<string>();
            int length = s.Length;
            if(length > 12)
                return result;
            
            var segments = new int[4];
            
            void DFS(int count, int index){
                if(count == 4){
                    if(index == length)
                        result.Add(string.Join(".", segments));
                    
                    return;
                }

                if(index == length)
                    return;
                
                if(s[index] == '0'){
                    segments[count] = 0;
                    DFS(count + 1, index + 1);
                }

                int addr = 0;
                int max = Math.Min(index + 3, length);
                for(int end = index; end < max; end++){
                    addr = addr * 10 + (s[end] - '0');
                    if(addr > 0 && addr <= 255){
                        segments[count] = addr;
                        DFS(count + 1, end + 1);
                    }else{
                        break;
                    }
                }
            }

            DFS(0, 0);

            return result;
        }
    }
}