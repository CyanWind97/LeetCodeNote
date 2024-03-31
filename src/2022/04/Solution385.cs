using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 385
    /// title: 迷你语法分析器
    /// problems: https://leetcode-cn.com/problems/mini-parser/
    /// date: 20220415
    /// </summary>
    public static class Solution385
    {

        public static NestedInteger Deserialize(string s) {
            int i = 0;
            int length = s.Length;
            
            NestedInteger GetNested(){
                if (s[i] == '['){
                    i++;
                    var ni = new NestedInteger();
                    while(s[i] != ']'){
                        ni.Add(GetNested());
                        if(s[i] == ',')
                            i++;
                    }

                    i++;
                    return ni;
                }else{
                   return GetInt();
                }
            }
            
            NestedInteger GetInt(){
                var multi = 1;
                if(s[i] == '-'){
                    multi = -1;
                    i++;
                }
                 
                var value = 0;
                while(i < length && char.IsDigit(s[i])){
                    value = value * 10 + (s[i] - '0');
                    i++;
                }

                return new NestedInteger(multi * value);
            }
            

            return GetNested();
        }

        public static NestedInteger DeserializeInt(IEnumerable<char> chars)
        {
            var value = 0;
            foreach(var c in chars)
            {
                value = value * 10 + (c - '0');
            }

            return new NestedInteger(value);
        }
    }

    
        // This is the interface that allows for creating nested lists.
        // You should not implement it, or speculate about its implementation
        public interface INestedInteger {
        
            // Constructor initializes an empty nested list.
            // public NestedInteger();
        
            // Constructor initializes a single integer.
            // public NestedInteger(int value);
        
            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();
        
            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();
        
            // Set this NestedInteger to hold a single integer.
            public void SetInteger(int value);
        
            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            public void Add(NestedInteger ni);
        
            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }

        public class NestedInteger : INestedInteger
        {
            public NestedInteger() {}
        
            public NestedInteger(int value) { throw new NotImplementedException(); }

            public void Add(NestedInteger ni)
            {
                throw new System.NotImplementedException();
            }

            public int GetInteger()
            {
                throw new System.NotImplementedException();
            }

            public IList<NestedInteger> GetList()
            {
                throw new System.NotImplementedException();
            }

            public bool IsInteger()
            {
                throw new System.NotImplementedException();
            }

            public void SetInteger(int value)
            {
                throw new System.NotImplementedException();
            }
        }
}