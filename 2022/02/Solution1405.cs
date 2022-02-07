using System;
using System.Text;

namespace LeetCodeNote
{
    /// no: 1405
    /// title: 最长快乐字符串
    /// problems: https://leetcode-cn.com/problems/longest-happy-string/
    /// date: 20220207
    /// </summary>
    public static class Solution1405
    {
        // 参考解答 贪心
        public static string LongestDiverseString(int a, int b, int c) {
            var arr = new (char Ch, int Count)[]  { ('a', a), ('b', b), ('c', c) };
            var sb = new StringBuilder();

            while(true){
                Array.Sort(arr, (a,b) => b.Count - a.Count);
                var hasNext = false;

                for(int i = 0; i < 3; i++){
                    if (arr[i].Count <= 0)
                        break;
                    
                    int length = sb.Length;
                    if (length >= 2 && sb[length - 2] == arr[i].Ch && sb[length - 1] == arr[i].Ch)
                        continue;
                    
                    hasNext = true;
                    sb.Append(arr[i].Ch);
                    arr[i].Count--;
                    break;
                }

                if (!hasNext) 
                    break;
            }

            return sb.ToString();
        }
    }
}