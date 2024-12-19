using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3138
/// title: 同位字符串连接的最小长度
/// problems: https://leetcode.cn/problems/minimum-length-of-anagram-concatenation
/// date: 20241220
/// </summary>
public static class Solution3138
{
    public static int MinAnagramLength(string s) {
        int n = s.Length;
        // 使用 Span 只是为了调用 SequenceEqual 方法
        // 如果直接使用 int[]，Array.SequenceEqual 是 IEnumerable.SequenceEqual 的方法调用
        // 这比 Span.SequenceEqual 慢
        // 因此，当使用 int[] 时，直接比较数组元素是否相等即可
        var key = new Span<int>(new int[26]);
        var compare = new Span<int>(new int[26]);
        for(int l = 1; l <= n / 2; l++){
            key[s[l - 1] - 'a']++;
            if (n % l != 0)
                continue;
            
            bool flag = true;
            for (int i = l; i < n; i += l){
                compare.Clear();
                for (int j = 0; j < l; j++){
                    compare[s[i + j] - 'a']++;
                }

                if (!key.SequenceEqual(compare)){
                    flag = false;
                    break;
                }
            }

            if (flag)
                return l;
        }

        return n;
    }
}
