using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2034
    /// title: 股票价格波动
    /// problems: https://leetcode-cn.com/problems/stock-price-fluctuation/
    /// date: 20220123
    /// </summary>
    public static partial class Solution2034
    {
        public class StockPrice {
            Dictionary<int, int> time2price = new Dictionary<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int latestTime = -1;

            public StockPrice() {

            }
            
            public void Update(int timestamp, int price) {
                set.Add(price);

                if (dic.ContainsKey(price))
                    ++dic[price];
                else
                    dic[price] = 1;

                if (time2price.ContainsKey(timestamp))
                {
                    int val = time2price[timestamp];
                    --dic[val];

                    if (dic[val] == 0)
                    {
                        dic.Remove(val);
                        set.Remove(val);
                    }
                }

                time2price[timestamp] = price;
                latestTime = Math.Max(latestTime, timestamp);
            }
            
            public int Current() {
                if (latestTime >= 0)
                    return time2price[latestTime];
                
                return -1;
            }
            
            public int Maximum() {
                return set.Max;
            }
            
            public int Minimum() {
                return set.Min;
            }
        }

    }
}