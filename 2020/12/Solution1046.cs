using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    public static class Solution1046
    {
        public static int LastStoneWeight(int[] stones) {
            int length = stones.Length;
            Array.Sort(stones);
            int i = length - 1;
            while(i > 0){
                int diff = stones[i--] - stones[i];
                int j = 0;
                while(j < i && diff > stones[j])
                    j++;
                
                if(diff > 0){
                    for(int k = i; k > j; k--){
                        stones[k] = stones[k - 1];
                    }
                    stones[j] = diff;
                }else
                    i--;
                
            }

            return  i < 0 ? 0 : stones[0];
        }

        // 参考解答及堆实现
        public static int LastStoneWeight_1(int[] stones) {
            if (stones.Length == 1)
                return stones[0];
            Heap<int> heap = new Heap<int>(stones);
            while(heap.Count > 1)
            {
                int s1 = heap.Pop();
                int s2 = heap.Pop();
                if(s1 != s2)
                {
                    heap.Insert(Math.Abs(s1 - s2));
                }
            }
            if (heap.Empty)
                return 0;

            return heap.PeekTop();
        }
        
        // 大顶堆
        class Heap<T> where T : IComparable
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