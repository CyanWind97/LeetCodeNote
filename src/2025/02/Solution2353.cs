using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeeCodeNote;

/// <summary>
/// no: 2353
/// title: 设计食物评分系统
/// problems: https://leetcode.cn/problems/design-a-food-rating-system
/// date: 20250228
/// </summary>
public static class Solution2353
{
    // 参考解答
    // 修改SorteSet 为 PriorityQueue， 并在使用时才删除旧的评分记录
    public class FoodRatings {
        private Dictionary<string, FoodRating> _foodRatings = [];
        private Dictionary<string,  PriorityQueue<FoodRating, FoodRating>> _cuisineRatings = [];
        
        // 自定义比较器，按照评分降序，相同评分按食物名称字典序升序
        private class FoodRatingComparer : IComparer<FoodRating> {
            public int Compare(FoodRating x, FoodRating y) {
                if (x.Rating != y.Rating) {
                    return y.Rating.CompareTo(x.Rating); // 降序排列评分
                }
                return string.Compare(x.Food, y.Food); // 升序排列食物名称
            }
        }

        public FoodRatings(string[] foods, string[] cuisines, int[] ratings) {
            int n = foods.Length;
            for (int i = 0; i < n; i++) {
                var foodRating = new FoodRating {
                    Food = foods[i],
                    Cuisine = cuisines[i],
                    Rating = ratings[i]
                };

                _foodRatings[foods[i]] = foodRating;

                if (!_cuisineRatings.ContainsKey(cuisines[i])) {
                    _cuisineRatings[cuisines[i]] = new();
                }

                var copy = new FoodRating()
                {
                    Food = foods[i],
                    Cuisine = cuisines[i],
                    Rating = ratings[i]
                };
                _cuisineRatings[cuisines[i]].Enqueue(copy, copy);
            }
        }
        
        public void ChangeRating(string food, int newRating) {
            var foodRating = _foodRatings[food];
            var cuisine = foodRating.Cuisine;
            // 更新评分
            foodRating.Rating = newRating;

            var copy = new FoodRating()
            {
                Food = food,
                Cuisine = cuisine,
                Rating = newRating
            };
            
            // 将更新后的记录重新添加到有序集合中
            _cuisineRatings[cuisine].Enqueue(copy, copy);
        }
        
        public string HighestRated(string cuisine) {
            // 直接返回有序集合中的第一个元素
            var queue = _cuisineRatings[cuisine];
            FoodRating top;
            while((top = queue.Peek()).Rating != _foodRatings[top.Food].Rating) {
                queue.Dequeue();
            }

            return top.Food;
        }

        private class FoodRating : IComparable<FoodRating> {
            public string Food { get; set; }
            public int Rating { get; set; }
            public string Cuisine { get; set; }

            public int CompareTo(FoodRating other)
                => Rating != other.Rating ? other.Rating - Rating : Food.CompareTo(other.Food);
        }
    }
}
