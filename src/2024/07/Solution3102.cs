using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3102
/// title:  最小化曼哈顿距离
/// problems: https://leetcode.cn/problems/minimize-manhattan-distances
/// date: 20240709
/// </summary>
public static class Solution3102
{
    // 参考解答
    public static int MinimumDistance(int[][] points) {
        int n = points.Length;
        var sx = new List<(int Diff, int Index)>();
        var sy = new List<(int Sum, int Index)>();

        for(int i = 0; i < n; i++){
            (int x, int y) = (points[i][0], points[i][1]);
            sx.Add((x - y, i));
            sy.Add((x + y, i));
        }

        sx.Sort((a, b) => a.Diff - b.Diff);
        sy.Sort((a, b) => a.Sum - b.Sum);

        int maxVal1 = sx[^1].Diff - sx[0].Diff;
        int maxVal2 = sy[^1].Sum - sy[0].Sum;

        int Calc(IList<(int Value, int Index)> list, int index){
            if (index == list[0].Index)
                return list[^1].Value - list[1].Value;
            else if (index == list[^1].Index)
                return list[^2].Value - list[0].Value;
            else
                return list[^1].Value - list[0].Value;
        }
        
        int result = int.MaxValue;
        
        (int removeI, int removeJ) = maxVal1 >= maxVal2
                    ? (sx[0].Index, sx[^1].Index)
                    : (sy[0].Index, sy[^1].Index);
        
        result = Math.Min(result, Math.Max(Calc(sx, removeI), Calc(sy, removeI)));
        result = Math.Min(result, Math.Max(Calc(sx, removeJ), Calc(sy, removeJ)));

        return result;
    }
}
