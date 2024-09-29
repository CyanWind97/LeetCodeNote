using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1845
/// title: 座位预约管理系统
/// problems: https://leetcode.cn/problems/seat-reservation-manager
/// date: 20240930
/// </summary>
public static class Solution1845
{
    public class SeatManager {
        private PriorityQueue<int, int> _unreserved;

        private int _next;

        public SeatManager(int n) {
            _unreserved = new PriorityQueue<int, int>();
            _next = 1;
        }   
        
        public int Reserve() {
            if(_unreserved.Count == 0)
                return _next++;
            
            return _unreserved.Dequeue();
        }
        
        public void Unreserve(int seatNumber) {
            _unreserved.Enqueue(seatNumber, seatNumber);
        }
    }
}
