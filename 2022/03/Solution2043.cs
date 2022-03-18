namespace LeetCodeNote
{
    /// <summary>
    /// no: 2043
    /// title: 简易银行系统
    /// problems: https://leetcode-cn.com/problems/simple-bank-system/
    /// date: 20220318
    /// </summary>
    public static class Solution2043
    {
        public class Bank {

            private long[] _balance;

            private int _size;

            public Bank(long[] balance) {
                _balance = balance;
                _size = _balance.Length;
            }
            
            private bool IsValidAccount(int account)
                => 1 <= account && account <= _size;

            public bool Transfer(int account1, int account2, long money) {
                if(!IsValidAccount(account1) || !IsValidAccount(account2) || _balance[account1 - 1] < money)
                    return false;

                _balance[account1 - 1] -= money;
                _balance[account2 - 1] += money;
                
                return true;
            }
            
            public bool Deposit(int account, long money) {
                if(!IsValidAccount(account))
                    return false;

                _balance[account - 1] += money;
                    
                return  true;
            }
            
            public bool Withdraw(int account, long money) {
                if(!IsValidAccount(account) || _balance[account - 1] < money)
                    return false;
                
                _balance[account - 1] -= money;
                return true;
            }
        }
    }
}