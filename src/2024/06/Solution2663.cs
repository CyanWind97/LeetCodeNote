using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2663
/// title: 字典序最小的美丽字符串
/// problems: https://leetcode.cn/problems/lexicographically-smallest-beautiful-string
/// date: 20240622
/// </summary>
public static class Solution2663
{
    // 参考解答
    public static string SmallestBeautifulString(string s, int k) {
        int length = s.Length;

        string Generate(int index, int offset){
            var span = new Span<char>(s.ToCharArray());
            span[index] = (char)(span[index] + offset);

            for(int i = index + 1; i < length; i++){
                var blockedchars = new HashSet<char>();
                for(int j = 1; j < 3; j++){
                    if (i - j >= 0){
                        blockedchars.Add(span[i - j]);
                    }
                }

                for(int j = 0; j < 3; j++){
                    if (!blockedchars.Contains((char)('a' + j))){
                        span[i] = (char)('a' + j);
                        break;
                    }
                }
            }

            return new string(span);
        }

        for(int i = length - 1; i >= 0; i--){
            var blockedchars = new HashSet<char>();
            for(int j = 1; j < 3; j++){
                if (i - j >= 0){
                    blockedchars.Add(s[i - j]);
                }
            }

            for(int j = 1; j < 4; j++){
                if (s[i] - 'a' + j + 1 <= k
                && !blockedchars.Contains((char)(s[i] + j)))
                    return Generate(i, j);
            }
        }

        return string.Empty;
    }
}
