using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1705
    /// title:  吃苹果的最大数目
    /// problems: https://leetcode-cn.com/problems/maximum-number-of-eaten-apples/
    /// date: 20211224
    /// </summary>
    public static class Solution1705
    {
        public static int EatenApples(int[] apples, int[] days) {
            var list = new List<(int Day, int Apples)>();
            var comparer = Comparer<(int Day, int Apples)>.Create((a,b) => -a.Day.CompareTo(b.Day));

            int result = 0;
            int length = apples.Length;
            int i = 0;

            while(i < length){
                while(list.Count > 0 && list.Last().Day <= i){
                    list.RemoveAt(list.Count - 1);
                }

                (int Day, int Apples) item = (i + days[i], apples[i]);
                if(item.Apples > 0){
                    var index = list.BinarySearch(item, comparer);
                    if(index < 0)
                        index = ~index;
                    
                    list.Insert(index, item);
                }

                if(list.Count > 0){
                    var last = list[list.Count - 1];
                    last.Apples--;
                    if(last.Apples == 0)
                        list.RemoveAt(list.Count - 1);
                    else
                        list[list.Count - 1] = last;

                    result++;
                }
                
                i++;
            }

            while(list.Count > 0){
                while(list.Count > 0 && list.Last().Day <= i){
                    list.RemoveAt(list.Count - 1);
                }

                if(list.Count == 0)
                    break;
                
                var last = list.Last();
                list.RemoveAt(list.Count - 1);
                int cur = Math.Min(last.Day - i, last.Apples);
                result += cur;
                i += cur;
            }

            return result;
        }
    }
}