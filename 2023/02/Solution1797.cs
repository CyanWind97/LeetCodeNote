using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    // <summary>
    /// no: 1797
    /// title: 设计一个验证系统
    /// problems: https://leetcode.cn/problems/design-authentication-manager/
    /// date: 20230209
    /// </summary>
    public static class Solution1797
    {
        public class AuthenticationManager {

            private int _timeToLove;

            private Dictionary<string, int> _lookup;

            public AuthenticationManager(int timeToLive) {
                _timeToLove = timeToLive;
                _lookup = new Dictionary<string, int>();
            }
            
            public void Generate(string tokenId, int currentTime) {
                _lookup[tokenId] = currentTime + _timeToLove;
            }
            
            public void Renew(string tokenId, int currentTime) {
                if(!_lookup.ContainsKey(tokenId))
                    return;

                if(_lookup[tokenId] <= currentTime)
                    return;
                
                _lookup[tokenId] = currentTime + _timeToLove;
            }
            
            public int CountUnexpiredTokens(int currentTime) {
                return _lookup.Where(pair => pair.Value > currentTime).Count();
            }
        }
    }
}