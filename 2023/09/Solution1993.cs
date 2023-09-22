using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1993
    /// title: 树上的操作
    /// problems: https://leetcode.cn/problems/operations-on-tree/?envType=daily-question&envId=2023-09-23
    /// date: 20230923
    /// </summary>
    public static class Solution1993
    {
        // 参考解答
        public class LockingTree {
            private int[] _parent;
            private int[] _locked;
            private IList<int>[] _children;
            
            public LockingTree(int[] parent) {
                int length = parent.Length;
                _parent = parent;
                _locked = Enumerable.Repeat(-1, length).ToArray();
                _children = Enumerable.Range(0, length).Select(i => new List<int>()).ToArray();
                for(int i = 0; i < length; i++){
                    int p = parent[i];
                    if(p != -1)
                        _children[p].Add(i);
                }

            }
            
            public bool Lock(int num, int user) {
                if (_locked[num] != -1)
                    return false;
                
                _locked[num] = user;
                return true;
            }
            
            public bool Unlock(int num, int user) {
                if (_locked[num] != user)
                    return false;
                
                _locked[num] = -1;
                return true;
            }
            
            public bool Upgrade(int num, int user) {
                var result  = _locked[num] == -1 
                            && !HasLockAncestor(num)
                            && CheckAndUnlockDescendant(num);
                
                if(result)
                    _locked[num] = user;
                
                return result;
            }

            private bool HasLockAncestor(int num){
                while((num = _parent[num]) != -1){
                    if(_locked[num] != -1)
                        return true;
                }

                return false;
            }

            private bool CheckAndUnlockDescendant(int num){
                var result = _locked[num] != -1;
                _locked[num] = -1;
                foreach(var child in _children[num]){
                    result |= CheckAndUnlockDescendant(child);
                }

                return result;
            }
        }
    }
}