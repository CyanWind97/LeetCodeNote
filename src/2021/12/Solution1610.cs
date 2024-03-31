using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1610
    /// title:  可见点的最大数目
    /// problems: https://leetcode-cn.com/problems/maximum-number-of-visible-points/
    /// date: 20211216
    /// </summary>

    public static class Solution1610
    {
        public static int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location) {
            var dic = new Dictionary<double, int>();
            int locationCount = 0;

            int x = location[0];
            int y = location[1];
            
            
            var basisX = new Vector2(1, 0);

            double CalcAngle(Vector2 vector){
                var dot =  Vector2.Dot(basisX, vector) / vector.Length();
                var angle = Math.Acos(dot) / (2 * Math.PI) * 360;
                if (vector.Y < 0)
                    angle = 360 - angle;

                return Math.Round(angle, 2);
            }

            foreach(var point in points){
                var vector = new Vector2(point[0] - x, point[1] - y);
                if(vector == Vector2.Zero){
                    locationCount++;
                    continue;
                }

                var a = CalcAngle(vector);

                if(!dic.ContainsKey(a))
                    dic.Add(a, 0);
                
                dic[a]++;
            }

            var infos = dic.OrderBy(x => x.Key)
                           .Select(x => (x.Key, x.Value))
                           .ToList<(double Angle, int Count)>();

            var plusInfos = infos.Where(x => x.Angle <= angle)
                                 .Select(x => (x.Angle + 360, x.Count))
                                 .ToList();

            infos.AddRange(plusInfos);


            int result = 0;
            int count = 0;
            int left = 0;
            int right = 0;

            while(right < infos.Count && infos[right].Angle - infos[left].Angle <= angle){
                count += infos[right].Count;
                right++;
            }

            result = count;

            while(right < infos.Count){
                count += infos[right].Count;

                while(left < right && infos[right].Angle - infos[left].Angle > angle){
                    count -= infos[left].Count;
                    left++;
                }

                result = Math.Max(result, count);

                right++;
            }

            return result + locationCount;
        }


        /// <summary>
        /// 参考解答 二分查找
        /// </summary>
        public static int VisiblePoints_1(IList<IList<int>> points, int angle, IList<int> location) {
            int sameCnt = 0;
            List<double> polarDegrees = new List<double>();
            int locationX = location[0];
            int locationY = location[1];
            for (int i = 0; i < points.Count; ++i) {
                int x = points[i][0];
                int y = points[i][1];
                if (x == locationX && y == locationY) {
                    sameCnt++;
                    continue;
                }
                double degree = Math.Atan2(y - locationY, x - locationX);
                polarDegrees.Add(degree);
            }
            polarDegrees.Sort();

            int m = polarDegrees.Count;
            for (int i = 0; i < m; ++i) {
                polarDegrees.Add(polarDegrees[i] + 2 * Math.PI);
            }

            int maxCnt = 0;
            double toDegree = angle * Math.PI / 180.0;
            for (int i = 0; i < m; ++i) {
                int iteration = BinarySearch(polarDegrees, polarDegrees[i] + toDegree, false);
                maxCnt = Math.Max(maxCnt, iteration - i);
            }
            return maxCnt + sameCnt;
        }

        public static int BinarySearch(List<double> nums, double target, bool lower) {
            int left = 0, right = nums.Count - 1;
            int ans = nums.Count;
            while (left <= right) {
                int mid = (left + right) / 2;
                if (nums[mid] > target || (lower && nums[mid] >= target)) {
                    right = mid - 1;
                    ans = mid;
                } else {
                    left = mid + 1;
                }
            }
            return ans;
        }

    }
}