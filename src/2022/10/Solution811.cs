using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 811
    /// title: 子域名访问计数
    /// problems: https://leetcode.cn/problems/subdomain-visit-count/
    /// date: 20221005
    /// </summary>
    public static class Solution811
    {
        public static IList<string> SubdomainVisits(string[] cpdomains) {
            var count = new Dictionary<string, int>();

            void CountDomain(int rep, string d){
                if(count.ContainsKey(d))
                    count[d] += rep;
                else
                    count[d] = rep;
            }
            
            foreach(var domain in cpdomains){
                var sub = domain.Split(" ");
                var rep = int.Parse(sub[0]);
                var d = sub[1];

                CountDomain(rep, d);

                var index = d.IndexOf('.');
                d = d.Substring(index + 1);
                CountDomain(rep, d);

                index = d.IndexOf('.');
                if(index < 0)
                    continue;
                
                d = d.Substring(index + 1);
                CountDomain(rep, d);
            }

            return count.Select(pair => $"{pair.Value} {pair.Key}").ToList();
        }
    }
}