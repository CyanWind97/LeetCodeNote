using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 17.14
    /// title: 17.14. 最小K个数
    /// problems: https://leetcode-cn.com/problems/smallest-k-lcci/
    /// date: 20210403
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_17_14
    {
        public static int[] SmallestK(int[] arr, int k) {
            if(k == 0)
                return new int[]{};

            Array.Sort(arr);
            
            return arr.Take(k).ToArray();
        }

        // 参考解答 快排
        public static int[] SmallestK_2(int[] arr, int k) {
            void RandomizedSelected(int l, int r, int k) {
                if (l >= r)
                    return;

                int pos = RandomizedPartition(arr, l, r);
                int num = pos - l + 1;

                if (k > num)
                    RandomizedSelected( pos + 1, r, k - num);
                else if (k < num)
                    RandomizedSelected(l, pos - 1, k);
                
            }

            // 基于随机的划分
            int RandomizedPartition(int[] nums, int l, int r) {
                int i = new Random().Next(l, r + 1);
                (nums[r], nums[i]) = (nums[i], nums[r]);

                return Partition(nums, l, r);
            }
            
            int Partition(int[] nums, int l, int r) {
                int pivot = nums[r];
                int i = l - 1;
                for (int j = l; j <= r - 1; ++j) {
                    if (nums[j] <= pivot) {
                        i = i + 1;
                        (nums[i], nums[j]) = (nums[j], nums[i]);
                    }
                }
                (nums[i + 1], nums[r]) = (nums[r], nums[i + 1]);
                return i + 1;
            }

            RandomizedSelected(0, arr.Length - 1, k);

            return arr.Take(k).ToArray();
        }


        public static int[] SmallestK_1(int[] arr, int k) {
            if(k == 0)
                return new int[]{};

            int[] result = new int[k];
            Heap<int> heap = new Heap<int>(arr, false);

            for(int i = 0; i < k; i++){
                result[i] = heap.Pop();
            }
            
            return result;
        }

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