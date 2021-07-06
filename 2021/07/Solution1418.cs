using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1418
    /// title: 点菜展示表
    /// problems: https://leetcode-cn.com/problems/display-table-of-food-orders-in-a-restaurant/
    /// date: 20210706
    /// </summary>
    public static class Solution1418
    {
        public static IList<IList<string>> DisplayTable(IList<IList<string>> orders) {
            // 从订单中获取餐品名称和桌号，统计每桌点餐数量
            ISet<string> nameSet = new HashSet<string>();
            Dictionary<int, Dictionary<string, int>> foodsCnt = new Dictionary<int, Dictionary<string, int>>();
            foreach (IList<string> order in orders) {
                nameSet.Add(order[2]);
                int id = int.Parse(order[1]);
                Dictionary<string, int> dictionary = foodsCnt.ContainsKey(id) ? foodsCnt[id] : new Dictionary<string, int>();
                if (dictionary.ContainsKey(order[2])) {
                    ++dictionary[order[2]];
                } else {
                    dictionary.Add(order[2], 1);
                }
                if (!foodsCnt.ContainsKey(id)) {
                    foodsCnt.Add(id, dictionary);
                }
            }

            // 提取餐品名称，并按字母顺序排列
            int n = nameSet.Count;
            List<string> names = new List<string>();
            foreach (string name in nameSet) {
                names.Add(name);
            }
            names.Sort((a, b) => string.CompareOrdinal(a, b));

            // 提取桌号，并按餐桌桌号升序排列
            int m = foodsCnt.Count;
            List<int> ids = new List<int>();
            foreach (int id in foodsCnt.Keys) {
                ids.Add(id);
            }
            ids.Sort();

            // 填写点菜展示表
            IList<IList<string>> table = new List<IList<string>>();
            IList<string> header = new List<string>();
            header.Add("Table");
            foreach (string name in names) {
                header.Add(name);
            }
            table.Add(header);
            for (int i = 0; i < m; ++i) {
                int id = ids[i];
                Dictionary<string, int> cnt = foodsCnt[id];
                IList<string> row = new List<string>();
                row.Add(id.ToString());
                for (int j = 0; j < n; ++j) {
                    int val = cnt.ContainsKey(names[j]) ? cnt[names[j]] : 0;
                    row.Add(val.ToString());
                }
                table.Add(row);
            }
            return table;
        }
    }
}