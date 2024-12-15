using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1847
/// title: 最近的房间
/// problems: https://leetcode.cn/problems/closest-room
/// date: 20241216
/// </summary>
public static class Solution1847
{
    // 参考解答
    // 将查询与实际房间合并，然后按照房间大小排序
    // 然后利用加入房间的顺序，从查询中找到最近的房间
    public static int[] ClosestRoom(int[][] rooms, int[][] queries) {
        int m = rooms.Length;
        int n = queries.Length;
        var events = new List<Event>();

        for (int i = 0; i < m; i++) {
            events.Add(new (0, rooms[i][1], rooms[i][0], i));
        }

        for (int i = 0; i < n; i++) {
            events.Add(new (1, queries[i][1], queries[i][0], i));
        }

        events.Sort();
        var result = Enumerable.Repeat(-1, n).ToArray();
        var roomSet = new SortedSet<int>();
        foreach(var ev in events){
            if (ev.Type == 0){
                roomSet.Add(ev.Id);
                continue;
            }
            
             // 询问事件，查找最近的房间
            int dist = int.MaxValue;
            var ceil = roomSet.GetViewBetween(ev.Id, int.MaxValue).Min;
            if (ceil != default && ceil - ev.Id < dist) {
                dist = ceil - ev.Id;
                result[ev.Index] = ceil;
            }
            var floor = roomSet.GetViewBetween(0, ev.Id).Max;
            if (floor != default && ev.Id - floor <= dist)
                result[ev.Index] = floor;
        }

        return result;
    }

    public record Event(int Type, int Size, int Id, int Index) : IComparable<Event>
    {
        public int CompareTo(Event other)
            => Size == other.Size 
            ? Type.CompareTo(other.Type) 
            : other.Size.CompareTo(Size);
    }
}
