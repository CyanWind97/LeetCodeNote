using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1472
/// title: 设计浏览器历史记录
/// problems: https://leetcode.cn/problems/design-browser-history
/// date: 20250226
/// </summary>
public static class Solution1472
{
    public class BrowserHistory {
        private List<string> history;
        private int current;
        private int end;

        public BrowserHistory(string homepage) {
            history = new List<string> { homepage };
            current = 0;
            end = 0;
        }
        
        public void Visit(string url) {
            // 在当前位置后添加新的URL，并删除当前位置之后的所有记录
            current++;
            if (current < history.Count) {
                history[current] = url;
            } else {
                history.Add(url);
            }
            end = current;
        }
        
        public string Back(int steps) {
            // 后退指定步数，但不能超过历史记录的起点
            current = Math.Max(0, current - steps);
            return history[current];
        }
        
        public string Forward(int steps) {
            // 前进指定步数，但不能超过最后访问的位置
            current = Math.Min(end, current + steps);
            return history[current];
        }
    }
}
