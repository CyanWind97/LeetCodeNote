using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 68
    /// title: 文本左右对齐
    /// problems: https://leetcode-cn.com/problems/text-justification/
    /// date: 20210909
    /// </summary>
    public static class Solution68
    {
        public static IList<string> FullJustify(string[] words, int maxWidth) {
            int length = words.Length;
            var wordsGroups = new List<(List<string> Words, int Width)>();
            int curWidth = 0;
            var wordsGroup = new List<string>();
            for(int i = 0; i < length; i++){
                int sLength = words[i].Length;
                if(curWidth + sLength > maxWidth){
                    wordsGroups.Add((new List<string>(wordsGroup), curWidth - 1));
                    wordsGroup.Clear();
                    curWidth = 0;
                }

                wordsGroup.Add(words[i]);
                curWidth += sLength + 1;
            }
            
            var result = new List<string>();
            foreach(var group in wordsGroups){
                int count = group.Words.Count;
                int spaceLength = count == 1 ?  maxWidth - group.Width : (maxWidth - group.Width) / (count - 1) + 1;
                int remainSpace = maxWidth - group.Width - (count == 1 ?  spaceLength : (count - 1) * (spaceLength - 1));
                
                char[] spaces = new char[spaceLength];
                Array.Fill(spaces, ' ');
                string space = new string(spaces);

                var sb = new StringBuilder();
                for(int i  = 0; i < count - 1; i++){
                    sb.Append(group.Words[i]);
                    sb.Append(space);
                    if(remainSpace > 0){
                        sb.Append(" ");
                        remainSpace--;
                    }
                }
                sb.Append(group.Words[count - 1]);
                if(count == 1)
                    sb.Append(space);

                result.Add(sb.ToString());
            }
            
            var lastSb = new StringBuilder();
            int wCount = wordsGroup.Count;
            for(int i = 0; i < wCount; i++){
                lastSb.Append(wordsGroup[i]);
                if(i < wCount - 1)
                    lastSb.Append(" ");
            }

            for(int i = curWidth - 1; i < maxWidth; i++){
                lastSb.Append(" ");
            }

            result.Add(lastSb.ToString());

            return result;
        }
    }
}