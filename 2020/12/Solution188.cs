using System.Net;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 188
    /// title: 买卖股票的最佳时机 IV
    /// problems: https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iv/
    /// date: 20201228
    /// </summary>
    public static class Solution188
    {
        public static int MaxProfit(int k, int[] prices) {
            if(k == 0)
                return k;
            int length = prices.Length;
            if(length <= 1)
                return 0;
            int[] profits = new int[length];
            int[] delta = new int[length];
            int buy = prices[0], sell = prices[0];
            int preBuy = prices[0], preSell = prices[0];

            for(int i = 1; i < length; i++){
                if(prices[i] < prices[i - 1]){
                    if(sell > buy){
                        if(sell > preSell && buy >= preBuy){
                            delta[i] = preSell - buy;
                            preSell = sell;
                        }else if(sell <= preSell && sell - buy < preSell -preBuy){
                            delta[i] = sell - buy;
                        }else{
                            delta[i] = preSell - preBuy;
                            preBuy = buy;
                            preSell = sell;
                        }
                    }

                    profits[i - 1] = sell - buy;
                    buy = prices[i];
                    sell = prices[i];
                }else if(prices[i] > sell){
                    sell = prices[i];
                }
            }

            if(sell > buy ){
                profits[length - 1] = sell - buy;
                delta[length - 1] = sell > preSell
                        ? buy < preBuy
                            ? preSell - preBuy
                            : preSell - buy
                        : Math.Min(sell - buy, preSell - preBuy);
            }
            
            int count = 0;
            int result = 0;
            for(int i = 0; i < length; i++){
                if(profits[i] > 0){
                    count++;
                    result += profits[i];
                }
            }
            if(k < count)
                result -= delta.Where(x => x > 0).OrderBy(x => x).Take(count - k).Sum();


            return result;
        }

        public static int MaxProfit_1(int k, int[] prices) {
            if(k == 0)
                return k;
            int length = prices.Length;
            if(length <= 1)
                return 0;
            
            List<int> buys = new List<int>();
            List<int> sells = new List<int>();
            int buy = prices[0], sell = prices[0];

            for(int i = 1; i < length; i++){
                if(prices[i] < prices[i - 1]){
                    if(sell > buy){
                        buys.Add(buy);
                        sells.Add(sell);
                    }
                    buy = prices[i];
                    sell = prices[i];
                }else if(prices[i] > sell){
                    sell = prices[i];
                }
            }

            if(sell > buy ){
                buys.Add(buy);
                sells.Add(sell);
            }
            
            int count = buys.Count;

            if(k < count){
                int[] delta = new int[count];
                int[] type = new int[count];
                for(int i = 1; i < count; i++){
                    if(sells[i] > sells[i - 1] && buys[i] >= buys[i - 1]){
                        delta[i] = sells[i - 1] - buys[i];
                        type[i] = 1;
                    }else if(sells[i] <= sells[i - 1] 
                        && sells[i] - buys[i] < sells[i - 1] - buys[i - 1]){
                        delta[i] = sells[i] - buys[i];
                    }else{
                        if(delta[i - 1] == 0 || sells[i - 1] - buys[i - 1] < delta[i - 1]){
                            delta[i] = 0;
                            delta[i - 1] = sells[i - 1] - buys[i - 1];
                            type[i - 1] = 0;
                        }
                    }
                }
                while(count > k){
                    int min = 0;
                    int index = 0;
                    for(int j = 0; j < count; j++){
                        if(delta[j] > 0){
                            if(delta[j] < min || min == 0){
                                min = delta[j];
                                index = j;
                            }
                        }
                    }
                    
                    int tmpType = type[index];
                    for(int j = index; j < count - 1; j++){
                        delta[j] = delta[j + 1];
                        type[j] = type[j + 1];
                    }
                    
                    buys.RemoveAt(index);
                    int maxIndex = index;
                    if(tmpType == 1){
                        index--;
                        delta[index] = 0;
                    }
                    sells.RemoveAt(index);
                    
                    count--;
                    if(k == count || index == 0){
                        delta[index] = 0;
                        continue;
                    }

                    for(int j = index; j <= count - 1 && j <= maxIndex; j++){
                        if(sells[j] > sells[j - 1] && buys[j] >= buys[j - 1]){
                            delta[j] = sells[j - 1] - buys[j];
                            type[j] = 1;
                        }else if(sells[j] <= sells[j - 1] 
                            && sells[j] - buys[j] < sells[j - 1] - buys[j - 1]){
                            delta[j] = sells[j] - buys[j];
                            type[j] = 0;
                        }else{
                            if(delta[j - 1] == 0 || sells[j - 1] - buys[j - 1] < delta[j - 1]){
                                delta[j] = 0;
                                type[j] = 0;
                                delta[j - 1] = sells[j - 1] - buys[j - 1];
                                type[j - 1] = 0;
                            }
                        }
                    }
                }
            }

            return sells.Sum() - buys.Sum();
        }
    
        public static void WriteText(string tag, int count, int index, List<int> buys, List<int> sells, int[] delta, int[] type){
            string path = @"test.txt";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"{count}\t{tag}:");
            sb.AppendLine($"index:\t{index}");
            StringBuilder b = new StringBuilder("buy:");
            StringBuilder s = new StringBuilder("sell:");
            StringBuilder d = new StringBuilder("delta:");
            StringBuilder t = new StringBuilder("type:");

            int minIndex = index - 2 > 0 ? index - 2 : 0;
            int maxIndex =  index + 2 < buys.Count() - 1 ? index + 2 : buys.Count() - 1;
            for(int i = minIndex; i <= maxIndex; i++){
                b.Append($"\t{buys[i]}");
                s.Append($"\t{sells[i]}");
                d.Append($"\t{delta[i]}");
                t.Append($"\t{type[i]}");
            }
            sb.AppendLine(b.ToString()).AppendLine(s.ToString()).AppendLine(d.ToString()).AppendLine(t.ToString());
            File.AppendAllText(path,sb.ToString());
        } 
    }
}