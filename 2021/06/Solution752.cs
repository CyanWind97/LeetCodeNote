using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 752
    /// title: 打开转盘锁
    /// problems: https://leetcode-cn.com/problems/open-the-lock/
    /// date: 20210625
    /// </summary>
    public static class Solution752
    {
        // 参考 启发性搜索 A*算法
        // f(n) = g(n) + h(n)
        // f(n) 为最小代价
        // g(n) 为初始状态到当前状态的代价
        // h(n) 为当前状态到目标状态的代价
        public static int OpenLock(string[] deadends, string target) {
            if(target == "0000")
                return 0;
            
            HashSet<string> dead = deadends.ToHashSet();
            if(dead.Contains("0000"))
                return -1;
            
            Heap<AStart> heap = new Heap<AStart>(false);
            heap.Insert(new AStart("0000", target, 0));
            HashSet<string> seen = new HashSet<string>();
            seen.Add("0000");
            while(!heap.Empty){
                AStart node = heap.Pop();
                foreach(var nextStatus in Get(node.Status)){
                    if(!seen.Contains(nextStatus) && !dead.Contains(nextStatus)){
                        if(nextStatus == target)
                            return node.G + 1;
                        
                        heap.Insert(new AStart(nextStatus, target, node.G + 1));
                        seen.Add(nextStatus);
                    }
                }
            }

            return -1;
        }

        public static char PrevNum(char x) => x == '0' ? '9' : (char)(x -1);

        public static char SuccNum(char x) => x == '9' ? '0' : (char)(x + 1);

        // 枚举 status 通过一次旋转得到的数字
        public static IEnumerable<string> Get(string status) {
            char[] array = status.ToCharArray();
            for (int i = 0; i < 4; ++i) {
                char num = array[i];
                array[i] = PrevNum(num);
                yield return new string(array);
                array[i] = SuccNum(num);
                yield return new string(array);
                array[i] = num;
            }
        }

        public class AStart : IComparable<AStart>
        {
            public string Status;
            public int F;
            public int G;
            public int H;

            public AStart(string status, string target, int g){
                this.Status = status;
                this.G = g;
                this.H = GetH(status, target);
                this.F = this.G + this.H;
            }

            public static int GetH(string status, string target){
                int result = 0;
                for(int i = 0; i < 4; i++){
                    int dist = Math.Abs(status[i] - target[i]);
                    result += Math.Min(dist, 10 - dist);
                }
                return result;
            }

            public int CompareTo(AStart other) => this.F - other.F;
        }
    
        // 大顶堆
        class Heap<T> where T : IComparable<T>
        {
            private T[] data;
            private int size;

            private bool isMax;//是否是大顶堆

            public Heap(bool max = true):this(7, max) {}

            public Heap(int capacity, bool max)
            {
                data = new T[capacity];
                isMax = max;
            }

            public Heap(T[] array, bool max = true)
            {
                isMax = max;
                data = new T[array.Length];
                for(int i = 0; i < data.Length; i++)
                {
                    data[i] = array[i];
                }
                size = array.Length;
                for (int i = Parent(data.Length - 1); i >= 0; i--)
                {
                    SiftDown(i);
                }
                
            }

            public bool Empty
            {
                get { return size == 0; }
            }

            public int Count
            {
                get { return size; }
            }

            public void Clear()
            {
                size = 0;
                if(data.Length > 7)
                    data = new T[7];
            }

            public void Insert(T value)
            {
                if(size >= data.Length)
                {
                    Resize(size * 2);
                }
                data[size] = value;
                SiftUp(size);
                size++;
            }

            //弹出堆顶元素
            public T Pop()
            {
                if (size == 0)
                    throw new InvalidOperationException("heap is empty");
                T value = data[0];
                data[0] = data[size - 1];
                size--;
                SiftDown(0);
                return value;
            }

            public T PeekTop()
            {
                if (size == 0)
                    throw new InvalidOperationException("heap is empty");
                return data[0];
            }


            private void SiftUp(int index)
            {
                while(index > 0 && Compare(data[index], data[Parent(index)]))
                {
                    Swap(index, Parent(index));
                    index = Parent(index);
                }
            }

            private void SiftDown(int index)
            {
                while(LeftChild(index) < size)
                {
                    //与左孩子和有孩子中较大节点比较
                    int maxIndex = LeftChild(index);
                    if(RightChild(index) < size && Compare(data[RightChild(index)], data[maxIndex]))
                    {
                        maxIndex = RightChild(index);
                    }
                    if(!Compare(data[index], data[maxIndex]))
                    {
                        Swap(index, maxIndex);
                        index = maxIndex;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            /// <summary>
            /// 比较，大顶堆时返回是否a>b，小顶堆反之
            /// </summary>
            private bool Compare(T a, T b)
            {
                if (isMax)
                    return a.CompareTo(b) > 0;
                else
                    return a.CompareTo(b) <= 0;
            }

            private void Swap(int a, int b)
            {
                T temp = data[a];
                data[a] = data[b];
                data[b] = temp;
            }


            private void Resize(int newSize)
            {
                T[] newData = new T[newSize];
                for(int i = 0; i < size; i++)
                {
                    newData[i] = data[i];
                }
                data = newData;
            }

            private int Parent(int index)
            {
                return (index - 1) / 2;
            }

            private int LeftChild(int index)
            {
                return index * 2 + 1;
            }
            
            private int RightChild(int index)
            {
                return index * 2 + 2;
            }
        }
    
    }
}