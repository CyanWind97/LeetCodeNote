using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1206
    /// title: 设计跳表
    /// problems: https://leetcode.cn/problems/design-skiplist/
    /// date: 20220726
    /// </summary>
    public static class Solution1206
    {
        // 参考解答
        public class Skiplist {

            const int MAX_LEVEL = 32;
            const double P_FACTOR = 0.25;
            
            private SkiplistNode _head;
            private int _level;
            private Random _random;

            public Skiplist() {
                _head = new SkiplistNode(-1, MAX_LEVEL);
                _level = 0;
                _random = new();
            }
            
            public bool Search(int target) {
                var cur = _head;
                for(int i = _level - 1; i >= 0; i--){
                    /* 找到第 i 层小于且最接近 target 的元素*/
                    while (cur.Forward[i] != null 
                        && cur.Forward[i].Value < target) {
                        cur = cur.Forward[i];
                    }
                }

                cur = cur.Forward[0];
                
                return cur != null && cur.Value == target;
            }
            
            public void Add(int num) {
                var update = new SkiplistNode[MAX_LEVEL];
                Array.Fill(update, _head);
                var cur = _head;
                for(int i = _level - 1; i >= 0; i--){
                    /* 找到第 i 层小于且最接近 num 的元素*/
                    while (cur.Forward[i] != null
                        && cur.Forward[i].Value < num) {
                        cur = cur.Forward[i];
                    }
                    update[i] = cur;
                }

                int lv = RandomLevel();
                _level = Math.Max(_level, lv);
                var newNode = new SkiplistNode(num, lv);
                for(int i = 0; i < lv; i++){
                     /* 对第 i 层的状态进行更新，将当前元素的 forward 指向新的节点 */
                    newNode.Forward[i] = update[i].Forward[i];
                    update[i].Forward[i] = newNode;
                }
            }
            
            public bool Erase(int num) {
                var update = new SkiplistNode[MAX_LEVEL];
                var cur = _head;
                for (int i = _level - 1; i >= 0; i--) {
                    /* 找到第 i 层小于且最接近 num 的元素*/
                    while (cur.Forward[i] != null 
                        && cur.Forward[i].Value < num) {
                        cur = cur.Forward[i];
                    }
                    update[i] = cur;
                }
                cur = cur.Forward[0];

                /* 如果值不存在则返回 false */
                if (cur == null || cur.Value != num)
                    return false;
                
                for (int i = 0; i < _level; i++) {
                    if (update[i].Forward[i] != cur) 
                        break;
                    
                    /* 对第 i 层的状态进行更新，将 forward 指向被删除节点的下一跳 */
                    update[i].Forward[i] = cur.Forward[i];
                }
                /* 更新当前的 level */
                while (_level > 1 && _head.Forward[_level - 1] == null) {
                    _level--;
                }
                
                return true;
            }

            private int RandomLevel() {
                int level = 1;
                while(_random.NextDouble() < P_FACTOR && _level < MAX_LEVEL){
                    level++;
                }

                return level;
            }
        }

        public class SkiplistNode {
            public int Value;
            public SkiplistNode[] Forward;

            public SkiplistNode(int val, int maxLevel) {
                Value = val;
                Forward = new SkiplistNode[maxLevel];
            }
        }
    }
}