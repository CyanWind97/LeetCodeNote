 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2462
/// title: 雇佣 K 位工人的总代价
/// problems: https://leetcode.cn/problems/total-cost-to-hire-k-workers
/// date: 20240501
/// </summary>
public static class Solution2462
{
    public static long TotalCost(int[] costs, int k, int candidates) {
        int length = costs.Length;
        var leftQueue = new PriorityQueue<int, int>();
        var rightQueue = new PriorityQueue<int, int>();
        int left = 0;
        int right = 1;

        while(left < candidates){
            leftQueue.Enqueue(costs[left], costs[left]);
            left++;
        }

        while(left + right <= length && right <= candidates){
            rightQueue.Enqueue(costs[^right], costs[^right]);
            right++;
        }

        var count = 0;
        long sum = 0;
        while(left + right <= length && count < k){
            if(leftQueue.Peek() <= rightQueue.Peek()){
                sum += leftQueue.Dequeue();
                count++;
                if(left + right <= length){
                    leftQueue.Enqueue(costs[left], costs[left]);
                    left++;
                }
            }else{
                sum += rightQueue.Dequeue();
                count++;
                if(left + right <= length){
                    rightQueue.Enqueue(costs[^right], costs[^right]);
                    right++;
                }
            }
        }

        while(count < k){
            if(rightQueue.Count == 0 
            || (leftQueue.Count > 0 && leftQueue.Peek() <= rightQueue.Peek())){
                sum += leftQueue.Dequeue();
                count++;
            }else{
                sum += rightQueue.Dequeue();
                count++;
            }
        }

        return sum;
    }
}
