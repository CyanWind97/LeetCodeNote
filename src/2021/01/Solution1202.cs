using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1202
    /// title: 交换字符串中的元素
    /// problems: https://leetcode-cn.com/problems/smallest-string-with-swaps/
    /// date: 20210111
    /// </summary>
    public static class Solution1202
    {
        public static string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
            if(0 == pairs.Count)
                return s;
            
            char[] chars = s.ToCharArray();
            int length = chars.Length;
            int[] parent = new int[length];
            Dictionary<int, IList<int>> dic = new Dictionary<int, IList<int>>();

            for(int i = 0; i < length; i++){
                parent[i] = i;
            }

            int find(int x) {
                if(x != parent[x]){
                    parent[x] = find(parent[x]);
                }
                return parent[x];
            }

            void uion(int x, int y){
                int rootX = find(x);
                int rootY = find(y);
                if(rootX == rootY)
                    return;
                
                parent[rootY] = rootX;
                
            }

            foreach(var pair in pairs){
                uion(pair[0], pair[1]);
            }

            for(int i = 0; i < length; i++){
                int root = find(i);
                if(dic.ContainsKey(root)){
                    dic[root].Add(i);
                }else{
                    dic.Add(root, new List<int>(){i});
                }
            }

            foreach(var index in dic.Values.Where(x => x.Count > 1).Select(x => x.ToArray())){
                int n = index.Length;
                int[] temp = new int[n];
                for(int i = 0; i < n; i++){
                    temp[i] = chars[index[i]];
                }

                Array.Sort(temp);
                for(int i = 0; i < n; i++){
                    chars[index[i]] = (char)temp[i];
                }

            }

            return new string(chars);
        }

        public static string SmallestStringWithSwaps_1(string s, IList<IList<int>> pairs) {
            if(0 == pairs.Count)
                return s;
            
            char[] chars = s.ToCharArray();
            int length = chars.Length;
            
            int[] parent = new int[length];
            int[] rank = new int[length];

            for(int i = 0; i < length; i++){
                parent[i] = i;
                rank[i] = 1;
            }

            int find(int x) {
                if(x != parent[x]){
                    parent[x] = find(parent[x]);
                }
                return parent[x];
            }

            void uion(int x, int y){
                int rootX = find(x);
                int rootY = find(y);
                if(rootX == rootY)
                    return;
                
                if (rank[rootX] == rank[rootY]) {
                    parent[rootX] = rootY;
                    rank[rootY]++;
                } else if (rank[rootX] < rank[rootY]) {
                    parent[rootX] = rootY;
                } else {
                    parent[rootY] = rootX;
                }
                
            }

            foreach(var pair in pairs){
                uion(pair[0], pair[1]);
            }
            
            Dictionary<int, Heap<char>> map = new Dictionary<int, Heap<char>>(length);
            for(int i = 0; i < length; i++){
                int root = find(i);
                if(map.ContainsKey(root)){
                    map[root].Insert(chars[i]);
                }else{
                    Heap<char> minHeap = new Heap<char>(false);
                    minHeap.Insert(chars[i]);
                    map.Add(root, minHeap);
                }
            }

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < length; i++){
                int root = find(i);
                sb.Append(map[root].Pop());
            }

            return sb.ToString();
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