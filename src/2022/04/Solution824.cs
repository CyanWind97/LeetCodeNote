using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 824
    /// title: 山羊拉丁文
    /// problems: https://leetcode-cn.com/problems/goat-latin/
    /// date: 20220421
    /// </summary>

    public static class Solution824
    {
        public static string ToGoatLatin(string sentence) {
            var vowels = new char[]{'a', 'e', 'i', 'o', 'u'};
            var sb = new StringBuilder();

            string ToGoat(string word, int index){
                sb.Clear();

                if(!vowels.Contains(char.ToLower(word[0]))){
                    if(word.Length > 0)
                        sb.Append(word.Substring(1));

                    sb.Append(word[0]);
                }else{
                    sb.Append(word);
                }
                
                sb.Append("ma");

                while(index >= 0){
                    sb.Append('a');
                    index--;
                }

                return sb.ToString();
            }

            return string.Join(" ", sentence.Split(" ").Select(ToGoat));
        }
    }
}