using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote;

/// <summary>
/// no: 2810
/// title: 键盘故障
/// problems: https://leetcode.cn/problems/faulty-keyboard
/// date: 20240401
/// </summary>
public static class Solution2810
{
    public static string FinalString(string s) {
        var span = new Span<char>(s.ToCharArray());
        var result = new Span<char>(new char[s.Length]);
        var stack = new Stack<(int Start, int Count)>();
        bool isReverse = false;
        var end = span.Length;
        var endI = end;
        var flag = true;

        while(flag){
            var curr = span[..endI];
            var index = curr.LastIndexOf('i');
            if(index == -1)
                flag = false;
            
            var copy = curr[(index + 1)..];
            if (isReverse){
                stack.Push((index + 1, copy.Length));
            }else{
                end -= copy.Length;
                copy.CopyTo(result[end..]);
            }
            endI = index;

            isReverse = !isReverse;
        }

        while(stack.Count > 0){
            var (start, count) = stack.Pop();
            var copy = span[start..(start + count)];
            copy.Reverse();
            end -= count;
            copy.CopyTo(result[end..]);
        }


        return new string(result[end..]);
    }

    // 参考解答
    // 双端队列
    public static string FinalString_1(string s) {
        var forward = true;
        var list = new LinkedList<char>();
        foreach(var c in s){
            if(c == 'i')
                forward = !forward;
            else if(forward)
                list.AddLast(c);
            else
                list.AddFirst(c);
        }
        
        return forward 
                ? new string(list.ToArray()) 
                : new string(list.Reverse().ToArray());
    }
}