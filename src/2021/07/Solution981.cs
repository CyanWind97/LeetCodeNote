using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 981
    /// title: 基于时间的键值存储
    /// problems: https://leetcode-cn.com/problems/time-based-key-value-store/
    /// date: 20210710
    /// </summary>
    public static class Solution981
    {
        public class TimeMap {
            Dictionary<string, List<(int TimeStamp, string Value)>> _dic;

            /** Initialize your data structure here. */
            public TimeMap() => _dic = new Dictionary<string, List<(int TimeStamp, string Value)>>();

            public void Set(string key, string value, int timestamp) {
                if(!_dic.ContainsKey(key))
                    _dic.Add(key, new List<(int TimeStamp, string Value)>());

                _dic[key].Add((timestamp, value));
            }
            
            public string Get(string key, int timestamp) {
                _dic.TryGetValue(key, out List<(int TimeStamp, string Value)> list);
                if(list == null)
                    return "";
                
                int i = BinarySearch(list, (timestamp, ((char) 127).ToString()));
                return i > 0 ?  list[i - 1].Value : "";
            }

            private int BinarySearch(List<(int TimeStamp, string Value)> list, (int TimeStamp, string Value) target)
            {
                int Compare((int Timetamp, string Value) item1, (int Timetamp, string Value) item2){
                    return item1.Timetamp != item2.Timetamp
                            ? item1.Timetamp - item2.Timetamp
                            : string.CompareOrdinal(item1.Value, item2.Value);
                }
                
                int low = 0; 
                int high = list.Count - 1;
                if(high < 0 || Compare(list[high], target) <= 0)
                    return high + 1;
                
                while(low < high){
                    int mid = (high - low) / 2 + low;
                    var cur = list[mid];
                    if(Compare(cur, target) <= 0)
                        low = mid + 1;
                    else
                        high = mid;
                }

                return low;
            }
        }

        
        
    }
}