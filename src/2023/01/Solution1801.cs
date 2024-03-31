using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1801
    /// title: 积压订单中的订单总数
    /// problems: https://leetcode.cn/problems/number-of-orders-in-the-backlog/
    /// date: 20230102
    /// </summary>
    public static class Solution1801
    {
        // 参考解答
        // 优先队列
        public static int GetNumberOfBacklogOrders(int[][] orders) {
            const int MOD = 1000000007;
            var buys = new PriorityQueue<(int Price, int Amount) ,int>();
            var sells = new PriorityQueue<(int Price, int Amount) ,int>();

            foreach(var order in orders){
                int price = order[0];
                int amount = order[1];
                int type = order[2];
                
                if(type == 0){
                    while(amount > 0 && sells.Count > 0 && sells.Peek().Price <= price){
                        (int sellPirce, int sellAmount) = sells.Dequeue();
                        amount -= sellAmount;
                        if(amount < 0)
                            sells.Enqueue((sellPirce, -amount), sellPirce);
                    }

                    if(amount > 0)
                        buys.Enqueue((price, amount), -price);

                }else{
                    while(amount > 0 && buys.Count > 0 && buys.Peek().Price >= price){
                        (int buyPrice, int buyAmout) = buys.Dequeue();
                        amount -= buyAmout;
                        if(amount < 0)
                            buys.Enqueue((buyPrice, -amount), -buyPrice);
                    }

                    if(amount > 0)
                        sells.Enqueue((price, amount), price);
                }
            }

            
            int total = 0;
            while(sells.Count > 0){
                total = (total + sells.Dequeue().Amount) % MOD;
            }

            while(buys.Count > 0){
                total = (total + buys.Dequeue().Amount) % MOD;
            }

            return total;
        }
    }
}