using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 341
    /// title: 扁平化嵌套列表迭代器
    /// problems: https://leetcode-cn.com/problems/flatten-nested-list-iterator/
    /// date: 20210323
    /// </summary>

    public static class Solution341
    {
        public interface NestedInteger {
            bool IsInteger();
            int GetInteger();
            IList<NestedInteger> GetList();
        }


        public class NestedIterator {
            
            IEnumerator<int> result;

            public NestedIterator(IList<NestedInteger> nestedList) {
                List<int> list = new List<int>();
                void Add(NestedInteger nested){
                    if(nested.IsInteger())
                        list.Add(nested.GetInteger());
                    else
                        foreach(var nest in nested.GetList()){
                            Add(nest);
                        }
                }

                foreach(var nested in nestedList){
                    Add(nested);
                }

                result = list.GetEnumerator();
            }

            public bool HasNext() {
                return result.MoveNext();
            }

            public int Next() {
                return result.Current;
            }
        }
    }
}