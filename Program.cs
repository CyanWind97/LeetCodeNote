using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace LeetCodeNote
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {2,1};
            IList<string>[] equations = {
                new string[]{"x1","x2"},
                new string[]{"x2","x3"},
                new string[]{"x1","x4"},
                new string[]{"x2","x5"}
            };
            double[] values = {3.0,0.5,3.4,5.6};
            IList<string>[] queries = { 
                new string[]{"x2","x4"},
                new string[]{"x3","x4"},
                new string[]{"x2","x1"},
                new string[]{"x4","x3"},
            };
            var result = Solution399.CalcEquation_2(equations, values, queries);

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}
