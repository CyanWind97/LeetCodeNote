using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 301
    /// title: 删除无效的括号
    /// problems: https://leetcode-cn.com/problems/remove-invalid-parentheses/
    /// date: 20211027
    /// </summary>
    public static class Solution301
    {
        // 参考解答 回溯
        public static IList<string> RemoveInvalidParentheses(string s) {
            var res = new List<string>();
                
            bool IsValid(string str) {
                int cnt = 0;
                for (int i = 0; i < str.Length; i++) {
                    if (str[i] == '(') {
                        cnt++;
                    } else if (str[i] == ')') {
                        cnt--;
                        if (cnt < 0) {
                            return false;
                        }
                    }
                }

                return cnt == 0;
            }


            void Helper(string str, int start, int lcount, int rcount, int lremove, int rremove) {
                if (lremove == 0 && rremove == 0) {
                    if (IsValid(str)) 
                        res.Add(str);
                    
                    return;
                }

                for (int i = start; i < str.Length; i++) {
                    if (i != start && str[i] == str[i - 1]) 
                        continue;
                    
                    // 如果剩余的字符无法满足去掉的数量要求，直接返回
                    if (lremove + rremove > str.Length - i) 
                        return;
                    
                    // 尝试去掉一个左括号
                    if (lremove > 0 && str[i] == '(') 
                        Helper(str.Substring(0, i) + str.Substring(i + 1), i, lcount, rcount, lremove - 1, rremove);
                    
                    // 尝试去掉一个右括号
                    if (rremove > 0 && str[i] == ')') 
                        Helper(str.Substring(0, i) + str.Substring(i + 1), i, lcount, rcount, lremove, rremove - 1);
                    
                    if (str[i] == ')') 
                        lcount++;
                    else if (str[i] == ')')
                        rcount++;
                    
                    // 当前右括号的数量大于左括号的数量则为非法,直接返回.
                    if (rcount > lcount) 
                        break;
                }
            }


            int lremove = 0;
            int rremove = 0;

            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') {
                    lremove++;
                } else if (s[i] == ')') {
                    if (lremove == 0) 
                        rremove++;
                    else 
                        lremove--;
                }
            }

            Helper(s, 0, 0, 0, lremove, rremove);

            return res;
        }


    }
}