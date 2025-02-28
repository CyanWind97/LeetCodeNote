using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 131
    /// title: 分割回文串
    /// problems: https://leetcode-cn.com/problems/palindrome-partitioning/
    /// date: 20210307
    /// </summary>
    public static partial class Solution131
    {
        // 参考解答 回溯法 记忆搜索法
        public static IList<IList<string>> Partition(string s) {
            int length = s.Length;
            List<string> ans  = new List<string>();
            List<IList<string>> result = new List<IList<string>>();
            
            int[,] f = new int[length,length];

            int IsPalindrome(int i, int j){
                if(f[i, j] == 0){
                    if(i >= j)
                        f[i, j] = 1;
                    else if(s[i] == s[j])
                        f[i, j] = IsPalindrome(i + 1, j - 1);
                    else
                        f[i, j] = -1;

                }
                
                return f[i, j];

            }

            void dfs(int i){
                if(i == length){
                    result.Add(new List<string>(ans));
                    return;
                }
                
                for(int j = i; j < length; j++){
                    if(IsPalindrome(i,j) == 1){
                        ans.Add(s.Substring(i, j + 1 - i));
                        dfs(j + 1);
                        ans.RemoveAt(ans.Count() - 1);
                    }
                }
            }

            dfs(0);

            return result;
        }   
    }
}