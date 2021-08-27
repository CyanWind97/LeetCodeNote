using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 295
    /// title: 数据流的中位数
    /// problems: https://leetcode-cn.com/problems/find-median-from-data-stream/
    /// date: 20210827
    /// </summary>
    public static class Solution295
    {
        public class MedianFinder {
            private List<int> _sortedlist;

            /** initialize your data structure here. */
            public MedianFinder() {
                _sortedlist = new List<int>();
            }
            
            public void AddNum(int num) {
                int index = BinarySearch(num);
                _sortedlist.Insert(index, num);
            }
            
            private int BinarySearch(int target){
                int start = 0;
                int end = _sortedlist.Count - 1;

                while(start <= end){
                    int mid = start + (end - start) / 2;
                    if(_sortedlist[mid] >= target)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }

                return  start;
            }

            public double FindMedian() {
                if(_sortedlist.Count == 0)
                    return 0;
                
                int length = _sortedlist.Count;
                int mid = length / 2;

                return length % 2 == 0
                    ? ((double)_sortedlist[mid] + (double)_sortedlist[mid - 1]) / 2
                    : _sortedlist[mid];
            }
        }

        
        // 参考解答 大小堆维护中位数
        public class MedianFinder_1 {
            private Heap<int> _min;
            private Heap<int> _max;

            /** initialize your data structure here. */
            public MedianFinder_1() {
                _min = new Heap<int>(true);
                _max = new Heap<int>(false);
            }
            
            public void AddNum(int num) {
                if(_min.Count == 0 || _min.PeekTop() >= num){
                    _min.Push(num);
                    if(_max.Count + 1 < _min.Count)
                        _max.Push(_min.Pop());
                }
                else{
                    _max.Push(num);
                    if(_max.Count > _min.Count)
                        _min.Push(_max.Pop());
                }
            }

            public double FindMedian() 
                =>  _min.Count > _max.Count
                  ? _min.PeekTop()
                  : ((double)_min.PeekTop() + (double)_max.PeekTop()) / 2;
            

            #region 大顶堆
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

                public void Push(T value)
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
            #endregion
        }
    }
}