using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 423
    /// title: 从英文中重建数字
    /// problems: https://leetcode-cn.com/problems/reconstruct-original-digits-from-english/
    /// date: 20211124
    /// </summary>
    public class Solution423
    {
        public static string OriginalDigits(string s) {
            // var maps = new string[10]
            // { 
            //     "zero", "one", "two", "three", "four",
            //     "five", "six", "seven", "eight", "nine"
            // };

            var lookup = new Dictionary<char, int>() 
            {
                {'z', 0}, {'o', 1}, {'w', 2}, {'h', 3}, {'u', 4},
                {'f', 5}, {'x', 6}, {'s', 7}, {'g', 8}, {'i', 9},
            };

            var count = new int[10];

            foreach(var c in s){
                if(lookup.ContainsKey(c))
                    count[lookup[c]]++;
            }

            count[1] -= (count[0] + count[2] + count[4]);
            count[3] -= count[8];
            count[5] -= count[4];
            count[7] -= count[6];
            count[9] -= (count[5] + count[6] + count[8]);

            var sb = new StringBuilder();

            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < count[i]; j++){
                    sb.Append(i);
                }
            }

            return sb.ToString();
        }
    }
}