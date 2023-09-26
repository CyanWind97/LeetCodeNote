using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1333
    /// title: 餐厅过滤器
    /// problems: https://leetcode.cn/problems/filter-restaurants-by-vegan-friendly-price-and-distance/?envType=daily-question&envId=2023-09-27
    /// date: 20230927
    /// </summary>
    public static class Solution1333
    {
        public static IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance) {
            return restaurants.Where(x => x[2] >= veganFriendly && x[3] <= maxPrice && x[4] <= maxDistance)
                                    .OrderByDescending(x => x[1])
                                    .ThenByDescending(x => x[0])
                                    .Select(x => x[0])
                                    .ToList();
        }
    }
}