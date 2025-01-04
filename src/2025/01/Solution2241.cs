using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2241
/// title: 设计一个 ATM 机器
/// problems: https://leetcode.cn/problems/design-an-atm-machine
/// date: 20250105
/// </summary>
public static class Solution2241
{
    public class ATM {
        private const int Kind = 5;

        private int[] _banknotes = new int[]{20, 50, 100, 200, 500};

        private int[] _banknotesCount = new int[Kind];

        public ATM() {
            
        }
        
        public void Deposit(int[] banknotesCount) {
            for(int i = 0; i < Kind; i++){
                _banknotesCount[i] += banknotesCount[i];
            }
        }
        
        public int[] Withdraw(int amount) {
            var result = new int[Kind];

            for (int i = Kind - 1; i >= 0; i--) {
                result[i] = Math.Min(amount / _banknotes[i], _banknotesCount[i]);
                amount -= result[i] * _banknotes[i];
            }

            if(amount > 0)
                return [-1];
            
            for(int i = 0; i < Kind; i++){
                _banknotesCount[i] -= result[i];
            }

            return result;
        }
    }
}
