using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1203
    /// title: 项目管理
    /// problems: https://leetcode-cn.com/problems/sort-items-by-groups-respecting-dependencies/
    /// date: 20210112
    /// </summary>
    public static class Solution1203
    {
        // 待补
        // you need study more
        // 官方解答 拓扑排序
        public static int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems) {
            IList<int>[] groupItem = new IList<int>[n + m];
            // 组间依赖图
            IList<int>[] groupGraph = new IList<int>[n + m];
            // 组内依赖图
            IList<int>[] itemGraph = new IList<int>[n];

            // 组间入度数组
            int[] groupDegree = new int[n + m];
            // 组内入度数组
            int[] itemDegree = new int[n]; 

            int[] id = new int[n + m];
            
            
            for(int i = 0; i < m + n; i++){
                groupItem[i] = new List<int>();
                groupGraph[i] = new List<int>();
                id[i] = i;
            }


            int groupId = m;
            // 给未分配项目分配groupId
            for(int i = 0; i < n; i++){
                itemGraph[i] = new List<int>();
                if(group[i] == -1){
                    group[i] = groupId;
                    groupId++;
                }
                groupItem[group[i]].Add(i);
            }

            //依赖关系建图
            for(int i = 0; i < n; i++){
                int curId = group[i];
                foreach(var item in beforeItems[i]){
                    int beforeId = group[item];
                    if(beforeId == curId){
                        itemDegree[i]++;
                        itemGraph[item].Add(i);
                    }else{
                        groupDegree[curId]++;
                        groupGraph[beforeId].Add(curId);
                    }
                }
            }

            // 组间拓扑关系排序
            IList<int> gorupTopSort = topSort(groupDegree, groupGraph, id);
            if(gorupTopSort.Count == 0)
                return new int[]{};
            
            int[] result = new int[n];
            int index = 0;

            // 组内拓扑关系排序
            foreach(var curId in gorupTopSort){
                if(groupItem[curId].Count == 0)
                    continue;
                
                IList<int> itemTopSort = topSort(itemDegree, itemGraph, groupItem[curId]);
                if(itemTopSort.Count == 0)
                    return new int[]{};
                
                foreach(var item in itemTopSort){
                    result[index++] = item;
                }
            }

            return result;
        }       
        

        // 拓扑排序
        public static IList<int> topSort(int[] deg, IList<int>[] graph, IList<int> items){
            Queue<int> queue = new Queue<int>();
            foreach(var item in items){
                if(deg[item] == 0)
                    queue.Enqueue(item);
            }
            
            IList<int> result = new List<int>();
            while(queue.Count > 0){
                int u = queue.Dequeue();
                result.Add(u);
                foreach(var v in graph[u]){
                    if(--deg[v] == 0)
                        queue.Enqueue(v);
                }
            }

            return result.Count == items.Count ? result : new int[]{};
        }
    }
}