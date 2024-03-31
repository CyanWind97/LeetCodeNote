using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 460
    /// title: LFU 缓存
    /// problems: https://leetcode.cn/problems/lfu-cache/?envType=daily-question&envId=2023-09-25
    /// date: 20230925
    /// </summary>
    public class Solution460
    {
        // 参考解答
        public class LFUCache {
            private int _minFreq;
            private int _capacity;

            private Dictionary<int, CacheInfo> _keys;

            private Dictionary<int, LinkedList<CacheInfo>> _freqs;

            public LFUCache(int capacity) {
                _minFreq = 0;
                _capacity = capacity; 
                _keys = new();
                _freqs = new();

            }
            
            public int Get(int key) {
                if (_capacity == 0)
                    return -1;
                
                if (!_keys.ContainsKey(key))
                    return -1;
                

                var info = _keys[key];
                (int val, int freq) = (info.Value, info.Freq);
                _freqs[freq].Remove(info);

                if (_freqs[freq].Count == 0) {
                    _freqs.Remove(freq);
                    if (_minFreq == freq)
                        _minFreq++;
                }

                var list = _freqs.GetValueOrDefault(freq + 1, new LinkedList<CacheInfo>());
                var newInfo = new CacheInfo(key, val, freq + 1);
                list.AddFirst(newInfo);
                _freqs[freq + 1] = list;
                _keys[key] = newInfo;

                return val;
            }
            
            public void Put(int key, int value) {
                if (_capacity == 0)
                    return;
                
                if (!_keys.ContainsKey(key)) {
                    if (_keys.Count == _capacity){
                        var info = _freqs[_minFreq].Last.Value;
                        _keys.Remove(info.Key);
                        _freqs[_minFreq].RemoveLast();

                        if (_freqs[_minFreq].Count == 0)
                            _freqs.Remove(_minFreq);
                    }

                    var list = _freqs.GetValueOrDefault(1, new LinkedList<CacheInfo>());
                    var newInfo = new CacheInfo(key, value, 1);
                    list.AddFirst(newInfo);
                    _freqs[1] = list;
                    _keys[key] = newInfo;
                    
                    _minFreq = 1;
                }else{
                    var info = _keys[key];
                    (int val, int freq) = (info.Value, info.Freq);
                    _freqs[freq].Remove(info);
                    if (_freqs[freq].Count == 0) {
                        _freqs.Remove(freq);
                        if (_minFreq == freq)
                            _minFreq++;
                    }

                    var list = _freqs.GetValueOrDefault(freq + 1, new LinkedList<CacheInfo>());
                    var newInfo = new CacheInfo(key, value, freq + 1);
                    list.AddFirst(newInfo);
                    _freqs[freq + 1] = list;
                    _keys[key] = newInfo;
                }
            }
        }


        internal record CacheInfo(int Key, int Value, int Freq);
    }
}