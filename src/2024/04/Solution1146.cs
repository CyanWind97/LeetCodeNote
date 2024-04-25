using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1146
/// title: 快照数组
/// problems: https://leetcode.cn/problems/snapshot-array
/// date: 20240426
/// </summary>
public static class Solution1146
{
    public class SnapshotArray {
        private int _snapId;

        private List<(int SnapId, int Value)>[] _snapshots;

        private IComparer<(int SnapId, int Value)> _comparer 
            = Comparer<(int SnapId, int Value)>.Create((a, b) => a.SnapId - b.SnapId);

        public SnapshotArray(int length) {
            _snapshots = new List<(int SnapId, int Value)>[length];
        }
        
        public void Set(int index, int val) {
            if (_snapshots[index] == null)
                _snapshots[index] = [];

            var snapshot = _snapshots[index];
            if (snapshot.Count > 0 
            && snapshot[^1].SnapId == _snapId)
                snapshot.RemoveAt(snapshot.Count - 1);
            
            snapshot.Add((_snapId, val));
        }
        
        public int Snap() {
            return _snapId++;
        }
        
        public int Get(int index, int snap_id) {
            if (_snapshots[index] == null)
                return 0;

            var snapshot = _snapshots[index];
            int search = snapshot.BinarySearch((snap_id, 0), _comparer);
            if (search >= 0)
                return snapshot[search].Value;
            
            search = ~search;
            return search == 0 ? 0 : snapshot[search - 1].Value;
        }
    }
}
