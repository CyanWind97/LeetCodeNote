using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 929
    /// title: 独特的电子邮件地址
    /// problems: https://leetcode.cn/problems/unique-email-addresses/
    /// date: 20220604
    /// </summary>
    public static class Solution929
    {
        public static int NumUniqueEmails(string[] emails) {
            var emailSet = new HashSet<string>();
            foreach (string email in emails) {
                var parts = email.Split("@");
                var local = parts[0].Split("+")[0].Replace(".", "");
                
                emailSet.Add($"{local}@{parts[1]}");
            }

            return emailSet.Count;
        }
    }
}